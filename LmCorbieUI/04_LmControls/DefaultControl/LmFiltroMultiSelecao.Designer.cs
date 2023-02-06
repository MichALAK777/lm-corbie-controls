
namespace LmCorbieUI.Controls
{
    partial class LmFiltroMultiSelecao
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txt = new LmCorbieUI.Controls.LmTextBox();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            this.txt.BorderRadius = 15;
            this.txt.BorderSize = 2;
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.F7ToolTipText = null;
            this.txt.F8ToolTipText = null;
            this.txt.F9ToolTipText = null;
            this.txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt.IconRight = true;
            this.txt.IconToolTipText = null;
            this.txt.Lines = new string[0];
            this.txt.Location = new System.Drawing.Point(0, 0);
            this.txt.MaxLength = 32767;
            this.txt.Name = "txt";
            this.txt.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txt.PasswordChar = '\0';
            this.txt.Propriedade = null;
            this.txt.ReadOnly = true;
            this.txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt.SelectedText = "";
            this.txt.SelectionLength = 0;
            this.txt.SelectionStart = 0;
            this.txt.ShortcutsEnabled = true;
            this.txt.Size = new System.Drawing.Size(180, 30);
            this.txt.TabIndex = 1;
            this.txt.UnderlinedStyle = false;
            this.txt.Valor_Decimais = ((short)(0));
            this.txt.MouseEnter += new System.EventHandler(this.Txt_MouseEnter);
            // 
            // LmFiltroMultiSelecao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LmFiltroMultiSelecao";
            this.Size = new System.Drawing.Size(180, 30);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private LmTextBox txt;
    }
}
