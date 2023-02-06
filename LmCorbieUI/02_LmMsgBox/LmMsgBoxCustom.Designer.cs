
namespace LmCorbieUI
{
    partial class LmMsgBoxCustom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LmMsgBoxCustom));
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.lblTexto = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.flpBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOpcao3 = new LmCorbieUI.Controls.LmButton();
            this.btnOpcao2 = new LmCorbieUI.Controls.LmButton();
            this.btnOpcao1 = new LmCorbieUI.Controls.LmButton();
            this.ptbIcone = new System.Windows.Forms.PictureBox();
            this.pnlPrincipal.SuspendLayout();
            this.flpBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcone)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(216)))), ((int)(((byte)(217)))));
            this.pnlPrincipal.Controls.Add(this.lblTexto);
            this.pnlPrincipal.Controls.Add(this.lblTitulo);
            this.pnlPrincipal.Controls.Add(this.flpBotoes);
            this.pnlPrincipal.Controls.Add(this.ptbIcone);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(2, 2);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(670, 87);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTexto.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.lblTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(87)))), ((int)(((byte)(90)))));
            this.lblTexto.Location = new System.Drawing.Point(69, 24);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Padding = new System.Windows.Forms.Padding(13, 3, 13, 4);
            this.lblTexto.Size = new System.Drawing.Size(146, 25);
            this.lblTexto.TabIndex = 3;
            this.lblTexto.Text = "Seu Texto Aqui";
            this.lblTexto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(87)))), ((int)(((byte)(90)))));
            this.lblTitulo.Location = new System.Drawing.Point(69, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(601, 24);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Titulo Aqui";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // flpBotoes
            // 
            this.flpBotoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(207)))));
            this.flpBotoes.Controls.Add(this.btnOpcao3);
            this.flpBotoes.Controls.Add(this.btnOpcao2);
            this.flpBotoes.Controls.Add(this.btnOpcao1);
            this.flpBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBotoes.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBotoes.Location = new System.Drawing.Point(69, 57);
            this.flpBotoes.Name = "flpBotoes";
            this.flpBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.flpBotoes.Size = new System.Drawing.Size(601, 30);
            this.flpBotoes.TabIndex = 1;
            this.flpBotoes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // btnOpcao3
            // 
            this.btnOpcao3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOpcao3.BorderRadius = 13;
            this.btnOpcao3.BorderSize = 0;
            this.btnOpcao3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOpcao3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcao3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpcao3.Location = new System.Drawing.Point(489, 3);
            this.btnOpcao3.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnOpcao3.Name = "btnOpcao3";
            this.btnOpcao3.Size = new System.Drawing.Size(94, 26);
            this.btnOpcao3.TabIndex = 3;
            this.btnOpcao3.Text = "Opção 3";
            this.btnOpcao3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpcao3.UseVisualStyleBackColor = false;
            // 
            // btnOpcao2
            // 
            this.btnOpcao2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOpcao2.BorderRadius = 13;
            this.btnOpcao2.BorderSize = 0;
            this.btnOpcao2.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnOpcao2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcao2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpcao2.Location = new System.Drawing.Point(393, 3);
            this.btnOpcao2.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnOpcao2.Name = "btnOpcao2";
            this.btnOpcao2.Size = new System.Drawing.Size(94, 26);
            this.btnOpcao2.TabIndex = 2;
            this.btnOpcao2.Text = "Opção 2";
            this.btnOpcao2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpcao2.UseVisualStyleBackColor = false;
            // 
            // btnOpcao1
            // 
            this.btnOpcao1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpcao1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOpcao1.BorderRadius = 13;
            this.btnOpcao1.BorderSize = 0;
            this.btnOpcao1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOpcao1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcao1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpcao1.Location = new System.Drawing.Point(297, 3);
            this.btnOpcao1.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnOpcao1.Name = "btnOpcao1";
            this.btnOpcao1.Size = new System.Drawing.Size(94, 26);
            this.btnOpcao1.TabIndex = 1;
            this.btnOpcao1.Text = "Opção 1";
            this.btnOpcao1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpcao1.UseVisualStyleBackColor = false;
            // 
            // ptbIcone
            // 
            this.ptbIcone.BackColor = System.Drawing.Color.Transparent;
            this.ptbIcone.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbIcone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.ptbIcone.Image = global::LmCorbieUI.Properties.Resources.information;
            this.ptbIcone.Location = new System.Drawing.Point(0, 0);
            this.ptbIcone.Name = "ptbIcone";
            this.ptbIcone.Size = new System.Drawing.Size(69, 87);
            this.ptbIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbIcone.TabIndex = 0;
            this.ptbIcone.TabStop = false;
            this.ptbIcone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // LmMsgBoxCustom
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(674, 91);
            this.ControlBox = false;
            this.Controls.Add(this.pnlPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LmMsgBoxCustom";
            this.ShowInTaskbar = false;
            this.Text = "LmMsgBoxCustom";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LmMsgBoxCustom_KeyDown);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.flpBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.PictureBox ptbIcone;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.FlowLayoutPanel flpBotoes;
        private Controls.LmButton btnOpcao3;
        private Controls.LmButton btnOpcao2;
        private Controls.LmButton btnOpcao1;
    }
}