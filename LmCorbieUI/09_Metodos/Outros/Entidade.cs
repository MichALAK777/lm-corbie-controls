using LmCorbieUI.Metodos.AtributosCustomizados;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace LmCorbieUI.Metodos
{
    public class Entidade
    {
        /// <summary>
        /// Comparar Objeto Salvo com o que está em alteração, para ver o que foi alterado
        /// </summary>
        /// <param name="salvo">Classe atual salva na base de dados</param>
        /// <param name="alterado">Classe que esta em alteração</param>
        /// <param name="alteracoes">Saida String contendo detalhamento das alterações</param>
        /// <returns>Verdadeiro ou falso, se teve alteração</returns>
        public static bool TeveAlteracao(object salvo, object alterado, out string alteracoes)
        {
            try
            {
                alteracoes = "";
                if (salvo.Equals(alterado))
                    return false;

                var pSalvo = salvo.GetType().GetProperties().Where(p => p.GetCustomAttribute(typeof(NaoVerificarAlteracao)) == null).ToList();
                var pAlt = alterado.GetType().GetProperties().Where(p => p.GetCustomAttribute(typeof(NaoVerificarAlteracao)) == null).ToList();

                for (int i = 0; i < pSalvo.Count; i++)
                {
                    DisplayNameAttribute atbName = (DisplayNameAttribute)pSalvo[i].GetCustomAttribute(typeof(DisplayNameAttribute));

                    var pName = atbName != null ? atbName.DisplayName : pSalvo[i].Name;

                    object valorSalvo = pSalvo[i].GetValue(salvo, null);
                    object valorAlterado = pAlt[i].GetValue(alterado, null);

                    if (valorSalvo is byte[])
                    {
                        if (valorSalvo == null && valorAlterado != null ||
                            valorSalvo != null && valorAlterado == null ||
                            ((byte[])valorSalvo).LongLength != ((byte[])valorAlterado).LongLength)
                        {
                            alteracoes += $"{pName}\n Imagem Alterada\n\n";
                            valorSalvo = valorAlterado;

                            pSalvo[i].SetValue(salvo, pAlt[i].GetValue(alterado, null));
                        }
                    }
                    else if (valorSalvo is DateTime)
                    {
                        if (valorSalvo != null && valorAlterado != null)
                        {
                            valorSalvo = valorSalvo != null ? ((DateTime)valorSalvo).Date.AddHours(((DateTime)valorSalvo).Hour).AddMinutes(((DateTime)valorSalvo).Minute) : new DateTime(1, 1, 1);
                            valorAlterado = valorAlterado != null ? ((DateTime)valorAlterado).Date.AddHours(((DateTime)valorAlterado).Hour).AddMinutes(((DateTime)valorAlterado).Minute) : new DateTime(1, 1, 1);

                            if ((DateTime)valorSalvo != (DateTime)valorAlterado)
                            {
                                alteracoes += $"{pName} {Environment.NewLine}" +
                                  $"De".PadRight(5, '.') + $": {valorSalvo} {Environment.NewLine}" +
                                  $"Para".PadRight(5, '.') + $": {valorAlterado} {Environment.NewLine}{Environment.NewLine}";

                                valorSalvo = valorAlterado;

                                pSalvo[i].SetValue(salvo, pAlt[i].GetValue(alterado, null));
                            }
                        }
                        else if (valorSalvo != valorAlterado)
                        {
                            alteracoes += $"{pName} {Environment.NewLine}" +
                              $"De".PadRight(5, '.') + $": {valorSalvo} {Environment.NewLine}" +
                              $"Para".PadRight(5, '.') + $": {valorAlterado} {Environment.NewLine}{Environment.NewLine}";

                            valorSalvo = valorAlterado;

                            pSalvo[i].SetValue(salvo, pAlt[i].GetValue(alterado, null));
                        }
                    }
                    else if (Convert.ToString(valorSalvo) != Convert.ToString(valorAlterado))
                    {
                        if (Convert.ToString(valorAlterado).Length < 1000)
                        {
                            alteracoes += $"{pName} {Environment.NewLine}" +
                                $"De".PadRight(5, '.') + $": {valorSalvo} {Environment.NewLine}" +
                                $"Para".PadRight(5, '.') + $": {valorAlterado} {Environment.NewLine}{Environment.NewLine}";
                        }
                        else
                        {
                            alteracoes += $"{pName} {Environment.NewLine}" +
                               $"Registro Alterado {Environment.NewLine}{Environment.NewLine}";
                        }

                        valorSalvo = valorAlterado;

                        pSalvo[i].SetValue(salvo, pAlt[i].GetValue(alterado, null));
                    }
                }

                if (!string.IsNullOrEmpty(alteracoes))
                {
                    alteracoes = alteracoes.Substring(0, alteracoes.Length - 2);

                    if (alteracoes.EndsWith("\r\n"))
                        alteracoes = alteracoes.Substring(0, alteracoes.Length - 2);

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
