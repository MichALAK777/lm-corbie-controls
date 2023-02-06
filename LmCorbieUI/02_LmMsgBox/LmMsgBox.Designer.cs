
namespace LmCorbieUI
{
    partial class LmMsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LmMsgBox));
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.lblTexto = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.flpBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new LmCorbieUI.Controls.LmButton();
            this.btnNo = new LmCorbieUI.Controls.LmButton();
            this.btnYes = new LmCorbieUI.Controls.LmButton();
            this.btnOk = new LmCorbieUI.Controls.LmButton();
            this.btnIgnore = new LmCorbieUI.Controls.LmButton();
            this.btnRetry = new LmCorbieUI.Controls.LmButton();
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
            this.flpBotoes.Controls.Add(this.btnCancel);
            this.flpBotoes.Controls.Add(this.btnNo);
            this.flpBotoes.Controls.Add(this.btnYes);
            this.flpBotoes.Controls.Add(this.btnOk);
            this.flpBotoes.Controls.Add(this.btnIgnore);
            this.flpBotoes.Controls.Add(this.btnRetry);
            this.flpBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBotoes.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBotoes.Location = new System.Drawing.Point(69, 57);
            this.flpBotoes.Name = "flpBotoes";
            this.flpBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.flpBotoes.Size = new System.Drawing.Size(601, 30);
            this.flpBotoes.TabIndex = 1;
            this.flpBotoes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitulo_MouseDown);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderRadius = 13;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(489, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = " &Cancelar";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            // 
            // btnNo
            // 
            this.btnNo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnNo.BorderRadius = 13;
            this.btnNo.BorderSize = 0;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNo.Location = new System.Drawing.Point(393, 3);
            this.btnNo.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(94, 26);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = " &Não";
            this.btnNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Visible = false;
            // 
            // btnYes
            // 
            this.btnYes.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnYes.BorderRadius = 13;
            this.btnYes.BorderSize = 0;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Image = ((System.Drawing.Image)(resources.GetObject("btnYes.Image")));
            this.btnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYes.Location = new System.Drawing.Point(297, 3);
            this.btnYes.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(94, 26);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = " &Sim";
            this.btnYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOk.BorderRadius = 13;
            this.btnOk.BorderSize = 0;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(201, 3);
            this.btnOk.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 26);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = " &OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Visible = false;
            // 
            // btnIgnore
            // 
            this.btnIgnore.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnIgnore.BorderRadius = 13;
            this.btnIgnore.BorderSize = 0;
            this.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIgnore.Image = ((System.Drawing.Image)(resources.GetObject("btnIgnore.Image")));
            this.btnIgnore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIgnore.Location = new System.Drawing.Point(105, 3);
            this.btnIgnore.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(94, 26);
            this.btnIgnore.TabIndex = 5;
            this.btnIgnore.Text = " &Ignorar";
            this.btnIgnore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIgnore.UseVisualStyleBackColor = false;
            this.btnIgnore.Visible = false;
            // 
            // btnRetry
            // 
            this.btnRetry.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRetry.BorderRadius = 13;
            this.btnRetry.BorderSize = 0;
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetry.Image = ((System.Drawing.Image)(resources.GetObject("btnRetry.Image")));
            this.btnRetry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetry.Location = new System.Drawing.Point(9, 3);
            this.btnRetry.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(94, 26);
            this.btnRetry.TabIndex = 4;
            this.btnRetry.Text = " &Repetir";
            this.btnRetry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRetry.UseVisualStyleBackColor = false;
            this.btnRetry.Visible = false;
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
            // LmMsgBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(674, 91);
            this.ControlBox = false;
            this.Controls.Add(this.pnlPrincipal);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LmMsgBox";
            this.ShowInTaskbar = false;
            this.Text = "LmMsgBox";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LmMsgBox_KeyDown);
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
        private Controls.LmButton btnCancel;
        private Controls.LmButton btnNo;
        private Controls.LmButton btnYes;
        private Controls.LmButton btnOk;
        private Controls.LmButton btnIgnore;
        private Controls.LmButton btnRetry;
    }
}