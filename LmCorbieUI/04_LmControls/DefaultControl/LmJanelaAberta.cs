using LmCorbieUI.Design;
using LmCorbieUI.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LmCorbieUI.Controls
{
    [Designer(typeof(Design.LmJanelaAbertaDesign))]
    public partial class LmJanelaAberta : UserControl, ILmControl
    {
        //private bool isRedCloseIcon = false;

        #region Construtor

        public LmJanelaAberta()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            this.DoubleBuffered = true;
        }

        #endregion

        #region Interface

        [Category(LmDefault.PropertyCategory.LmUI)]
        public event EventHandler<LmPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(LmPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category(LmDefault.PropertyCategory.LmUI)]
        public event EventHandler<LmPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(LmPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category(LmDefault.PropertyCategory.LmUI)]
        public event EventHandler<LmPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(LmPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

        #endregion

        #region Fields

        [Browsable(false)]
        public bool IsSelected { get; set; } = true;
        [Browsable(false)]
        public bool IsHovered { get; set; } = false;
        [Browsable(false)]

        #endregion

        #region Paint Method

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Color backColor = BackColor;
                Color foreColor = ForeColor;

                if (IsSelected)
                    backColor = LmCor.Bc_Form;
                else if (IsHovered)
                {
                    backColor = LmCor.Bc_Header;

                    if (backColor.IsDarkColor())
                        backColor = backColor.Escurecer();
                    else
                        backColor = backColor.Clarear();
                }
                else
                    backColor = LmCor.Bc_Header;

                foreColor = backColor.GetForeColor(LmControlStatus.Normal);

                lblNomeJanela.ForeColor = foreColor;
             
                lblNomeJanela.BackColor = backColor;

                if (backColor.A == 255 && BackgroundImage == null)
                {
                    e.Graphics.Clear(backColor);
                    return;
                }

                base.OnPaint(e);
            }
            catch
            {
                Invalidate();
            }
        }

        #endregion

        #region Eventos

        public delegate void ClickControl(object sender, EventArgs e);

        public event ClickControl ClickJanela;
        public event ClickControl FecharContainerForms;
        public event ClickControl FecharTudoPeloMenu;
        public event ClickControl FecharTudoExetoEsta;
        public event ClickControl FecharTudoDireita;
        public event ClickControl FecharTudoEsquerda;


        #endregion

        public void SetText(string text)
        {
            this.lblNomeJanela.Text = text;

            this.lblNomeJanela.Refresh();
            this.Width = this.lblNomeJanela.Width + this.lnkFechar.Width - 1;
        }

        private void LmJanelaAberta_MouseEnter(object sender, EventArgs e)
        {
            if (!IsHovered)
            {
                IsHovered = true;
                Invalidate();
            }
        }

        private void LmJanelaAberta_MouseLeave(object sender, EventArgs e)
        {
            if (IsHovered)
            {
                IsHovered = false;
                Invalidate();
            }
        }

        private void LblNomeJanela_Click(object sender, EventArgs e)
        {
            ClickJanela?.Invoke(this, new EventArgs());
        }

        private void LnkFechar_Click(object sender, EventArgs e)
        {
            FecharContainerForms?.Invoke(this, new EventArgs());
        }

        private void TsFecharTudoExcetoEsta_Click(object sender, EventArgs e)
        {
            FecharTudoExetoEsta?.Invoke(this, new EventArgs());
        }

        private void TsFecharEstaAba_Click(object sender, EventArgs e)
        {
            FecharContainerForms?.Invoke(this, new EventArgs());
        }

        private void TsFecharTudoEsquerda_Click(object sender, EventArgs e)
        {
            FecharTudoEsquerda?.Invoke(this, new EventArgs());
        }

        private void TsFecharTudoDireita_Click(object sender, EventArgs e)
        {
            FecharTudoDireita?.Invoke(this, new EventArgs());
        }

        private void TsFecharTudo_Click(object sender, EventArgs e)
        {
            FecharTudoPeloMenu?.Invoke(this, new EventArgs());
        }

        private void LnkFechar_MouseEnter(object sender, EventArgs e)
        {
            lnkFechar.Image = lnkFechar.Image.ApplyColor(Color.Red);
            //isRedCloseIcon = true;
        }

        private void LnkFechar_MouseLeave(object sender, EventArgs e)
        {
            lnkFechar.Image = lnkFechar.Image.ApplyColor(lblNomeJanela.ForeColor);
            //isRedCloseIcon = false;
        }

    }
}
