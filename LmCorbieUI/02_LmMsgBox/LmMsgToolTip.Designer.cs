
namespace LmCorbieUI
{
    partial class LmMsgToolTip
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(16, 7);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(48, 0, 48, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(96, 15);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título Aqui";
            this.lblTitulo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblMsg_MouseClick);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F);
            this.lblMsg.Location = new System.Drawing.Point(22, 22);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(48, 0, 48, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(77, 13);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Seu Texto Aqui";
            this.lblMsg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LblMsg_MouseClick);
            // 
            // LmMsgToolTip
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(128, 46);
            this.ControlBox = false;
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(48, 22, 48, 22);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LmMsgToolTip";
            this.Padding = new System.Windows.Forms.Padding(16, 7, 16, 7);
            this.ShowInTaskbar = false;
            this.Text = "LmMsgToolTip";
            this.Load += new System.EventHandler(this.LmMsgToolTip_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Label lblMsg;
    }
}