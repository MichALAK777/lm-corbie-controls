using LmCorbieUI.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LmCorbieUI.Controls
{
    [ProvideToolboxControl()]
    [ToolboxBitmap(typeof(ListBox))]
    [DefaultEvent("Click")]
    public partial class LmFiltroMultiSelecao : LmUserControl
    {
        #region Construtor

        public LmFiltroMultiSelecao()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            this.DoubleBuffered = true;
        }

        #endregion

        public delegate void ListChanged(object sender, EventArgs e);
        public event ListChanged SelectedValuesChanged;

        public List<ColunaGridMultiselecao> _items = new List<ColunaGridMultiselecao>();
        public List<int> _idSelecionados = new List<int>();

        public void CarregarFiltro(List<ColunaGridMultiselecao> CmbDados)
        {
            _items = CmbDados;
            SetarValores();
        }

        private void Txt_MouseEnter(object sender, EventArgs e)
        {
            if (_items.Count > 0)
            {
                FrmCaixaMultiselecao frm = new FrmCaixaMultiselecao(_items);
                Rectangle areaTrabalho = Screen.GetWorkingArea(this);

                var ptScreen = this.PointToScreen(Point.Empty);
                ptScreen.Y += this.Height;

                bool paraBaixo = areaTrabalho.Bottom - ptScreen.Y < ptScreen.Y ? false : true;

                int ladoMaior = (areaTrabalho.Bottom - ptScreen.Y) < ptScreen.Y ? ptScreen.Y : areaTrabalho.Bottom - ptScreen.Y;
                int ladoMenor = ladoMaior == ptScreen.Y ? areaTrabalho.Bottom - ptScreen.Y : ptScreen.Y;

                ladoMaior -= 50;

                int cmbHeight = 4;
                foreach (DataGridViewRow r in frm.dgv.Rows)
                    if (cmbHeight < ladoMaior)
                        cmbHeight += r.Height;
                    else break;

                frm.Height = cmbHeight;
                frm.Width = this.Width;

                int posX = ptScreen.X;
                int posY = ptScreen.Y;

                if (paraBaixo || (!paraBaixo && ladoMenor > frm.Height))
                {
                    posY -= this.Height;
                }
                else if (!paraBaixo)
                {
                    posY -= frm.Height;
                }

                frm.Location = new Point(posX, posY);

                frm.SelectedValuesChanged += Frm_SelectedValuesChanged;
                frm.ShowDialog();
            }
        }

        private void Frm_SelectedValuesChanged(object sender, EventArgs e)
        {
            SetarValores();
            SelectedValuesChanged?.Invoke(this, new EventArgs());
        }

        private void SetarValores()
        {
            _idSelecionados.Clear();
            string selecionados = string.Empty;
            foreach (var item in _items)
            {
                if (item.Select)
                {
                    _idSelecionados.Add(item.ID);

                    selecionados += item.Descricao + Environment.NewLine;
                }
            }

            if (selecionados.EndsWith(Environment.NewLine))
                selecionados = selecionados.Substring(0, selecionados.Length - 2);

            if (_items.Count == 0)
            {
                txt.Text = "Falta Dados acionar Infra";
                txt.IconToolTipText = "Dados não Carregados no Filtro";
            }
            else if (_idSelecionados.Count == 1)
            {
                txt.Text = selecionados;
                txt.IconToolTipText = "Filtro Multiseleção";
            }
            else if (_idSelecionados.Count > 1 && _idSelecionados.Count == _items.Count)
            {
                txt.Text = "Todos";
                txt.IconToolTipText = selecionados;
            }
            else if (_idSelecionados.Count > 1)
            {
                txt.Text = "Selecionados";
                txt.IconToolTipText = selecionados;
            }
            else
            {
                txt.Text = "Nenhum Selecionado";
                txt.IconToolTipText = selecionados;
            }
        }
    }
}
