using LmCorbieUI.Controls;
using LmCorbieUI.Design;
using LmCorbieUI.Metodos;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace LmCorbieUI.LmForms
{
    [ProvideToolboxControl()]
    [ToolboxBitmap(typeof(Form))]
    [DefaultEvent("Load")]
    [Designer(typeof(Design.LmChildFormDesign), typeof(IRootDesigner))]
    public partial class LmChildForm : Form, IDisposable
    {
        internal Control _lastFocusedControl = null;

        #region Constructor

        public LmChildForm()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.ResizeRedraw |
              ControlStyles.UserPaint, true);

            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScroll = true;
            this.Name = "LmChildForm";
            this.TransparencyKey = Color.Magenta;

            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(150, 150);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.Collect();
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Campos

        
        [DefaultValue(true)]
        [Browsable(true)]
        public bool CloseOnEscape { get; set; } = true;

        [Browsable(false)]
        public string MenuStripName { get; set; } = null;

        private new Padding Padding
        {
            get { return base.Padding; }
            set
            {
                base.Padding = value;
            }
        }

        protected override Padding DefaultPadding
        {
            get { return new Padding(3, 3, 3, 3); }
        }

        private Modo _modo = Modo.Padrao;
        [Browsable(false)]
        public Modo Modo
        {
            get { return _modo; }
            set
            {
                _modo = value;

                if (_modo == Modo.Novo)
                {
                    AtualizarPrimaria(tornarSomenteLeitura: false);
                    MensagemRodape = "Inserindo Novo Registro";
                }
                else if (_modo == Modo.Alteracao)
                {
                    AtualizarPrimaria(tornarSomenteLeitura: true);
                    MensagemRodape = "Alterando Registro";
                }
                else if (_modo == Modo.EmLock)
                {
                    AtualizarPrimaria(tornarSomenteLeitura: true);
                    MensagemRodape = "Em Lock";
                }
                else if (_modo == Modo.Bloqueado)
                {
                    AtualizarPrimaria(tornarSomenteLeitura: true);
                    MensagemRodape = "Bloqueado";
                }
                else
                {
                    MensagemRodape = "";
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Nome do controle usado como Chave primaria
        /// </summary>
        [Browsable(true)]
        public LmTextBox ChavePrimaria { get; set; } = null;

        private string mensagemRodape;

        [DefaultValue(Modo.Padrao)]
        [Browsable(false)]
        public string MensagemRodape
        {
            get { return mensagemRodape; }
            set
            {
                mensagemRodape = value;
                Invalidate();
            }
        }

        [DefaultValue(false)]
        [Browsable(false)]
        public bool IsClosing { get; set; } = false;

        [DefaultValue(false)]
        [Browsable(false)]
        private bool isSelected;

        [DefaultValue(false)]
        [Browsable(false)]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;

                if (IsClosing) return;

                if (IsSelected && this.Parent != null && this.Name != "LmChildForm")
                {
                    foreach (Control ctrl in this.Parent?.Controls)
                    {
                        if (ctrl is LmChildForm form && form.Name != this.Name && form.IsSelected)
                            form.IsSelected = false;
                    }

                    if (this.AguardandoAtualizacaoDados)
                    {
                        this.AtualizarDados.Invoke(this, new EventArgs());
                        this.AguardandoAtualizacaoDados = false;
                    }
                   if (_lastFocusedControl != null)
                        _lastFocusedControl.Focus();

                }
            }
        }

        [DefaultValue(false)]
        [Browsable(false)]
        public bool aguardandoAtualizacaoDados = false;

        public bool AguardandoAtualizacaoDados
        {
            get { return aguardandoAtualizacaoDados; }
            set
            {
                aguardandoAtualizacaoDados = value;

                if (this.AguardandoAtualizacaoDados)
                {
                    if (IsSelected)
                    {
                        this.AtualizarDados.Invoke(this, new EventArgs());
                        this.AguardandoAtualizacaoDados = false;
                    }
                }
                Refresh();
            }
        }

        #endregion

        #region Eventos

        public delegate void FormSelect(object sender, EventArgs e);
        public delegate void FormLoad(object sender, EventArgs e);

        public event FormSelect AtualizarDados;
        public event FormLoad Loaded;
        public event FormLoad Loading;

        #endregion

        #region Paint Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            BackColor = LmCor.Bc_Form;// LmPaint.BackColor.Form(this.Theme);
        }

        #endregion

        #region Metodos de Gestão

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;

            IsSelected = true;

            try
            {
                System.Threading.Thread t2 = new System.Threading.Thread(() => { this.OnLoaded(); }) { IsBackground = true };
                t2.Start();
            }
            catch (Exception)
            {
            }

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape && CloseOnEscape)
            {
                try
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            try
            {
                AguardandoAtualizacaoDados = false;
                IsClosing = true;
            }
            catch (Exception)
            {
            }
        }

        internal void OnLoading()
        {
            Loading?.Invoke(this, new EventArgs());
        }

        private void OnLoaded()
        {
            System.Threading.Thread.Sleep(300);

            try
            {
                System.Threading.Thread.Sleep(200);

                if (this.IsClosing) return;

                if (ChavePrimaria != null)
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        ChavePrimaria.Focus();
                        ChavePrimaria.Refresh();
                    }));
                }

                Loaded?.Invoke(this, new EventArgs());

                //Invoke(new MethodInvoker(delegate ()
                //{
                //    _lastFocusControl = this.ActiveControl;
                //}));
            }
            catch (InvalidOperationException ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                MsgBox.Show("Evento Load deve manipular Objetos com 'Invoke', informar Desenvolvedores",
                    "Erro ao Carregar Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Metodos Públicos

        public bool PodeExcluir()
        {
            bool podeExcluir = this.Modo == Modo.Novo ? false :
             MsgBox.Show("Deseja Realmente Excluir Este Registro?", "Excluir",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;

            if (podeExcluir)
                this.Modo = Modo.Exclusao;

            return podeExcluir;
        }

        public void AtualizarPrimaria(bool tornarSomenteLeitura, string texto = "")
        {
            if (ChavePrimaria != null)
            {
                ChavePrimaria.ReadOnly = tornarSomenteLeitura;

                if (!string.IsNullOrEmpty(texto))
                    ChavePrimaria.Text = texto;

                ChavePrimaria.Refresh();
            }
            else
                Controles.UpdatePrimaryKeyControl(this, tornarSomenteLeitura);
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LmChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "LmChildForm";
            this.ResumeLayout(false);

        }
    }
}
