
namespace LmCorbieUI
{
    partial class LmImputBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LmImputBox));
            this.lblTitulo = new LmCorbieUI.Controls.LmLabel();
            this.lblDesc = new LmCorbieUI.Controls.LmLabel();
            this.txt = new LmCorbieUI.Controls.LmTextBox();
            this.btnConfirmar = new LmCorbieUI.Controls.LmButton();
            this.btnCancelar = new LmCorbieUI.Controls.LmButton();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(13, 4);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(64, 19);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "lmLabel1";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(38, 24);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(3);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(64, 19);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "lmLabel2";
            // 
            // txt
            // 
            this.txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(223)))), ((int)(((byte)(246)))));
            this.txt.BorderRadius = 14;
            this.txt.BorderSize = 2;
            this.txt.F7ToolTipText = null;
            this.txt.F8ToolTipText = null;
            this.txt.F9ToolTipText = null;
            this.txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt.IconF7 = ((System.Drawing.Image)(resources.GetObject("txt.IconF7")));
            this.txt.IconF8 = ((System.Drawing.Image)(resources.GetObject("txt.IconF8")));
            this.txt.IconToolTipText = null;
            this.txt.Lines = new string[0];
            this.txt.Location = new System.Drawing.Point(38, 42);
            this.txt.MaxLength = 32767;
            this.txt.Name = "txt";
            this.txt.PasswordChar = '\0';
            this.txt.Propriedade = null;
            this.txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt.SelectedText = "";
            this.txt.SelectionLength = 0;
            this.txt.SelectionStart = 0;
            this.txt.ShortcutsEnabled = true;
            this.txt.ShowButtonF7 = true;
            this.txt.ShowButtonF8 = true;
            this.txt.Size = new System.Drawing.Size(237, 29);
            this.txt.TabIndex = 0;
            this.txt.UnderlinedStyle = false;
            this.txt.UseSelectable = true;
            this.txt.Valor_Decimais = ((short)(0));
            this.txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt.ButtonClickF7 += new LmCorbieUI.Controls.LmTextBox.ButClick(this.Txt_ButtonClickF7);
            this.txt.ButtonClickF8 += new LmCorbieUI.Controls.LmTextBox.ButClick(this.Txt_ButtonClickF8);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_KeyDown);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnConfirmar.BorderRadius = 15;
            this.btnConfirmar.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(81, 75);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(94, 26);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = " Confirmar";
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancelar.BorderRadius = 15;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(181, 75);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 26);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // LmImputBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(313, 81);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblTitulo);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LmImputBox";
            this.ShowInTaskbar = false;
            this.Text = "FrmImputBox";
            this.SizeChanged += new System.EventHandler(this.LmImputBox_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.LmLabel lblTitulo;
        private Controls.LmLabel lblDesc;
        private Controls.LmButton btnConfirmar;
        private Controls.LmButton btnCancelar;
        internal Controls.LmTextBox txt;
    }
}