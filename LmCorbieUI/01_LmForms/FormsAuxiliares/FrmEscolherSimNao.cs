using LmCorbieUI.Controls;
using LmCorbieUI.Design;
using LmCorbieUI.LmForms;
using LmCorbieUI.Native;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public partial class FrmEscolherSimNao : LmChildForm
    {
        MouseHook mh;

        public FrmEscolherSimNao(Point location, string textoSim = "Sim", string textoNao = "Não", bool ocultarSegundoBotao = false)
        {
            InitializeComponent();

            lblSim.Text = textoSim;
            lblNao.Text = textoNao;

            Location = location;

            lblSim.BackColor = LmCor.Bc_Btn_Normal;// LmPaint.BackColor.Button.Normal(Theme);
            lblNao.BackColor = LmCor.Bc_Btn_Normal;// LmPaint.BackColor.Button.Normal(Theme);
            lblSim.ForeColor = lblSim.BackColor.GetForeColor(LmControlStatus.Normal);
            lblNao.ForeColor = lblNao.BackColor.GetForeColor(LmControlStatus.Normal);

            if (ocultarSegundoBotao)
            {
                lblNao.Visible = false;
                this.Height = lblSim.Height + 2;
                Refresh();
            }
        }

        private void FrmEscolherSimNao_Load(object sender, EventArgs e)
        {
            mh = new MouseHook();
            mh.SetHook();
            mh.MouseClickEvent += mh_MouseClickEvent;
        }

        private void FrmEscolherSimNao_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            mh.UnHook();
        }

        private void mh_MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X < Left || e.X > Left + Width || e.Y < Top || e.Y > Top + Height)
                {
                    mh.UnHook();
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
        }

        private void Lbl_MouseEnter(object sender, EventArgs e)
        {
            ((LmLabel)sender).BackColor = LmCor.Bc_Btn_Selected;// LmCor.Bc_Btn_Selected;
            ((LmLabel)sender).ForeColor = ((LmLabel)sender).BackColor.GetForeColor(LmControlStatus.Selected);
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            ((LmLabel)sender).BackColor = LmCor.Bc_Btn_Normal;// LmPaint.BackColor.Button.Normal(Theme);
            ((LmLabel)sender).ForeColor = ((LmLabel)sender).BackColor.GetForeColor(LmControlStatus.Normal);
        }

        private void LblSim_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void LblNao_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void FrmEscolherSimNao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
