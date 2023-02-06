using LmCorbieUI.Controls;
using LmCorbieUI.Design;
using LmCorbieUI.LmForms;
using LmCorbieUI.Metodos.AtributosCustomizados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public partial class FrmConsultaGeral : LmSingleForm
    {
        BindingSource listaDados = new BindingSource();
        BindingSource listaFiltrados = new BindingSource();
        BindingSource subListaDados = new BindingSource();

        Control _sender;

        public List<string> valor = new List<string>();
        public object objeto;
        public List<object> objetos;

        int InicioSubLista = 0, fimSubLista;
        int limiteRegistros = 15;

        const int limiteInfinito = 1000000;
        const string simboloInfinito = "∞";

        public FrmConsultaGeral(object sender, object bsTabelaDados, string tituloPesquisa = "", string filtro = "", bool selecionarVariasLinhas = false)
        {
            InitializeComponent();
            _sender = (Control)sender;

            txtPesquisar.SupressAutoLeaveEvent = true;

            if (selecionarVariasLinhas)
            {
                dgv.MultiSelect = selecionarVariasLinhas;
                objetos = new List<object>();
            }

            if (limiteRegistros == limiteInfinito)
            {
                tslTotalRetorno.Text = simboloInfinito;

                lblPagina.Visible = false;
                lnkIrPrimeiro.Visible = false;
                lnkIrAnterior.Visible = false;
                lnkIrProximo.Visible = false;
                lnkIrUltimo.Visible = false;
            }
            else
                tslTotalRetorno.Text = limiteRegistros.ToString();

            listaDados.DataSource = bsTabelaDados;
            if (!string.IsNullOrEmpty(tituloPesquisa))
            {
                Text = tituloPesquisa;
            }
            else
            {
                Text = "Consulta ";
                if (listaDados.Count > 0)
                    Text += listaDados[0].GetType().Name;
            }

            FormatarGrid();

            FiltrarDados();
            if (!string.IsNullOrEmpty(filtro))
            {
                txtPesquisar.Text = filtro;
                FiltrarDados();
            }
        }

        private void FrmConsultaGeral_Load(object sender, EventArgs e)
        {
            if (listaDados.Count == 0)
                Close();

            dgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            Lnk_MouseLeave(lnkIrPrimeiro, null);
            Lnk_MouseLeave(lnkIrAnterior, null);
            Lnk_MouseLeave(lnkIrProximo, null);
            Lnk_MouseLeave(lnkIrUltimo, null);

            this.dgv.UpdateStyleGrid();
            this.dgv.ColumnHeadersDefaultCellStyle.WrapMode =  DataGridViewTriState.False;
            this.dgv.AllowUserToOrderColumns = false;
            this.dgv.AllowUserToResizeColumns = false;

            this.dgv.Refresh();
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                ConfirmarSelecao();
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ConfirmarSelecao();
            else if (e.KeyCode == Keys.Escape)
                Close();
            else if (e.KeyCode == Keys.Left)
                IrParaPaginaAnterior();
            else if (e.KeyCode == Keys.Right)
                IrParaPaginaProximo();
        }

        private void Dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != (char)8 && e.KeyChar != (char)9 && e.KeyChar != (char)13)
                    txtPesquisar.Text += e.KeyChar;
                else if (txtPesquisar.Text.Length > 1 && e.KeyChar != (char)9 && e.KeyChar != (char)13)
                    txtPesquisar.Text = txtPesquisar.Text.Substring(0, txtPesquisar.Text.Length - 1);
                else if (txtPesquisar.Text.Length == 1)
                    txtPesquisar.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro não visivel pelo Usuario", true);
            }
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (tmrInicioPesquisa.Enabled == false)
                tmrInicioPesquisa.Enabled = true;
            else
                tmrInicioPesquisa.Tag = 0;
        }

        private void TmrInicioPesquisa_Tick(object sender, EventArgs e)
        {
            int tempo = Convert.ToInt16(tmrInicioPesquisa.Tag);
            tmrInicioPesquisa.Tag = tempo + 1;
            if (tempo > 7)
            {
                tmrInicioPesquisa.Tag = 0;
                tmrInicioPesquisa.Enabled = false;
                try
                {
                    FiltrarDados();
                }
                catch (Exception ex)
                {
                    LmException.ShowException(ex, "Erro ao Pesquisar");
                }
            }
        }

        private void LnkIrPrimeiro_Click(object sender, EventArgs e)
        {
            InicioSubLista = 0;
            PreencherGrid();
        }

        private void LnkIrUltimo_Click(object sender, EventArgs e)
        {
            if (listaFiltrados.Count <= limiteRegistros) return;

            if (listaFiltrados.Count % limiteRegistros == 0)
                InicioSubLista = listaFiltrados.Count - limiteRegistros;
            else
            {
                InicioSubLista = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaFiltrados.Count / limiteRegistros)));
                InicioSubLista *= limiteRegistros;
            }
            PreencherGrid();
        }

        private void LnkIrAnterior_Click(object sender, EventArgs e)
        {
            IrParaPaginaAnterior();
        }

        private void LnkIrProximo_Click(object sender, EventArgs e)
        {
            IrParaPaginaProximo();
        }

        private void IrParaPaginaAnterior()
        {
            if (InicioSubLista >= limiteRegistros)
                InicioSubLista -= limiteRegistros;
            else
                InicioSubLista = 0;
            PreencherGrid();
        }

        private void IrParaPaginaProximo()
        {
            if (fimSubLista == listaFiltrados.Count) return;

            InicioSubLista += limiteRegistros;
            PreencherGrid();
        }

        private void ConfirmarSelecao()
        {
            try
            {
                if (dgv.RowCount > 0 && dgv.CurrentRow != null)
                {
                    foreach (DataGridViewCell cel in dgv.CurrentRow.Cells)
                        valor.Add(Convert.ToString(cel.Value));

                    bool encontrou = false;

                    foreach (var item in subListaDados)
                    {
                        encontrou = false;
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            foreach (PropertyInfo pro in item.GetType().GetProperties().ToList()
                            .Where(p => p.GetCustomAttribute(typeof(KeyAttribute)) != null))
                            {
                                foreach (DataGridViewCell cel in row.Cells)
                                {
                                    if (pro.Name == dgv.Columns[cel.ColumnIndex].Name)
                                    {
                                        if (pro.GetValue(item).ToString() == Convert.ToString(cel.Value))
                                            encontrou = true;
                                        else
                                            encontrou = false;

                                        break;
                                    }
                                }
                            }

                            //if (!encontrou) break;

                            if (encontrou)
                            {
                                if (dgv.MultiSelect)
                                {
                                    encontrou = false;
                                    objetos.Add(item);
                                }
                                else
                                {
                                    objeto = item;
                                    break;
                                }
                            }
                        }
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro não visivel pelo Usuario", true);
            }
        }

        private void FiltrarDados()
        {
            try
            {
                string msg = txtPesquisar.Text;
                InicioSubLista = 0;
                listaFiltrados.Clear();
                foreach (var item in listaDados)
                {
                    foreach (PropertyInfo pro in item.GetType().GetProperties().ToList()
                        .Where(p => p.GetCustomAttribute(typeof(LarguraColunaGrid)) != null))
                    {
                        ForeignKeyAttribute atbFK = (ForeignKeyAttribute)pro.GetCustomAttribute(typeof(ForeignKeyAttribute));

                        if (atbFK == null)
                        {
                            string value = Convert.ToString(pro.GetValue(item));

                            if (value == "True")
                                value = "SIM";
                            else if (value == "False")
                                value = "NÃO";

                            if (value.RemoverCaracteresEspeciais().ToUpper().Contains(msg.RemoverCaracteresEspeciais().ToUpper()))
                            {
                                listaFiltrados.Add(item);
                                break;
                            }
                        }
                        else
                        {
                            var FK = pro.GetValue(item);
                            if (FK != null)
                            {
                                foreach (PropertyInfo proFK in FK.GetType().GetProperties().ToList()
                                    .Where(p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
                                {
                                    DataObjectFieldAttribute atbProDOF = (DataObjectFieldAttribute)proFK.GetCustomAttribute(typeof(DataObjectFieldAttribute));
                                    if (atbProDOF.IsIdentity)
                                    {
                                        string value = Convert.ToString(proFK.GetValue(FK));

                                        if (value.ToString().RemoverCaracteresEspeciais().ToUpper().Contains(msg.RemoverCaracteresEspeciais().ToUpper()))
                                        {
                                            listaFiltrados.Add(item);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                PreencherGrid();

                if (listaFiltrados.Count == 0)
                    MsgBox.Show("Sem dados para a consulta!", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro ao Filtrar Dados");
            }
        }

        private void PreencherGrid()
        {
            try
            {
                subListaDados.Clear();

                for (int i = InicioSubLista; i < InicioSubLista + limiteRegistros; i++)
                {
                    if (i >= listaFiltrados.Count) break;
                    subListaDados.Add(listaFiltrados[i]);
                }

                CarregarDataGrigView();
                //dgv.DataSource = subListaDados;
                dgv.Refresh();

                if (listaFiltrados.Count - InicioSubLista < limiteRegistros)
                    fimSubLista = listaFiltrados.Count;
                else
                    fimSubLista = InicioSubLista + limiteRegistros;


                if (listaFiltrados.Count == 0)
                    lblPagina.Text = $"PG.: 0 de 0";
                else if (listaFiltrados.Count <= limiteRegistros)
                    lblPagina.Text = $"PG.: 1 de 1";
                else
                {
                    double numPaginas = Math.Ceiling(listaFiltrados.Count / (double)limiteRegistros);
                    int pgAtual = InicioSubLista / limiteRegistros;
                    lblPagina.Text = $"PG.: {pgAtual + 1} de {numPaginas}";
                }

                if (listaFiltrados.Count != 0)
                    lblPosicao.Text = $"{InicioSubLista + 1} a {fimSubLista} de {listaFiltrados.Count}";
                else
                    lblPosicao.Text = "0 a 0 de 0";
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro ao Preencher Grid");
            }
        }

        private void FormatarGrid()
        {
            try
            {
                if (listaDados.Count == 0) return;

                int largForm = Padding.Left + Padding.Right;
                var item = listaDados[0];

                foreach (PropertyInfo pro in item.GetType().GetProperties().ToList()
                   .Where(p => p.GetCustomAttribute(typeof(LarguraColunaGrid)) != null))
                {
                    LarguraColunaGrid atb = (LarguraColunaGrid)pro.GetCustomAttribute(typeof(LarguraColunaGrid));
                    DisplayNameAttribute atbDisplay = (DisplayNameAttribute)pro.GetCustomAttribute(typeof(DisplayNameAttribute));
                    AlinhamentoColunaGrid atbAlinhamento = (AlinhamentoColunaGrid)pro.GetCustomAttribute(typeof(AlinhamentoColunaGrid));

                    string TextoCabecaolho = pro.Name;
                    if (atbDisplay != null)
                        TextoCabecaolho = atbDisplay.DisplayName;

                    dgv.Columns.Add(pro.Name, TextoCabecaolho);

                    if (pro.PropertyType == typeof(System.DateTime))
                        dgv.Columns[pro.Name].ValueType = typeof(System.DateTime);
                    if (pro.PropertyType == typeof(System.DateTime?))
                        dgv.Columns[pro.Name].ValueType = typeof(System.DateTime);
                    else if (pro.PropertyType == typeof(System.Boolean))
                        dgv.Columns[pro.Name].ValueType = typeof(System.Boolean);

                    dgv.Columns[pro.Name].Width = atb.LarguraColuna;
                    largForm += atb.LarguraColuna;

                    if (atbAlinhamento != null)
                    {
                        dgv.Columns[pro.Name].DefaultCellStyle.Alignment = atbAlinhamento.Alinhamento;
                        dgv.Columns[pro.Name].HeaderCell.Style.Alignment = atbAlinhamento.Alinhamento;
                    }
                }
                Width = largForm + 2;

                if (limiteRegistros > 15)
                    Width += 19;

                tslDropDown.Image = tslDropDown.Image.ApplyColor(tslTodos.ForeColor);
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro ao Formatar Grid");
            }
        }

        private void CarregarDataGrigView()
        {
            dgv.Rows.Clear();
            foreach (var item in subListaDados)
            {
                dgv.Rows.Add(1);

                foreach (PropertyInfo pro in item.GetType().GetProperties().ToList()
                   .Where(p => p.GetCustomAttribute(typeof(LarguraColunaGrid)) != null))
                {
                    ForeignKeyAttribute atbFK = (ForeignKeyAttribute)pro.GetCustomAttribute(typeof(ForeignKeyAttribute));

                    string nomeColuna = pro.Name;

                    if (atbFK != null)
                    {
                        var FK = pro.GetValue(item);
                        if (FK != null)
                            foreach (PropertyInfo proFK in FK.GetType().GetProperties().ToList()
                                .Where(p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
                            {
                                DataObjectFieldAttribute atbProDOF = (DataObjectFieldAttribute)proFK.GetCustomAttribute(typeof(DataObjectFieldAttribute));
                                if (atbProDOF.IsIdentity)
                                {
                                    dgv.Rows[dgv.RowCount - 1].Cells[nomeColuna].Value = Convert.ToString(proFK.GetValue(FK));
                                }
                            }
                    }
                    else
                    {
                        if (pro.PropertyType == typeof(System.Boolean))
                        {
                            if ((bool)pro.GetValue(item) == true)
                                dgv.Rows[dgv.RowCount - 1].Cells[nomeColuna].Value = "Sim";
                            else
                                dgv.Rows[dgv.RowCount - 1].Cells[nomeColuna].Value = "Não";
                        }
                        else if (pro.PropertyType.IsEnum)
                            dgv.Rows[dgv.RowCount - 1].Cells[nomeColuna].Value = ((Enum)pro.GetValue(item)).ObterDescricaoEnum();
                        else
                            dgv.Rows[dgv.RowCount - 1].Cells[nomeColuna].Value = pro.GetValue(item);
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(dgv.Rows[dgv.RowCount - 1].Cells[nomeColuna].Value)))
                        FormatarCelula(_sender, dgv.Rows[dgv.RowCount - 1].Cells[nomeColuna]);
                }
            }
            //Height = this.Padding.Top + this.Padding.Bottom + msMenuStrip.Height + flpRodape.Height + dgv.ColumnHeadersHeight + (21 * dgv.RowCount);
        }

        private void FormatarCelula(Control sender, DataGridViewCell cell)
        {
            foreach (Control ctrl in sender.Controls)
            {
                if (string.IsNullOrEmpty(ctrl.Name)) continue;
                if (ctrl is LmTextBox)
                {
                    if (((LmTextBox)ctrl).Propriedade == dgv.Columns[cell.ColumnIndex].Name)
                    {
                        if (((LmTextBox)ctrl).Valor == LmValueType.Fone)
                        {
                            cell.Value = cell.Value.ToString().FormatarFone();
                            return;
                        }
                        else if (((LmTextBox)ctrl).Valor == LmValueType.Monetario)
                        {
                            if (cell.Value.ToString() != "0")
                                cell.Value = cell.Value.ToString().FormatarMonetario();
                            else
                                cell.Value = null;
                            return;
                        }
                        else if (((LmTextBox)ctrl).Valor == LmValueType.Cpf_Cnpj)
                        {
                            cell.Value = cell.Value.ToString().FormatarCpf_Cnpf();
                            return;
                        }
                        else if (((LmTextBox)ctrl).Valor == LmValueType.Data)
                        {
                            cell.Value = cell.Value.ToString().FormatarData();
                            return;
                        }
                        else if (((LmTextBox)ctrl).Valor == LmValueType.Num_Real)
                        {
                            if (cell.Value.ToString() != "0")
                                cell.Value = cell.Value.ToString().Numerico(((LmTextBox)ctrl).Valor_Decimais);
                            else
                                cell.Value = null;
                            return;
                        }
                        else if (((LmTextBox)ctrl).Valor == LmValueType.Num_Inteiro)
                        {
                            if (cell.Value.ToString() == "0" &&
                                !((LmTextBox)ctrl).IsPrimaryKey && !dgv.Columns[cell.ColumnIndex].Name.ToUpper().EndsWith("ID"))
                                cell.Value = null;
                            return;
                        }
                    }
                }
                FormatarCelula(ctrl, cell);
            }
        }

        private void TslLimite_Click(object sender, EventArgs e)
        {
            try
            {
                if (((ToolStripMenuItem)sender).Text != "Todos")
                {
                    tslTotalRetorno.Text = ((ToolStripMenuItem)sender).Text;
                    limiteRegistros = Convert.ToInt32(((ToolStripMenuItem)sender).Text);

                    lblPagina.Visible = true;
                    lnkIrPrimeiro.Visible = true;
                    lnkIrAnterior.Visible = true;
                    lnkIrProximo.Visible = true;
                    lnkIrUltimo.Visible = true;
                }
                else
                {
                    tslTotalRetorno.Text = simboloInfinito;
                    limiteRegistros = limiteInfinito;

                    lblPagina.Visible = false;
                    lnkIrPrimeiro.Visible = false;
                    lnkIrAnterior.Visible = false;
                    lnkIrProximo.Visible = false;
                    lnkIrUltimo.Visible = false;
                }

                FiltrarDados();
                if (!string.IsNullOrEmpty(txtPesquisar.Text))
                {
                    FiltrarDados();
                }
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro ao retornar Limite");
            }
        }

        private void Dgv_Sorted(object sender, EventArgs e)
        {
            try
            {
                if (listaDados.Count == 0) return;

                ListSortDirection direction = dgv.SortOrder == SortOrder.Descending ? ListSortDirection.Descending : ListSortDirection.Ascending;
                string columnName = dgv.SortedColumn.Name;

                PropertyInfo pro = listaDados[0].GetType().GetProperty(columnName);

                ForeignKeyAttribute atbFK = (ForeignKeyAttribute)pro.GetCustomAttribute(typeof(ForeignKeyAttribute));

                var propType = pro.PropertyType;

                for (int i = 0; i < listaDados.Count; i++)
                {
                    for (int j = i + 1; j < listaDados.Count; j++)
                    {
                        if (atbFK != null)
                        {
                            var FKI = pro.GetValue(listaDados[i]);
                            if (FKI != null)
                            {
                                foreach (PropertyInfo proFKI in FKI.GetType().GetProperties().ToList()
                                    .Where(p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
                                {
                                    DataObjectFieldAttribute atbProDOFI = (DataObjectFieldAttribute)proFKI
                                        .GetCustomAttribute(typeof(DataObjectFieldAttribute));

                                    if (atbProDOFI.IsIdentity)
                                    {
                                        string strFkI = Convert.ToString(proFKI.GetValue(FKI));

                                        var FKJ = pro.GetValue(listaDados[j]);
                                        if (FKJ != null)
                                        {
                                            foreach (PropertyInfo proFKJ in FKJ.GetType().GetProperties().ToList()
                                                .Where(p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
                                            {
                                                DataObjectFieldAttribute atbProDOFJ = (DataObjectFieldAttribute)proFKJ
                                                    .GetCustomAttribute(typeof(DataObjectFieldAttribute));

                                                if (atbProDOFJ.IsIdentity)
                                                {
                                                    string strFkJ = Convert.ToString(proFKJ.GetValue(FKJ));

                                                    int h = string.Compare(strFkI, strFkJ);
                                                    if ((h == 1 && direction == ListSortDirection.Ascending) ||
                                                        (h == -1 && direction == ListSortDirection.Descending))
                                                    {
                                                        var objChange = listaDados[i];
                                                        listaDados[i] = listaDados[j];
                                                        listaDados[j] = objChange;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (pro.PropertyType == typeof(System.Int16) || pro.PropertyType == typeof(System.Int32))
                        {
                            var vlrI = Convert.ToInt32(pro.GetValue(listaDados[i]));
                            var vlrJ = Convert.ToInt32(pro.GetValue(listaDados[j]));

                            if ((vlrI > vlrJ && direction == ListSortDirection.Ascending) ||
                                (vlrI < vlrJ && direction == ListSortDirection.Descending))
                            {
                                var objChange = listaDados[i];
                                listaDados[i] = listaDados[j];
                                listaDados[j] = objChange;
                            }
                        }
                        else if (pro.PropertyType == typeof(System.Double))
                        {
                            var vlrI = Convert.ToDouble(pro.GetValue(listaDados[i]));
                            var vlrJ = Convert.ToDouble(pro.GetValue(listaDados[j]));

                            if ((vlrI > vlrJ && direction == ListSortDirection.Ascending) ||
                                (vlrI < vlrJ && direction == ListSortDirection.Descending))
                            {
                                var objChange = listaDados[i];
                                listaDados[i] = listaDados[j];
                                listaDados[j] = objChange;
                            }
                        }
                        else if (pro.PropertyType == typeof(System.DateTime))
                        {
                            var dateI = Convert.ToDateTime(pro.GetValue(listaDados[i]));
                            var dateJ = Convert.ToDateTime(pro.GetValue(listaDados[j]));

                            if ((dateI > dateJ && direction == ListSortDirection.Ascending) ||
                                (dateI < dateJ && direction == ListSortDirection.Descending))
                            {
                                var objChange = listaDados[i];
                                listaDados[i] = listaDados[j];
                                listaDados[j] = objChange;
                            }
                        }
                        else //if (pro.PropertyType == typeof(System.Boolean) || pro.PropertyType == typeof(System.String))
                        {
                            var strI = Convert.ToString(pro.GetValue(listaDados[i]));
                            var strJ = Convert.ToString(pro.GetValue(listaDados[j]));

                            int h = string.Compare(strI, strJ);
                            if ((h == 1 && direction == ListSortDirection.Ascending) ||
                                (h == -1 && direction == ListSortDirection.Descending))
                            {
                                var objChange = listaDados[i];
                                listaDados[i] = listaDados[j];
                                listaDados[j] = objChange;
                            }
                        }
                    }
                }

                InicioSubLista = 0;
                FiltrarDados();
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro ao ordenar grid");
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            ConfirmarSelecao();
        }

        private void Lnk_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                ((PictureBox)sender).Image = ((PictureBox)sender).Image.ApplyColor(LmCor.Br_Selected);
            }
            catch (Exception ex)
            {

            }
        }

        private void Lnk_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                ((PictureBox)sender).Image = ((PictureBox)sender).Image.ApplyColor(LmCor.Br_Normal);
            }
            catch (Exception ex)
            {

            }
        }

        private void TxtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tmrInicioPesquisa.Tag = 0;
                tmrInicioPesquisa.Enabled = false;
                try
                {
                    FiltrarDados();
                }
                catch (Exception ex)
                {
                    LmException.ShowException(ex, "Erro ao Pesquisar");
                }
            }
        }

    }
}
