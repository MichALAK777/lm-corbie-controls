using LmCorbieUI.Controls;
using LmCorbieUI.LmForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public partial class FrmConfigGeralGrid : LmSingleForm
    {
        class ColunaGrid
        {
            [DataObjectField(true, false)]
            public string Name { get; set; }

            [DataObjectField(false, true)]
            public string Display { get; set; }
        }

        bool possuiImgAnexo = false;
        LmDataGridView _dgv = new LmDataGridView();

        public FrmConfigGeralGrid(LmDataGridView lmDataGrid)
        {
            InitializeComponent();

            _dgv = lmDataGrid;

            Rectangle areaTrabalho = Screen.GetWorkingArea(this);
            this.MaximumSize = new Size(width: 777, height: areaTrabalho.Height);

            this.Height += (lmDataGrid.Grid.Columns.Count * 24);

            Thread t1 = new Thread(() => { CriarControles(); }) { IsBackground = true };
            t1.Start();

            flpColVisivel.Focus();
        }

        private void CriarControles()
        {
            string[] colBloqueadas = !string.IsNullOrEmpty(_dgv.ColunasBloqueadasGrid)
                ? _dgv.ColunasBloqueadasGrid.Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries)
                : null;

            string[] colOcultas = !string.IsNullOrEmpty(_dgv.ColunasOcultasGrid)
                ? _dgv.ColunasOcultasGrid.Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries)
                : null;

            List<DataGridViewColumn> colunasVisiveis = new List<DataGridViewColumn>();
            List<DataGridViewColumn> colunasOcultas = new List<DataGridViewColumn>();

            foreach (DataGridViewColumn cln in _dgv.Grid.Columns)
            {
                if (cln.ValueType != typeof(System.Drawing.Bitmap) && (colBloqueadas == null || !colBloqueadas.Contains(cln.Name)))
                {
                    if (colOcultas == null || !colOcultas.Contains(cln.Name))
                    {
                        colunasVisiveis.Add(cln);
                    }
                    else
                    {
                        colunasOcultas.Add(cln);
                    }
                }
                else if (cln.ValueType == typeof(System.Drawing.Bitmap))
                {
                    possuiImgAnexo = true;
                }
            }

            for (int i = 0; i < colunasVisiveis.Count; i++)
            {
                for (int h = i + 1; h < colunasVisiveis.Count; h++)
                {
                    if (colunasVisiveis[i].DisplayIndex > colunasVisiveis[h].DisplayIndex)
                    {
                        DataGridViewColumn clnChange = colunasVisiveis[i];
                        colunasVisiveis[i] = colunasVisiveis[h];
                        colunasVisiveis[h] = clnChange;
                    }
                }
            }

            foreach (var item in colunasVisiveis)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    LmColunaGrid uc = new LmColunaGrid( colunaVisivel: true);
                    uc.lblDescricao.Text = item.HeaderText.Replace("▲  ", "").Replace("▼  ", "");
                    uc.Name = item.Name;

                    uc.MouseDownCtrl += Uc_MouseDownVisivel;
                    uc.MoverParaOculto += Uc_MoverParaOculto;

                    flpColVisivel.Controls.Add(uc);
                }));
            }

            foreach (var item in colunasOcultas)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    LmColunaGrid uc = new LmColunaGrid( colunaVisivel: false);
                    uc.lblDescricao.Text = item.HeaderText.Replace("▲  ", "").Replace("▼  ", "");
                    uc.Name = item.Name;

                    uc.MoverParaVisivel += Uc_MoverParaVisivel;

                    flpColOculta.Controls.Add(uc);
                }));
            }
        }

        private void Uc_MoverParaOculto(object sender, EventArgs e)
        {
            if (flpColVisivel.Controls.Count == 1)
            {
                MsgBox.Show("Você não pode ocultar todas as colunas!",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ucSend = (LmColunaGrid)sender;
            flpColVisivel.Controls.RemoveByKey(ucSend.Name);

            LmColunaGrid uc = new LmColunaGrid( colunaVisivel: false);
            uc.lblDescricao.Text = ucSend.lblDescricao.Text;
            uc.Name = ucSend.Name;

            uc.MoverParaVisivel += Uc_MoverParaVisivel;

            flpColOculta.Controls.Add(uc);
        }

        private void Uc_MoverParaVisivel(object sender, EventArgs e)
        {
            var ucSend = (LmColunaGrid)sender;
            flpColOculta.Controls.RemoveByKey(ucSend.Name);

            LmColunaGrid uc = new LmColunaGrid( colunaVisivel: true);
            uc.lblDescricao.Text = ucSend.lblDescricao.Text;
            uc.Name = ucSend.Name;

            uc.MouseDownCtrl += Uc_MouseDownVisivel;
            uc.MoverParaOculto += Uc_MoverParaOculto;

            flpColVisivel.Controls.Add(uc);
        }

        private void Uc_MouseDownVisivel(object sender, MouseEventArgs e)
        {
            ((LmColunaGrid)sender).DoDragDrop((LmColunaGrid)sender, DragDropEffects.Move);
        }

        private void flpColVisivel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(LmColunaGrid)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void FlpColVisivel_DragDrop(object sender, DragEventArgs e) 
        {
            var pt = new Point(e.X, e.Y);

            var control = (LmColunaGrid)e.Data.GetData(typeof(LmColunaGrid));

            Point mousePosition = flpColVisivel.PointToClient(pt);
            Control destination = flpColVisivel.GetChildAtPoint(mousePosition);

            if (destination == null)
            {
                pt = new Point(pt.X, pt.Y + 10);
                mousePosition = flpColVisivel.PointToClient(pt);
                destination = flpColVisivel.GetChildAtPoint(mousePosition);
            }

            int indexDestination = flpColVisivel.Controls.IndexOf(destination);
            if (flpColVisivel.Controls.IndexOf(control) < indexDestination)
                indexDestination--;

            flpColVisivel.Controls.SetChildIndex(control, indexDestination);
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            int index = possuiImgAnexo ? 1 : 0;
            foreach (var ctrl in flpColVisivel.Controls)
            {
                _dgv.Grid.Columns[((LmColunaGrid)ctrl).Name].Visible = true;
                _dgv.Grid.Columns[((LmColunaGrid)ctrl).Name].DisplayIndex = index;
                index++;
            }

            _dgv.ColunasOcultasGrid = "";
            foreach (var ctrl in flpColOculta.Controls)
            {
                _dgv.Grid.Columns[((LmColunaGrid)ctrl).Name].Visible = false;
                _dgv.ColunasOcultasGrid += ((LmColunaGrid)ctrl).Name + "^";
            }

            if (_dgv.ColunasOcultasGrid.EndsWith("^"))
                _dgv.ColunasOcultasGrid = _dgv.ColunasOcultasGrid.Substring(0, _dgv.ColunasOcultasGrid.Length - 1);

            if (!string.IsNullOrEmpty(_dgv.ColunaOrdenacaoGrid))
                _dgv.Grid.Sort(_dgv.Grid.Columns[_dgv.ColunaOrdenacaoGrid.Split('^')[0]], (ListSortDirection)Convert.ToInt16(_dgv.ColunaOrdenacaoGrid.Split('^')[1]));

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
