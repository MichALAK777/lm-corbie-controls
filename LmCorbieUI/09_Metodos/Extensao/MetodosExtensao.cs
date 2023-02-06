using LmCorbieUI.Design;
using LmCorbieUI.LmForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LmCorbieUI
{
    public static class MetodosExtensao
    {
        /// <summary>
        /// Retorna Telefone Formatado
        /// </summary>
        /// <param name="fone"> string contemdo Telefone (Formatado ou não)</param>
        /// <returns></returns>
        public static string FormatarFone(this string fone)
        {
            fone = fone.SomenteNumeros();

            if (fone.Length == 10 && !fone.StartsWith("0800"))
                fone = Convert.ToInt64(fone).ToString("(00) 0000-0000");
            else if (fone.Length == 10)
                fone = Convert.ToInt64(fone).ToString("0000 00 0000");
            else if (fone.Length == 11 && !fone.StartsWith("0800"))
                fone = Convert.ToInt64(fone).ToString("(00) 0 0000-0000");
            else if (fone.Length == 11)
                fone = Convert.ToInt64(fone).ToString("0000 000 0000");
            else if (fone.Length == 9)
                fone = Convert.ToInt64(fone).ToString("(47) 0 0000-0000");
            else if (fone.Length == 8)
                fone = Convert.ToInt64(fone).ToString("(47) 0000-0000");

            return fone;
        }

        /// <summary>
        /// Retorna Telefone Formatado com operadora
        /// </summary>
        /// <param name="fone"> string contemdo Telefone (Formatado ou não)</param>
        /// <returns></returns>
        public static string FormatarFone(this string fone, string operadoraFixo, string OperadoraMovel)
        {
            fone = fone.SomenteNumeros();

            if (string.IsNullOrEmpty(fone)) return "";

            fone = Convert.ToInt64(fone).ToString();

            if (fone.Length == 8)
            {
                fone = Convert.ToInt64(fone).ToString("0000-0000");
            }
            else if (fone.Length == 9)
            {
                fone = Convert.ToInt64(fone).ToString("0 0000-0000");
            }
            else if (fone.Length == 10 && !fone.StartsWith("0800"))
            {
                fone = operadoraFixo + fone;     //fone.Substring(0, 2) + operadoraFixo + fone.Substring(2, 8);
                fone = Convert.ToInt64(fone).ToString("(000) (00) 0000-0000");
            }
            else if (fone.Length == 10)
            {
                fone = Convert.ToInt64(fone).ToString("0000 00 0000");
            }
            else if (fone.Length == 11 && !fone.StartsWith("0800"))
            {
                fone = OperadoraMovel + fone;    // fone.Substring(0, 2) + OperadoraMovel + fone.Substring(2, 9);
                fone = Convert.ToInt64(fone).ToString("(00) (00) 0 0000-0000");
            }
            else if (fone.Length == 11)
            {
                fone = Convert.ToInt64(fone).ToString("0000 000 0000");
            }
            else if (fone.Length == 12)
            {
                fone = operadoraFixo + fone.Substring(2, 10);    // fone.Substring(0, 2) + operadoraFixo + fone.Substring(4, 8);
                fone = Convert.ToInt64(fone).ToString("(000) (00) 0000-0000");
            }
            else if (fone.Length == 13)
            {
                fone = OperadoraMovel + fone.Substring(2, 11);    // fone.Substring(0, 2) + OperadoraMovel + fone.Substring(4, 9);
                fone = Convert.ToInt64(fone).ToString("(00) (00) 0 0000-0000");
            }

            return fone;
        }

        /// <summary>
        /// Retorna Valor Monetário Formatado
        /// </summary>
        /// <param name="valor">String com Valor Monetário (Formatado ou não)</param>
        /// <returns></returns>
        public static string FormatarMonetario(this string valor)
        {
            if (string.IsNullOrEmpty(valor))
                valor = "0";
            valor = valor.Replace("R", "").Replace("$", "");
            return Convert.ToDouble(valor).ToString("R$ #,###,###,###,##0.00");
        }

        /// <summary>
        /// Retorna Valor Monetário Formatado
        /// </summary>
        /// <param name="valor">String com Valor Monetário (Formatado ou não)</param>
        /// <returns></returns>
        public static string FormatarMonetario(this double valor)
        {
            return Convert.ToDouble(valor).ToString("R$ #,###,###,###,##0.00");
        }

        /// <summary>
        /// Retorna Valor Monetário Formatado
        /// </summary>
        /// <param name="valor">String com Valor Monetário (Formatado ou não)</param>
        /// <returns></returns>
        public static string FormatarMonetario(this decimal valor)
        {
            return Convert.ToDouble(valor).ToString("R$ #,###,###,###,##0.00");
        }

        /// <summary>
        /// Retorna Data Formatada DD/MM/AAAA
        /// </summary>
        /// <param name="data">String com Data (Formatada ou não)</param>
        /// <returns></returns>
        public static string FormatarData(this string data)
        {
            try
            {
                if (data.ToLower().StartsWith("h"))
                {
                    short dias = (short)data.ToLower().Replace("h", "h0").SomenteNumerosToInt();
                    return DateTime.Now.AddDays(data.Contains("-") ? -dias : dias).ToShortDateString();
                }
                else
                    data = data.SomenteNumeros();

                if (string.IsNullOrEmpty(data))
                    return string.Empty;

                if (data.Length > 8)
                    data = data.Substring(0, 8);

                //if (Convert.ToInt64(data) == 0) return DateTime.Now.ToShortDateString();
                var dia = DateTime.Now.Day;
                var mes = DateTime.Now.Month;
                var ano = DateTime.Now.Year;

                switch (data.Length)
                {
                    case 1:
                        data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt16(data)).ToShortDateString();
                        break;
                    case 2:
                        dia = Convert.ToInt16(data);
                        if (DateTime.TryParse($"{dia:00}/{mes:00}/{ano:0000}", out DateTime dt2))
                            data = dt2.ToShortDateString();
                        break;
                    /*
                    if (dia > 31)
                        data = new DateTime(DateTime.Now.Year, Convert.ToInt16(data.Substring(1, 1)),
                            Convert.ToInt16(data.Substring(0, 1))).ToShortDateString();
                    else
                    {
                        DateTime newData = DateTime.Now;
                        int ano = newData.Year;
                        int mes = newData.Month;
                        while (!DateTime.TryParse($"{dia:00}/{mes:00}/{DateTime.Now.Year}", out newData))
                            mes--;

                        data = newData.ToShortDateString();
                    }
                    */
                    /*
                case 3:
                    int op1Dia3 = Convert.ToInt16(data.Substring(0, 2));
                    int op1Mes3 = Convert.ToInt16(data.Substring(2, 1));

                    int op2Dia3 = Convert.ToInt16(data.Substring(0, 1));
                    int op2Mes3 = Convert.ToInt16(data.Substring(1, 2));

                    if (op1Dia3 <= 31)
                        data = new DateTime(DateTime.Now.Year, op1Mes3, op1Dia3).ToShortDateString();
                    else
                        data = new DateTime(DateTime.Now.Year, op2Mes3, op2Dia3).ToShortDateString();

                    break;
                    */
                    case 4:
                        dia = Convert.ToInt16(data.Substring(0, 2));
                        mes = Convert.ToInt16(data.Substring(2, 2));
                        if (DateTime.TryParse($"{dia:00}/{mes:00}/{ano:0000}", out DateTime dt4))
                            data = dt4.ToShortDateString();
                        break;
                    /*
                case 5:
                    int op1Dia5 = Convert.ToInt16(data.Substring(0, 2));
                    int op1Mes5 = Convert.ToInt16(data.Substring(2, 1));

                    int op2Dia5 = Convert.ToInt16(data.Substring(0, 1));
                    int op2Mes5 = Convert.ToInt16(data.Substring(1, 2));
                    int op2Ano5 = PegarAnoMaisProximo(Convert.ToInt16(data.Substring(3, 2)));

                    if (op1Dia5 == 0)
                        op1Dia5 = DateTime.Now.Day;
                    if (op2Dia5 == 0)
                        op2Dia5 = DateTime.Now.Day;

                    if (op1Mes5 == 0)
                        op1Mes5 = DateTime.Now.Month;
                    if (op2Mes5 == 0)
                        op2Mes5 = DateTime.Now.Month;

                    if (op2Ano5 == 0)
                        op2Ano5 = DateTime.Now.Year;

                    if (op1Dia5 <= 31 && op1Mes5 <= 12)
                        data = new DateTime(op2Ano5, op1Mes5, op1Dia5).ToShortDateString();
                    else
                        data = new DateTime(op2Ano5, op2Mes5, op2Dia5).ToShortDateString();

                    break;
                    */
                    case 6:
                        dia = Convert.ToInt16(data.Substring(0, 2));
                        mes = Convert.ToInt16(data.Substring(2, 2));
                        ano = Convert.ToInt16("20" + data.Substring(4, 2));
                        if (DateTime.TryParse($"{dia:00}/{mes:00}/{ano:0000}", out DateTime dt6))
                            data = dt6.ToShortDateString();
                        break;
                    /*
                    int op1Dia6 = Convert.ToInt16(data.Substring(0, 2));
                    int op1Mes6 = Convert.ToInt16(data.Substring(2, 2));
                    int op1Ano6 = PegarAnoMaisProximo(Convert.ToInt16(data.Substring(4, 2)));

                    int op2Dia6 = Convert.ToInt16(data.Substring(0, 1));
                    int op2Mes6 = Convert.ToInt16(data.Substring(1, 1));
                    int op2Ano6 = Convert.ToInt16(data.Substring(2, 4));

                    if (op1Dia6 <= 31 && op1Mes6 <= 12)
                        data = new DateTime(op1Ano6, op1Mes6, op1Dia6).ToShortDateString();
                    else
                        data = new DateTime(op2Ano6, op2Mes6, op2Dia6).ToShortDateString();

                    break;
                    */
                    case 8:
                        {
                            dia = Convert.ToInt16(data.Substring(0, 2));
                            mes = Convert.ToInt16(data.Substring(2, 2));
                            ano = Convert.ToInt16(data.Substring(4, 4));
                            if (DateTime.TryParse($"{dia:00}/{mes:00}/{ano:0000}", out DateTime dt8))
                                data = dt8.ToShortDateString();
                        }
                        break;
                    /*
                    int op1Dia6 = Convert.ToInt16(data.Substring(0, 2));
                    int op1Mes6 = Convert.ToInt16(data.Substring(2, 2));
                    int op1Ano6 = PegarAnoMaisProximo(Convert.ToInt16(data.Substring(4, 2)));

                    int op2Dia6 = Convert.ToInt16(data.Substring(0, 1));
                    int op2Mes6 = Convert.ToInt16(data.Substring(1, 1));
                    int op2Ano6 = Convert.ToInt16(data.Substring(2, 4));

                    if (op1Dia6 <= 31 && op1Mes6 <= 12)
                        data = new DateTime(op1Ano6, op1Mes6, op1Dia6).ToShortDateString();
                    else
                        data = new DateTime(op2Ano6, op2Mes6, op2Dia6).ToShortDateString();

                    break;
                    */
                    /*
                case 7:
                    int op1Dia7 = Convert.ToInt16(data.Substring(0, 2));
                    int op1Mes7 = Convert.ToInt16(data.Substring(2, 1));

                    int op2Dia7 = Convert.ToInt16(data.Substring(0, 1));
                    int op2Mes7 = Convert.ToInt16(data.Substring(1, 2));
                    int op2Ano7 = Convert.ToInt16(data.Substring(3, 4));

                    if (op1Dia7 <= 31 && op1Mes7 <= 12)
                        data = new DateTime(op2Ano7, op1Mes7, op1Dia7).ToShortDateString();
                    else
                        data = new DateTime(op2Ano7, op2Mes7, op2Dia7).ToShortDateString();
                    break;

                case 8:
                    data = new DateTime(Convert.ToInt16(data.Substring(4, 4)),
                        Convert.ToInt16(data.Substring(2, 2)), Convert.ToInt16(data.Substring(0, 2))).ToShortDateString();
                    break;
                    */
                    default:
                        break;
                }
                return data;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Retorna Hora Formatada
        /// </summary>
        /// <param name="hora">Hora informada Somente Numeros</param>
        /// <returns></returns>
        public static string FormatarHora(this string hora)
        {
            try
            {
                if (string.IsNullOrEmpty(hora)) return "";

                if (hora != null && hora.ToLower().StartsWith("h"))
                    return $"{DateTime.Now.Hour:00}:{DateTime.Now.Minute:00}";

                hora = Convert.ToInt32(hora.Trim().Replace(":", "")).ToString("0000");
                if (!string.IsNullOrEmpty(hora))
                {
                    if (hora.Length > 7)//99999.99
                    {
                        MsgBox.Show("Sistema não aceita hora superior a 99999.",
                            "Informação", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        return string.Empty;
                    }

                    int h = Convert.ToInt16(hora.Substring(0, hora.Length - 2));
                    int m = Convert.ToInt16(hora.Substring(hora.Length - 2, 2));

                    if (m == 60)
                    {
                        h++;
                        m = 0;
                    }

                    hora = h.ToString("00") + ":" + m.ToString("00");
                }
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "erro ao Formatar Hora");
            }

            return hora;
        }

        /// <summary>
        /// Converte numero decimal horas para hora e minutos
        /// </summary>
        /// <param name="hora">decimal hora</param>
        /// <returns></returns>
        public static string FormatarHora(this decimal hora)
        {
            short h;
            short m;
            if (hora >= 0)
            {
                h = (short)Math.Floor(hora);
                m = Convert.ToInt16((hora - h) * 60);

                if (m == 60)
                {
                    h++;
                    m = 0;
                }

                return h.ToString("00") + ":" + m.ToString("00");
            }
            else
            {
                hora *= -1;

                h = (short)Math.Floor(hora);
                m = Convert.ToInt16((hora - h) * 60);

                if (m == 60)
                {
                    h++;
                    m = 0;
                }

                return "-" + h.ToString("00") + ":" + m.ToString("00");
            }
        }

        /// <summary>
        /// Converte numero real(double) horas para hora e minutos
        /// </summary>
        /// <param name="hora">double hora</param>
        /// <returns></returns>
        public static string FormatarHora(this double hora)
        {
            short h;
            short m;
            if (hora >= 0)
            {
                h = (short)Math.Floor(hora);
                m = (short)Math.Round(((hora - h) * 60));

                if (m == 60)
                {
                    h++;
                    m = 0;
                }

                return h.ToString("00") + ":" + m.ToString("00");
            }
            else
            {
                hora *= -1;

                h = (short)Math.Floor(hora);
                m = (short)Math.Round(((hora - h) * 60));

                if (m == 60)
                {
                    h++;
                    m = 0;
                }

                return "-" + h.ToString("00") + ":" + m.ToString("00");
            }
        }

        /// <summary>
        /// Formatar hora e minutos para horas decimal
        /// </summary>
        /// <param name="hora">hora com formato padrão</param>
        /// <returns></returns>
        public static double FormatarHoraDouble(this string hora)
        {
            hora = hora.FormatarHora(/*true*/);

            if (hora.Contains(":"))
            {
                string[] hm = hora.Split(':');

                short h = Convert.ToInt16(hm[0]);
                short m = Convert.ToInt16(hm[1]);

                return h + ((double)m / 60);
            }

            return 0;
        }

        /// <summary>
        /// Formatar data para horas decimal
        /// </summary>
        /// <param name="date">Data padrão</param>
        /// <returns></returns>
        public static decimal ToDecimalHour(this DateTime date)
        {
            short horas = (short)date.Hour;
            short minutos = (short)date.Minute;

            return (decimal)horas + ((decimal)minutos / (decimal)60);
        }

        /// <summary>
        /// Formatar data para horas decimal
        /// </summary>
        /// <param name="hora">Data padrão</param>
        /// <returns></returns>
        public static decimal ToDecimalHour(this string hora)
        {
            var spl = hora.FormatarHora().Split(':');
            short horas = Convert.ToInt16(spl[0]);
            short minutos = Convert.ToInt16(spl[1]);

            return (decimal)horas + ((decimal)minutos / (decimal)60);
        }

        /// <summary>
        /// Formatar data para horas decimal
        /// </summary>
        /// <param name="date">Data padrão</param>
        /// <returns></returns>
        public static string ToShortDateTimeString(this DateTime date)
        {
            return $"{date.ToShortDateString()} {date.ToShortTimeString()}";
        }

        /// <summary>
        /// Retorna CPF ou CNPJ Formatado de acordo com o comprimento do valor informado
        /// </summary>
        /// <param name="valor">String com Cpf ou Cnpj (Formatada ou não)</param>
        /// <returns></returns>
        public static string FormatarCpf_Cnpf(this string valor)
        {
            if (string.IsNullOrEmpty(valor)) return string.Empty;

            valor = valor.SomenteNumeros();

            if (valor.Length >= 9 && valor.Length <= 11)
                valor = Convert.ToInt64(valor).ToString(@"000\.000\.000-00");
            else if (valor.Length >= 12 && valor.Length <= 14)
                valor = Convert.ToInt64(valor).ToString(@"00\.000\.000/0000-00");

            return valor;
        }

        //public static string CriptografarAES(this string valor)
        //{
        //    if (string.IsNullOrEmpty(valor)) return string.Empty;

        //    return Criptografar.EncryptAES(valor);
        //}

        //public static string DescriptografarAES(this string valor)
        //{
        //    if (string.IsNullOrEmpty(valor)) return string.Empty;

        //    return Criptografar.DecryptAES(valor);
        //}

        /// <summary>
        /// Retorna apenas numeros de uma string
        /// </summary>
        /// <param name="valor">Campo alfanumérico</param>
        /// <returns></returns>
        public static string SomenteNumeros(this string valor)
        {
            return string.Join("", System.Text.RegularExpressions.Regex.Split(valor, @"[^\d]"));
        }

        /// <summary>
        /// Retorna apenas numero inteiro de uma string
        /// </summary>
        /// <param name="valor">Campo alfanumérico</param>
        /// <returns></returns>
        public static int SomenteNumerosToInt(this string valor)
        {
            int.TryParse(string.Join("", System.Text.RegularExpressions.Regex.Split(valor, @"[^\d]")), out int numero);
            return numero;
        }

        /// <summary>
        /// Retorna formatado com casas decimais definida
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="casasDecimais"></param>
        /// <returns></returns>
        public static string Numerico(this string valor, short casasDecimais = 0)
        {
            if (!string.IsNullOrEmpty(valor))
                return String.Format("{0:N" + casasDecimais + "}", Convert.ToDouble(valor));
            else return valor;
        }

        public static string ConverterNumeroParaLetra(this int valor)
        {
            switch (valor)
            {
                case 0: return "A";
                case 1: return "B";
                case 2: return "C";
                case 3: return "D";
                case 4: return "E";
                case 5: return "F";
                case 6: return "G";
                case 7: return "H";
                case 8: return "I";
                case 9: return "J";
                case 10: return "K";
                case 11: return "L";
                case 12: return "M";
                case 13: return "N";
                case 14: return "O";
                case 15: return "P";
                case 16: return "Q";
                case 17: return "R";
                case 18: return "S";
                case 19: return "T";
                case 20: return "U";
                case 21: return "V";
                case 22: return "W";
                case 23: return "X";
                case 24: return "Y";
                case 25: return "Z";
                default: return string.Empty;
            }
        }

        public static int ConverterLetraParaNumero(this string valor)
        {
            switch (valor)
            {
                case "A": return 0;
                case "B": return 1;
                case "C": return 2;
                case "D": return 3;
                case "E": return 4;
                case "F": return 5;
                case "G": return 6;
                case "H": return 7;
                case "I": return 8;
                case "J": return 9;
                case "K": return 10;
                case "L": return 11;
                case "M": return 12;
                case "N": return 13;
                case "O": return 14;
                case "P": return 15;
                case "Q": return 16;
                case "R": return 17;
                case "S": return 18;
                case "T": return 19;
                case "U": return 20;
                case "V": return 21;
                case "W": return 22;
                case "X": return 23;
                case "Y": return 24;
                case "Z": return 25;
                default: return 99;
            }
        }

        public static string PrimeiraMaiuscula(this string valor, bool todasPalavras = false, bool finalMinuscula = false)
        {
            if (string.IsNullOrEmpty(valor) || valor.Length < 2) return valor;

            string txt = valor.Trim();
            if (!todasPalavras)
            {
                if (!finalMinuscula)
                    return valor.Substring(0, 1).ToUpper() + valor.Substring(1, valor.Length - 1);
                else
                    return valor.Substring(0, 1).ToUpper() + valor.Substring(1, valor.Length - 1).ToLower();
            }
            else
            {
                string[] spl = txt.Split(' ');
                string _return = "";
                foreach (var str in spl)
                {
                    if (string.IsNullOrEmpty(str.Trim()))
                        continue;

                    if (!finalMinuscula)
                        _return += str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1) + " ";
                    else
                        _return += str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1).ToLower() + " ";
                }

                return _return.TrimEnd();
            }
        }

        public static string PrimeiraMinuscula(this string valor, bool todasPalavras = false, bool finalMinuscula = false)
        {
            if (string.IsNullOrEmpty(valor) || valor.Length < 2) return valor;

            string txt = valor.Trim();
            if (!todasPalavras)
            {
                if (!finalMinuscula)
                    return valor.Substring(0, 1).ToLower() + valor.Substring(1, valor.Length - 1);
                else
                    return valor.Substring(0, 1).ToLower() + valor.Substring(1, valor.Length - 1).ToLower();
            }
            else
            {
                string[] spl = txt.Split(' ');
                string _return = "";
                foreach (var str in spl)
                {
                    if (string.IsNullOrEmpty(str.Trim()))
                        continue;

                    if (!finalMinuscula)
                        _return += str.Substring(0, 1).ToLower() + str.Substring(1, str.Length - 1) + " ";
                    else
                        _return += str.Substring(0, 1).ToLower() + str.Substring(1, str.Length - 1).ToLower() + " ";
                }

                return _return.TrimEnd();
            }
        }

        public static string RemoverCaracteresEspeciais(this string valor, bool substituirEspacoPorUnderline = false)
        {
            if (string.IsNullOrEmpty(valor)) return valor;

            if (substituirEspacoPorUnderline)
                valor = valor.Replace(" ", "_");

            return valor.Replace("!", "")
                        .Replace("∆", "")
                        .Replace("▄", "")
                        .Replace("•", "")
                        .Replace("Ø", "")
                        .Replace("#", "")
                        .Replace("$", "")
                        .Replace("%", "")
                        .Replace("&", "")
                        .Replace("'", "")
                        .Replace("(", "")
                        .Replace(")", "")
                        .Replace("*", "")
                        .Replace("+", "")
                        .Replace("-", "")
                        .Replace("/", "")
                        .Replace(":", "")
                        .Replace(";", "")
                        .Replace("<", "")
                        .Replace("=", "")
                        .Replace(">", "")
                        .Replace("?", "")
                        .Replace("@", "")
                        .Replace("[", "")
                        .Replace("\"", "")
                        .Replace("]", "")
                        .Replace("^", "")
                        .Replace("`", "")
                        .Replace("{", "")
                        .Replace("|", "")
                        .Replace("}", "")
                        .Replace("~", "")
                        .Replace("æ", "")
                        .Replace("Æ", "")
                        .Replace("¢", "")
                        .Replace("£", "")
                        .Replace("¥", "")
                        .Replace("ƒ", "")
                        .Replace("ª", "")
                        .Replace("º", "")
                        .Replace("¿", "")
                        .Replace("¬", "")
                        .Replace("½", "1_2")
                        .Replace("¼", "1_4")
                        .Replace("¡", "")
                        .Replace("«", "")
                        .Replace("»", "")
                        .Replace("ç", "c")
                        .Replace("ç", "c")
                        .Replace("Ç", "C")
                        .Replace("ü", "u")
                        .Replace("á", "a")
                        .Replace("à", "a")
                        .Replace("â", "a")
                        .Replace("ã", "a")
                        .Replace("ä", "a")
                        .Replace("å", "a")
                        .Replace("Á", "A")
                        .Replace("Á", "A")
                        .Replace("À", "A")
                        .Replace("Â", "A")
                        .Replace("Ã", "A")
                        .Replace("Ä", "A")
                        .Replace("Å", "A")
                        .Replace("é", "e")
                        .Replace("è", "e")
                        .Replace("ê", "e")
                        .Replace("ë", "e")
                        .Replace("É", "E")
                        .Replace("È", "E")
                        .Replace("Ê", "E")
                        .Replace("Ë", "E")
                        .Replace("í", "i")
                        .Replace("ì", "i")
                        .Replace("î", "i")
                        .Replace("ï", "i")
                        .Replace("Í", "I")
                        .Replace("Ì", "I")
                        .Replace("Î", "I")
                        .Replace("Ï", "I")
                        .Replace("ó", "o")
                        .Replace("ò", "o")
                        .Replace("ô", "o")
                        .Replace("õ", "o")
                        .Replace("ö", "o")
                        .Replace("Ó", "O")
                        .Replace("Ò", "O")
                        .Replace("Ô", "O")
                        .Replace("Õ", "O")
                        .Replace("Ö", "O")
                        .Replace("ú", "u")
                        .Replace("ù", "u")
                        .Replace("û", "u")
                        .Replace("ü", "u")
                        .Replace("Ú", "U")
                        .Replace("Ù", "U")
                        .Replace("Û", "U")
                        .Replace("Ü", "U")
                        .Replace("ý", "y")
                        .Replace("ÿ", "y")
                        .Replace("Ý", "Y")
                        .Replace("ñ", "n")
                        .Replace("Ñ", "N");
        }

        public static string RemoverNumeros(this string valor)
        {
            if (string.IsNullOrEmpty(valor)) return valor;

            return valor.Replace("0", "")
                        .Replace("1", "")
                        .Replace("2", "")
                        .Replace("3", "")
                        .Replace("4", "")
                        .Replace("5", "")
                        .Replace("6", "")
                        .Replace("7", "")
                        .Replace("8", "")
                        .Replace("9", "");
        }

        //public static DateTime ToDateTime(this string data)
        //{
        //    try
        //    {
        //        return Convert.ToDateTime(data.FormatarData());
        //    }
        //    catch (Exception ex)
        //    {
        //        LmException.ShowException(ex, "Data Inválida, Retornou data Atual");
        //        return DateTime.Now;
        //    }
        //}

        public static DateTime AddHoursAndMinutes(this DateTime data, string horasMinutos)
        {
            try
            {
                return data
                    .AddHours(Convert.ToInt32(horasMinutos.FormatarHora(/*true*/).Split(':')[0]))
                    .AddMinutes(Convert.ToInt32(horasMinutos.FormatarHora(/*true*/).Split(':')[1]));

            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Data Inválida");
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Seta a variável "_lastFocusedControl" no formulário
        /// </summary>
        /// <param name="control">Controle proprietário</param>
        public static void SetLastFocusedControl(this System.Windows.Forms.Control control)
        {
            try
            {
                if (control.Parent != null && control.Parent is LmChildForm frm1)
                    frm1._lastFocusedControl = control;

                else if (control.Parent.Parent != null && control.Parent.Parent is LmChildForm frm2)
                    frm2._lastFocusedControl = control;

                else if (control.Parent.Parent.Parent != null && control.Parent.Parent.Parent is LmChildForm frm3)
                    frm3._lastFocusedControl = control;

                else if (control.Parent.Parent.Parent.Parent != null && control.Parent.Parent.Parent.Parent is LmChildForm frm4)
                    frm4._lastFocusedControl = control;

                else if (control.Parent.Parent.Parent.Parent.Parent != null && control.Parent.Parent.Parent.Parent.Parent is LmChildForm frm5)
                    frm5._lastFocusedControl = control;

                else if (control.Parent.Parent.Parent.Parent.Parent.Parent != null && control.Parent.Parent.Parent.Parent.Parent.Parent is LmChildForm frm6)
                    frm6._lastFocusedControl = control;
            }
            catch (Exception ex)
            {

            }
        }

        public static DateTime AddHoursAndMinutes(this DateTime data, double horas)
        {
            try
            {
                return data
                    .AddHours(Convert.ToInt32(horas.FormatarHora().Split(':')[0]))
                    .AddMinutes(Convert.ToInt32(horas.FormatarHora().Split(':')[1]));

            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Data Inválida");
                return DateTime.Now;
            }
        }
        /// <summary>
        /// Retorna uma lista com os valores de um determinado enumerador.
        /// </summary>
        /// <param name="tipo"> Tipo "Objeto"</param>
        /// <returns></returns>
        public static IList ObterListaItensEnum(this Type tipo, string listaExecao = "")
        {
            ArrayList lista = new ArrayList();
            if (tipo != null)
            {
                string[] list = null;
                if (!string.IsNullOrEmpty(listaExecao))
                {
                    list = listaExecao.Replace(" ", "").Replace("^", ";").Replace(",", ";").Replace(".", ";").Split(';');
                }

                Array enumValores = Enum.GetValues(tipo);
                foreach (Enum valor in enumValores)
                {
                    if (list != null && list.Contains(valor.ToString()))
                        continue;

                    lista.Add(new KeyValuePair<Enum, string>(valor, ObterDescricaoEnum(valor)));
                }
            }

            return lista;
        }

        /// <summary>
        /// Obtém a descrição de um determinado Enumerador.
        /// </summary>
        /// <param name="valor">Enumerador que terá a descrição obtida.</param>
        /// <returns>String com a descrição do Enumerador.</returns>
        public static string ObterDescricaoEnum(this Enum valor)
        {
            try
            {
                FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());
                DescriptionAttribute[] atributos = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                return atributos.Length > 0 ? atributos[0].Description ?? "Nulo" : valor.ToString();
            }
            catch (Exception ex)
            {
                return valor.ToString();
            }
        }


        public static void CarregarComboBoxEnum(this Controls.LmTextBox cmb, Type tipoEnum, string listaExcecao = "")
        {
            cmb.CmbDados.DataSource = tipoEnum.ObterListaItensEnum(listaExcecao);
        }

        public static void CarregarComboBox(this Controls.LmTextBox cmb, object dataSource)
        {
            cmb.CmbDados.DataSource = dataSource;
        }

        public static async Task CarregarComboBoxEnumAsync(this Controls.LmTextBox cmb, Type tipoEnum, string listaExcecao = "")
        {
            cmb.CmbDados.DataSource = await Task.Run(() => tipoEnum.ObterListaItensEnum(listaExcecao));
        }

        public static async Task CarregarComboBoxAsync(this Controls.LmTextBox cmb, object dataSource)
        {
            cmb.CmbDados.DataSource = await Task.Run(() => dataSource);
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static Image ToImage(this byte[] bytes)
        {
            if (bytes == null) return null;
            try
            {
                using (var ms = new System.IO.MemoryStream(bytes))
                    return Image.FromStream(ms);

            }
            catch { return null; }
        }

        public static byte[] ToByteArray(this Image imagem)
        {
            if (imagem == null) return null;
            try
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            catch { return null; }
        }

        public static byte[] ToByteArray(this string base64String)
        {
            if (base64String == null) return null;
            try
            {
                return Convert.FromBase64String(base64String);
            }
            catch { return null; }
        }

        public static Image ToImageFromBase64(this string base64String)
        {
            if (string.IsNullOrEmpty(base64String)) return null;
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);

            }
            catch { return null; }
        }

        public static string ToBase64String(this Image image)
        {
            if (image == null) return null;
            try
            {
                byte[] bytesOfImage = image.ToByteArray();
                Image newImage = bytesOfImage.ToImage();

                using (var m = new System.IO.MemoryStream())
                {
                    newImage.Save(m, newImage.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string ToBase64String(this byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;
            try
            {
                return Convert.ToBase64String(byteArray);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Image SetImageOpacity(this Image image, double opacity)
        {
            if (image == null)
                return null;

            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = (float)opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default,
                                                  ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   0, 0, image.Width, image.Height,
                                   GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        public static Image SetImageQuality(this Image image, int quality/*, int base64Length = 0*/)
        {
            if ((quality < 1) || (quality > 100))
            {
                MsgBox.Show("Qualidade da imagem deve estar entre 1 e 100", "Qualidade Inválida",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                return image;
            }

            float nPorcentagem = ((float)quality / 100);

            int fonteLargura = image.Width;
            int fonteAltura = image.Height;

            int destWidth = (int)(fonteLargura * nPorcentagem);
            int destHeight = (int)(fonteAltura * nPorcentagem);

            Bitmap bmImagem = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);

            bmImagem.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            Graphics grImagem = Graphics.FromImage(bmImagem);
            grImagem.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grImagem.DrawImage(image,
               new Rectangle(0, 0, destWidth, destHeight),
               new Rectangle(0, 0, fonteLargura, fonteAltura),
               GraphicsUnit.Pixel);

            grImagem.Dispose();

            GC.Collect();

            return bmImagem;
        }

        public static string ValorExtenso_Monetario(this double valor, bool substantivoMasclino = true)
        {
            return ToExtension(valor, TipoValorExtenso.Monetario, substantivoMasclino);
        }

        public static string ValorExtenso_Percent(this double valor, bool substantivoMasclino = true)
        {
            return ToExtension(valor, TipoValorExtenso.Porcentagem, substantivoMasclino);
        }

        public static string ValorExtenso_Decimal(this double valor, bool substantivoMasclino = true)
        {
            return ToExtension(valor, TipoValorExtenso.Decimal, substantivoMasclino);
        }

        public static string ValorExtenso_Inteiro(this int valor, bool substantivoMasclino = true)
        {
            return ToExtension(valor, TipoValorExtenso.Decimal, substantivoMasclino);
        }

        public static Color GetForeColor(this Color cor, LmControlStatus statusCtrl)
        {
            return LmCor.GetForeColor(statusCtrl, cor);
        }

        public static bool IsDarkColor(this Color cor)
        {
            return LmCor.IsDarkColor(cor.R, cor.G, cor.B);
        }

        public static bool IsDarkColor(this Image bitmap)
        {
            int preto = 0;
            int branco = 0;
            int neutro = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    var clr = ((Bitmap)bitmap).GetPixel(i, j);

                    if (clr.A > 150 && clr.R < 100 && clr.G < 100 && clr.B < 100)
                        return true;
                    else if (clr.A > 150 && clr.R > 200 && clr.G > 200 && clr.B > 200)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Aplicar Cores a um BitMap
        /// </summary>
        /// <param name="bitmapImage"></param>
        /// <returns></returns>
        public static Bitmap ApplyColor(this System.Drawing.Image imagem, Color novaCor)
        {
            if (imagem == null)
                return null;

            try
            {
                // byte A, R, G, B;
                Color pixelColor;

                Bitmap bitmapImage = new Bitmap(imagem);

                for (int y = 0; y < bitmapImage.Height; y++)
                {
                    for (int x = 0; x < bitmapImage.Width; x++)
                    {
                        pixelColor = bitmapImage.GetPixel(x, y);

                        if (pixelColor.A > 10)
                            bitmapImage.SetPixel(x, y, Color.FromArgb(pixelColor.A, novaCor.R, novaCor.G, novaCor.B));
                    }
                }

                return bitmapImage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Tornar a cor mais Escura determinada quantidade de pontos
        /// </summary>
        /// <param name="cor">Cor que será escurecida</param>
        /// <param name="qtdPontos">Entre 0 e 255</param>
        /// <returns></returns>
        public static Color Escurecer(this Color cor, int qtdPontos = 33)
        {
            int r = cor.R - qtdPontos > 0 ? cor.R - qtdPontos : 0;
            int g = cor.G - qtdPontos > 0 ? cor.G - qtdPontos : 0;
            int b = cor.B - qtdPontos > 0 ? cor.B - qtdPontos : 0;
            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Tornar a cor mais Clara determinada quantidade de pontos
        /// </summary>
        /// <param name="cor">Cor que será Clareada</param>
        /// <param name="qtdPontos">Entre 0 e 255</param>
        /// <returns></returns>
        public static Color Clarear(this Color cor, int qtdPontos = 33)
        {
            int r = cor.R + qtdPontos < 255 ? cor.R + qtdPontos : 255;
            int g = cor.G + qtdPontos < 255 ? cor.G + qtdPontos : 255;
            int b = cor.B + qtdPontos < 255 ? cor.B + qtdPontos : 255;
            return Color.FromArgb(r, g, b);
        }

        #region Metodos Privados

        private static int PegarAnoMaisProximo(short ano)
        {
            int contador = 0;
            while (true)
            {
                if (DateTime.Now.AddYears(contador).Year.ToString("0000").EndsWith(ano.ToString("00")))
                    return DateTime.Now.AddYears(contador).Year;
                else if (DateTime.Now.AddYears(-contador).Year.ToString("0000").EndsWith(ano.ToString("00")))
                    return DateTime.Now.AddYears(-contador).Year;

                contador++;
            }
        }

        private static string ToExtension(double valor, TipoValorExtenso tipoValorExtenso, bool substantivoMasclino)
        {
            if (valor <= 0 | valor >= 1000000000000000)
                return "Valor não suportado pelo sisTema. Valor: " + valor;

            string strValor = valor.ToString("000000000000000.00#");

            string valorPorExtenso = string.Empty;
            int qtdCasasDecimais = strValor.Substring(strValor.IndexOf(',') + 1, strValor.Length - (strValor.IndexOf(',') + 1)).Length;
            bool existemValoresAposDecimal = Convert.ToInt32(strValor.Substring(16, qtdCasasDecimais)) > 0;

            for (int i = 0; i <= 15; i += 3)
            {
                var parte = strValor.Substring(i, 3);

                if (parte.Contains(','))
                    parte = strValor.Substring(i + 1, qtdCasasDecimais);

                valorPorExtenso += EscrevaParte(Convert.ToDecimal(parte), substantivoMasclino);

                if (i == 0 && valorPorExtenso != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                        valorPorExtenso += " TRILHÃO" +
                                             ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0)
                                                  ? " E "
                                                  : string.Empty);
                    else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                        valorPorExtenso += " TRILHÕES" +
                                             ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0)
                                                  ? " E "
                                                  : string.Empty);
                }
                else if (i == 3 && valorPorExtenso != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                        valorPorExtenso += " BILHÃO" +
                                             ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0)
                                                  ? " E "
                                                  : string.Empty);
                    else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                        valorPorExtenso += " BILHÕES" +
                                             ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0)
                                                  ? " E "
                                                  : string.Empty);
                }
                else if (i == 6 && valorPorExtenso != string.Empty)
                {
                    if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                        valorPorExtenso += " MILHÃO" +
                                             ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0)
                                                  ? " E "
                                                  : string.Empty);
                    else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                        valorPorExtenso += " MILHÕES" +
                                             ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0)
                                                  ? " E "
                                                  : string.Empty);
                }
                else if (i == 9 && valorPorExtenso != string.Empty)
                    if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                        valorPorExtenso += " MIL" +
                                             ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0)
                                                  ? " E "
                                                  : string.Empty);

                if (i == 12)
                {
                    if (valorPorExtenso.Length > 8)
                        if (valorPorExtenso.Substring(valorPorExtenso.Length - 6, 6) == "BILHÃO" |
                            valorPorExtenso.Substring(valorPorExtenso.Length - 6, 6) == "MILHÃO")
                            valorPorExtenso += " DE";
                        else if (valorPorExtenso.Substring(valorPorExtenso.Length - 7, 7) == "BILHÕES" |
                                 valorPorExtenso.Substring(valorPorExtenso.Length - 7, 7) == "MILHÕES" |
                                 valorPorExtenso.Substring(valorPorExtenso.Length - 8, 7) == "TRILHÕES")
                            valorPorExtenso += " DE";
                        else if (valorPorExtenso.Substring(valorPorExtenso.Length - 8, 8) == "TRILHÕES")
                            valorPorExtenso += " DE";

                    if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                    {
                        switch (tipoValorExtenso)
                        {
                            case TipoValorExtenso.Monetario:
                                valorPorExtenso += " REAL";
                                break;
                            case TipoValorExtenso.Porcentagem:
                                if (existemValoresAposDecimal == false)
                                    valorPorExtenso += " PORCENTO";
                                break;
                            case TipoValorExtenso.Decimal:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("tipoValorExtenso");
                        }
                    }

                    else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                    {
                        switch (tipoValorExtenso)
                        {
                            case TipoValorExtenso.Monetario:
                                valorPorExtenso += " REAIS";
                                break;
                            case TipoValorExtenso.Porcentagem:
                                if (existemValoresAposDecimal == false)
                                    valorPorExtenso += " PORCENTO";
                                break;
                            case TipoValorExtenso.Decimal:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("tipoValorExtenso");
                        }
                    }

                    if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valorPorExtenso != string.Empty)
                    {
                        switch (tipoValorExtenso)
                        {
                            case TipoValorExtenso.Monetario:
                                valorPorExtenso += " E ";
                                break;
                            case TipoValorExtenso.Porcentagem:
                                valorPorExtenso += " VÍRGULA ";
                                break;
                            case TipoValorExtenso.Decimal:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("tipoValorExtenso");
                        }
                    }
                }

                if (i == 15)
                {
                    if (Convert.ToInt32(strValor.Substring(16, qtdCasasDecimais)) == 1)
                    {
                        switch (tipoValorExtenso)
                        {
                            case TipoValorExtenso.Monetario:
                                valorPorExtenso += " CENTAVO";
                                break;
                            case TipoValorExtenso.Porcentagem:
                                valorPorExtenso += " CENTAVO";
                                break;
                            case TipoValorExtenso.Decimal:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("tipoValorExtenso");
                        }
                    }

                    else if (Convert.ToInt32(strValor.Substring(16, qtdCasasDecimais)) > 1)
                    {
                        switch (tipoValorExtenso)
                        {
                            case TipoValorExtenso.Monetario:
                                valorPorExtenso += " CENTAVOS";
                                break;
                            case TipoValorExtenso.Porcentagem:
                                valorPorExtenso += " PORCENTO";
                                break;
                            case TipoValorExtenso.Decimal:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("tipoValorExtenso");
                        }
                    }
                }
            }

            return valorPorExtenso;
        }

        private static string EscrevaParte(decimal valor, bool substantivoMasclino)
        {
            if (valor <= 0)
                return string.Empty;
            else
            {
                string montagem = string.Empty;
                if (valor > 0 && valor < 1)
                {
                    valor *= 100;
                }
                string strValor = valor.ToString("000");
                int a = Convert.ToInt32(strValor.Substring(0, 1));
                int b = Convert.ToInt32(strValor.Substring(1, 1));
                int c = Convert.ToInt32(strValor.Substring(2, 1));

                if (a == 1) montagem += (b + c == 0) ? "CEM" : "CENTO";
                else if (a == 2) montagem += "DUZENTOS";
                else if (a == 3) montagem += "TREZENTOS";
                else if (a == 4) montagem += "QUATROCENTOS";
                else if (a == 5) montagem += "QUINHENTOS";
                else if (a == 6) montagem += "SEISCENTOS";
                else if (a == 7) montagem += "SETECENTOS";
                else if (a == 8) montagem += "OITOCENTOS";
                else if (a == 9) montagem += "NOVECENTOS";

                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? " E " : string.Empty) + "DEZ";
                    else if (c == 1) montagem += ((a > 0) ? " E " : string.Empty) + "ONZE";
                    else if (c == 2) montagem += ((a > 0) ? " E " : string.Empty) + "DOZE";
                    else if (c == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TREZE";
                    else if (c == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUATORZE";
                    else if (c == 5) montagem += ((a > 0) ? " E " : string.Empty) + "QUINZE";
                    else if (c == 6) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSEIS";
                    else if (c == 7) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSETE";
                    else if (c == 8) montagem += ((a > 0) ? " E " : string.Empty) + "DEZOITO";
                    else if (c == 9) montagem += ((a > 0) ? " E " : string.Empty) + "DEZENOVE";
                }
                else if (b == 2) montagem += ((a > 0) ? " E " : string.Empty) + "VINTE";
                else if (b == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TRINTA";
                else if (b == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUARENTA";
                else if (b == 5) montagem += ((a > 0) ? " E " : string.Empty) + "CINQUENTA";
                else if (b == 6) montagem += ((a > 0) ? " E " : string.Empty) + "SESSENTA";
                else if (b == 7) montagem += ((a > 0) ? " E " : string.Empty) + "SETENTA";
                else if (b == 8) montagem += ((a > 0) ? " E " : string.Empty) + "OITENTA";
                else if (b == 9) montagem += ((a > 0) ? " E " : string.Empty) + "NOVENTA";

                if (strValor.Substring(1, 1) != "1" && c != 0 && montagem != string.Empty) montagem += " E ";

                if (strValor.Substring(1, 1) != "1")
                    if (c == 1 && substantivoMasclino) montagem += "UM";
                    else if (c == 1 && !substantivoMasclino) montagem += "UMA";
                    else if (c == 2 && substantivoMasclino) montagem += "DOIS";
                    else if (c == 2 && !substantivoMasclino) montagem += "DUAS";
                    else if (c == 3) montagem += "TRÊS";
                    else if (c == 4) montagem += "QUATRO";
                    else if (c == 5) montagem += "CINCO";
                    else if (c == 6) montagem += "SEIS";
                    else if (c == 7) montagem += "SETE";
                    else if (c == 8) montagem += "OITO";
                    else if (c == 9) montagem += "NOVE";

                return montagem;
            }
        }

        #endregion

        #region Enum

        private enum TipoValorExtenso
        {
            Monetario,
            Porcentagem,
            Decimal
        }

        #endregion
    }
}
