using LmCorbieUI.Controls;
using LmCorbieUI.Design;
using LmCorbieUI.LmForms;
using LmCorbieUI.Native;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public partial class FrmCaixaMultiselecao : LmSingleForm
    {
        MouseHook mh = new MouseHook();

        public delegate void ListChanged(object sender, EventArgs e);
        public event ListChanged SelectedValuesChanged;

        public FrmCaixaMultiselecao(List<ColunaGridMultiselecao> CmdDados)
        {
            InitializeComponent();

            dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
            dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;

            dgv.DataSource = CmdDados;
        }

        private void FrmCaixaMultiselecao_Load(object sender, EventArgs e)
        {
            mh = new MouseHook();
            mh.SetHook();
            mh.MouseMoveEvent += Mh_MouseMoveEvent; //.MouseClickEvent += Mh_MouseClickEvent;

            dgv.Columns["ID"].Visible = false;
            dgv.Columns["Select"].ReadOnly = true;
            dgv.Columns["Descricao"].ReadOnly = true;

            dgv.Columns["ID"].Width = 40;
            dgv.Columns["Select"].Width = 25;
            dgv.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if ((bool)row.Cells["Select"].Value == true)
                {
                    row.DefaultCellStyle.SelectionBackColor =
                    row.DefaultCellStyle.BackColor = LmCor.Bc_Dgv_CellSelected;
                }
            }
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((bool)dgv.CurrentRow.Cells["Select"].Value == true)
            {
                bool possuiSelecionado = false;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if ((bool)row.Cells["Select"].Value == true && row.Cells["Select"].RowIndex != e.RowIndex)
                    {
                        possuiSelecionado = true;
                        break;
                    }
                }
                if (possuiSelecionado)
                    dgv.CurrentRow.Cells["Select"].Value = false;
                else
                    MsgBox.Show("Você não pode desmarcar todos itens", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgv.CurrentRow.Cells["Select"].Value = true;
            }

            SelectedValuesChanged?.Invoke(this, new EventArgs());
        }

        private void Dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.CurrentRow.Cells["Select"].ColumnIndex)
            {
                if ((bool)dgv.CurrentRow.Cells["Select"].Value == true)
                {
                    dgv.CurrentRow.DefaultCellStyle.SelectionBackColor =
                    dgv.CurrentRow.DefaultCellStyle.BackColor = LmCor.Bc_Dgv_CellSelected;
                }
                else
                {
                    dgv.CurrentRow.DefaultCellStyle.SelectionBackColor =
                    dgv.CurrentRow.DefaultCellStyle.BackColor = LmCor.Bc_Dgv_CellNormal;
                }
            }
        }

        private void FrmCaixaMultiselecao_FormClosed(object sender, FormClosedEventArgs e)
        {
            mh.UnHook();
        }

        private void FrmCaixaMultiselecao_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Mh_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (e.X < Left || e.X > Left + Width || e.Y < Top || e.Y > Top + Height)
            {
                mh.UnHook();
                Close();
            }
        }

        private void CmsPrimeiro_Click(object sender, EventArgs e)
        {
            if (int.TryParse(cmsPrimeiro.Tag.ToString(), out int rowIndex))
            {
                dgv.Rows[rowIndex].Cells["Select"].Value = true;
                dgv.Rows[rowIndex].DefaultCellStyle.SelectionBackColor =
                    dgv.Rows[rowIndex].DefaultCellStyle.BackColor = LmCor.Bc_Dgv_CellSelected;

                for (int i = dgv.RowCount - 1; i >= 0; i--)
                {
                    if (i != rowIndex)
                    {
                        dgv.Rows[i].Cells["Select"].Value = false;
                        dgv.Rows[i].DefaultCellStyle.SelectionBackColor =
                            dgv.Rows[i].DefaultCellStyle.BackColor = LmCor.Bc_Dgv_CellNormal;
                    }
                }
                SelectedValuesChanged?.Invoke(this, new EventArgs());
            }
        }

        private void CmsMarcar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["Select"].Value = true;
                row.DefaultCellStyle.SelectionBackColor =
                    row.DefaultCellStyle.BackColor = LmCor.Bc_Dgv_CellSelected;
            }
            SelectedValuesChanged?.Invoke(this, new EventArgs());
        }

        private void Dgv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = this.dgv.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    var item = this.dgv.Rows[hit.RowIndex].DataBoundItem;
                    cmsPrimeiro.Text = "Selecionar Apenas " + this.dgv.Rows[hit.RowIndex].Cells["Descricao"].Value.ToString();
                    cmsPrimeiro.Tag = hit.RowIndex;
                }
            }
        }
    }
}
