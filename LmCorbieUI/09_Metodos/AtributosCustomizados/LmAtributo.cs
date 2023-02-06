using LmCorbieUI.Design;
using System;
using System.Windows.Forms;

namespace LmCorbieUI.Metodos.AtributosCustomizados 
{
    /// <summary>
    /// Ao Salvar, Não Verificar se teve alteração
    /// </summary>
    public class NaoVerificarAlteracao : Attribute
    {
        /// <summary>
        /// Ao Salvar, Não Verificar se teve alteração
        /// </summary>
        public NaoVerificarAlteracao()
        {
        }
    }

    /// <summary>
    /// Não exibe no dgv Padrão
    /// </summary>
    public class NaoImprimirColunaNoGrid : Attribute
    {
        /// <summary>
        /// Não exibe no dgv Padrão
        /// </summary>
        public NaoImprimirColunaNoGrid()
        {
        }
    }

    public class EhLink : Attribute
    {
        /// <summary>
        /// Formata Celula como link ao FormatarGrid
        /// </summary>
        public EhLink()
        {
        }

    }

    /// <summary>
    /// Fixar uma largura para coluna ao inserir em uma tabela
    /// </summary>
    public class LarguraColunaGrid : Attribute
    {
        /// <summary>
        /// Fixar uma largura para coluna ao inserir em uma tabela
        /// </summary>
        /// <param name="larguraColuna">Largura da coluna no Grid [zero(0) patra Fill]</param>
        public LarguraColunaGrid(int larguraColuna)
        {
            this.LarguraColuna = larguraColuna;
        }

        public int LarguraColuna { get; }
    }

    /// <summary>
    /// Inserir Cálculo de Valor Total no grid
    /// </summary>
    public class CalcularTotal : Attribute
    {
        /// <summary>
        /// Inserir Cálculo de Valor Total no grid
        /// </summary>
        /// <param name="TipoValor"></param>
        public CalcularTotal(LmValueType TipoValor, string ToolTipColuna = "", bool CalcularMedia = false, bool IgnorarNulosEZerosNaMedia = false)
        {
            this.TipoValor = TipoValor;
            this.ToolTipColuna = ToolTipColuna;
            this.CalcularMedia = CalcularMedia;
            this.IgnorarNulosEZerosNaMedia = IgnorarNulosEZerosNaMedia;
        }

        public LmValueType TipoValor { get; }
        public string ToolTipColuna { get; }
        public bool CalcularMedia { get; }
        public bool IgnorarNulosEZerosNaMedia { get; }
    }

    /// <summary>
    /// Formata o Grid de Acordo Com previsão, comparando a Data Atual
    /// </summary>
    public class FormatarColunaPrevisao : Attribute
    {
        /// <summary>
        /// Formata o Grid de Acordo Com previsão, comparando a Data Atual
        /// </summary>
        /// <param name="FormatarVencida"></param>
        /// <param name="FormatarVenceHoje"></param>
        /// <param name="FormatarNaoVenceuAinda"></param>
        public FormatarColunaPrevisao(bool FormatarVencida, bool FormatarVenceHoje, bool FormatarNaoVenceuAinda)
        {
            this.FormatarVencida = FormatarVencida;
            this.FormatarVenceHoje = FormatarVenceHoje;
            this.FormatarNaoVenceuAinda = FormatarNaoVenceuAinda;
        }

        public bool FormatarVencida { get; }
        public bool FormatarVenceHoje { get; }
        public bool FormatarNaoVenceuAinda { get; }
    }

    /// <summary>
    ///  Ignorar a Formatação de vencimanto
    /// </summary>
    public class IgnorarFormatacaoPrevisao : Attribute
    {
        /// <summary>
        /// Ignorar a Formatação de vencimanto
        /// </summary>
        public IgnorarFormatacaoPrevisao()
        {
        }
    }

    /// <summary>
    ///  Ignorar a Formatação de vencimanto
    /// </summary>
    public class NaoFormataDataPrevisaorQuando : Attribute
    {
        /// <summary>
        /// Ignorar a Formatação de vencimanto
        /// </summary>
        public NaoFormataDataPrevisaorQuando(string[] texto)
        {
            this.Texto = texto;
        }

        public string[] Texto { get; }
    }

    /// <summary>
    /// Formata Texto da Coluna de Acordo com parametro 
    /// </summary>
    public class Formatacao : Attribute
    {
        /// <summary>
        /// Formatar texto da Coluna
        /// </summary>
        /// <param name="texto">Estilo Formatacao</param>
        public Formatacao(string texto)
        {
            this.formatacao = texto;
        }

        public string formatacao { get; }
    }

    /// <summary>
    /// Mostrar display ao posicionar mouse sobre coluna do Grid
    /// </summary>
    public class ToolTipGrid : Attribute
    {
        /// <summary>
        /// Display mostrado ao posicionar mouse sobre coluna do Grid
        /// </summary>
        /// <param name="toolTipText">Texto para exibição</param>
        public ToolTipGrid(string toolTipText)
        {
            this.Texto = toolTipText;
        }

        public string Texto { get; }
    }

    /// <summary>
    /// Alinhar Coluna em uma tabela
    /// </summary>
    public class AlinhamentoColunaGrid : Attribute
    {
        /// <summary>
        /// Define o alinhamento da propriedade ao inserir em uma coluna
        /// </summary>
        /// <param name="alinhamento">Escolher tipo alinhamento</param>
        public AlinhamentoColunaGrid(DataGridViewContentAlignment alinhamento)
        {
            Alinhamento = alinhamento;
        }

        public DataGridViewContentAlignment Alinhamento { get; }
    }

}
