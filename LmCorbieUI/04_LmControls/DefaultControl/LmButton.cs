using LmCorbieUI;
using LmCorbieUI.Design;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace LmCorbieUI.Controls
{
    [ProvideToolboxControl()]
    [ToolboxBitmap(typeof(Button))]
    [DefaultEvent("Click")]
    [Designer(typeof(LmCorbieUI.Controls.Design.LmButtonDesign))]
    public class LmButton : Button
    {
        private bool isHovered = false;
        private bool isPressed = false;
        private bool isFocused = false;

        private Font _default = new Font("Segoe UI", 8F, FontStyle.Bold);

        private static Color Bc_Info_Normal => Color.FromArgb(25, 118, 210);
        private static Color Bc_Info_Selected => Color.FromArgb(13, 71, 161);
        private static Color Bc_Info_Press => Color.FromArgb(144, 202, 249);
        private static Color Bc_Info_Disabled => Color.FromArgb(100, 181, 246);
        
        private static Color Bc_Error_Normal => Color.FromArgb(211, 47, 47);
        private static Color Bc_Error_Selected => Color.FromArgb(183, 28, 28);
        private static Color Bc_Error_Press => Color.FromArgb(239, 154, 154);
        private static Color Bc_Error_Disabled => Color.FromArgb(229, 115, 115);
        
        private static Color Bc_Question_Normal => Color.FromArgb(56, 142, 60);
        private static Color Bc_Question_Selected => Color.FromArgb(27, 94, 32);
        private static Color Bc_Question_Press => Color.FromArgb(165, 214, 167);
        private static Color Bc_Question_Disabled => Color.FromArgb(129, 199, 132);
        
        private static Color Bc_Warning_Normal => Color.FromArgb(175, 180, 43);
        private static Color Bc_Warning_Selected => Color.FromArgb(130, 119, 23);
        private static Color Bc_Warning_Press => Color.FromArgb(230, 238, 156);
        private static Color Bc_Warning_Disabled => Color.FromArgb(205, 220, 57);
        
        private static Color Bc_Gray_Normal => Color.FromArgb(66, 66, 66);
        private static Color Bc_Gray_Selected => Color.FromArgb(33, 33, 33);
        private static Color Bc_Gray_Press => Color.FromArgb(158, 158, 158);
        private static Color Bc_Gray_Disabled => Color.FromArgb(117, 117, 117);

        public LmButton()
        {
            Font = _default;
            this.Size = new Size(110, 30);

            AplicarStilo();
        }

        #region Fields

        private int borderSize = 0;

        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        private int borderRadius = 15;

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;

                if (borderRadius > Height / 2)
                    borderRadius = Height / 2;

                this.Invalidate();
            }
        }

        private Color borderColor = Color.PaleVioletRed;

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        private ButtonStyle style = ButtonStyle.Default;
        [Browsable(true)]
        internal ButtonStyle Style
        {
            get { return style; }
            set
            {
                style = value;
                this.Invalidate();
            }
        }

        #endregion

        #region Paint Methods

        public void AplicarStilo()
        {
            Font = _default;

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            switch (Style)
            {
                case ButtonStyle.Default:
                    {
                        this.BackColor = Enabled ? LmCor.Bc_Btn_Normal : LmCor.Bc_Btn_Disabled;
                        this.FlatAppearance.BorderColor = LmCor.Bc_Btn_Normal;
                        this.FlatAppearance.MouseDownBackColor = LmCor.Bc_Btn_Press;
                        this.FlatAppearance.MouseOverBackColor = LmCor.Bc_Btn_Selected;
                        break;
                    }
                case ButtonStyle.Information:
                    {
                        this.BackColor = Enabled ? Bc_Info_Normal : Bc_Info_Disabled;
                        this.FlatAppearance.BorderColor = Bc_Info_Disabled;
                        this.FlatAppearance.MouseDownBackColor = Bc_Info_Press;
                        this.FlatAppearance.MouseOverBackColor = Bc_Info_Selected;
                    }
                    break;
                case ButtonStyle.Question:
                    {
                        this.BackColor = Enabled ? Bc_Question_Normal : Bc_Question_Disabled;
                        this.FlatAppearance.BorderColor = Bc_Question_Disabled;
                        this.FlatAppearance.MouseDownBackColor = Bc_Question_Press;
                        this.FlatAppearance.MouseOverBackColor = Bc_Question_Selected;
                    }
                    break;
                case ButtonStyle.Warning:
                    {
                        this.BackColor = Enabled ? Bc_Warning_Normal : Bc_Warning_Disabled;
                        this.FlatAppearance.BorderColor = Bc_Warning_Disabled;
                        this.FlatAppearance.MouseDownBackColor = Bc_Warning_Press;
                        this.FlatAppearance.MouseOverBackColor = Bc_Warning_Selected;
                    }
                    break;
                case ButtonStyle.Error:
                    {
                        this.BackColor = Enabled ? Bc_Error_Normal : Bc_Error_Disabled;
                        this.FlatAppearance.BorderColor = Bc_Error_Disabled;
                        this.FlatAppearance.MouseDownBackColor = Bc_Error_Press;
                        this.FlatAppearance.MouseOverBackColor = Bc_Error_Selected;
                    }
                    break;
                case ButtonStyle.Gray:
                    {
                        this.BackColor = Enabled ? Bc_Gray_Normal : Bc_Gray_Disabled;
                        this.FlatAppearance.BorderColor = Bc_Gray_Disabled;
                        this.FlatAppearance.MouseDownBackColor = Bc_Gray_Press;
                        this.FlatAppearance.MouseOverBackColor = Bc_Gray_Selected;
                    }
                    break;
                default:
                    break;
            }


            this.ForeColor =  this.BackColor.GetForeColor(LmControlStatus.Normal);

            this.Image = this.Image.ApplyColor(this.ForeColor);

            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            if (borderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button border                    
                    if (borderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                //Button surface
                this.Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        #endregion

        #region Override Metodos

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;

            switch (Style)
            {
                case ButtonStyle.Default:
                    {
                        this.BackColor = Enabled
                            ? LmCor.Bc_Btn_Selected
                            : LmCor.Bc_Btn_Disabled;
                    }
                    break;
                case ButtonStyle.Information:
                    {
                        this.BackColor = Enabled
                            ? Bc_Info_Selected
                            : Bc_Info_Disabled;
                    }
                    break;
                case ButtonStyle.Question:
                    {
                        this.BackColor = Enabled
                            ? Bc_Question_Selected
                            : Bc_Question_Disabled;
                    }
                    break;
                case ButtonStyle.Warning:
                    {
                        this.BackColor = Enabled
                            ? Bc_Warning_Selected
                            : Bc_Warning_Disabled;
                    }
                    break;
                case ButtonStyle.Error:
                    {
                        this.BackColor = Enabled
                            ? Bc_Error_Selected
                            : Bc_Error_Disabled;
                    }
                    break;
                case ButtonStyle.Gray:
                    {
                        this.BackColor = Enabled
                            ? Bc_Gray_Selected
                            : Bc_Gray_Disabled;
                    }
                    break;
                default:
                    break;
            }

            this.ForeColor = Enabled
                ? this.BackColor.GetForeColor(LmControlStatus.Selected)
                : this.BackColor.GetForeColor(LmControlStatus.Disabled);

            this.Image = this.Image.ApplyColor(this.ForeColor);

            Invalidate();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!isFocused)
                isHovered = false;

            switch (Style)
            {
                case ButtonStyle.Default:
                    {
                        this.BackColor =
                           Enabled
                           ? isFocused ? LmCor.Bc_Btn_Selected
                           : LmCor.Bc_Btn_Normal
                           : LmCor.Bc_Btn_Disabled;
                    }
                    break;
                case ButtonStyle.Information:
                    {
                        this.BackColor =
                           Enabled
                           ? isFocused ? Bc_Info_Selected
                           : Bc_Info_Normal
                           : Bc_Info_Disabled;
                    }
                    break;
                case ButtonStyle.Question:
                    {
                        this.BackColor =
                           Enabled
                           ? isFocused ? Bc_Question_Selected
                           : Bc_Question_Normal
                           : Bc_Question_Disabled;
                    }
                    break;
                case ButtonStyle.Warning:
                    {
                        this.BackColor =
                           Enabled
                           ? isFocused ? Bc_Warning_Selected
                           : Bc_Warning_Normal
                           : Bc_Warning_Disabled;
                    }
                    break;
                case ButtonStyle.Error:
                    {
                        this.BackColor =
                           Enabled
                           ? isFocused ? Bc_Error_Selected
                           : Bc_Error_Normal
                           : Bc_Error_Disabled;
                    }
                    break;
                case ButtonStyle.Gray:
                    {
                        this.BackColor =
                           Enabled
                           ? isFocused ? Bc_Gray_Selected
                           : Bc_Gray_Normal
                           : Bc_Gray_Disabled;
                    }
                    break;
                default:
                    break;
            }

            this.ForeColor =  Enabled
                ? isFocused ? this.BackColor.GetForeColor(LmControlStatus.Selected)
                : this.BackColor.GetForeColor(LmControlStatus.Normal)
                : this.BackColor.GetForeColor(LmControlStatus.Disabled);

            this.Image = this.Image.ApplyColor(this.ForeColor);

            Invalidate();

            Font = _default;
            GC.Collect();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPressed = true;
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isPressed = false;
            Invalidate();

            GC.Collect();
            base.OnMouseUp(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (Enabled)
            {
                FlatAppearance.BorderColor = LmCor.Br_Normal;
                this.BackColor = LmCor.Bc_Btn_Normal;
            }
            else
            {
                FlatAppearance.BorderColor = LmCor.Br_Disabled;
                this.BackColor = LmCor.Bc_Btn_Disabled;
            }

            Invalidate();

            //ColorIcon();

            GC.Collect();
            base.OnEnabledChanged(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            isFocused = true;
            isHovered = true;
            this.SetLastFocusedControl();

            switch (Style)
            {
                case ButtonStyle.Default:
                    {
                        this.BackColor = LmCor.Bc_Btn_Selected;
                    }
                    break;
                case ButtonStyle.Information:
                    {
                        this.BackColor = Bc_Info_Selected;
                    }
                    break;
                case ButtonStyle.Question:
                    {
                        this.BackColor = Bc_Question_Selected;
                    }
                    break;
                case ButtonStyle.Warning:
                    {
                        this.BackColor = Bc_Warning_Selected;
                    }
                    break;
                case ButtonStyle.Error:
                    {
                        this.BackColor = Bc_Error_Selected;
                    }
                    break;
                case ButtonStyle.Gray:
                    {
                        this.BackColor = Bc_Gray_Selected;
                    }
                    break;
                default:
                    break;
            }

            FlatAppearance.BorderColor = LmCor.Br_Selected;
            this.ForeColor = this.BackColor.GetForeColor(LmControlStatus.Selected);

            this.Image = this.Image.ApplyColor(this.ForeColor);

            Invalidate();

            //ColorIcon();

            GC.Collect();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            isFocused = false;
            isHovered = false;
            isPressed = false;

            switch (Style)
            {
                case ButtonStyle.Default:
                    {
                        this.BackColor = LmCor.Bc_Btn_Normal;
                    }
                    break;
                case ButtonStyle.Information:
                    {
                        this.BackColor = Bc_Info_Normal;
                    }
                    break;
                case ButtonStyle.Question:
                    {
                        this.BackColor = Bc_Question_Normal;
                    }
                    break;
                case ButtonStyle.Warning:
                    {
                        this.BackColor = Bc_Warning_Normal;
                    }
                    break;
                case ButtonStyle.Error:
                    {
                        this.BackColor = Bc_Error_Normal;
                    }
                    break;
                case ButtonStyle.Gray:
                    {
                        this.BackColor = Bc_Gray_Normal;
                    }
                    break;
                default:
                    break;
            }

            FlatAppearance.BorderColor = LmCor.Br_Normal;
            this.ForeColor = this.BackColor.GetForeColor(LmControlStatus.Normal);

            this.Image = this.Image.ApplyColor(this.ForeColor);

            Invalidate();

            //ColorIcon();

            GC.Collect();
            base.OnLostFocus(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        #endregion

        #region Metodos

        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        #endregion

        #region Events

        //private void Button_Resize(object sender, EventArgs e)
        //{
        //    if (borderRadius > this.Height / 2)
        //        borderRadius = this.Height / 2;
        //}

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        #endregion

    }
}
