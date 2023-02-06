using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LmMessageBox
{
    public partial class FrmMsgWait : Form
    {
        int x, y;

        public FrmMsgWait(/*string texto, Color backColor, Color foreColor, Color borderColor*/)
        {
            InitializeComponent();
        }

        private void FrmMsgWait_Load(object sender, EventArgs e)
        {
            try
            {
                this.BringToFront();
                this.TopMost = true;

                string fileName = "C:\\Temp\\MessageWait.lmmsg";

                using (System.IO.StreamReader leitor = new System.IO.StreamReader(fileName, Encoding.GetEncoding("UTF-8")))
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        Text = lblMessage.Text = leitor.ReadLine();
                        leitor.Close();
                    }));
                }

                //lblMessage.ForeColor =
                //lblTempo.ForeColor = Color.FromArgb(43, 41, 38);

                lblMessage.Refresh();
            }
            catch (Exception)
            {
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //timer.Enabled = false;
            //timer.Stop();
        }

        private void FecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMsgWait_MouseDown(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.6;
            if (e.Button != MouseButtons.Left) return;
            x = this.Left - MousePosition.X;
            y = this.Top - MousePosition.Y;
        }

        private void FrmMsgWait_MouseUp(object sender, MouseEventArgs e)
        {
            this.Opacity = 1;
        }

        private void FrmMsgWait_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = x + MousePosition.X;
            this.Top = y + MousePosition.Y;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen p = new Pen(Color.FromArgb(115, 115, 95)))
            {
                p.Width = 1;
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

    }
}
