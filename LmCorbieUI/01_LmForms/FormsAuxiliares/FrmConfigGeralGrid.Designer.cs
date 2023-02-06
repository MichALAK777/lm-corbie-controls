
namespace LmCorbieUI
{
    partial class FrmConfigGeralGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigGeralGrid));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gpbColOculta = new LmCorbieUI.Controls.LmGroupBox();
            this.flpColOculta = new LmCorbieUI.Controls.LmPanelFlow();
            this.btnCancelar = new LmCorbieUI.Controls.LmButton();
            this.btnConfirmar = new LmCorbieUI.Controls.LmButton();
            this.gpbColVisivel = new LmCorbieUI.Controls.LmGroupBox();
            this.flpColVisivel = new LmCorbieUI.Controls.LmPanelFlow();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpbColOculta.SuspendLayout();
            this.gpbColVisivel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gpbColOculta, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnConfirmar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gpbColVisivel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(614, 182);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gpbColOculta
            // 
            this.gpbColOculta.Controls.Add(this.flpColOculta);
            this.gpbColOculta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbColOculta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.gpbColOculta.Location = new System.Drawing.Point(310, 3);
            this.gpbColOculta.Name = "gpbColOculta";
            this.gpbColOculta.Size = new System.Drawing.Size(301, 145);
            this.gpbColOculta.TabIndex = 3;
            this.gpbColOculta.TabStop = false;
            this.gpbColOculta.Text = "Colunas Ocultas";
            // 
            // flpColOculta
            // 
            this.flpColOculta.AutoSize = true;
            this.flpColOculta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(242)))));
            this.flpColOculta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpColOculta.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpColOculta.Location = new System.Drawing.Point(3, 20);
            this.flpColOculta.Name = "flpColOculta";
            this.flpColOculta.Size = new System.Drawing.Size(295, 122);
            this.flpColOculta.TabIndex = 1;
            this.flpColOculta.WrapContents = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancelar.BorderRadius = 12;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(310, 154);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(301, 25);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = " Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnConfirmar.BorderRadius = 12;
            this.btnConfirmar.BorderSize = 0;
            this.btnConfirmar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(3, 154);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(301, 25);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = " Salvar e Fechar";
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // gpbColVisivel
            // 
            this.gpbColVisivel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(242)))));
            this.gpbColVisivel.Controls.Add(this.flpColVisivel);
            this.gpbColVisivel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbColVisivel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
            this.gpbColVisivel.Location = new System.Drawing.Point(3, 3);
            this.gpbColVisivel.Name = "gpbColVisivel";
            this.gpbColVisivel.Size = new System.Drawing.Size(301, 145);
            this.gpbColVisivel.TabIndex = 2;
            this.gpbColVisivel.TabStop = false;
            this.gpbColVisivel.Text = "Colunas Visíveis";
            // 
            // flpColVisivel
            // 
            this.flpColVisivel.AllowDrop = true;
            this.flpColVisivel.AutoSize = true;
            this.flpColVisivel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(242)))));
            this.flpColVisivel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpColVisivel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpColVisivel.Location = new System.Drawing.Point(3, 20);
            this.flpColVisivel.Name = "flpColVisivel";
            this.flpColVisivel.Size = new System.Drawing.Size(295, 122);
            this.flpColVisivel.TabIndex = 0;
            this.flpColVisivel.WrapContents = false;
            this.flpColVisivel.DragDrop += new System.Windows.Forms.DragEventHandler(this.FlpColVisivel_DragDrop);
            this.flpColVisivel.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpColVisivel_DragEnter);
            // 
            // FrmConfigGeralGrid
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(618, 210);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfigGeralGrid";
            this.Padding = new System.Windows.Forms.Padding(2, 26, 2, 2);
            this.Text = "Configuração Geral Grid";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gpbColOculta.ResumeLayout(false);
            this.gpbColOculta.PerformLayout();
            this.gpbColVisivel.ResumeLayout(false);
            this.gpbColVisivel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.LmButton btnCancelar;
        private Controls.LmGroupBox gpbColOculta;
        private Controls.LmPanelFlow flpColOculta;
        private Controls.LmGroupBox gpbColVisivel;
        private Controls.LmPanelFlow flpColVisivel;
        private Controls.LmButton btnConfirmar;
    }
}