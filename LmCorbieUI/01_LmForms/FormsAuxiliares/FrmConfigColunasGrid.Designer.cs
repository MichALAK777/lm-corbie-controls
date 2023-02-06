
namespace LmCorbieUI
{
    partial class FrmConfigColunasGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigColunasGrid));
            this.clbColunas = new System.Windows.Forms.CheckedListBox();
            this.lmPanel1 = new LmCorbieUI.Controls.LmPanel();
            this.btnConfirmar = new LmCorbieUI.Controls.LmButton();
            this.btnCancelar = new LmCorbieUI.Controls.LmButton();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsMarcar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDesmarcar = new System.Windows.Forms.ToolStripMenuItem();
            this.lmPanel1.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbColunas
            // 
            this.clbColunas.BackColor = System.Drawing.Color.Linen;
            this.clbColunas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbColunas.CheckOnClick = true;
            this.clbColunas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbColunas.FormattingEnabled = true;
            this.clbColunas.Location = new System.Drawing.Point(2, 26);
            this.clbColunas.Name = "clbColunas";
            this.clbColunas.Size = new System.Drawing.Size(401, 74);
            this.clbColunas.TabIndex = 1;
            // 
            // lmPanel1
            // 
            this.lmPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(242)))));
            this.lmPanel1.Controls.Add(this.btnConfirmar);
            this.lmPanel1.Controls.Add(this.btnCancelar);
            this.lmPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lmPanel1.IsPanelMenu = false;
            this.lmPanel1.Location = new System.Drawing.Point(2, 100);
            this.lmPanel1.Name = "lmPanel1";
            this.lmPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.lmPanel1.Size = new System.Drawing.Size(401, 31);
            this.lmPanel1.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnConfirmar.BorderRadius = 12;
            this.btnConfirmar.BorderSize = 0;
            this.btnConfirmar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(198, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 25);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = " Confirmar";
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancelar.BorderRadius = 12;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(298, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 25);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = " Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsMarcar,
            this.cmsDesmarcar});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(192, 52);
            // 
            // cmsMarcar
            // 
            this.cmsMarcar.Image = ((System.Drawing.Image)(resources.GetObject("cmsMarcar.Image")));
            this.cmsMarcar.Name = "cmsMarcar";
            this.cmsMarcar.Size = new System.Drawing.Size(191, 24);
            this.cmsMarcar.Text = "Selecionar Todos";
            this.cmsMarcar.Click += new System.EventHandler(this.CmsMarcar_Click);
            // 
            // cmsDesmarcar
            // 
            this.cmsDesmarcar.Image = ((System.Drawing.Image)(resources.GetObject("cmsDesmarcar.Image")));
            this.cmsDesmarcar.Name = "cmsDesmarcar";
            this.cmsDesmarcar.Size = new System.Drawing.Size(191, 24);
            this.cmsDesmarcar.Text = "Limpar Seleção";
            this.cmsDesmarcar.Click += new System.EventHandler(this.CmsDesmarcar_Click);
            // 
            // FrmConfigColunasGrid
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(405, 133);
            this.Controls.Add(this.clbColunas);
            this.Controls.Add(this.lmPanel1);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmConfigColunasGrid";
            this.Padding = new System.Windows.Forms.Padding(2, 26, 2, 2);
            this.Text = "Selecionar Colunas para Exibir";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmConfigColunasGrid_FormClosed);
            this.Load += new System.EventHandler(this.FrmConfigColunasGrid_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConfigColunasGrid_KeyDown);
            this.lmPanel1.ResumeLayout(false);
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.CheckedListBox clbColunas;
        private Controls.LmPanel lmPanel1;
        private Controls.LmButton btnConfirmar;
        private Controls.LmButton btnCancelar;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmsMarcar;
        private System.Windows.Forms.ToolStripMenuItem cmsDesmarcar;
    }
}