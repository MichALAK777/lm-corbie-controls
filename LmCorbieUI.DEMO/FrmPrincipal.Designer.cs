namespace LmCorbieUI.DEMO
{
    partial class FrmPrincipal
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.pnlMain = new LmCorbieUI.Controls.LmPanel();
            this.msMenuJanelaAberta = new LmCorbieUI.Controls.LmMenuJanelaAberta();
            this.pnlMenu = new LmCorbieUI.Controls.LmPanel();
            this.menuProcessoCad = new LmCorbieUI.Controls.LmMenuItem();
            this.menuSequenciaCad = new LmCorbieUI.Controls.LmMenuItem();
            this.menuMateriaPrimaCad = new LmCorbieUI.Controls.LmMenuItem();
            this.menuMaterialCad = new LmCorbieUI.Controls.LmMenuItem();
            this.menuUsuarioCad = new LmCorbieUI.Controls.LmMenuItem();
            this.menuDadosEmpresa = new LmCorbieUI.Controls.LmMenuItem();
            this.menuLogout = new LmCorbieUI.Controls.LmMenuItem();
            this.menuSistema = new LmCorbieUI.Controls.LmMenuItem();
            this.pnlLogo = new LmCorbieUI.Controls.LmPanel();
            this.menuSandwich = new LmCorbieUI.Controls.LmMenuItem();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.stpRodape = new LmCorbieUI.Controls.LmStatusStrip();
            this.tslVersao = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSecao = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslConsumoMemoria = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslFocusedCtrl = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslFormAberto = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslModo = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.stpRodape.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(242)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.IsPanelMenu = false;
            this.pnlMain.Location = new System.Drawing.Point(195, 51);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(510, 325);
            this.pnlMain.TabIndex = 7;
            // 
            // msMenuJanelaAberta
            // 
            this.msMenuJanelaAberta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.msMenuJanelaAberta.Dock = System.Windows.Forms.DockStyle.Top;
            this.msMenuJanelaAberta.Location = new System.Drawing.Point(195, 30);
            this.msMenuJanelaAberta.Name = "msMenuJanelaAberta";
            this.msMenuJanelaAberta.Size = new System.Drawing.Size(510, 21);
            this.msMenuJanelaAberta.TabIndex = 5;
            this.msMenuJanelaAberta.UseSelectable = true;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.pnlMenu.Controls.Add(this.menuProcessoCad);
            this.pnlMenu.Controls.Add(this.menuSequenciaCad);
            this.pnlMenu.Controls.Add(this.menuMateriaPrimaCad);
            this.pnlMenu.Controls.Add(this.menuMaterialCad);
            this.pnlMenu.Controls.Add(this.menuUsuarioCad);
            this.pnlMenu.Controls.Add(this.menuDadosEmpresa);
            this.pnlMenu.Controls.Add(this.menuLogout);
            this.pnlMenu.Controls.Add(this.menuSistema);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.IsPanelMenu = true;
            this.pnlMenu.Location = new System.Drawing.Point(2, 30);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(193, 346);
            this.pnlMenu.TabIndex = 4;
            // 
            // menuProcessoCad
            // 
            this.menuProcessoCad.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuProcessoCad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuProcessoCad.Image = ((System.Drawing.Image)(resources.GetObject("menuProcessoCad.Image")));
            this.menuProcessoCad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuProcessoCad.Location = new System.Drawing.Point(0, 232);
            this.menuProcessoCad.Name = "menuProcessoCad";
            this.menuProcessoCad.Size = new System.Drawing.Size(193, 30);
            this.menuProcessoCad.TabIndex = 11;
            this.menuProcessoCad.TabStop = false;
            this.menuProcessoCad.Text = "   Cadastro de Processo";
            this.menuProcessoCad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuProcessoCad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuProcessoCad.UseSelectable = true;
            this.menuProcessoCad.UseVisualStyleBackColor = false;
            // 
            // menuSequenciaCad
            // 
            this.menuSequenciaCad.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuSequenciaCad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuSequenciaCad.Image = ((System.Drawing.Image)(resources.GetObject("menuSequenciaCad.Image")));
            this.menuSequenciaCad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuSequenciaCad.Location = new System.Drawing.Point(0, 202);
            this.menuSequenciaCad.Name = "menuSequenciaCad";
            this.menuSequenciaCad.Size = new System.Drawing.Size(193, 30);
            this.menuSequenciaCad.TabIndex = 12;
            this.menuSequenciaCad.TabStop = false;
            this.menuSequenciaCad.Text = "   Cadastro de Sequência";
            this.menuSequenciaCad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuSequenciaCad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuSequenciaCad.UseSelectable = true;
            this.menuSequenciaCad.UseVisualStyleBackColor = false;
            // 
            // menuMateriaPrimaCad
            // 
            this.menuMateriaPrimaCad.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuMateriaPrimaCad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuMateriaPrimaCad.Image = ((System.Drawing.Image)(resources.GetObject("menuMateriaPrimaCad.Image")));
            this.menuMateriaPrimaCad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuMateriaPrimaCad.Location = new System.Drawing.Point(0, 172);
            this.menuMateriaPrimaCad.Name = "menuMateriaPrimaCad";
            this.menuMateriaPrimaCad.Size = new System.Drawing.Size(193, 30);
            this.menuMateriaPrimaCad.TabIndex = 9;
            this.menuMateriaPrimaCad.TabStop = false;
            this.menuMateriaPrimaCad.Text = "   Cadastro de Matéria Prima";
            this.menuMateriaPrimaCad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuMateriaPrimaCad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuMateriaPrimaCad.UseSelectable = true;
            this.menuMateriaPrimaCad.UseVisualStyleBackColor = false;
            // 
            // menuMaterialCad
            // 
            this.menuMaterialCad.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuMaterialCad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuMaterialCad.Image = ((System.Drawing.Image)(resources.GetObject("menuMaterialCad.Image")));
            this.menuMaterialCad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuMaterialCad.Location = new System.Drawing.Point(0, 142);
            this.menuMaterialCad.Name = "menuMaterialCad";
            this.menuMaterialCad.Size = new System.Drawing.Size(193, 30);
            this.menuMaterialCad.TabIndex = 8;
            this.menuMaterialCad.TabStop = false;
            this.menuMaterialCad.Text = "   Cadastro de Material";
            this.menuMaterialCad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuMaterialCad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuMaterialCad.UseSelectable = true;
            this.menuMaterialCad.UseVisualStyleBackColor = false;
            // 
            // menuUsuarioCad
            // 
            this.menuUsuarioCad.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuUsuarioCad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuUsuarioCad.Image = ((System.Drawing.Image)(resources.GetObject("menuUsuarioCad.Image")));
            this.menuUsuarioCad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuUsuarioCad.Location = new System.Drawing.Point(0, 112);
            this.menuUsuarioCad.Name = "menuUsuarioCad";
            this.menuUsuarioCad.Size = new System.Drawing.Size(193, 30);
            this.menuUsuarioCad.TabIndex = 7;
            this.menuUsuarioCad.TabStop = false;
            this.menuUsuarioCad.Text = "   Cadastro de Usuário";
            this.menuUsuarioCad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuUsuarioCad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuUsuarioCad.UseSelectable = true;
            this.menuUsuarioCad.UseVisualStyleBackColor = false;
            this.menuUsuarioCad.Click += new System.EventHandler(this.menuUsuarioCad_Click);
            // 
            // menuDadosEmpresa
            // 
            this.menuDadosEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuDadosEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuDadosEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("menuDadosEmpresa.Image")));
            this.menuDadosEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuDadosEmpresa.Location = new System.Drawing.Point(0, 82);
            this.menuDadosEmpresa.Name = "menuDadosEmpresa";
            this.menuDadosEmpresa.Size = new System.Drawing.Size(193, 30);
            this.menuDadosEmpresa.TabIndex = 3;
            this.menuDadosEmpresa.TabStop = false;
            this.menuDadosEmpresa.Text = "   Dados da Empresa";
            this.menuDadosEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuDadosEmpresa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuDadosEmpresa.UseSelectable = true;
            this.menuDadosEmpresa.UseVisualStyleBackColor = false;
            this.menuDadosEmpresa.Click += new System.EventHandler(this.menuDadosEmpresa_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuLogout.Location = new System.Drawing.Point(0, 316);
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(193, 30);
            this.menuLogout.TabIndex = 2;
            this.menuLogout.TabStop = false;
            this.menuLogout.Text = "   Sair";
            this.menuLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuLogout.UseSelectable = true;
            this.menuLogout.UseVisualStyleBackColor = false;
            // 
            // menuSistema
            // 
            this.menuSistema.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuSistema.Image = ((System.Drawing.Image)(resources.GetObject("menuSistema.Image")));
            this.menuSistema.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuSistema.Location = new System.Drawing.Point(0, 52);
            this.menuSistema.Name = "menuSistema";
            this.menuSistema.Size = new System.Drawing.Size(193, 30);
            this.menuSistema.TabIndex = 1;
            this.menuSistema.TabStop = false;
            this.menuSistema.Text = "   Sistema";
            this.menuSistema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuSistema.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuSistema.UseSelectable = true;
            this.menuSistema.UseVisualStyleBackColor = false;
            this.menuSistema.Visible = false;
            this.menuSistema.Click += new System.EventHandler(this.menuSistema_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.pnlLogo.Controls.Add(this.menuSandwich);
            this.pnlLogo.Controls.Add(this.ptbLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.IsPanelMenu = true;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(193, 52);
            this.pnlLogo.TabIndex = 0;
            // 
            // menuSandwich
            // 
            this.menuSandwich.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuSandwich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuSandwich.Image = ((System.Drawing.Image)(resources.GetObject("menuSandwich.Image")));
            this.menuSandwich.Location = new System.Drawing.Point(72, 26);
            this.menuSandwich.Name = "menuSandwich";
            this.menuSandwich.Size = new System.Drawing.Size(121, 26);
            this.menuSandwich.TabIndex = 1;
            this.menuSandwich.TabStop = false;
            this.menuSandwich.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuSandwich.UseSelectable = true;
            this.menuSandwich.UseVisualStyleBackColor = false;
            // 
            // ptbLogo
            // 
            this.ptbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.ptbLogo.Image = ((System.Drawing.Image)(resources.GetObject("ptbLogo.Image")));
            this.ptbLogo.Location = new System.Drawing.Point(0, 0);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(72, 52);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbLogo.TabIndex = 0;
            this.ptbLogo.TabStop = false;
            // 
            // stpRodape
            // 
            this.stpRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.stpRodape.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.stpRodape.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stpRodape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslVersao,
            this.tslSecao,
            this.tslUsuario,
            this.tslConsumoMemoria,
            this.tslFocusedCtrl,
            this.tslFormAberto,
            this.tslModo});
            this.stpRodape.Location = new System.Drawing.Point(2, 376);
            this.stpRodape.Name = "stpRodape";
            this.stpRodape.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.stpRodape.Size = new System.Drawing.Size(703, 22);
            this.stpRodape.SizingGrip = false;
            this.stpRodape.TabIndex = 6;
            this.stpRodape.Text = "lmStatusStrip1";
            // 
            // tslVersao
            // 
            this.tslVersao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tslVersao.Name = "tslVersao";
            this.tslVersao.Size = new System.Drawing.Size(44, 17);
            this.tslVersao.Text = "Versão:";
            // 
            // tslSecao
            // 
            this.tslSecao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tslSecao.Name = "tslSecao";
            this.tslSecao.Size = new System.Drawing.Size(40, 17);
            this.tslSecao.Text = "Seção:";
            // 
            // tslUsuario
            // 
            this.tslUsuario.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tslUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tslUsuario.Name = "tslUsuario";
            this.tslUsuario.Size = new System.Drawing.Size(83, 17);
            this.tslUsuario.Text = "Usuário: Perfil";
            // 
            // tslConsumoMemoria
            // 
            this.tslConsumoMemoria.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tslConsumoMemoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tslConsumoMemoria.Name = "tslConsumoMemoria";
            this.tslConsumoMemoria.Size = new System.Drawing.Size(56, 17);
            this.tslConsumoMemoria.Text = "Memória";
            // 
            // tslFocusedCtrl
            // 
            this.tslFocusedCtrl.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tslFocusedCtrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tslFocusedCtrl.Name = "tslFocusedCtrl";
            this.tslFocusedCtrl.Size = new System.Drawing.Size(27, 17);
            this.tslFocusedCtrl.Text = "ctrl";
            // 
            // tslFormAberto
            // 
            this.tslFormAberto.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tslFormAberto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tslFormAberto.Name = "tslFormAberto";
            this.tslFormAberto.Size = new System.Drawing.Size(75, 17);
            this.tslFormAberto.Text = "Form Aberto";
            // 
            // tslModo
            // 
            this.tslModo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.tslModo.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.tslModo.Name = "tslModo";
            this.tslModo.Size = new System.Drawing.Size(102, 17);
            this.tslModo.Tag = "MsgRodape";
            this.tslModo.Text = "Inserindo Registro";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 400);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.msMenuJanelaAberta);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.stpRodape);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmPrincipal";
            this.Padding = new System.Windows.Forms.Padding(2, 30, 2, 2);
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.stpRodape.ResumeLayout(false);
            this.stpRodape.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Controls.LmPanel pnlMain;
        private Controls.LmMenuJanelaAberta msMenuJanelaAberta;
        private Controls.LmPanel pnlMenu;
        private Controls.LmMenuItem menuProcessoCad;
        private Controls.LmMenuItem menuSequenciaCad;
        private Controls.LmMenuItem menuMateriaPrimaCad;
        private Controls.LmMenuItem menuMaterialCad;
        private Controls.LmMenuItem menuUsuarioCad;
        private Controls.LmMenuItem menuDadosEmpresa;
        private Controls.LmMenuItem menuLogout;
        private Controls.LmMenuItem menuSistema;
        private Controls.LmPanel pnlLogo;
        private Controls.LmMenuItem menuSandwich;
        private System.Windows.Forms.PictureBox ptbLogo;
        private Controls.LmStatusStrip stpRodape;
        private System.Windows.Forms.ToolStripStatusLabel tslVersao;
        private System.Windows.Forms.ToolStripStatusLabel tslSecao;
        private System.Windows.Forms.ToolStripStatusLabel tslUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tslConsumoMemoria;
        private System.Windows.Forms.ToolStripStatusLabel tslFocusedCtrl;
        private System.Windows.Forms.ToolStripStatusLabel tslFormAberto;
        private System.Windows.Forms.ToolStripStatusLabel tslModo;
    }
}

