using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using LmCorbieUI.Design;

namespace LmCorbieUI.Controls
{
    public class LmToggleButton : CheckBox
    {
        //Constructor
        public LmToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { }
        }

        private string propriedade = string.Empty;
        [DefaultValue("")]
        [Browsable(true)]
        public string Propriedade
        {
            get { return propriedade; }
            set { propriedade = value; }
        }

        //Methods
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.BackColor = LmCor.Bc_Form;
            pevent.Graphics.Clear(this.BackColor);

            if (this.Checked) //ON
            {
                if (this.Enabled)
                {
                    //Draw the control surface
                    pevent.Graphics.FillPath(new SolidBrush(LmCor.GetPercentColor(LmCor.CorPrimaria, LmCor.CorSecundaria, 20)), GetFigurePath());

                    //Draw the toggle
                    pevent.Graphics.FillEllipse(new SolidBrush(LmCor.GetPercentColor(LmCor.CorPrimaria, LmCor.CorSecundaria, 75)),
                      new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize)); 
                }
                else
                {
                    //Draw the control surface
                    pevent.Graphics.FillPath(new SolidBrush(LmCor.GetPercentColor(LmCor.CorPrimaria, LmCor.CorSecundaria, 40)), GetFigurePath());

                    //Draw the toggle
                    pevent.Graphics.FillEllipse(new SolidBrush(LmCor.GetPercentColor(LmCor.CorPrimaria, LmCor.CorSecundaria, 60)),
                      new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
                }
            }
            else //OFF
            {
                if (this.Enabled)
                {
                    //Draw the control surface
                    pevent.Graphics.FillPath(new SolidBrush(Color.FromArgb(123,123,123)), GetFigurePath());
                    //Draw the toggle
                    pevent.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(45, 45, 45)),
                      new Rectangle(2, 2, toggleSize, toggleSize)); 
                }
                else
                {
                    //Draw the control surface
                    pevent.Graphics.FillPath(new SolidBrush(Color.FromArgb(90, 90, 90)), GetFigurePath());
                    //Draw the toggle
                    pevent.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(70, 70, 70)),
                      new Rectangle(2, 2, toggleSize, toggleSize));
                }
            }
        }
    }
}
