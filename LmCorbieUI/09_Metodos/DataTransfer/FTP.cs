using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace LmCorbieUI.Metodos
{
    public class FTP
    {
        /// <summary>
        /// Upload de arquivos
        /// </summary>
        /// <param name="arquivo">Path do Arquivo a ser enviado</param>
        /// <param name="uri">URL acesso ao Servidor Ex: "ftp://192.168.20.777/nomeArquivo.extensao"</param>
        /// <param name="usuario">Usuário FTP</param>
        /// <param name="senha">Senha de Acesso ao Servidor FTP</param>
        public static bool EnviarArquivoFTP(string arquivo, string uri, string usuario, string senha)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(uri);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(usuario, senha);

                var conteudoArquivo = File.ReadAllBytes(arquivo);
                request.ContentLength = conteudoArquivo.Length;

                var requestStream = request.GetRequestStream();
                requestStream.Write(conteudoArquivo, 0, conteudoArquivo.Length);
                requestStream.Close();

                var response = (FtpWebResponse)request.GetResponse();
                Debug.Print("Upload completo. Status: {0}", response.StatusDescription);
                response.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        /// <summary>
        /// Download de arquivos
        /// </summary>
        /// <param name="uri">URL acesso ao Servidor Ex: "ftp://192.168.20.777/nomeArquivo.extensao"</param>
        /// <param name="destino">Diretório local para baixar Arquivo</param>
        /// <param name="usuario">Usuário FTP</param>
        /// <param name="senha">Senha de Acesso ao Servidor FTP</param>
        public static bool BaixarArquivoFTP(string uri, string destino, string usuario, string senha/*, out string responseMessage*/)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(uri);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(usuario, senha);

                var response = (FtpWebResponse)request.GetResponse();

                var responseStream = response.GetResponseStream();
                using (var memoryStream = new MemoryStream())
                {
                    responseStream.CopyTo(memoryStream);
                    var conteudoArquivo = memoryStream.ToArray();
                    File.WriteAllBytes(destino, conteudoArquivo);
                }

                Debug.Print("Download Complete, status {0}", response.StatusDescription);
                response.Close();
                // responseMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeletaArquivo(string uri, string usuario, string senha)//, string arquivo
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);// + "/" + arquivo); 
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(usuario, senha);

                var response = (FtpWebResponse)request.GetResponse();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void MoverArquivo(string url, string usuario, string senha, string ftpDiretorioAtual, string ftpDiretorioNovo, string arquivo)
        {
            FtpWebRequest ftpRequest = null;
            FtpWebResponse ftpResponse = null;
            try
            {
                ftpRequest = (FtpWebRequest)WebRequest.Create(url + "/" + ftpDiretorioAtual + "/" + arquivo);
                ftpRequest.Credentials = new NetworkCredential(usuario, senha);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                ftpRequest.RenameTo = ftpDiretorioNovo + "/" + arquivo;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool ValidaInformacaoServidorFTP(string url, string usuario, string senha)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
                return false;
            else
                return true;
        }

        private static bool ValidaInformacaoDownload(string arquivo, string local)
        {
            if (string.IsNullOrEmpty(arquivo) || string.IsNullOrEmpty(local))
                return false;
            else
                return true;
        }
    }
}
