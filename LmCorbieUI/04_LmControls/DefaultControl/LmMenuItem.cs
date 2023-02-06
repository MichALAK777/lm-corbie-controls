using LmCorbieUI.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System;
using LmCorbieUI.Interfaces;

namespace LmCorbieUI.Controls
{
    [ProvideToolboxControl()]
    [ToolboxBitmap(typeof(MenuStrip))]
    [DefaultEvent("Click")]
    [Designer(typeof(Design.LmMenuItemDesign))]
    public class LmMenuItem : Button, ILmControl
    {
        private bool isHovered = false;
        private bool isFocused = false;

        private Font _default = new Font("Segoe UI", 8F, FontStyle.Bold);

        public LmMenuItem()
        {
            Font = _default;
            this.Size = new Size(110, 30);
            TabStop = false;
            AplicarStilo();
        }

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

        #endregion

        #region Paint Methods

        public void AplicarStilo()
        {
            Font = _default;

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = LmCor.Bc_Header;
            this.FlatAppearance.MouseDownBackColor = LmCor.Bc_Btn_Normal;
            this.FlatAppearance.MouseOverBackColor = LmCor.Bc_Btn_Normal;
            this.ForeColor = this.BackColor.GetForeColor(LmControlStatus.Normal);

            this.Image = this.Image.ApplyColor(this.ForeColor);

            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //if (this.ContextMenuStrip == null)
            //    return;

            //var arrowSize = new Size(5, 12);
            //var rect = new Rectangle(this.Width - 15, (this.Height - arrowSize.Height) / 2, arrowSize.Width, arrowSize.Height);
            //// var rect = new Rectangle(this.Width - 15, y, 7, 14);
            //using (GraphicsPath path = new GraphicsPath())
            //using (Pen pen = new Pen(this.ForeColor, 2))
            //{
            //    //Drawing
            //    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //    path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + rect.Height / 2);
            //    path.AddLine(rect.Right, rect.Top + rect.Height / 2, rect.Left, rect.Top + rect.Height);
            //    e.Graphics.DrawPath(pen, path);
            //}
        }

        #endregion

        #region Override Metodos

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;

            this.BackColor = LmCor.Bc_Btn_Normal;// LmPaint.BackColor.Button.Normal(Theme);

            this.ForeColor = this.BackColor.GetForeColor(LmControlStatus.Selected);

            this.Image = this.Image.ApplyColor(this.ForeColor);

            Invalidate();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!isFocused)
                isHovered = false;

            this.BackColor = LmCor.Bc_Header;// LmPaint.BackColor.MenuStrip.MenuPrincipalNormal(Theme);

            this.ForeColor = this.BackColor.GetForeColor(LmControlStatus.Normal);

            this.Image = this.Image.ApplyColor(this.ForeColor);

            Invalidate();

            Font = _default;
            GC.Collect();
            base.OnMouseLeave(e);
        }

        //protected override void OnGotFocus(EventArgs e)
        //{
        //    isFocused = true;
        //    isHovered = true;
        //    this.SetLastFocusedControl();

        //    this.BackColor = LmPaint.BackColor.MenuStrip.MenuPrincipalNormal(Theme);
        //    this.ForeColor = this.IconColor = this.BackColor.GetForeColor(LmControlStatus.Selected);

        //    Invalidate();

        //    //ColorIcon();

        //    GC.Collect();
        //    base.OnGotFocus(e);
        //}

        //protected override void OnLostFocus(EventArgs e)
        //{
        //    isFocused = false;
        //    isHovered = false;

        //    this.BackColor = LmPaint.BackColor.MenuStrip.MenuPrincipalNormal(Theme);
        //    this.ForeColor = this.IconColor = this.BackColor.GetForeColor(LmControlStatus.Normal);

        //    Invalidate();

        //    //ColorIcon();

        //    GC.Collect();
        //    base.OnLostFocus(e);
        //}

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);

            this.Image = this.Image.ApplyColor(this.ForeColor);
        }

        #endregion

        #region Metodos

        #endregion

        #region Events

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        #endregion

    }
}
