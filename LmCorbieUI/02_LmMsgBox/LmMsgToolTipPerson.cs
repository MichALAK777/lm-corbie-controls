using LmCorbieUI.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public partial class LmMsgToolTipPerson : Form
    {
        MouseHook mh;

        public LmMsgToolTipPerson(string msg)
        {
            InitializeComponent();

            lblMsg.Text = msg;
        }

        private void LmMsgToolTipPerson_Load(object sender, EventArgs e)
        {
            mh = new MouseHook();
            mh.SetHook();
            mh.MouseMoveEvent += Mh_MouseMoveEvent; //.MouseClickEvent += Mh_MouseClickEvent;

            Thread t = new Thread(() => { DimensionarMsg(); }) { IsBackground = true };
            t.Start();
        }

        private void LmMsgToolTipPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            mh.UnHook();
        }

        private void Mh_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (e.X < Left || e.X > Left + Width || e.Y < Top || e.Y > Top + Height)
            {
                mh.UnHook();
                Close();
            }
        }

        private void DimensionarMsg()
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    this.Size = new System.Drawing.Size(
                        lblMsg.Width + this.Padding.Left + this.Padding.Right, lblMsg.Height + this.Padding.Top + this.Padding.Bottom);
                    Refresh();
                }));
            }
            catch (ObjectDisposedException)
            {

            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen p = new Pen(Color.FromArgb(123, 123, 123)))
            {
                p.Width = 1;
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

    }
}
