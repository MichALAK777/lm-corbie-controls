using LmCorbieUI.Design;
using LmCorbieUI.Metodos;
using LmCorbieUI.Metodos.AtributosCustomizados;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Linq;
using System.Collections.Generic;
using LmCorbieUI.Interfaces;

namespace LmCorbieUI.Controls
{
    public struct RodapeTotal
    {
        public string NomeColuna { get; set; }
        public LmValueType TipoValor { get; set; }
        public string Valor { get; set; }

        public string ToolTipColuna { get; set; }
        public bool CalcularMedia { get; set; }
        public bool IgnorarNulosEZerosNaMedia { get; set; }
        public int NumerosRegistros { get; set; }
        public double SomaParaMedia { get; set; }
    }

    [ProvideToolboxControl()]
    [ToolboxBitmap(typeof(DataGridView))]
    [DefaultEvent("Click")]
    [Designer(typeof(Design.LmDataGridViewDesign))]
    public partial class LmDataGridView : UserControl, ILmControl
    {
        const string setaCima = "▲  ";
        const string setaBaix = "▼  ";

        #region Construtor

        public LmDataGridView()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);

            BackColor = LmCor.Bc_Form;// LmPaint.BackColor.Form(Grid.Theme);

            var clrTmp = lnkCsv.Enabled ? LmCor.Br_Normal : Color.Red;
            lnkCsv.Image = lnkCsv.Image.ApplyColor(clrTmp);
            lnkPdf.Image = lnkPdf.Image.ApplyColor(clrTmp);
            lnkImprimir.Image = lnkImprimir.Image.ApplyColor(clrTmp);
            lnkResraurarGrid.Image = lnkResraurarGrid.Image.ApplyColor(clrTmp);
            lnkColunas.Image = lnkColunas.Image.ApplyColor(clrTmp);
        }

        #endregion

        #region Interface

        [Category(LmDefault.PropertyCategory.LmUI)]
        public event EventHandler<LmPaintEventArgs> CustomPaintBackground;
        protected virtual void OnCustomPaintBackground(LmPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintBackground != null)
            {
                CustomPaintBackground(this, e);
            }
        }

        [Category(LmDefault.PropertyCategory.LmUI)]
        public event EventHandler<LmPaintEventArgs> CustomPaint;
        protected virtual void OnCustomPaint(LmPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaint != null)
            {
                CustomPaint(this, e);
            }
        }

        [Category(LmDefault.PropertyCategory.LmUI)]
        public event EventHandler<LmPaintEventArgs> CustomPaintForeground;
        protected virtual void OnCustomPaintForeground(LmPaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint) && CustomPaintForeground != null)
            {
                CustomPaintForeground(this, e);
            }
        }

        private bool useCustomBackColor = false;
        [DefaultValue(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public bool UseCustomBackColor
        {
            get { return useCustomBackColor; }
            set { useCustomBackColor = value; }
        }

        private bool useCustomForeColor = false;
        [DefaultValue(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public bool UseCustomForeColor
        {
            get { return useCustomForeColor; }
            set { useCustomForeColor = value; }
        }

        private bool useStyleColors = false;
        [DefaultValue(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        public bool UseStyleColors
        {
            get { return useStyleColors; }
            set { useStyleColors = value; }
        }

        [Browsable(false)]
        [Category(LmDefault.PropertyCategory.LmUI)]
        [DefaultValue(false)]
        public bool UseSelectable
        {
            get { return GetStyle(ControlStyles.Selectable); }
            set { SetStyle(ControlStyles.Selectable, value); }
        }

        #endregion

        #region Fields

        private LmTextBoxSize lmTextBoxSize = LmTextBoxSize.Medium;
        [DefaultValue(LmTextBoxSize.Medium)]

        public LmTextBoxSize FontSize
        {
            get { return lmTextBoxSize; }
            set
            {
                lmTextBoxSize = value;
                Grid.FontSize = value;
                Refresh();
            }
        }

        private LmTextBoxWeight lmTextBoxWeight = LmTextBoxWeight.Regular;
        [DefaultValue(LmTextBoxWeight.Regular)]

        public LmTextBoxWeight FontWeight
        {
            get { return lmTextBoxWeight; }
            set
            {
                lmTextBoxWeight = value;
                Grid.FontWeight = value;
                Refresh();
            }
        }

        [Browsable(false)]
        public string PosColunasGrid { get; set; } = "";
        private string PosColunasGridDefault { get; set; } = "";

        [Browsable(false)]
        public string ColunaOrdenacaoGrid { get; set; } = "";

        [Browsable(false)]
        public string ColunasOcultasGrid { get; set; } = "";

        [Browsable(false)]
        public string ColunasOcultasImpressGrid { get; set; } = "";

        [Browsable(false)]
        public string ColunasBloqueadasGrid { get; set; } = "";

        [Browsable(false)]
        public string TituloRelatorio { get; set; } = "";

        public string Texto { get; set; } = "";

        private bool enabledCsvButton = true;
        public bool EnabledCsvButton
        {
            get { return enabledCsvButton; }
            set
            {
                enabledCsvButton = value;

                if (enabledCsvButton)
                {
                    lnkCsv.Enabled = true;
                    lnkCsv.Image = lnkCsv.Image.ApplyColor(LmCor.Br_Normal);
                }
                else
                {
                    lnkCsv.Enabled = false;
                    lnkCsv.Image = lnkCsv.Image.ApplyColor(LmCor.Br_Disabled);
                }
            }
        }

        private bool enabledPdfButton = true;
        public bool EnabledPdfButton
        {
            get { return enabledPdfButton; }
            set
            {
                enabledPdfButton = value;

                if (enabledPdfButton)
                {
                    lnkPdf.Enabled = true;
                    lnkPdf.Image = lnkPdf.Image.ApplyColor(LmCor.Br_Normal);
                }
                else
                {
                    lnkPdf.Enabled = false;
                    lnkPdf.Image = lnkPdf.Image.ApplyColor(LmCor.Br_Disabled);
                }
            }
        }

        private bool enabledPrintButton = true;
        [Browsable(false)]
        public bool EnabledPrintButton
        {
            get { return enabledPrintButton; }
            set
            {
                enabledPrintButton = value;

                if (enabledPrintButton)
                {
                    lnkImprimir.Enabled = true;
                    lnkImprimir.Image = lnkImprimir.Image.ApplyColor(LmCor.Br_Normal);
                }
                else
                {
                    lnkImprimir.Enabled = false;
                    lnkImprimir.Image = lnkImprimir.Image.ApplyColor(LmCor.Br_Disabled);
                }
            }
        }

        private bool enabledHideColumnsButton = true;
        public bool EnabledHideColumnsButton
        {
            get { return enabledHideColumnsButton; }
            set
            {
                enabledHideColumnsButton = value;

                if (enabledHideColumnsButton)
                {
                    lnkColunas.Enabled = true;
                    lnkColunas.Image = lnkColunas.Image.ApplyColor(LmCor.Br_Normal);
                }
                else
                {
                    lnkColunas.Enabled = false;
                    lnkColunas.Image = lnkColunas.Image.ApplyColor(LmCor.Br_Disabled);
                }
            }
        }

        private bool enabledRefreshButton = true;

        public bool EnabledRefreshButton
        {
            get { return enabledRefreshButton; }
            set
            {
                enabledRefreshButton = value;

                if (enabledRefreshButton)
                {
                    lnkResraurarGrid.Enabled = true;
                    lnkResraurarGrid.Image = lnkResraurarGrid.Image.ApplyColor(LmCor.Br_Normal);
                }
                else
                {
                    lnkResraurarGrid.Enabled = false;
                    lnkResraurarGrid.Image = lnkResraurarGrid.Image.ApplyColor(LmCor.Br_Disabled);
                }
            }
        }

        private bool enabledFind = true;
        public bool EnabledFind
        {
            get { return enabledFind; }
            set
            {
                enabledFind = value;

                if (enabledFind)
                    txtProcurar.Enabled = true;
                else
                    txtProcurar.Enabled = false;
            }
        }

        private RodapeTotal[] rodapeColunasTotal = null;
        [Browsable(false)]
        private RodapeTotal[] RodapeColunasTotal
        {
            get { return rodapeColunasTotal; }
            set
            {
                rodapeColunasTotal = value;
            }
        }

        private bool mostrarTotalizador = false;
        public bool MostrarTotalizador
        {
            get { return mostrarTotalizador; }
            set
            {
                mostrarTotalizador = value;

                if (!mostrarTotalizador)
                {
                    Grid.ScrollBars = ScrollBars.Both;
                    flpRodape.Visible = false;
                }
                else
                {
                    Grid.ScrollBars = ScrollBars.Vertical;
                    flpRodape.Visible = true;
                }

                DefinirTamanhoGrid_e_Rodape();
            }
        }


        private bool mostrarRodapeBotoes = true;
        public bool MostrarRodapeBotoes
        {
            get { return mostrarRodapeBotoes; }
            set
            {
                mostrarRodapeBotoes = value;

                if (!mostrarRodapeBotoes)
                {
                    flpBotoes.Visible = false;
                }
                else
                {
                    flpBotoes.Visible = true;
                }
            }
        }

        public string Botao1Texto { get; set; } = "";
        public string Botao2Texto { get; set; } = "";
        public int Botao1Largura { get; set; } = 100;
        public int Botao2Largura { get; set; } = 100;
        public bool PermiteOrdenarLinhas { get; set; } = true;
        public bool PermiteOrdenarColunas { get; set; } = true;
        public bool PermiteQuebrarLinhaCabecalho { get; set; } = false;
        public bool PermiteSelecaoMultipla { get; set; } = false;
        public bool PermiteDimensionarColuna { get; set; } = true;
        public bool PermiteAutoDimensionarLinha { get; set; } = false;
        public bool LimparSelecaoAposCarregar { get; set; } = false;

        /// <summary>
        /// Mostra a Mensagem no Grid Caso não retorne registro na Pesquisa
        /// </summary>
        //public bool MostrarMensagemNoGrid { get; set; } = true;

        #endregion

        #region Overridden Methods

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                Color backColor = backColor = LmCor.Bc_Form;//LmPaint.BackColor.Form(Theme);

                if (backColor.A == 255 && BackgroundImage == null)
                {
                    e.Graphics.Clear(backColor);
                    return;
                }

                base.OnPaintBackground(e);

                OnCustomPaintBackground(new LmPaintEventArgs(backColor, Color.Empty, e.Graphics));
            }
            catch
            {
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (GetStyle(ControlStyles.AllPaintingInWmPaint))
                {
                    OnPaintBackground(e);
                }

                OnCustomPaint(new LmPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
                OnPaintForeground(e);
            }
            catch
            {
                Invalidate();
            }
        }

        protected virtual void OnPaintForeground(PaintEventArgs e)
        {
            OnCustomPaintForeground(new LmPaintEventArgs(Color.Empty, Color.Empty, e.Graphics));
        }

        #endregion

        #region Eventos

        public delegate void TxtChange(object sender, EventArgs e);
        public delegate void GridEvent(object sender, EventArgs e);
        public delegate void CellEvent(object sender, DataGridViewCellEventArgs e);
        public delegate void KeyEvent(object sender, KeyEventArgs e);
        public delegate void MouseEvent(object sender, MouseEventArgs e);
        public delegate void RowEvent(object sender, EventArgs e);

        public event TxtChange ProcurarTextChanged;
        public event CellEvent CellEnter;
        public event CellEvent CellDoubleClick;
        public event CellEvent CellClick;
        public event CellEvent CellButton1Click;
        public event CellEvent CellButton2Click;
        public event CellEvent CellValueChanged;
        public event KeyEvent KeyDowm;
        public event MouseEvent MouseDownGrid;
        public event GridEvent Sorted;
        public event RowEvent RowIndexChanged;
        public event GridEvent SalvarConfiguracao;

        private void LmDataGridView_Load(object sender, EventArgs e)
        {
            this.Grid.UpdateStyleGrid();
        }

        private void Grid_Enter(object sender, EventArgs e)
        {
            ((Control)sender).SetLastFocusedControl();
        }

        internal void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CellEnter?.Invoke(sender, e);

            Invoke(new MethodInvoker(delegate ()
            {
                this.lblTotal.Text = $"Registro {Grid.CurrentRow.Index + 1} de {Grid.RowCount}";
            }));
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CellDoubleClick?.Invoke(sender, e);
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick?.Invoke(sender, e);

            try
            {
                if (Grid.CurrentCell != null && e.RowIndex != -1 && e.ColumnIndex == Grid.Columns["btn1"].Index)
                    CellButton1Click?.Invoke(sender, e);
            }
            catch (Exception)
            {
            }

            try
            {
                if (Grid.CurrentCell != null && e.RowIndex != -1 && e.ColumnIndex == Grid.Columns["btn2"].Index)
                    CellButton2Click?.Invoke(sender, e);
            }
            catch (Exception)
            {
            }

            try
            {
                if (e.RowIndex == -1 && this.PermiteOrdenarLinhas)
                {
                    if (Grid.Columns[e.ColumnIndex].ValueType == typeof(Bitmap))
                        return;

                    Grid.CellMouseUp -= Grid_CellMouseUp;
                    this.ShowMsgGrid("Ordenando Grid, Aguarde...");

                    if (string.IsNullOrEmpty(ColunaOrdenacaoGrid))
                    {
                        Grid.Sort(Grid.Columns[e.ColumnIndex], ListSortDirection.Ascending);
                    }
                    else
                    {
                        short sortDir = Convert.ToInt16(ColunaOrdenacaoGrid.Split('^')[1]);
                        int sortIndexColumn = Grid.Columns[ColunaOrdenacaoGrid.Split('^')[0]].Index;

                        if (sortIndexColumn != e.ColumnIndex)
                        {
                            Grid.Sort(Grid.Columns[e.ColumnIndex], ListSortDirection.Ascending);
                        }
                        else
                        {
                            Grid.Sort(Grid.Columns[e.ColumnIndex], sortDir == 0 ? ListSortDirection.Descending : ListSortDirection.Ascending);
                        }
                    }

                    Grid_Sorting(sender, e);

                    tmrInternal.Tag = -1;

                    this.Invalidate();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.CloseMsgGrid();
                Grid.CellMouseUp += Grid_CellMouseUp;
            }
        }

        private void Grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (MostrarTotalizador)
                {
                    foreach (DataGridViewColumn cln in Grid.Columns)
                        if (flpRodape.Controls.ContainsKey("rdp" + cln.Name))
                            flpRodape.Controls["rdp" + cln.Name].Width = cln.Width;

                    System.Threading.Thread t = new System.Threading.Thread(() =>
                    {
                        AtualizarScroll();
                        DefinirTamanhoGrid_e_Rodape();
                    })
                    { IsBackground = true };
                    t.Start();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.CloseMsgGrid();
            }
        }

        private void Grid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    PosColunasGrid = OrdemAtualColunas();

                    System.Threading.Thread th = new System.Threading.Thread(() =>
                    {
                        AtualizarRotuloSomatorio();
                    })
                    { IsBackground = true };
                    th.Start();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CellValueChanged?.Invoke(sender, e);
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDowm?.Invoke(sender, e);
        }

        private void Grid_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownGrid?.Invoke(sender, e);
        }

        private void TxtProcurar_TextChanged(object sender, EventArgs e)
        {
            if (tmrInicioLocalizar.Enabled == false)
                tmrInicioLocalizar.Enabled = true;
            else
                tmrInicioLocalizar.Tag = 0;
        }

        private void TxtProcurar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IniciarLocalizar();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtProcurar.Text = string.Empty;
                IniciarLocalizar();
            }
        }

        private void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && !string.IsNullOrEmpty(ColunaOrdenacaoGrid) &&
                Grid.Columns[ColunaOrdenacaoGrid.Split('^')[0]] != null &&
                e.ColumnIndex == Grid.Columns[ColunaOrdenacaoGrid.Split('^')[0]].Index)
            {
                Color clnSorted = Color.FromArgb(220, LmCor.Bc_Dgv_Header);

                LinearGradientBrush gb = new LinearGradientBrush(e.CellBounds, clnSorted, clnSorted, 90, true);

                e.Graphics.FillRectangle(gb, e.CellBounds);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
            else if (e.RowIndex == -1 && this.RectangleToScreen(e.CellBounds).Contains(MousePosition))
            {
                Color clnSorted = Color.FromArgb(240, LmCor.Bc_Dgv_Header);

                var r = e.CellBounds;
                r.X += 1;
                r.Width -= 2;
                LinearGradientBrush gb = new LinearGradientBrush(r, clnSorted, clnSorted, 90, true);

                e.Graphics.FillRectangle(gb, r);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
        }

        private void Grid_Sorting(object sender, DataGridViewCellEventArgs e)
        {
            ListSortDirection direction = Grid.Columns[e.ColumnIndex].HeaderText.Contains(setaCima) ? ListSortDirection.Descending : ListSortDirection.Ascending;
            ColunaOrdenacaoGrid = Grid.Columns[e.ColumnIndex].Name + "^" + ((int)direction).ToString();

            System.Threading.Thread t1 = new System.Threading.Thread(() =>
            {
                PersonalizarGridSorted();
            })
            { IsBackground = true };
            t1.Start();

            //Grid.SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None; // teste seta ocultar coluna alinhada

            System.Threading.Thread t2 = new System.Threading.Thread(() =>
            {
                FormatarCorFonteData();
            })
            { IsBackground = true };
            t2.Start();

            if (flpRodape.Visible)
                AtualizarScroll();

            Sorted?.Invoke(sender, e);
        }

        private void TmrInicioLocalizar_Tick(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Timer)sender).Tag = Convert.ToInt32(((System.Windows.Forms.Timer)sender).Tag) + 1;
            if (Convert.ToInt32(((System.Windows.Forms.Timer)sender).Tag) > 5)
                IniciarLocalizar();
        }

        private void LnkCsv_Click(object sender, EventArgs e)
        {
            Controles.ConvertGridToCSV(this);
        }

        private void LnkPdf_Click(object sender, EventArgs e)
        {
            Controles.ImprimirDGV(lnkPdf, this, Text, InfoDefaultUI.UsuarioLogado_Login, InfoDefaultUI.DadosEmpresa, InfoDefaultUI.LogoEmpresa,
                TituloRelatorio, ColunasOcultasImpressGrid, true, out string colunasOcultas);

            //ColunasOcultasImpressGrid = colunasOcultas;
        }

        private void LnkImprimir_Click(object sender, EventArgs e)
        {
            Controles.ImprimirDGV(lnkPdf, this, Text, InfoDefaultUI.UsuarioLogado_Login, InfoDefaultUI.DadosEmpresa, InfoDefaultUI.LogoEmpresa,
                TituloRelatorio, ColunasOcultasImpressGrid, false, out string colunasOcultas);

            ColunasOcultasImpressGrid = colunasOcultas;
        }

        private void LnkColunas_Click(object sender, EventArgs e)
        {
            FrmConfigGeralGrid frm = new FrmConfigGeralGrid(this);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PosColunasGrid = OrdemAtualColunas();

                SalvarConfiguracao?.Invoke(Grid, new EventArgs());

                System.Threading.Thread th = new System.Threading.Thread(() =>
                {
                    AtualizarRotuloSomatorio();
                })
                { IsBackground = true };
                th.Start();
            }
        }

        public void LnkResraurarGrid_Click(object sender, EventArgs e)
        {
            PosColunasGrid = PosColunasGridDefault;
            ColunaOrdenacaoGrid = ColunasOcultasGrid = ColunasOcultasImpressGrid = string.Empty;

            ReposicionarColunasGrid(ColunasBloqueadasGrid);
            CloseMsgGrid();
        }

        private void TmrInternal_Tick(object sender, EventArgs e)
        {
            tmrInternal.Enabled = false;

            try
            {
                if (Grid.CurrentRow != null && Grid.CurrentRow.Index != Convert.ToInt32(tmrInternal.Tag))
                {
                    tmrInternal.Tag = Grid.CurrentRow.Index;
                    RowIndexChanged?.Invoke(Grid.CurrentRow, new EventArgs());
                }
                else if (Grid.CurrentRow == null && Convert.ToInt32(tmrInternal.Tag) > -1)
                {
                    tmrInternal.Tag = -1;
                    RowIndexChanged?.Invoke(Grid.CurrentRow, new EventArgs());
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                tmrInternal.Enabled = true;
            }
        }

        private void Ptb_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                ((PictureBox)sender).Image = ((PictureBox)sender).Image.ApplyColor(LmCor.Br_Selected);
            }
            catch (Exception ex)
            {

            }
        }

        private void Ptb_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                ((PictureBox)sender).Image = ((PictureBox)sender).Image.ApplyColor(LmCor.Br_Normal);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Metodos Publicos

        public void MontarGrid<T>() where T : class, new()
        {
            this.Grid.DataSource = new SortableBindingList<T>();
            FormatarGrid<T>(false);
            System.Threading.Thread t1 = new System.Threading.Thread(() =>
            {
                PersonalizarGridSorted();
            })
            { IsBackground = true };
            t1.Start();

        }

        public void CarregarGrid<T>(SortableBindingList<T> sortableList) where T : class, new()
        {
            int rowIndex = Grid.CurrentRow != null ? Grid.CurrentRow.Index : 0;
            int posScroll = Grid.HorizontalScrollingOffset;

            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    if (this.Grid.Columns.Contains("btn1"))
                        this.Grid.Columns.RemoveAt(this.Grid.Columns["btn1"].Index);
                    if (this.Grid.Columns.Contains("btn2"))
                        this.Grid.Columns.RemoveAt(this.Grid.Columns["btn2"].Index);
                }));

                Invoke(new MethodInvoker(delegate ()
                {
                    lblTotal.Visible =
                    lblSep3.Visible = false;

                    lblTotal.Refresh();
                    lblSep3.Refresh();

                    Color colorDefault = LmCor.Bc_Dgv_CellNormal;
                    Color colorSelected = LmCor.Bc_Dgv_CellSelected;

                    colorDefault = colorDefault.Escurecer(20);
                    colorSelected = colorSelected.Escurecer(20);

                    if (string.IsNullOrEmpty(txtProcurar.Text))
                    {
                        ShowMsgGrid("Carregando Grid. Aguarde...");

                        this.Grid.DataSource = sortableList;

                        FormatarGrid<T>(true);

                        CloseMsgGrid();

                        System.Threading.Thread t = new System.Threading.Thread(() =>
                        {
                            CalcularSomatorio(sortableList);
                        })
                        { IsBackground = true };
                        t.Start();
                    }
                    else
                    {
                        SortableBindingList<T> novaLista = new SortableBindingList<T>();

                        bool valorEncontrado = false;

                        foreach (var w_oB in sortableList)
                        {
                            valorEncontrado = false;
                            foreach (PropertyInfo pro in w_oB.GetType().GetProperties()
                                .Where(p => p.GetCustomAttribute(typeof(BrowsableAttribute)) == null).ToList())
                            {
                                if (Convert.ToString(pro.GetValue(w_oB)).RemoverCaracteresEspeciais().ToUpper().Contains(txtProcurar.Text.RemoverCaracteresEspeciais().ToUpper()))
                                {
                                    valorEncontrado = true;
                                    break;
                                }
                            }

                            if (valorEncontrado)
                                novaLista.Add(w_oB);
                        }

                        ShowMsgGrid("Carregando Grid. Aguarde...");

                        this.Grid.DataSource = novaLista;

                        FormatarGrid<T>(true);

                        CloseMsgGrid();

                        if (novaLista.Count > 0)
                        {
                            foreach (DataGridViewRow row in this.Grid.Rows)
                            {
                                foreach (DataGridViewCell cel in row.Cells)
                                {
                                    if (Convert.ToString(cel.Value).RemoverCaracteresEspeciais().ToUpper().Contains(txtProcurar.Text.RemoverCaracteresEspeciais().ToUpper()))
                                    {
                                        cel.Style.BackColor = colorDefault;
                                        cel.Style.SelectionBackColor = colorSelected;
                                    }
                                }
                            }

                            System.Threading.Thread t = new System.Threading.Thread(() =>
                            {
                                CalcularSomatorio(novaLista);
                            })
                            { IsBackground = true };
                            t.Start();
                        }
                    }
                }));

                Invoke(new MethodInvoker(delegate ()
                {
                    lblTotal.Visible =
                    lblSep3.Visible = true;

                    lblTotal.Refresh();
                    lblSep3.Refresh();

                    if (this.Grid.RowCount > 0)
                    {
                        int colIndex = 0;

                        if (rowIndex > this.Grid.RowCount - 1)
                            rowIndex = this.Grid.RowCount - 1;

                        while (!this.Grid.Rows[0].Cells[colIndex].Visible || colIndex >= 100)
                            colIndex++;

                        if (colIndex < 100)
                        {
                            this.Grid.Rows[rowIndex].Cells[colIndex].Selected = true;

                            this.Dgv_CellEnter(this.Grid, new DataGridViewCellEventArgs(colIndex, rowIndex));

                            RowIndexChanged?.Invoke(Grid.CurrentRow, new EventArgs());
                        }

                        if (LimparSelecaoAposCarregar)
                        {
                            Grid.ClearSelection();
                        }

                        Grid.HorizontalScrollingOffset = posScroll;

                        System.Threading.Thread t1 = new System.Threading.Thread(() =>
                        {
                            PersonalizarGridSorted();
                        })
                        { IsBackground = true };
                        t1.Start();

                        System.Threading.Thread t = new System.Threading.Thread(() =>
                        {
                            FormatarCorFonteData();
                        })
                        { IsBackground = true };
                        t.Start();
                    }
                    else
                    {
                        lblTotal.Text = "Registro 0 de 0";
                    }

                    GC.Collect();
                }));
            }
            catch (ObjectDisposedException ex)
            {

            }
            catch (InvalidOperationException ex)
            {

            }
            catch (Exception ex)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    LmException.ShowException(ex, "Erro ao Pesquisar");
                }));
            }
            finally
            {
            }
        }

        private string OrdemAtualColunas()
        {
            SortableBindingList<string> lista = GetColumList();

            string posicaoColunasGrid = "";

            foreach (var item in lista)
                posicaoColunasGrid += $"{item}^";

            if (posicaoColunasGrid.EndsWith("^"))
                posicaoColunasGrid = posicaoColunasGrid.Substring(0, posicaoColunasGrid.Length - 1);

            return posicaoColunasGrid;
        }

        public void ShowMsgGrid(string msg = "Aguarde...")
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    lblMessage.Top = Grid.ColumnHeadersHeight + 1;

                    lblMessage.Height = Grid.DisplayRectangle.Height - lblMessage.Top;
                    lblMessage.Width = Grid.DisplayRectangle.Width;

                    this.lblMessage.Text = msg;
                    this.lblMessage.Visible = true;
                    this.lblMessage.Refresh();
                }));
            }
            catch (Exception ex)
            {
            }
        }

        public void CloseMsgGrid()
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    this.lblMessage.Text = string.Empty;
                    this.lblMessage.Visible = false;
                    this.lblMessage.Refresh();
                }));
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Metodos Privados

        private void FormatarGrid<T>(bool naConsulta)
        {
            try
            {
                if (DesignMode) return;

                Type tipoObjeto = typeof(T);
                PosColunasGridDefault = string.Empty;
                short displayIndex = 0;

                var colunasOcultasGrid = !string.IsNullOrEmpty(ColunasOcultasGrid) || !string.IsNullOrEmpty(ColunasBloqueadasGrid) ? ColunasOcultasGrid + "^" + ColunasBloqueadasGrid : "";

                if (!string.IsNullOrEmpty(Botao1Texto) || !string.IsNullOrEmpty(Botao2Texto))
                {
                    var tamanhoTexto = Botao1Texto.Length;

                    if (tamanhoTexto < Botao2Texto.Length)
                        tamanhoTexto = Botao2Texto.Length;

                    if (!string.IsNullOrEmpty(Botao1Texto))
                    {
                        DataGridViewButtonColumn ColumnAlt = new DataGridViewButtonColumn
                        {
                            Name = "btn1",
                            HeaderText = "",
                            Text = Botao1Texto,
                            UseColumnTextForButtonValue = true,
                            ReadOnly = true,
                            Width = Botao1Largura,
                        };

                        this.Grid.Columns.Add(ColumnAlt);
                    }

                    if (!string.IsNullOrEmpty(Botao2Texto))
                    {
                        DataGridViewButtonColumn ColumnExcl = new DataGridViewButtonColumn
                        {
                            Name = "btn2",
                            HeaderText = "",
                            Text = Botao2Texto,
                            UseColumnTextForButtonValue = true,
                            ReadOnly = true,
                            Width = Botao2Largura,
                        };

                        this.Grid.Columns.Add(ColumnExcl);
                    }
                }

                PropertyInfo[] props = tipoObjeto.GetProperties();

                foreach (PropertyInfo pro in props.ToList())
                {
                    BrowsableAttribute atbBrowsable = (BrowsableAttribute)pro.GetCustomAttribute(typeof(BrowsableAttribute));
                    if (atbBrowsable != null && atbBrowsable.Browsable == false) continue;

                    string name = pro.Name;
                    int width = 0;

                    AlinhamentoColunaGrid atbAlinhamento = (AlinhamentoColunaGrid)pro.GetCustomAttribute(typeof(AlinhamentoColunaGrid));
                    if (atbAlinhamento != null)
                    {
                        this.Grid.Columns[pro.Name].HeaderCell.Style.Alignment =
                        this.Grid.Columns[pro.Name].DefaultCellStyle.Alignment = atbAlinhamento.Alinhamento;
                    }

                    LarguraColunaGrid atbLarg = (LarguraColunaGrid)pro.GetCustomAttribute(typeof(LarguraColunaGrid));
                    if (atbLarg != null && this.Grid.Columns != null && this.Grid.Columns.Count > 0)
                    {
                        width = atbLarg.LarguraColuna;

                        if (atbLarg.LarguraColuna > 0)
                            this.Grid.Columns[pro.Name].Width = atbLarg.LarguraColuna;
                        else
                            this.Grid.Columns[pro.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    ToolTipGrid atbToolTip = (ToolTipGrid)pro.GetCustomAttribute(typeof(ToolTipGrid));
                    if (atbToolTip != null && !string.IsNullOrEmpty(atbToolTip.Texto))
                        this.Grid.Columns[pro.Name].ToolTipText = atbToolTip.Texto;

                    Formatacao atbFormatar = (Formatacao)pro.GetCustomAttribute(typeof(Formatacao));

                    if (atbFormatar != null && !string.IsNullOrEmpty(atbFormatar.formatacao))
                        this.Grid.Columns[pro.Name].DefaultCellStyle.Format = atbFormatar.formatacao;

                    EhLink ehLink = (EhLink)pro.GetCustomAttribute(typeof(EhLink));
                    if (ehLink != null)
                    {
                        Color clrLink = Color.FromArgb(70, 110, 255);

                        this.Grid.Columns[pro.Name].ValueType = typeof(LinkArea);
                        this.Grid.Columns[pro.Name].DefaultCellStyle.ForeColor = clrLink;
                        this.Grid.Columns[pro.Name].DefaultCellStyle.SelectionForeColor = clrLink;
                        this.Grid.Columns[pro.Name].DefaultCellStyle.Font = new System.Drawing.Font(this.Grid.Font, FontStyle.Underline);
                    }

                    NaoImprimirColunaNoGrid naoImprimirColuna = (NaoImprimirColunaNoGrid)pro.GetCustomAttribute(typeof(NaoImprimirColunaNoGrid));
                    if (naoImprimirColuna != null)
                    {
                        this.ColunasBloqueadasGrid += !this.ColunasBloqueadasGrid.Contains(pro.Name) ? "^" + pro.Name : "";
                        colunasOcultasGrid += "^" + pro.Name;
                    }

                    this.Grid.Columns[pro.Name].SortMode = DataGridViewColumnSortMode.NotSortable;

                    PosColunasGridDefault += $"{name}|{displayIndex}|{width}^";
                    displayIndex++;
                }

                if (PosColunasGridDefault.EndsWith("^"))
                    PosColunasGridDefault = PosColunasGridDefault.Substring(0, PosColunasGridDefault.Length - 1);

                this.Grid.ColumnHeadersDefaultCellStyle.WrapMode = PermiteQuebrarLinhaCabecalho ? DataGridViewTriState.True : DataGridViewTriState.False;

                this.Grid.AllowUserToOrderColumns = PermiteOrdenarColunas;

                this.Grid.AllowUserToResizeColumns = PermiteDimensionarColuna;

                this.Grid.MultiSelect = PermiteSelecaoMultipla;

                this.Grid.RowsDefaultCellStyle.WrapMode = PermiteAutoDimensionarLinha
                    ? DataGridViewTriState.True
                    : DataGridViewTriState.False;

                this.Grid.AutoSizeRowsMode = PermiteAutoDimensionarLinha
                    ? DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders :
                    DataGridViewAutoSizeRowsMode.None;

                Object obj = Activator.CreateInstance(typeof(T));

                rodapeColunasTotal = new RodapeTotal[obj.GetType().GetProperties()
                    .Where(p => p.GetCustomAttribute(typeof(CalcularTotal)) != null).Count()];

                short pos = 0;
                foreach (PropertyInfo pro in obj.GetType().GetProperties().ToList()
                    .Where(p => p.GetCustomAttribute(typeof(CalcularTotal)) != null))
                {
                    var atbCalculoTotal = (CalcularTotal)pro.GetCustomAttribute(typeof(CalcularTotal));
                    RodapeColunasTotal[pos] = new RodapeTotal
                    {
                        NomeColuna = pro.Name,
                        TipoValor = atbCalculoTotal.TipoValor,
                        CalcularMedia = atbCalculoTotal.CalcularMedia,
                        IgnorarNulosEZerosNaMedia = atbCalculoTotal.IgnorarNulosEZerosNaMedia,
                        ToolTipColuna = atbCalculoTotal.ToolTipColuna,
                    };
                    pos++;
                }

                ReposicionarColunasGrid(colunasOcultasGrid);

                if (naConsulta)
                {
                    System.Threading.Thread t = new System.Threading.Thread(() =>
                    {
                        CriarRotuloSomatorio();
                    })
                    { IsBackground = true };
                    t.Start();
                }
                else
                {
                    CriarRotuloSomatorio();
                }
            }
            catch (Exception ex)
            {
                LmException.ShowException(ex, $"Erro ao Formatar Grid '{this.Name}'");
            }
        }

        private void IniciarLocalizar()
        {
            tmrInicioLocalizar.Tag = 0;
            tmrInicioLocalizar.Enabled = false;

            ProcurarTextChanged?.Invoke(txtProcurar, new EventArgs());
        }

        private void DefinirTamanhoGrid_e_Rodape()
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    if (flpRodape.HorizontalScroll.Visible)
                        flpRodape.Height = 18 + 17;
                    else
                        flpRodape.Height = 18;

                    flpRodape.BackColor =
                        Grid.ColumnHeadersDefaultCellStyle.BackColor;
                }));
            }
            catch (Exception)
            {
            }
        }

        private void ReposicionarColunasGrid(string colunasOcultas)
        {
            try
            {
                if (!string.IsNullOrEmpty(colunasOcultas))
                {
                    var splCln = colunasOcultas.Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (DataGridViewColumn cln in this.Grid.Columns)
                    {
                        if (splCln.Contains(cln.Name))
                            cln.Visible = false;
                        else
                            cln.Visible = true;
                    }
                }

                if (!string.IsNullOrEmpty(PosColunasGrid))
                {
                    var posicaoColunas = PosColunasGrid.Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in posicaoColunas)
                    {
                        try
                        {
                            string[] spl = item.Split('|');

                            string nomeColuna = spl[0];
                            int indiceColuna = Convert.ToInt16(spl[1]);
                            int larguraColuna = Convert.ToInt16(spl[2]);

                            if (this.Grid.Columns[nomeColuna] == null)
                                continue;

                            this.Grid.Columns[nomeColuna].DisplayIndex = indiceColuna;

                            if (this.Grid.Columns[nomeColuna].AutoSizeMode != DataGridViewAutoSizeColumnMode.Fill)
                                this.Grid.Columns[nomeColuna].Width = larguraColuna;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                this.Grid.Update();
                this.Grid.Refresh();
            }
            catch (Exception ex)
            {
                MsgBox.Show($"As colunas deste grid ({this.Grid.Parent?.Name})foram modificadas e a formatação será restaurada", "Nova Formatação do Grid",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SortableBindingList<string> GetColumList()
        {
            try
            {
                SortableBindingList<string> lista = new SortableBindingList<string>();

                foreach (DataGridViewColumn cln in Grid.Columns)
                    if (cln.Visible)
                        lista.Add($"{cln.Name}|{cln.DisplayIndex}|{cln.Width}");

                for (int i = 0; i < lista.Count; i++)
                {
                    for (int h = i + 1; h < lista.Count; h++)
                    {
                        int idxI = Convert.ToInt32(lista[i].Split('|')[1]);
                        int idxH = Convert.ToInt32(lista[h].Split('|')[1]);

                        if (idxI > idxH)
                        {
                            string strChange = lista[i];
                            lista[i] = lista[h];
                            lista[h] = strChange;
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                return new SortableBindingList<string>();
            }
        }

        private void CriarRotuloSomatorio()
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    if (MostrarTotalizador)
                    {
                        int posScroll = Grid.HorizontalScrollingOffset;
                        bool hScrollAtivo = Controles.HScrollAtivo(this.Grid);

                        flpRodape.Controls.Clear();
                        Control[] ls = new Control[Grid.Columns.Count];

                        foreach (DataGridViewColumn c in Grid.Columns)
                        {
                            var align = ContentAlignment.MiddleLeft;
                            switch (c.HeaderCell.Style.Alignment)
                            {
                                case DataGridViewContentAlignment.TopLeft:
                                align = ContentAlignment.MiddleLeft;
                                break;
                                case DataGridViewContentAlignment.TopCenter:
                                align = ContentAlignment.MiddleCenter;
                                break;
                                case DataGridViewContentAlignment.TopRight:
                                align = ContentAlignment.MiddleRight;
                                break;
                                case DataGridViewContentAlignment.MiddleLeft:
                                align = ContentAlignment.MiddleLeft;
                                break;
                                case DataGridViewContentAlignment.MiddleCenter:
                                align = ContentAlignment.MiddleCenter;
                                break;
                                case DataGridViewContentAlignment.MiddleRight:
                                align = ContentAlignment.MiddleRight;
                                break;
                                case DataGridViewContentAlignment.BottomLeft:
                                align = ContentAlignment.MiddleLeft;
                                break;
                                case DataGridViewContentAlignment.BottomCenter:
                                align = ContentAlignment.MiddleCenter;
                                break;
                                case DataGridViewContentAlignment.BottomRight:
                                align = ContentAlignment.MiddleRight;
                                break;
                                default:
                                break;
                            }

                            int width = c.Width;

                            ls[c.DisplayIndex] = new LmLabel()
                            {
                                FontWeight = LmLabelWeight.Regular,
                                Margin = new System.Windows.Forms.Padding(0, 0, 0, 0),
                                Name = "rdp" + c.Name,
                                Size = new System.Drawing.Size(width, 18),
                                FontSize = LmLabelSize.Small,
                                TabIndex = 0,
                                Text = "",
                                TextAlign = align,
                                //UseCustomForeColor = true,
                                Visible = c.Visible,
                                ForeColor = this.Grid.RowHeadersDefaultCellStyle.ForeColor,
                            };
                        }
                        flpRodape.Controls.AddRange(ls);

                        DefinirTamanhoGrid_e_Rodape();

                        if (posScroll > 0)
                            flpRodape.HorizontalScroll.Value = posScroll;

                        if (RodapeColunasTotal != null && RodapeColunasTotal.Count() > 0)
                        {
                            for (int i = 0; i < RodapeColunasTotal.Count(); i++)
                            {
                                var rdp = RodapeColunasTotal[i];
                                switch (rdp.TipoValor)
                                {
                                    case LmValueType.Num_Inteiro:
                                    {
                                        rdp.Valor = "0";
                                    }
                                    break;
                                    case LmValueType.Num_Real:
                                    {
                                        rdp.Valor = "0,00";
                                    }
                                    break;
                                    case LmValueType.Monetario:
                                    {
                                        rdp.Valor = "R$ 0,00";
                                    }
                                    break;
                                    case LmValueType.Data:
                                    {
                                        rdp.Valor = "";
                                    }
                                    break;
                                    case LmValueType.Hora:
                                    {
                                        rdp.Valor = "00:00";
                                    }
                                    break;
                                    default:
                                    break;
                                }

                                if (flpRodape.Controls.ContainsKey("rdp" + rdp.NomeColuna))
                                {
                                    if (!rdp.CalcularMedia)
                                        flpRodape.Controls["rdp" + rdp.NomeColuna].Text = rdp.Valor;
                                    else
                                        flpRodape.Controls["rdp" + rdp.NomeColuna].Text = "M=" + rdp.Valor;

                                    this.toolTip1.SetToolTip(flpRodape.Controls["rdp" + rdp.NomeColuna], rdp.ToolTipColuna);
                                }
                            }
                        }

                        flpRodape.Scroll += FlpRodape_Scroll;
                        flpRodape.MouseWheel += FlpRodape_MouseWheel;
                    }
                }));
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
            }
            catch (System.ArgumentNullException ex)
            {
            }
            catch (System.Exception ex)
            {
            }
        }

        private void CalcularSomatorio<T>(SortableBindingList<T> sortableList) where T : class, new()
        {
            try
            {
                if (MostrarTotalizador && RodapeColunasTotal != null)
                {
                    for (int i = 0; i < RodapeColunasTotal.Count(); i++)
                    {
                        var rdp = RodapeColunasTotal[i];
                        switch (rdp.TipoValor)
                        {
                            case LmValueType.Num_Inteiro:
                            {
                                RodapeColunasTotal[i].Valor = "0";
                            }
                            break;
                            case LmValueType.Num_Real:
                            {
                                RodapeColunasTotal[i].Valor = "0,00";
                            }
                            break;
                            case LmValueType.Monetario:
                            {
                                RodapeColunasTotal[i].Valor = "R$ 0,00";
                            }
                            break;
                            case LmValueType.Data:
                            {
                                RodapeColunasTotal[i].Valor = "";
                            }
                            break;
                            case LmValueType.Hora:
                            {
                                RodapeColunasTotal[i].Valor = "00:00";
                            }
                            break;
                            default:
                            break;
                        }

                        if (flpRodape.Controls.ContainsKey("rdp" + rdp.NomeColuna))
                        {
                            Invoke(new MethodInvoker(delegate ()
                            {
                                flpRodape.Controls["rdp" + rdp.NomeColuna].Text = rdp.Valor;
                            }));
                        }
                    }

                    foreach (var item in sortableList)
                    {
                        for (int i = 0; i < RodapeColunasTotal.Count(); i++)
                        {
                            var rdp = RodapeColunasTotal[i];

                            var vlr = item.GetType().GetProperty(rdp.NomeColuna).GetValue(item);
                            if (vlr != null)
                            {
                                switch (rdp.TipoValor)
                                {
                                    case LmValueType.Num_Inteiro:
                                    {
                                        if (rdp.CalcularMedia)
                                        {
                                            if (Convert.ToInt32(vlr) > 0)
                                            {
                                                RodapeColunasTotal[i].SomaParaMedia = Math.Round(rdp.SomaParaMedia + Convert.ToInt32(vlr), 2);

                                                RodapeColunasTotal[i].NumerosRegistros++;

                                                RodapeColunasTotal[i].Valor = (RodapeColunasTotal[i].SomaParaMedia / RodapeColunasTotal[i].NumerosRegistros)
                                                    .ToString("M=#,###,###,##0.00");
                                            }
                                            else if (!rdp.IgnorarNulosEZerosNaMedia)
                                            {
                                                RodapeColunasTotal[i].NumerosRegistros++;

                                                RodapeColunasTotal[i].Valor = (RodapeColunasTotal[i].SomaParaMedia / RodapeColunasTotal[i].NumerosRegistros)
                                                    .ToString("M=#,###,###,##0.00");
                                            }
                                        }
                                        else
                                            RodapeColunasTotal[i].Valor =
                                            (Convert.ToInt32(string.IsNullOrEmpty(rdp.Valor) ? "0" + rdp.Valor : rdp.Valor) + Convert.ToInt32(vlr))
                                            .ToString("0");
                                    }
                                    break;
                                    case LmValueType.Num_Real:
                                    {
                                        if (rdp.CalcularMedia)
                                        {
                                            if (Convert.ToDouble(vlr) > 0)
                                            {
                                                RodapeColunasTotal[i].SomaParaMedia = Math.Round(rdp.SomaParaMedia + Convert.ToDouble(vlr), 2);

                                                RodapeColunasTotal[i].NumerosRegistros++;

                                                RodapeColunasTotal[i].Valor = (RodapeColunasTotal[i].SomaParaMedia / RodapeColunasTotal[i].NumerosRegistros)
                                                    .ToString("M=#,###,###,##0.00");
                                            }
                                            else if (!rdp.IgnorarNulosEZerosNaMedia)
                                            {
                                                RodapeColunasTotal[i].NumerosRegistros++;

                                                RodapeColunasTotal[i].Valor = (RodapeColunasTotal[i].SomaParaMedia / RodapeColunasTotal[i].NumerosRegistros)
                                                    .ToString("M=#,###,###,##0.00");
                                            }
                                        }
                                        else
                                            RodapeColunasTotal[i].Valor =
                                                (Convert.ToDouble(string.IsNullOrEmpty(rdp.Valor) ? "0" + rdp.Valor : rdp.Valor) + Convert.ToDouble(vlr))
                                                .ToString("#,###,###,##0.00");
                                    }
                                    break;
                                    case LmValueType.Monetario:
                                    {
                                        RodapeColunasTotal[i].Valor = (Convert.ToDouble("0" + rdp.Valor.Replace("R$", "")) + Convert.ToDouble(vlr.ToString().Replace("R$", ""))).ToString("R$ #,###,###,##0.00");
                                    }
                                    break;
                                    case LmValueType.Data:
                                    {
                                        var vlrDataDec = Convert.ToDateTime(vlr.ToString().FormatarData());
                                        var vlrDataAtualGr = Convert.ToDateTime(rdp.Valor.ToString().FormatarData());
                                        var ts = vlrDataAtualGr - vlrDataDec;
                                        RodapeColunasTotal[i].Valor = vlrDataAtualGr.AddHours(ts.TotalHours).ToShortDateString();
                                    }
                                    break;
                                    case LmValueType.Hora:
                                    {
                                        var vlrHoraDec = vlr.ToString().FormatarHora(/*ignorarMsgInfo: true*/).FormatarHoraDouble();
                                        var vlrHoraAtualGr = rdp.Valor.FormatarHora(/*ignorarMsgInfo: true*/).FormatarHoraDouble();
                                        RodapeColunasTotal[i].Valor = (vlrHoraDec + vlrHoraAtualGr).FormatarHora();
                                    }
                                    break;
                                    default:
                                    break;
                                }
                            }
                            else if (rdp.CalcularMedia && !rdp.IgnorarNulosEZerosNaMedia)
                            {
                                RodapeColunasTotal[i].NumerosRegistros++;
                            }
                        }
                    }

                    Invoke(new MethodInvoker(delegate ()
                    {
                        foreach (var item in RodapeColunasTotal)
                            if (flpRodape.Controls.ContainsKey("rdp" + item.NomeColuna))
                                flpRodape.Controls["rdp" + item.NomeColuna].Text = item.Valor;
                    }));
                }
            }
            catch (ObjectDisposedException ex)
            {

            }
            catch (Exception ex)
            {
            }
        }

        private void AtualizarRotuloSomatorio()
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    if (MostrarTotalizador)
                    {
                        var hScrollAtivo = Controles.HScrollAtivo(this.Grid);
                        System.Collections.IList list = Grid.Columns;
                        for (int i = 0; i < list.Count; i++)
                        {
                            DataGridViewColumn c = (DataGridViewColumn)list[i];
                            var nm = "rdp" + c.Name;
                            if (flpRodape.Controls.ContainsKey(nm))
                            {
                                flpRodape.Controls.SetChildIndex(flpRodape.Controls[nm], c.DisplayIndex);
                                flpRodape.Controls[nm].Visible = c.Visible;

                                flpRodape.Controls[nm].Width = c.Width;
                            }
                        }

                        DefinirTamanhoGrid_e_Rodape();
                    }
                }));
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
            }
            catch (System.ArgumentNullException ex)
            {
            }
            catch (System.Exception ex)
            {
            }
        }

        private void AtualizarScroll()
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    if (flpRodape.HorizontalScroll.Value + flpRodape.HorizontalScroll.LargeChange < flpRodape.HorizontalScroll.Maximum)
                        Grid.HorizontalScrollingOffset = flpRodape.HorizontalScroll.Value;
                    else
                        Grid.HorizontalScrollingOffset = flpRodape.HorizontalScroll.Value + 100;
                }));
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
            }
            catch (System.ArgumentNullException ex)
            {
            }
            catch (System.Exception ex)
            {
            }
        }

        private void FlpRodape_Scroll(object sender, ScrollEventArgs e)
        {
            AtualizarScroll();
        }

        private void FlpRodape_MouseWheel(object sender, MouseEventArgs e)
        {
            AtualizarScroll();
        }

        private void PersonalizarGridSorted()
        {
            try
            {
                if (string.IsNullOrEmpty(ColunaOrdenacaoGrid))
                    return;

                foreach (DataGridViewColumn cln in Grid.Columns)
                {
                    if (cln.HeaderText.Contains(setaCima) || cln.HeaderText.Contains(setaBaix))
                        cln.HeaderText = cln.HeaderText.Replace(setaCima, "").Replace(setaBaix, "");
                }

                Invoke(new MethodInvoker(delegate ()
                {
                    var clnName = ColunaOrdenacaoGrid.Split('^')[0];

                    var direct = (ListSortDirection)Convert.ToInt16(ColunaOrdenacaoGrid.Split('^')[1]);

                    if (Grid.Columns[clnName] != null)
                    {
                        if (Grid.Columns[clnName].ValueType == typeof(Bitmap))
                            return;

                        Grid.Columns[clnName].HeaderText =
                            direct == ListSortDirection.Descending
                            ? setaBaix + Grid.Columns[clnName].HeaderText
                            : setaCima + Grid.Columns[clnName].HeaderText;
                    }
                }));
            }
            catch (Exception ex)
            {
            }
        }

        private void FormatarCorFonteData()
        {
            try
            {
                if (Grid.CurrentRow != null)
                {
                    var hoje = DateTime.Now.Date;

                    Color corVencida = Color.Red;
                    Color corVenceHoje = Color.FromArgb(111, 111, 0);
                    Color corNaoVenceuAinda = Color.Green;
                    string[] colPrevIgnorarFormatacao;
                    string colPrevNome = "";
                    string colNaoFormatarNome = "";

                    FormatarColunaPrevisao atbFormatar = null;
                    NaoFormataDataPrevisaorQuando atbIgorarQuando = null;

                    foreach (PropertyInfo pro in Grid.CurrentRow.DataBoundItem.GetType().GetProperties()
                        .Where(p => p.GetCustomAttribute(typeof(FormatarColunaPrevisao)) != null).ToList())
                    {
                        atbFormatar = (FormatarColunaPrevisao)pro.GetCustomAttribute(typeof(FormatarColunaPrevisao));

                        if (atbFormatar == null || (!atbFormatar.FormatarVencida && !atbFormatar.FormatarVenceHoje && !atbFormatar.FormatarNaoVenceuAinda))
                            return;
                        else
                            colPrevNome = pro.Name;
                    }

                    if (string.IsNullOrEmpty(colPrevNome))
                        return;

                    foreach (PropertyInfo pro in Grid.CurrentRow.DataBoundItem.GetType().GetProperties()
                    .Where(p => p.GetCustomAttribute(typeof(NaoFormataDataPrevisaorQuando)) != null).ToList())
                    {
                        atbIgorarQuando = (NaoFormataDataPrevisaorQuando)pro.GetCustomAttribute(typeof(NaoFormataDataPrevisaorQuando));

                        if (atbIgorarQuando == null)
                            return;
                        else
                            colNaoFormatarNome = pro.Name;
                    }

                    // colunas a serem ignoradas durante a formatação
                    List<PropertyInfo> list = Grid.CurrentRow.DataBoundItem.GetType().GetProperties()
                        .Where(p => p.GetCustomAttribute(typeof(IgnorarFormatacaoPrevisao)) != null).ToList();

                    colPrevIgnorarFormatacao = new string[list.Count];

                    for (int i = 0; i < list.Count; i++)
                        colPrevIgnorarFormatacao[i] = list[i].Name;

                    foreach (DataGridViewRow row in Grid.Rows)
                    {
                        if (!string.IsNullOrEmpty(colNaoFormatarNome))
                        {
                            var valorColunaIgnorar = row.DataBoundItem.GetType().GetProperty(colNaoFormatarNome).GetValue(row.DataBoundItem);
                            if (valorColunaIgnorar != null && atbIgorarQuando.Texto.Contains(valorColunaIgnorar))
                                continue;
                        }

                        var previsao = row.DataBoundItem.GetType().GetProperty(colPrevNome).GetValue(row.DataBoundItem);
                        if (previsao != null)
                        {
                            if (hoje > ((DateTime)previsao).Date && atbFormatar.FormatarVencida)
                                FormatarForeColor(row, corVencida, colPrevIgnorarFormatacao);
                            else if (hoje == ((DateTime)previsao).Date && atbFormatar.FormatarVenceHoje)
                                FormatarForeColor(row, corVenceHoje, colPrevIgnorarFormatacao);
                            else if (hoje < ((DateTime)previsao).Date && atbFormatar.FormatarNaoVenceuAinda)
                                FormatarForeColor(row, corNaoVenceuAinda, colPrevIgnorarFormatacao);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void FormatarForeColor(DataGridViewRow row, Color cor, string[] colPrevIgnorarFormatacao)
        {
            try
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (colPrevIgnorarFormatacao != null && colPrevIgnorarFormatacao.Contains(Grid.Columns[cell.ColumnIndex].Name))
                            continue;

                        cell.Style.ForeColor = cell.Style.SelectionForeColor = cor;
                    }
                }));
            }
            catch (ObjectDisposedException ex)
            {
            }
        }

        #endregion

    }
}
