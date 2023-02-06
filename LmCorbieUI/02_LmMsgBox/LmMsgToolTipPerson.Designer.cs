
namespace LmCorbieUI
{
    partial class LmMsgToolTipPerson
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.lblMsg.Location = new System.Drawing.Point(16, 7);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(48, 0, 48, 0);
            this.lblMsg.MaximumSize = new System.Drawing.Size(16464, 4482);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(91, 13);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Seu Texto Aqui";
            // 
            // LmMsgToolTipPerson
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(137, 37);
            this.ControlBox = false;
            this.Controls.Add(this.lblMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(48, 22, 48, 22);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(13712, 3198);
            this.MinimizeBox = false;
            this.Name = "LmMsgToolTipPerson";
            this.ShowInTaskbar = false;
            this.Text = "LmMsgToolTipPerson";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LmMsgToolTipPerson_FormClosing);
            this.Load += new System.EventHandler(this.LmMsgToolTipPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblMsg;
    }
}