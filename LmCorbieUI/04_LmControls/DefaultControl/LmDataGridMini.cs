using LmCorbieUI.Design;
using LmCorbieUI.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LmCorbieUI.Controls
{
    public class LmDataGridMini : DataGridView, ILmControl
    {
        #region Construtor

        public LmDataGridMini()
        {
            UpdateStyleGrid();

            this.DoubleBuffered = true;
            this.MouseDown += LmDataGridMini_MouseDown;
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

        #region Campos

        private LmTextBoxSize lmGridSize = LmTextBoxSize.Medium;
        [DefaultValue(LmTextBoxSize.Medium)]

        public LmTextBoxSize FontSize
        {
            get { return lmGridSize; }
            set
            {
                lmGridSize = value;
                UpdateStyleGrid();
                Refresh();
            }
        }

        private LmTextBoxWeight lmGridWeight = LmTextBoxWeight.Regular;
        [DefaultValue(LmTextBoxWeight.Regular)]

        public LmTextBoxWeight FontWeight
        {
            get { return lmGridWeight; }
            set
            {
                lmGridWeight = value;
                UpdateStyleGrid();
                Refresh();
            }
        }

        #endregion

        #region Eventos

        private void LmDataGridMini_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = this.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    this[hit.ColumnIndex, hit.RowIndex].Selected = true;
                }
            }
        }

        /// <summary>
        /// Inserir Highlight
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);
            if (this.RectangleToScreen(e.RowBounds).Contains(MousePosition))
            {
                using (var b = new SolidBrush(Color.FromArgb(50, LmCor.Bc_Dgv_CellSelected)))// LmPaint.BackColor.GridView.CellSelected(Theme))))
                {
                    var r = e.RowBounds; r.Width -= 1; r.Height -= 1;
                    e.Graphics.FillRectangle(b, r);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e); this.Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e); this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e); this.Invalidate();
        }
        protected override void OnScroll(ScrollEventArgs e)
        {
            base.OnScroll(e); this.Invalidate();
        }

        #endregion

        #region Private Metodos

        public void UpdateStyleGrid()
        {
            Font fRow = LmFonts.Grid(lmGridSize, lmGridWeight);// new Font("Segoe UI", 9F, FontStyle.Regular);
            Font fHeader = LmFonts.Grid(lmGridSize, lmGridWeight);//new Font("Segoe UI", 9F, FontStyle.Regular);

            this.BorderStyle = BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            this.EnableHeadersVisualStyles = false;
            //this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BackgroundColor = LmCor.Bc_Form;//  LmPaint.BackColor.Form(Theme);
            this.GridColor = LmCor.Bc_Form;//  LmPaint.BackColor.Form(Theme);
            this.ForeColor = BackgroundColor.GetForeColor(LmControlStatus.Normal);
            this.DefaultCellStyle.Font = fRow;
            this.Font = fRow;

            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            this.RowHeadersVisible = false;
            this.MultiSelect = false;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.AllowUserToResizeRows = false;

            // Estilo do Cabeçalho Coluna
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Outset;
            //this.AdvancedColumnHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Inset;
            this.ColumnHeadersDefaultCellStyle.Font = fHeader;
            this.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle.BackColor = LmCor.Bc_Dgv_Header;// LmPaint.BackColor.GridView.Header(Theme);
            this.ColumnHeadersDefaultCellStyle.ForeColor = LmCor.Bc_Dgv_Header.GetForeColor(LmControlStatus.Normal);
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = LmCor.Bc_Dgv_Header;// LmPaint.BackColor.GridView.Header(Theme);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = LmCor.Bc_Dgv_Header.GetForeColor(LmControlStatus.Normal);

            // Estilo do Cabeçalho Linha
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.RowHeadersDefaultCellStyle.BackColor = LmCor.Bc_Dgv_Header;// LmPaint.BackColor.GridView.Header(Theme);
            this.RowHeadersDefaultCellStyle.ForeColor = LmCor.Bc_Dgv_Header.GetForeColor(LmControlStatus.Normal);
            this.RowHeadersDefaultCellStyle.SelectionBackColor = LmCor.Bc_Dgv_Header;//  LmPaint.BackColor.GridView.Header(Theme);
            this.RowHeadersDefaultCellStyle.SelectionForeColor = LmCor.Bc_Dgv_Header.GetForeColor(LmControlStatus.Normal);

            // Estilo da Celula
            this.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.DefaultCellStyle.BackColor = LmCor.Bc_Dgv_CellNormal;//  LmPaint.BackColor.GridView.CellNormal(Theme);
            this.DefaultCellStyle.ForeColor = LmCor.Bc_Dgv_CellNormal.GetForeColor(LmControlStatus.Normal);
            this.DefaultCellStyle.SelectionBackColor = LmCor.Bc_Dgv_CellSelected;// LmPaint.BackColor.GridView.CellSelected(Theme);
            this.DefaultCellStyle.SelectionForeColor = LmCor.Bc_Dgv_CellSelected.GetForeColor(LmControlStatus.Selected);

            // Atualizar Altura da linha
            this.RowTemplate.Height = lmGridSize == LmTextBoxSize.Small ? 18 : lmGridSize == LmTextBoxSize.Medium ? 21 : 27;

        }

        #endregion
    }
}
