
namespace LmCorbieUI.Controls
{
    partial class LmTextBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LmTextBox));
            this.baseTextBox = new System.Windows.Forms.TextBox();
            this.ptbIcon = new System.Windows.Forms.PictureBox();
            this.btnF7 = new System.Windows.Forms.PictureBox();
            this.btnF8 = new System.Windows.Forms.PictureBox();
            this.btnF9 = new System.Windows.Forms.PictureBox();
            this.btnClearButton = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearButton)).BeginInit();
            this.SuspendLayout();
            // 
            // baseTextBox
            // 
            this.baseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.baseTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.baseTextBox.Location = new System.Drawing.Point(34, 7);
            this.baseTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.baseTextBox.Name = "baseTextBox";
            this.baseTextBox.Size = new System.Drawing.Size(82, 16);
            this.baseTextBox.TabIndex = 0;
            this.baseTextBox.AcceptsTabChanged += new System.EventHandler(this.BaseTextBoxAcceptsTabChanged);
            this.baseTextBox.Click += new System.EventHandler(this.BaseTextBoxClick);
            this.baseTextBox.CausesValidationChanged += new System.EventHandler(this.BaseTextBoxCausesValidationChanged);
            this.baseTextBox.ClientSizeChanged += new System.EventHandler(this.BaseTextBoxClientSizeChanged);
            this.baseTextBox.ContextMenuStripChanged += new System.EventHandler(this.BaseTextBoxContextMenuStripChanged);
            this.baseTextBox.SizeChanged += new System.EventHandler(this.BaseTextBoxSizeChanged);
            this.baseTextBox.TextChanged += new System.EventHandler(this.BaseTextBoxTextChanged);
            this.baseTextBox.Enter += new System.EventHandler(this.baseTextBox_Enter);
            this.baseTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseTextBoxKeyDown);
            this.baseTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseTextBoxKeyPress);
            this.baseTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BaseTextBoxKeyUp);
            this.baseTextBox.Leave += new System.EventHandler(this.baseTextBox_Leave);
            this.baseTextBox.MouseEnter += new System.EventHandler(this.BaseTextBox_MouseEnter);
            this.baseTextBox.MouseLeave += new System.EventHandler(this.BaseTextBox_MouseLeave);
            this.baseTextBox.MouseHover += new System.EventHandler(this.BaseTextBox_MouseHover);
            this.baseTextBox.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.BaseTextBoxChangeUiCues);
            // 
            // ptbIcon
            // 
            this.ptbIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ptbIcon.Location = new System.Drawing.Point(10, 7);
            this.ptbIcon.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.ptbIcon.Name = "ptbIcon";
            this.ptbIcon.Size = new System.Drawing.Size(24, 16);
            this.ptbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbIcon.TabIndex = 1;
            this.ptbIcon.TabStop = false;
            // 
            // btnF7
            // 
            this.btnF7.BackColor = System.Drawing.Color.Transparent;
            this.btnF7.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnF7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnF7.Location = new System.Drawing.Point(140, 7);
            this.btnF7.Name = "btnF7";
            this.btnF7.Size = new System.Drawing.Size(16, 16);
            this.btnF7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnF7.TabIndex = 3;
            this.btnF7.TabStop = false;
            this.btnF7.Click += new System.EventHandler(this._buttonF7_Click);
            this.btnF7.MouseEnter += new System.EventHandler(this.Ptb_MouseEnter);
            this.btnF7.MouseLeave += new System.EventHandler(this.Ptb_MouseLeave);
            // 
            // btnF8
            // 
            this.btnF8.BackColor = System.Drawing.Color.Transparent;
            this.btnF8.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnF8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnF8.Location = new System.Drawing.Point(156, 7);
            this.btnF8.Name = "btnF8";
            this.btnF8.Size = new System.Drawing.Size(16, 16);
            this.btnF8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnF8.TabIndex = 2;
            this.btnF8.TabStop = false;
            this.btnF8.Click += new System.EventHandler(this._buttonF8_Click);
            this.btnF8.MouseEnter += new System.EventHandler(this.Ptb_MouseEnter);
            this.btnF8.MouseLeave += new System.EventHandler(this.Ptb_MouseLeave);
            // 
            // btnF9
            // 
            this.btnF9.BackColor = System.Drawing.Color.Transparent;
            this.btnF9.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnF9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnF9.Location = new System.Drawing.Point(172, 7);
            this.btnF9.Name = "btnF9";
            this.btnF9.Size = new System.Drawing.Size(16, 16);
            this.btnF9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnF9.TabIndex = 5;
            this.btnF9.TabStop = false;
            this.btnF9.Click += new System.EventHandler(this._buttonF9_Click);
            this.btnF9.MouseEnter += new System.EventHandler(this.Ptb_MouseEnter);
            this.btnF9.MouseLeave += new System.EventHandler(this.Ptb_MouseLeave);
            // 
            // btnClearButton
            // 
            this.btnClearButton.BackColor = System.Drawing.Color.Transparent;
            this.btnClearButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClearButton.Image = ((System.Drawing.Image)(resources.GetObject("btnClearButton.Image")));
            this.btnClearButton.Location = new System.Drawing.Point(116, 7);
            this.btnClearButton.Name = "btnClearButton";
            this.btnClearButton.Size = new System.Drawing.Size(24, 16);
            this.btnClearButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClearButton.TabIndex = 4;
            this.btnClearButton.TabStop = false;
            this.toolTip1.SetToolTip(this.btnClearButton, "Limpar Caixa de texto");
            this.btnClearButton.Click += new System.EventHandler(this.PtbClearButton_Click);
            this.btnClearButton.MouseEnter += new System.EventHandler(this.Ptb_MouseEnter);
            this.btnClearButton.MouseLeave += new System.EventHandler(this.PtbClose_MouseLeave);
            // 
            // LmTextBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.baseTextBox);
            this.Controls.Add(this.btnClearButton);
            this.Controls.Add(this.ptbIcon);
            this.Controls.Add(this.btnF7);
            this.Controls.Add(this.btnF8);
            this.Controls.Add(this.btnF9);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "LmTextBox";
            this.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.Size = new System.Drawing.Size(198, 30);
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox baseTextBox;
        private System.Windows.Forms.PictureBox ptbIcon;
        private System.Windows.Forms.PictureBox btnClearButton;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.PictureBox btnF8;
        public System.Windows.Forms.PictureBox btnF7;
        public System.Windows.Forms.PictureBox btnF9;
    }
}
