using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LmCore.Metodos
{
    //Classe adicionada por Matheus em 29/05/2020
    //Converte textos formatados em HTML para RTF
    public static class HTMLtoRTF
    {
        public static List<string> Cores { get; set; }

        public static string ListaFontes { get; set; } = "Arial,Calibri,Courier New";

        public static int TamanhoPadraoFonte { get; set; } = 8;

        public static string Imagens { get; set; }

        private static readonly string baseRTF =
@"{\rtf1\ansi\deff0
{\fonttbl
{\f0
@font;
}
{\colortbl;@colors
}
}\cf0\fs@size @text
\cf0}";

        public static string Converter(string _html)
        {
            //MAPEAMENTO

            List<string> imagens = new List<string>();

            string html = IsolarHTML(_html);

            string fontePadrao = string.Empty;

            int tamanhoFonte = ((int)Math.Round((decimal)TamanhoPadraoFonte * 2));

            List<string> cores = new List<string>();
            cores.Add("\\red0\\green0\\blue0;");

            Imagens = string.Empty;

            foreach (var item in ListaFontes.Split(','))
                if (html.Contains(item))
                {
                    fontePadrao = item;
                    break;
                }

            if (string.IsNullOrEmpty(fontePadrao))
                fontePadrao = "Arial";

            //-- Tratamento de entidades 1
            html = html.Replace(@"\", @"\\");
            html = html.Replace("<br>", "\\line");
            html = html.Replace("</p>", "\\cf0");

            html = html.Replace("</br>", "");
            html = html.Replace("</li>", "\\line");

            html = html.Replace("<span>", "");
            html = html.Replace("</span>", "");

            //---- Negrito
            html = html.Replace("<strong>", @"\b ");
            html = html.Replace("</strong>", @"\b0 ");

            //---- Titulos
            html = html.Replace("</h1>", $"\\b0\\fs{tamanhoFonte.ToString()}\\line ");
            html = html.Replace("</h2>", $"\\b0\\fs{tamanhoFonte.ToString()}\\line ");
            html = html.Replace("</h3>", $"\\b0\\fs{tamanhoFonte.ToString()}\\line ");
            html = html.Replace("</h4>", $"\\b0\\fs{tamanhoFonte.ToString()}\\line ");

            html = html.Replace("&nbsp;", " ");
            html = html.Replace("&#160;", " ");

            html = html.Replace("&#009;", "\\tab");

            string tag = string.Empty;
            int i = 0;
            int lasti = 0;

            // <Formatacao Geral>
            while (true)
            {
                i = 0;
                tag = string.Empty;

                i = html.IndexOf("<", 0);

                if (i == -1)
                    break;

                lasti = html.IndexOf(">", i);

                if (lasti == -1)
                    break;

                tag = html.Substring(i, lasti - i + 1);

                // <Adiciona caracteristicas especificas da tag html>
                string replacer = string.Empty;

                if (tag.Contains("<br") || tag.Contains("<p"))
                    replacer = @"\line";
                else if (tag.Contains("<li"))
                    replacer = @"\line • ";
                else if (tag.Contains("<h1"))
                    replacer = @"\line\b\fs" + ((int)Math.Round((decimal)((tamanhoFonte * 1.8) - (TamanhoPadraoFonte * 0.1)))).ToString();
                else if (tag.Contains("<h2"))
                    replacer = @"\line\b\fs" + ((int)Math.Round((decimal)((tamanhoFonte * 1.6) - (TamanhoPadraoFonte * 0.1)))).ToString();
                else if (tag.Contains("<h3"))
                    replacer = @"\line\b\fs" + ((int)Math.Round((decimal)((tamanhoFonte * 1.4) - (TamanhoPadraoFonte * 0.1)))).ToString();
                else if (tag.Contains("<h4"))
                    replacer = @"\line\b\fs" + ((int)Math.Round((decimal)((tamanhoFonte * 1.2) - (TamanhoPadraoFonte * 0.1)))).ToString();
                else if (tag.Contains("<img"))
                {
                    imagens.Add(GetImagem(tag));
                    replacer = $"@linkIMG{imagens.Count() - 1}";
                }
                // </Adiciona caracteristicas especificas da tag html>

                // <Formata a cor atribuida na tag html>
                if (!tag.Contains("<br") && ((tag.Contains(" color:") || tag.Contains(" color=")) ||
                     (tag.Contains(";color:") || tag.Contains(";color=")) ||
                     (tag.Contains("\"color:") || tag.Contains("\"color=")) && !tag.Contains("/>")))
                {
                    string corIsolada = IsolarCor(tag);

                    if (!cores.Contains(corIsolada))
                        cores.Add(corIsolada);

                    html = html.Replace(tag, replacer + @"\cf" + (cores.IndexOf(corIsolada) + 1).ToString() + " ");

                    html = html.Replace(GetTagClosed(tag), @"\cf0\fs" + tamanhoFonte.ToString() + " ");
                    continue;
                }
                // <Formata a cor atribuida na tag html>

                html = html.Replace(tag, replacer + " ");
            }
            // </Formatacao Geral>

            //-- Tratamento de entidades 2

            html = html.Replace("&lt;", "<");
            html = html.Replace("&#60;", "<");

            html = html.Replace("&gt;", ">");
            html = html.Replace("&#62;", ">");

            html = html.Replace("&amp;", "&");
            html = html.Replace("&#38;", "&");

            html = html.Replace("&apos;", "'");
            html = html.Replace("&#39;", "'");

            html = html.Replace("&cent;", "¢");
            html = html.Replace("&#162;", "¢");

            html = html.Replace("&pound;", "£");
            html = html.Replace("&#163;", "£");

            html = html.Replace("&yen;", "¥");
            html = html.Replace("&#165;", "¥");

            html = html.Replace("&euro;", "€");
            html = html.Replace("&#8364;", "€");

            html = html.Replace("&dollar;", "$");
            html = html.Replace("&#36;", "$");

            html = html.Replace("&copy;", "©");
            html = html.Replace("&#169;", "©");

            html = html.Replace("&reg;", "®");
            html = html.Replace("&#174;", "®");

            html = html.Replace("&quot;", "\"");
            html = html.Replace("&#34;", "\"");

            html = RetirarCharsDesconhecidos(html);

            //PREENCHER PALETA DE CORES
            string coresRGB = string.Empty;

            foreach (string cor in cores)
                coresRGB += cor + "\n";

            if (coresRGB.EndsWith("\n"))
                coresRGB = coresRGB.Substring(0, coresRGB.Length - 1);

            //ADICIONAR IMAGENS
            string imgsstr = string.Empty;

            foreach (var item in imagens)
                imgsstr += item.Replace(";", "{{{P&V}}}") + ";";

            if (imgsstr.EndsWith(";"))
                imgsstr = imgsstr.Substring(0, imgsstr.Length - 1);

            Imagens = imgsstr;

            //ORGANIZAR RTF
            string rtf = baseRTF.Replace("@colors", "\n" + coresRGB);

            rtf = rtf.Replace("@font", fontePadrao);
            rtf = rtf.Replace("@size", tamanhoFonte.ToString());

            while (html.StartsWith("\n") || html.StartsWith("\r") || html.StartsWith(" "))
                html = html.Substring(1, html.Length - 1);

            rtf = rtf.Replace("@text", html);

            return rtf;
        }

        public static string GetTagClosed(string tag)
        {
            string _return = string.Empty;

            foreach (char caractere in tag.ToCharArray())
                if (caractere == ' ')
                    break;
                else
                    _return += caractere.ToString();

            _return = _return.Replace("<", "");
            _return = "</" + _return + ">";

            return _return;
        }
        public static string IsolarCor(string tag)
        {
            string _return = string.Empty;

            string suportstr = string.Empty;
            foreach (char caractere in tag.ToCharArray())
            {
                suportstr += caractere.ToString();

                if ((suportstr.Contains(" color:") || suportstr.Contains(" color=")) ||
                         (suportstr.Contains(";color:") || suportstr.Contains(";color=")) ||
                         (suportstr.Contains("\"color:") || suportstr.Contains("\"color=")))
                {
                    if ((caractere == '"' || caractere == ';') && _return.Length > 3)
                        break;

                    _return += caractere.ToString();
                }

            }

            _return = _return.Replace(":", "");
            _return = _return.Replace("=", "");
            _return = _return.Replace(" ", "");
            _return = _return.Replace("\"", "");
            _return = ConverterCor(_return);
            return _return;
        }

        public static string ConverterCor(string cor)
        {
            string _return = cor.ToLower();

            //RGB
            if (_return.Contains("rgb"))
            {
                string crudeColor = _return.Replace("rgb(", "");
                crudeColor = crudeColor.Replace(")", "");
                string[] rgbPalette = crudeColor.Split(',');

                if (rgbPalette.Count() == 3)
                    return $"\\red{rgbPalette[0]}\\green{rgbPalette[1]}\\blue{rgbPalette[2]};";
            }

            //HEXADECIMAL
            if (_return.Contains("#"))
            {
                _return = _return.TrimStart('#');

                if (_return.Length >= 6)
                    _return = $"\\red{int.Parse(_return.Substring(0, 2), NumberStyles.HexNumber).ToString()}\\green{int.Parse(_return.Substring(2, 2), NumberStyles.HexNumber).ToString()}\\blue{int.Parse(_return.Substring(4, 2), NumberStyles.HexNumber).ToString()};";
                else
                    _return = @"\red0\green0\blue0;";
            }
            else
                _return = @"\red0\green0\blue0;";

            return _return;
        }

        public static string RetirarCharsDesconhecidos(string html)
        {
            string _return = html;

            List<string> toRemove = new List<string>();

            bool addStr = false;
            string str = string.Empty;

            foreach (char chr in html.ToCharArray())
            {
                if (chr == '&')
                    addStr = true;

                if (addStr == true)
                    str += chr.ToString();

                if (chr == ';' && addStr == true)
                {
                    addStr = false;

                    if (!toRemove.Contains(str) && str.Length < 10)
                        toRemove.Add(str);

                    str = string.Empty;
                }
            }

            foreach (string item in toRemove)
                _return = _return.Replace(item, " ");

            return _return;
        }

        public static string GetImagem(string _imgTag)
        {
            string imgTag = _imgTag.Replace(" ", "");
            string imgUrl = string.Empty;

            string[] imgInfos;

            imgTag = imgTag.Replace("<img", "");
            imgTag = imgTag.Replace("/>", "");

            imgTag = imgTag.Replace("src=", "src\"");
            imgTag = imgTag.Replace("width:", "width\"");
            imgTag = imgTag.Replace("height:", "height\"");
            imgTag = imgTag.Replace("\"\"", "\"");

            imgInfos = imgTag.Split('"');

            for (int i = 0; i < imgInfos.Length; i++)
            {
                if ((i + 1) >= imgInfos.Length)
                    break;

                if (imgInfos[i].ToLower() == "src")
                    imgUrl = imgInfos[i + 1];
            }

            if (string.IsNullOrEmpty(imgUrl))
                return string.Empty;
            else
                return imgUrl;
        }

        public static string IsolarHTML(string html)
        {
            string textoNovo = html;

            while (!textoNovo.StartsWith("<body>"))
                textoNovo = textoNovo.Substring(1, textoNovo.Length - 1);

            return textoNovo;
        }
    }
}