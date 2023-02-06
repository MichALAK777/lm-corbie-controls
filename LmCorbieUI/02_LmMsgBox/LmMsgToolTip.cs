using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public partial class LmMsgToolTip : Form
    {
        int larguraMax = 0;
        int alturaMax = 0;
        int delay = 0;

        public LmMsgToolTip(string texto, string titulo = "", int tempoExibicao = 2)
        {
            InitializeComponent();

            lblMsg.Text = texto;
            lblTitulo.Text = titulo;

            if (string.IsNullOrEmpty(lblTitulo.Text))
                lblTitulo.Visible = false;

            if (tempoExibicao != 0)
                delay = tempoExibicao * 1000;
            else
                delay = 2000;
        }

        private void LmMsgToolTip_Load(object sender, EventArgs e)
        {
            if (!lblTitulo.Visible)
                lblMsg.Location = new Point(1, 1);

            larguraMax = lblMsg.Width + 7;

            if (!lblTitulo.Visible)
                alturaMax = lblMsg.Height + 4;
            else
                alturaMax = lblTitulo.Height + lblMsg.Height + 12;

            Height = alturaMax;
            Width = larguraMax;

            lblTitulo.ForeColor = Color.Black;
            lblMsg.ForeColor = Color.Black;

            System.Threading.Thread t = new System.Threading.Thread(() => { FecharMesage(); }) { IsBackground = true };
            t.Start();
        }

        private void FecharMesage()
        {
            System.Threading.Thread.Sleep(delay);

            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    Close();
                }));
            }
            catch (System.InvalidOperationException ex)
            { }
            catch (Exception ex)
            { }
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

        private void LblMsg_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
