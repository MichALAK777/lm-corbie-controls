using LmCorbieUI.LmForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LmCorbieUI.DEMO
{
    public partial class FrmPrincipal : LmMainForm
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void lmMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void menuSistema_Click(object sender, EventArgs e)
        {
        }

        private void menuDadosEmpresa_Click(object sender, EventArgs e)
        {
            FrmSingle frm = new FrmSingle();
            frm.ShowDialog();
        }

        private void menuUsuarioCad_Click(object sender, EventArgs e)
        {
            this.OpenFormChild(new FrmChild());

        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
