
namespace LmCorbieUI
{
    partial class FrmEscolherSimNao
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNao = new LmCorbieUI.Controls.LmLabel();
            this.lblSim = new LmCorbieUI.Controls.LmLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Magenta;
            this.panel1.Controls.Add(this.lblNao);
            this.panel1.Controls.Add(this.lblSim);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 52);
            this.panel1.TabIndex = 0;
            // 
            // lblNao
            // 
            this.lblNao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblNao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNao.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
            this.lblNao.FontWeight = LmCorbieUI.Design.LmLabelWeight.Bold;
            this.lblNao.Location = new System.Drawing.Point(1, 28);
            this.lblNao.Margin = new System.Windows.Forms.Padding(3);
            this.lblNao.Name = "lblNao";
            this.lblNao.Size = new System.Drawing.Size(128, 23);
            this.lblNao.TabIndex = 1;
            this.lblNao.Text = "Não";
            this.lblNao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNao.Click += new System.EventHandler(this.LblNao_Click);
            this.lblNao.MouseEnter += new System.EventHandler(this.Lbl_MouseEnter);
            this.lblNao.MouseLeave += new System.EventHandler(this.Lbl_MouseLeave);
            // 
            // lblSim
            // 
            this.lblSim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblSim.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSim.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
            this.lblSim.FontWeight = LmCorbieUI.Design.LmLabelWeight.Bold;
            this.lblSim.Location = new System.Drawing.Point(1, 1);
            this.lblSim.Margin = new System.Windows.Forms.Padding(3);
            this.lblSim.Name = "lblSim";
            this.lblSim.Size = new System.Drawing.Size(128, 23);
            this.lblSim.TabIndex = 0;
            this.lblSim.Text = "Sim";
            this.lblSim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSim.Click += new System.EventHandler(this.LblSim_Click);
            this.lblSim.MouseEnter += new System.EventHandler(this.Lbl_MouseEnter);
            this.lblSim.MouseLeave += new System.EventHandler(this.Lbl_MouseLeave);
            // 
            // FrmEscolherSimNao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(130, 52);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEscolherSimNao";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Text = "FrmEscolherSimNao";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEscolherSimNao_FormClosed);
            this.Load += new System.EventHandler(this.FrmEscolherSimNao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEscolherSimNao_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controls.LmLabel lblNao;
        private Controls.LmLabel lblSim;
    }
}