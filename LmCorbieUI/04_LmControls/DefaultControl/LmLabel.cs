using LmCorbieUI.Design;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LmCorbieUI.Controls
{
    [ToolboxBitmap(typeof(Label))]
    [DefaultEvent("Click")]
    [Designer(typeof(Design.LmLabelDesign))]
    public partial class LmLabel : Label
    {
        #region Construtor

        public LmLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);

            Margin = new Padding(3);
        }

        #endregion

        #region Campos

        private LmLabelSize lmLabelSize = LmLabelSize.Medium;
        [DefaultValue(LmLabelSize.Medium)]

        public LmLabelSize FontSize
        {
            get { return lmLabelSize; }
            set { lmLabelSize = value; Refresh(); }
        }

        private LmLabelWeight lmLabelWeight = LmLabelWeight.Regular;
        [DefaultValue(LmLabelWeight.Regular)]

        public LmLabelWeight FontWeight
        {
            get { return lmLabelWeight; }
            set { lmLabelWeight = value; Refresh(); }
        }

        private bool wrapToLine;
        [DefaultValue(false)]

        public bool WrapToLine
        {
            get { return wrapToLine; }
            set { wrapToLine = value; Refresh(); }
        }

        private bool isLink;
        [DefaultValue(false)]

        public bool IsLink
        {
            get { return isLink; }
            set
            {
                isLink = value;
                Cursor = isLink ? Cursors.Hand : Cursors.Default;
            }
        }

        private bool useCustomColor = false;
        [DefaultValue(false)]
        public bool UseCustomColor
        {
            get { return useCustomColor; }
            set { useCustomColor = value; }
        }

        #endregion

        #region Paint Methods

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                Color backColor = backColor = Color.Transparent;

                if (backColor.A == 255 && BackgroundImage == null)
                {
                    e.Graphics.Clear(backColor);
                    return;
                }

                base.OnPaintBackground(e);

                // OnCustomPaintBackground(new LmPaintEventArgs(backColor, Color.Empty, e.Graphics));
            }
            catch
            {
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    OnPaintBackground(e);
                }

                // OnCustomPaint(new LmPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
                OnPaintForeground(e);
            }
            catch
            {
                Invalidate();
            }
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            Color foreColor = ForeColor;

            if (!useCustomColor)
            {
                if (IsLink)
                {
                    foreColor = Color.FromArgb(70, 110, 255);
                }
                else
                {
                    if (!Enabled)
                    {
                        if (Parent != null)
                        {
                            foreColor = this.Parent.BackColor.GetForeColor(LmControlStatus.Disabled);
                        }
                        else
                        {
                            foreColor = LmCor.Bc_Form.GetForeColor(LmControlStatus.Disabled);
                        }
                    }
                    else
                    {
                        if (Parent != null)
                        {
                            foreColor = this.Parent.BackColor.GetForeColor(LmControlStatus.Normal);
                        }
                        else
                            foreColor = LmCor.Bc_Form.GetForeColor(LmControlStatus.Normal);
                    }
                }
            }

            TextRenderer.DrawText(e.Graphics, Text, LmFonts.Label(lmLabelSize, lmLabelWeight, IsLink), ClientRectangle, foreColor, LmFonts.GetTextFormatFlags(TextAlign, wrapToLine));
            // OnCustomPaintForeground(new LmPaintEventArgs(Color.Empty, foreColor, e.Graphics));
        }

        #endregion

        #region Overridden Methods

        public override Size GetPreferredSize(Size proposedSize)
        {
            Size preferredSize;
            base.GetPreferredSize(proposedSize);

            using (var g = CreateGraphics())
            {
                proposedSize = new Size(int.MaxValue, int.MaxValue);
                preferredSize = TextRenderer.MeasureText(g, Text, LmFonts.Label(lmLabelSize, lmLabelWeight), proposedSize, LmFonts.GetTextFormatFlags(TextAlign));
            }

            return preferredSize;
        }

        #endregion
    }
}
