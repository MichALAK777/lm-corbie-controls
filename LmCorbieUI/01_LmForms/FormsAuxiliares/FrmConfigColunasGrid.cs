using LmCorbieUI.Design;
using LmCorbieUI.LmForms;
using LmCorbieUI.Native;
using System;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public partial class FrmConfigColunasGrid : LmSingleForm
    {
        MouseHook mh;

        public FrmConfigColunasGrid(string text = "Selecionar Colunas para Exibir")
        {
            InitializeComponent();

            this.Text = text;

            clbColunas.BackColor = LmCor.Bc_Form;
            clbColunas.ForeColor = clbColunas.BackColor.GetForeColor(LmControlStatus.Normal);
        }

        private void FrmConfigColunasGrid_Load(object sender, EventArgs e)
        {
            mh = new MouseHook();
            mh.SetHook();
            mh.MouseClickEvent += Mh_MouseClickEvent;
        }

        private void FrmConfigColunasGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            mh.UnHook();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Mh_MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Rectangle clirec = this.RectangleToClient(ClientRectangle);
                if (e.X < Left || e.X > Left + Width || e.Y < Top || e.Y > Top + Height)
                {
                    mh.UnHook();
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void FrmConfigColunasGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CmsMarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbColunas.Items.Count; i++)
                clbColunas.SetItemCheckState(i, CheckState.Checked);
        }

        private void CmsDesmarcar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbColunas.Items.Count; i++)
                clbColunas.SetItemCheckState(i, CheckState.Unchecked);
        }
    }
}
