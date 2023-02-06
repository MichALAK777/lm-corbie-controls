using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LmCorbieUI.Metodos
{
    public class Email
    {
        public static string ServidorSMTP_Envio { get; set; } = "mail.cooper.ind.br";
        public static int PortaSMTP_Envio { get; set; } = 587;
        public static string UsuarioEmail_Envio { get; set; } = "no-reply@cooper.ind.br";
        public static string SenhaEmail_Envio { get; set; } = "JQKHQ72ikH";

        public static void SetarPadrao(
            string servidorSMTP_Envio, int portaSMTP_Envio, string usuarioEmail_Envio, string senhaEmail_Envio)
        {
            Email.ServidorSMTP_Envio = servidorSMTP_Envio;
            Email.PortaSMTP_Envio = portaSMTP_Envio;
            Email.UsuarioEmail_Envio = usuarioEmail_Envio;
            Email.SenhaEmail_Envio = senhaEmail_Envio;

        }

        internal static void SendEmailofException(Exception ex, string mensagemErro)
        {
            try
            {
                string emailTitulo = $"{ValPadrao.NomeCliente} LogErro {mensagemErro}";

                string emailCorpo = $"Cliente: {ValPadrao.NomeCliente}\n" +
                                    $"Software: {ValPadrao.NomeSistema}\n" +
                                    $"Máquina: {Environment.MachineName}\n" +
                                    $"Usuário: {Environment.UserName}\n" +
                                    $"Mensagem: {mensagemErro}\n\n\n{ex}";

                List<string> emailAnexo = new List<string>() { ValPadrao.PathImagemLogErro };

                SendMail(emailTitulo, emailCorpo, ValPadrao.Mail, emailAnexo);
            }
            catch (Exception)
            {
                //MsgBox.Show( "Erro ao Enviar Email.\n" + exc.Message, "Erro");
            }
        }

        /// <summary>
        /// Envia email atraves da conta configurado
        /// </summary>
        /// <param name="titulo">Titulo do Email</param>
        /// <param name="corpoEmail">Mensagem do corpo do email</param>
        /// <param name="emailPara">email destino, separar com ";" para mais de 1</param>
        /// <param name="anexos">Lista com Local do Anexo</param>
        /// <returns>retorno padrao string nula, caso de erro retorna string com Informações do Erro</returns>
        public static string SendMail(string titulo, string corpoEmail, string emailPara = "", List<string> anexos = null, bool isHtml = false, string emailResposta = "", string emailCC = "", string emailCCO = "")
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(UsuarioEmail_Envio);

                mail.IsBodyHtml = isHtml;

                emailPara = emailPara.Replace(",", ";").Replace("|", ";").Replace("^", ";");
                emailResposta = emailResposta.Replace(",", ";").Replace("|", ";").Replace("^", ";");

                foreach (string s in emailPara.Split(';'))
                    if (!string.IsNullOrEmpty(s.Trim()) && ValidarEmail(s.Trim()) && !mail.To.Contains(new MailAddress(s.Trim())))
                        mail.To.Add(s.Trim());

                if (!string.IsNullOrEmpty(emailCC))
                {
                    emailCC = emailCC.Replace(",", ";").Replace("|", ";").Replace("^", ";");
                    foreach (string s in emailCC.Split(';'))
                        if (!string.IsNullOrEmpty(s.Trim()) && ValidarEmail(s.Trim()) && !mail.To.Contains(new MailAddress(s.Trim())))
                            mail.CC.Add(s.Trim());
                }

                if (!string.IsNullOrEmpty(emailCCO))
                {
                    emailCCO = emailCCO.Replace(",", ";").Replace("|", ";").Replace("^", ";");
                    foreach (string s in emailCCO.Split(';'))
                        if (!string.IsNullOrEmpty(s.Trim()) && ValidarEmail(s.Trim()) && !mail.To.Contains(new MailAddress(s.Trim())))
                            mail.Bcc.Add(s.Trim());
                }

                foreach (string s in emailResposta.Split(';'))
                    if (!string.IsNullOrEmpty(s.Trim()) && ValidarEmail(s.Trim()))
                        mail.ReplyToList.Add(s.Trim());

                mail.Subject = titulo.Replace("\r\n", " ").Replace("\n", " ");

                corpoEmail = corpoEmail.Replace("\r\r\n", Environment.NewLine);
                corpoEmail = corpoEmail.Replace("\n", Environment.NewLine);
                corpoEmail = corpoEmail.Replace("\r\r\n", Environment.NewLine);

                mail.Body = !isHtml ? corpoEmail : corpoEmail.Replace("\r\n", "<br>");

                if (anexos != null)
                    foreach (string s in anexos)
                        if (System.IO.File.Exists(s))
                            mail.Attachments.Add(new Attachment(s));

                using (var smtp = new SmtpClient(ServidorSMTP_Envio))
                {
                    smtp.EnableSsl = true; // GMail requer SSL
                    smtp.Port = PortaSMTP_Envio;       // porta para SSL
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                    smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas
                    smtp.Credentials = new NetworkCredential(UsuarioEmail_Envio, SenhaEmail_Envio);

                    smtp.Send(mail);
                    System.Diagnostics.Debug.Print($"E-mail enviado para: {mail.To[0]} - \"{titulo}\"");
                    mail.Dispose();
                    GC.SuppressFinalize(mail);
                    GC.Collect();
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                //SendEmailofException(exc, "Desconhecido", "Customax", "Erro ao enviar Mensagem para Suporte");
                return $"Dados Técnicos Para análise\n" +
                    $"____________________________________________________________\n" +
                    $"{ex}";
            }
        }

        public static bool ValidarEmail(string email, System.Windows.Forms.Control control)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) return false;

                email = email.Replace(" ", "");

                string modelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                foreach (var m in email.Split(','))
                {
                    if (!string.IsNullOrEmpty(m) && !System.Text.RegularExpressions.Regex.IsMatch(m.Trim(), modelo))
                    {
                        if (control != null)
                            MsgBox.ShowToolTip(control, "E-Mail Inválido!");

                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                MsgBox.ShowToolTip(control, "E-Mail Inválido!", "Erro");
                return false;
            }
        }

        public static bool ValidarEmail(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) return false;

                email = email.Replace(" ", "");

                string modelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                foreach (var m in email.Split(','))
                {
                    if (!string.IsNullOrEmpty(m) && !System.Text.RegularExpressions.Regex.IsMatch(m.Trim(), modelo))
                    {
                        //if (control != null)
                        //    MsgBox.ShowToolTip(control, "E-Mail Inválido!");

                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
