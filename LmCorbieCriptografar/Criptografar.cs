using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LmCorbieUI
{
    public static class Criptografar
    {
        /// <summary>
        /// Codificar string Modelo MD5 (Irreversivel)
        /// </summary>
        /// <param name="content">Valor alfanumerico a ser criptografado</param>
        /// <returns>string Criptografada 32bits</returns>
        public static string MD5(string content, bool toUpper = false)
        {
            MD5CryptoServiceProvider M5 = new MD5CryptoServiceProvider();
            byte[] ByteString = Encoding.ASCII.GetBytes(content);
            ByteString = M5.ComputeHash(ByteString);
            string FinalString = null;
            foreach (byte bt in ByteString)
            {
                FinalString += bt.ToString("x2");
            }
            if (toUpper)
                return FinalString.ToUpper();
            else
                return FinalString;
        }

        #region AES / Rijndael

        /// <summary>     
        /// Vetor de bytes utilizados para a criptografia (Chave Externa)     
        /// </summary>     
        private static byte[] bIV =
        { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
        0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        /// <summary>     
        /// Representação de valor em base 64 (Chave Interna)    
        /// O Valor representa a transformação para base64 de     
        /// um conjunto de 32 caracteres (8 * 32 = 256bits)    
        /// A chave é: "michalak leonardo", gerada através da chave original "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=" A chave é: "Criptografias com Rijndael / AES"
        /// </summary>      
        private const string cryptoKey = "nTNL8Rq0vIQJPSBp0g3CugCSHUu49Qpft0WRQcF2e9w=";
        /*
         *              JAMAIS ALTERE A CONSTANTE 'cryptoKey' POIS SENÃO NADA QUE TENHA SIDO 
         *              CRIPTOGRAFADO COM ESTA CHAVE PODERÁ SER DESCRIPTOGRAFADO           
         *          
         *    ------->> MUITA ATENÇÃO POIS JÁ EXISTEM PROJETOS CRIPTOGRAFADOS COM ESTA CHAVE <<-------
         */


        /// <summary>     
        /// Metodo de criptografia de valor     
        /// </summary>     
        /// <param name="text">valor a ser criptografado</param>     
        /// <returns>valor criptografado</returns>
        public static string EncryptAES(string text)
        {
            try
            {
                // Se a string não está vazia, executa a criptografia
                if (!string.IsNullOrEmpty(text))
                {
                    // Cria instancias de vetores de bytes com as chaves                
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = new UTF8Encoding().GetBytes(text);

                    // Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"                
                    // Lembre-se: chaves possíves:                
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor criptografado:                
                    MemoryStream mStream = new MemoryStream();
                    // Instancia o encriptador                 
                    CryptoStream encryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateEncryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória
                    encryptor.Write(bText, 0, bText.Length);
                    // Despeja toda a memória.                
                    encryptor.FlushFinalBlock();
                    // Pega o vetor de bytes da memória e gera a string criptografada                
                    return Convert.ToBase64String(mStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo                
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Se algum erro ocorrer, dispara a exceção            
                throw new ApplicationException("Erro ao criptografar", ex);
            }
        }

        /// <summary>     
        /// Pega um valor previamente criptografado e retorna o valor inicial 
        /// </summary>     
        /// <param name="text">texto criptografado</param>     
        /// <returns>valor descriptografado</returns>     
        public static string DecryptAES(string text)
        {
            try
            {
                // Se a string não está vazia, executa a criptografia           
                if (!string.IsNullOrEmpty(text))
                {
                    // Cria instancias de vetores de bytes com as chaves                
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = Convert.FromBase64String(text);

                    // Instancia a classe de criptografia Rijndael                
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"                
                    // Lembre-se: chaves possíves:                
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor DEScriptografado:               
                    MemoryStream mStream = new MemoryStream();

                    // Instancia o Decriptador                 
                    CryptoStream decryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateDecryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória   
                    decryptor.Write(bText, 0, bText.Length);
                    // Despeja toda a memória.                
                    decryptor.FlushFinalBlock();
                    // Instancia a classe de codificação para que a string venha de forma correta         
                    UTF8Encoding utf8 = new UTF8Encoding();
                    // Com o vetor de bytes da memória, gera a string descritografada em UTF8       
                    return utf8.GetString(mStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo                
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Se algum erro ocorrer, dispara a exceção            
                throw new ApplicationException("Erro ao descriptografar", ex);
            }
        }


        #endregion

        #region Metodos de Extensão

        public static string CriptografarAES(this string valor) => !string.IsNullOrEmpty(valor) ? Criptografar.EncryptAES(valor) : string.Empty;
        public static string DescriptografarAES(this string valor) => !string.IsNullOrEmpty(valor) ? Criptografar.DecryptAES(valor) : string.Empty;

        public static string CriptografarMD5(this string valor) => !string.IsNullOrEmpty(valor) ? Criptografar.MD5(valor, false) : string.Empty;
        #endregion
    }
}
