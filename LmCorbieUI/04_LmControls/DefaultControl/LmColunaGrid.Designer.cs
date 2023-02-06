
namespace LmCorbieUI.Controls
{
    partial class LmColunaGrid
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
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lnkAddRem = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lnkAddRem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescricao
            // 
            this.lblDescricao.BackColor = System.Drawing.Color.Transparent;
            this.lblDescricao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescricao.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDescricao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescricao.Location = new System.Drawing.Point(0, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(226, 21);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Nome Coluna no Grid";
            this.lblDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDescricao.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblDescricao_MouseDown);
            this.lblDescricao.MouseEnter += new System.EventHandler(this.UcColunaGrid_MouseEnter);
            this.lblDescricao.MouseLeave += new System.EventHandler(this.UcColunaGrid_MouseLeave);
            // 
            // lnkAddRem
            // 
            this.lnkAddRem.BackColor = System.Drawing.Color.Transparent;
            this.lnkAddRem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkAddRem.Dock = System.Windows.Forms.DockStyle.Right;
            this.lnkAddRem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnkAddRem.Image = global::LmCorbieUI.Properties.Resources.avancar;
            this.lnkAddRem.Location = new System.Drawing.Point(226, 0);
            this.lnkAddRem.Name = "lnkAddRem";
            this.lnkAddRem.Size = new System.Drawing.Size(22, 21);
            this.lnkAddRem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.lnkAddRem.TabIndex = 1;
            this.lnkAddRem.TabStop = false;
            this.lnkAddRem.MouseEnter += new System.EventHandler(this.UcColunaGrid_MouseEnter);
            this.lnkAddRem.MouseLeave += new System.EventHandler(this.UcColunaGrid_MouseLeave);
            // 
            // LmColunaGrid
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lnkAddRem);
            this.Name = "LmColunaGrid";
            this.Size = new System.Drawing.Size(248, 21);
            this.MouseEnter += new System.EventHandler(this.UcColunaGrid_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UcColunaGrid_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.lnkAddRem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox lnkAddRem;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Label lblDescricao;
    }
}
