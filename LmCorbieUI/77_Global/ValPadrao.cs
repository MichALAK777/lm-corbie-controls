using System.Drawing;

namespace LmCorbieUI
{
    public class ValPadrao
    {
        public static string PastaPrograma { get; set; } = string.Empty;
        public static string PastaTemp { get; set; } = string.Empty;
        public static string PastaConfig { get; set; } = string.Empty;
        public static string PastaLog { get; set; } = string.Empty;
        public static string PastaArquivo { get; set; } = string.Empty;
        public static string PastaImagem { get; set; } = string.Empty;
        public static string PathImagemLogoRelatorio { get; set; } = string.Empty;
        public static string PathImagemLogErro { get; set; } = string.Empty;
        public static string ConnectionString { get; set; } = string.Empty;
        public static string Mail { get; set; } = string.Empty;
        public static string NomeSistema { get; set; } = string.Empty;
        public static string NomeCliente { get; set; } = string.Empty;


        public static void DefinirPadrao(string PastaRaiz, string nomeSistema, string nomeCliente = "", string mail = "")
        {
            NomeSistema = nomeSistema;

            if (string.IsNullOrEmpty(nomeCliente))
                NomeCliente = "LM Projetos";
            else
                NomeCliente = nomeCliente;

            if (string.IsNullOrEmpty(mail))
                Mail = "michalakleo@gmail.com";
            else Mail = mail;

            PastaPrograma = $@"C:\{PastaRaiz}\{nomeSistema}\";
            PastaImagem = PastaPrograma + @"Imagens\";
            PastaTemp = $@"{PastaPrograma}Temp\";
            PastaConfig = $@"{PastaPrograma}Config\";
            PastaLog = $@"{PastaPrograma}Logs\";
            PastaArquivo = $@"{PastaPrograma}Arquivos\";

            PathImagemLogoRelatorio = $@"{PastaImagem}Logo.PNG";

            PathImagemLogErro = $@"{PastaImagem}Error.PNG";

            ConnectionString = PastaConfig + "ConnectionString.cnn";

            if (!System.IO.Directory.Exists(PastaPrograma))
                System.IO.Directory.CreateDirectory(PastaPrograma);

            if (!System.IO.Directory.Exists(PastaTemp))
                System.IO.Directory.CreateDirectory(PastaTemp);

            if (!System.IO.Directory.Exists(PastaImagem))
                System.IO.Directory.CreateDirectory(PastaImagem);

            if (!System.IO.Directory.Exists(PastaConfig))
                System.IO.Directory.CreateDirectory(PastaConfig);

            if (!System.IO.Directory.Exists(PastaLog))
                System.IO.Directory.CreateDirectory(PastaLog);

            if (!System.IO.Directory.Exists(PastaArquivo))
                System.IO.Directory.CreateDirectory(PastaArquivo);

            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(PathImagemLogoRelatorio)))
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(PathImagemLogoRelatorio));

            if (!System.IO.File.Exists(PathImagemLogoRelatorio))
            {
                Image img = new Bitmap(50, 50);
                img.Save(PathImagemLogoRelatorio, System.Drawing.Imaging.ImageFormat.Png);
            }

        }

    }
}
