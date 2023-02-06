
namespace LmCorbieUI.Controls
{
    partial class LmJanelaAberta
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LmJanelaAberta));
            this.lnkFechar = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblNomeJanela = new LmCorbieUI.Controls.LmLabel();
            this.msAcaoFechar = new LmCorbieUI.Controls.LmDropdownMenu(this.components);
            this.tsFecharTudoExcetoEsta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFecharEstaAba = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFecharTudoEsquerda = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFecharTudoDireita = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFecharTudo = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.lnkFechar)).BeginInit();
            this.msAcaoFechar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnkFechar
            // 
            this.lnkFechar.BackColor = System.Drawing.Color.Transparent;
            this.lnkFechar.Dock = System.Windows.Forms.DockStyle.Right;
            this.lnkFechar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnkFechar.Image = ((System.Drawing.Image)(resources.GetObject("lnkFechar.Image")));
            this.lnkFechar.Location = new System.Drawing.Point(159, 3);
            this.lnkFechar.Name = "lnkFechar";
            this.lnkFechar.Size = new System.Drawing.Size(18, 18);
            this.lnkFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.lnkFechar.TabIndex = 1;
            this.lnkFechar.TabStop = false;
            this.toolTip1.SetToolTip(this.lnkFechar, "Fechar");
            this.lnkFechar.Click += new System.EventHandler(this.LnkFechar_Click);
            this.lnkFechar.MouseEnter += new System.EventHandler(this.LnkFechar_MouseEnter);
            this.lnkFechar.MouseLeave += new System.EventHandler(this.LnkFechar_MouseLeave);
            // 
            // lblNomeJanela
            // 
            this.lblNomeJanela.AutoSize = true;
            this.lblNomeJanela.Location = new System.Drawing.Point(0, 1);
            this.lblNomeJanela.Margin = new System.Windows.Forms.Padding(3);
            this.lblNomeJanela.Name = "lblNomeJanela";
            this.lblNomeJanela.Size = new System.Drawing.Size(134, 19);
            this.lblNomeJanela.TabIndex = 0;
            this.lblNomeJanela.Text = "Cadastro de Usuário";
            this.lblNomeJanela.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblNomeJanela.UseCustomColor = true;
            this.lblNomeJanela.Click += new System.EventHandler(this.LblNomeJanela_Click);
            this.lblNomeJanela.MouseEnter += new System.EventHandler(this.LmJanelaAberta_MouseEnter);
            this.lblNomeJanela.MouseLeave += new System.EventHandler(this.LmJanelaAberta_MouseLeave);
            // 
            // msAcaoFechar
            // 
            this.msAcaoFechar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msAcaoFechar.IsMainMenu = false;
            this.msAcaoFechar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFecharTudoExcetoEsta,
            this.tsFecharEstaAba,
            this.tsFecharTudoEsquerda,
            this.tsFecharTudoDireita,
            this.tsFecharTudo});
            this.msAcaoFechar.MenuItemHeight = 25;
            this.msAcaoFechar.MenuItemTextColor = System.Drawing.Color.Empty;
            this.msAcaoFechar.Name = "msAcaoFechar";
            this.msAcaoFechar.NaoInverterCorImagem = false;
            this.msAcaoFechar.PrimaryColor = System.Drawing.Color.Empty;
            this.msAcaoFechar.Size = new System.Drawing.Size(247, 134);
            this.msAcaoFechar.Z_Teste = 0;
            // 
            // tsFecharTudoExcetoEsta
            // 
            this.tsFecharTudoExcetoEsta.Image = ((System.Drawing.Image)(resources.GetObject("tsFecharTudoExcetoEsta.Image")));
            this.tsFecharTudoExcetoEsta.Name = "tsFecharTudoExcetoEsta";
            this.tsFecharTudoExcetoEsta.Size = new System.Drawing.Size(246, 26);
            this.tsFecharTudoExcetoEsta.Text = "Fechar todas exceto esta aba";
            this.tsFecharTudoExcetoEsta.Click += new System.EventHandler(this.TsFecharTudoExcetoEsta_Click);
            // 
            // tsFecharEstaAba
            // 
            this.tsFecharEstaAba.Image = ((System.Drawing.Image)(resources.GetObject("tsFecharEstaAba.Image")));
            this.tsFecharEstaAba.Name = "tsFecharEstaAba";
            this.tsFecharEstaAba.Size = new System.Drawing.Size(246, 26);
            this.tsFecharEstaAba.Text = "Fechar somente esta aba";
            this.tsFecharEstaAba.Click += new System.EventHandler(this.TsFecharEstaAba_Click);
            // 
            // tsFecharTudoEsquerda
            // 
            this.tsFecharTudoEsquerda.Image = ((System.Drawing.Image)(resources.GetObject("tsFecharTudoEsquerda.Image")));
            this.tsFecharTudoEsquerda.Name = "tsFecharTudoEsquerda";
            this.tsFecharTudoEsquerda.Size = new System.Drawing.Size(246, 26);
            this.tsFecharTudoEsquerda.Text = "Fechar todas as abas à esquerda";
            this.tsFecharTudoEsquerda.Click += new System.EventHandler(this.TsFecharTudoEsquerda_Click);
            // 
            // tsFecharTudoDireita
            // 
            this.tsFecharTudoDireita.Image = ((System.Drawing.Image)(resources.GetObject("tsFecharTudoDireita.Image")));
            this.tsFecharTudoDireita.Name = "tsFecharTudoDireita";
            this.tsFecharTudoDireita.Size = new System.Drawing.Size(246, 26);
            this.tsFecharTudoDireita.Text = "Fechar todas as abas à direita";
            this.tsFecharTudoDireita.Click += new System.EventHandler(this.TsFecharTudoDireita_Click);
            // 
            // tsFecharTudo
            // 
            this.tsFecharTudo.Image = ((System.Drawing.Image)(resources.GetObject("tsFecharTudo.Image")));
            this.tsFecharTudo.Name = "tsFecharTudo";
            this.tsFecharTudo.Size = new System.Drawing.Size(246, 26);
            this.tsFecharTudo.Text = "Fechar todas as abas";
            this.tsFecharTudo.Click += new System.EventHandler(this.TsFecharTudo_Click);
            // 
            // LmJanelaAberta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.msAcaoFechar;
            this.Controls.Add(this.lnkFechar);
            this.Controls.Add(this.lblNomeJanela);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LmJanelaAberta";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 1, 1);
            this.Size = new System.Drawing.Size(178, 22);
            ((System.ComponentModel.ISupportInitialize)(this.lnkFechar)).EndInit();
            this.msAcaoFechar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal LmLabel lblNomeJanela;
        private System.Windows.Forms.ToolTip toolTip1;
        private LmDropdownMenu msAcaoFechar;
        private System.Windows.Forms.ToolStripMenuItem tsFecharTudoExcetoEsta;
        private System.Windows.Forms.ToolStripMenuItem tsFecharEstaAba;
        private System.Windows.Forms.ToolStripMenuItem tsFecharTudoEsquerda;
        private System.Windows.Forms.ToolStripMenuItem tsFecharTudoDireita;
        private System.Windows.Forms.ToolStripMenuItem tsFecharTudo;
        internal System.Windows.Forms.PictureBox lnkFechar;
    }
}
