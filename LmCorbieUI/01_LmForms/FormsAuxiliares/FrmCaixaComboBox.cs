using LmCorbieUI.Design;
using LmCorbieUI.LmForms;
using LmCorbieUI.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LmCorbieUI
{
    public partial class FrmCaixaComboBox : LmChildForm
    {
        MouseHook mh;

        public BindingSource _dataSource;
        public object _selectedValue;
        public object _selectedItem;
        public string _displayText;

        private int _largura;
        private LmValueType _tipoValor;
        private string columnName = "DescriptionColumn";

        public FrmCaixaComboBox(BindingSource dataSource, object selectedItem, object selectedValue, LmValueType tipoValor, int largura)
        {
            InitializeComponent();

            _dataSource = dataSource;
            _selectedItem = selectedItem;
            _selectedValue = selectedValue;
            _tipoValor = tipoValor;

            FormatarGrid();
            CarregarDataGrigView();

            _largura = largura;
        }

        private void FrmCaixaComboBox_Load(object sender, EventArgs e)
        {
            mh = new MouseHook();
            mh.SetHook();
            mh.MouseClickEvent += Mh_MouseClickEvent;

            this.Width = _largura;

        }

        private void FrmCaixaComboBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            mh.UnHook();
        }

        private void Mh_MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Rectangle clirec = this.RectangleToClient(ClientRectangle);
                if (e.X < Left || e.X > Left + Width || e.Y < Top || e.Y > Top + Height)
                {
                    mh.UnHook();
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
        }

        private void Dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
        }

        private void Dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ConfirmarSelecao();
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void Dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != (char)8 && e.KeyChar != (char)9 && e.KeyChar != (char)13)
                    txt.Text += e.KeyChar;
                else if (txt.Text.Length > 1 && e.KeyChar != (char)9 && e.KeyChar != (char)13)
                    txt.Text = txt.Text.Substring(0, txt.Text.Length - 1);
                else if (txt.Text.Length == 1)
                    txt.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro não visivel pelo Usuario", true);
            }
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfirmarSelecao();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarDataGrigView();
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro ao Filtrar Dados");
            }
        }

        private void FormatarGrid()
        {
            try
            {
                dgv.BorderStyle = BorderStyle.FixedSingle;

                if (_dataSource.Count == 0) return;

                //int largForm = 0;

                var item = _dataSource[0];

                if (_tipoValor == LmValueType.ComboBox)
                {
                    foreach (PropertyInfo pro in item.GetType().GetProperties().ToList()
                       .Where(p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
                    {
                        DataObjectFieldAttribute atb = (DataObjectFieldAttribute)pro.GetCustomAttribute(typeof(DataObjectFieldAttribute));

                        if (atb != null && atb.IsIdentity == true)
                        {
                            DisplayNameAttribute atbDisplay = (DisplayNameAttribute)pro.GetCustomAttribute(typeof(DisplayNameAttribute));

                            //LarguraColunaGrid atbLarg = (LarguraColunaGrid)pro.GetCustomAttribute(typeof(LarguraColunaGrid));

                            //if (atbLarg != null)
                            //    largForm += atbLarg.larguraColuna;

                            string TextoCabecaolho = pro.Name;
                            if (atbDisplay != null)
                                TextoCabecaolho = atbDisplay.DisplayName;

                            dgv.Columns.Add(pro.Name, TextoCabecaolho);
                            dgv.Columns[pro.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                            if (pro.PropertyType == typeof(System.DateTime))
                                dgv.Columns[pro.Name].ValueType = typeof(System.DateTime);
                        }
                    }
                }
                else if (_tipoValor == LmValueType.ComboBox_Enum)
                {
                    dgv.Columns.Add(columnName, columnName);
                    dgv.Columns[columnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                //if (largForm > 0)
                //    Width = largForm;
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, "Erro ao Formatar Grid");
            }
        }

        private void CarregarDataGrigView()
        {
            dgv.Rows.Clear();
            if (dgv.ColumnCount == 0) return;

            foreach (var item in _dataSource)
            {
                if (_tipoValor == LmValueType.ComboBox)
                {
                    foreach (PropertyInfo pro in item.GetType().GetProperties().ToList()
                    .Where(p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
                    {
                        DataObjectFieldAttribute atb = (DataObjectFieldAttribute)pro.GetCustomAttribute(typeof(DataObjectFieldAttribute));
                        if (atb != null && atb.IsIdentity == true)
                        {
                            if (Convert.ToString(pro.GetValue(item)).RemoverCaracteresEspeciais().ToUpper().Contains(txt.Text.RemoverCaracteresEspeciais().ToUpper()))
                            {
                                DataGridViewRow r = new DataGridViewRow();
                                r.Tag = item;
                                dgv.Rows.Add(r);
                                dgv.Rows[dgv.RowCount - 1].Cells[pro.Name].Value = pro.GetValue(item);
                            }
                        }
                    }
                }
                else if (_tipoValor == LmValueType.ComboBox_Enum)
                {
                    DataGridViewRow r = new DataGridViewRow();
                    r.Tag = item;
                    dgv.Rows.Add(r);
                    dgv.Rows[dgv.RowCount - 1].Cells[columnName].Value = ((KeyValuePair<Enum, string>)item).Value;
                }
            }

            if (dgv.RowCount > 0)
                dgv.Rows[0].Cells[0].Selected = false;
        }

        private void ConfirmarSelecao()
        {
            try
            {
                if (dgv.RowCount > 0 && dgv.CurrentRow != null)
                {
                    _selectedItem = dgv.CurrentRow.Tag;
                    _displayText = dgv.CurrentRow.Cells[0].Value.ToString();

                    if (_tipoValor == LmValueType.ComboBox)
                    {
                        foreach (PropertyInfo pro in _selectedItem.GetType().GetProperties().ToList()
                            .Where(p => p.GetCustomAttribute(typeof(DataObjectFieldAttribute)) != null))
                        {
                            DataObjectFieldAttribute atb = (DataObjectFieldAttribute)pro.GetCustomAttribute(typeof(DataObjectFieldAttribute));
                            if (atb != null && atb.PrimaryKey == true)
                                _selectedValue = pro.GetValue(_selectedItem);
                        }
                    }
                    else if (_tipoValor == LmValueType.ComboBox_Enum)
                    {
                        _selectedValue = ((KeyValuePair<Enum, string>)dgv.CurrentRow.Tag).Key;
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

    }
}
