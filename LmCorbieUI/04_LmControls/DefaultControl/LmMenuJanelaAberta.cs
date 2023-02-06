using LmCorbieUI.Design;
using LmCorbieUI.Interfaces;
using LmCorbieUI.LmForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LmCorbieUI.Controls
{
    [ProvideToolboxControl()]
    [ToolboxBitmap(typeof(MenuStrip))]
    [DefaultEvent("Click")]
    [Designer(typeof(Design.LmMenuJanelaAbertaDesign))]
    public partial class LmMenuJanelaAberta : UserControl, ILmControl
    {
        #region Construtor

        public LmMenuJanelaAberta()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
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

        #region Paint Method

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.BackColor = LmCor.Bc_Header;
        }

        #endregion

        #region Metodos Publicos

        public void Removejanela(string name)
        {
            this.flpMain.Controls.RemoveByKey(name);
        }

        public void FocarContainer(string name)
        {
            foreach (var ctrl in flpMain.Controls)
            {
                if (ctrl is LmJanelaAberta)
                {
                    var container = this.Parent.Controls["pnlMain"].Controls[((LmJanelaAberta)ctrl).Name] as LmContainerForm;

                    Invoke(new MethodInvoker(delegate ()
                    {
                        if (((LmJanelaAberta)ctrl).Name == name)
                        {
                            container.BringToFront();
                            ((LmJanelaAberta)ctrl).IsSelected = true;

                            var frm = container.Controls[0] as LmChildForm;

                            frm._lastFocusedControl?.Focus();
                        }
                        else
                        {
                            ((LmJanelaAberta)ctrl).IsSelected = false;
                            container.SendToBack();

                        }

                        ((LmJanelaAberta)ctrl).Refresh();
                        ((LmJanelaAberta)ctrl).lnkFechar.Image = ((LmJanelaAberta)ctrl).lnkFechar.Image.ApplyColor(((LmJanelaAberta)ctrl).lblNomeJanela.ForeColor);
                    }));
                }
            }
        }

        #endregion

        private void FlpMain_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control.Location.Y > 60)
                this.Height = 4 * 22;
            else if (e.Control.Location.Y > 40)
                this.Height = 3 * 22;
            else if (e.Control.Location.Y > 20)
                this.Height = 2 * 22;
            else
                this.Height = 22;

            ((LmJanelaAberta)e.Control).ClickJanela += LmMenuJanelaAberta_ClickJanela;
        }

        private void LmMenuJanelaAberta_ClickJanela(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(() => { this.FocarContainer(((Control)sender).Name); }) { IsBackground = true };
            t.Start();
        }

        private void FlpMain_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (this.Height == 22) return;

            var maxY = 0;

            foreach (Control ctrl in flpMain.Controls)
                if (ctrl.Location.Y > maxY)
                    maxY = ctrl.Location.Y;

            if (maxY > 60)
                this.Height = 4 * 22;
            else if (maxY > 40)
                this.Height = 3 * 22;
            else if (maxY > 20)
                this.Height = 2 * 22;
            else
                this.Height = 22;
        }
    }
}
