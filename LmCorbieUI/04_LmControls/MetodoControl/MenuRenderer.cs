using LmCorbieUI.Design;
using LmCorbieUI.Metodos;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LmCorbieUI.Controls
{
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        bool _naoInverterCorImagem = false;

        //Constructor
        public MenuRenderer(bool naoInverterCorImagem)
            : base(new MenuColorTable())
        {
            _naoInverterCorImagem = naoInverterCorImagem;
        }

        //Overrides
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);

            if (!_naoInverterCorImagem)
            {
                e.Item.Font = new Font("Segoe UI", 9.75F);
                e.Item.ForeColor = e.Item.Selected
                    ? LmCor.Bc_Dgv_CellSelected.GetForeColor(LmControlStatus.Selected)
                    : LmCor.Bc_Dgv_CellNormal.GetForeColor(LmControlStatus.Normal);

                if (e.Item.Image == null) return;

                e.Item.Image = e.Item.Image.ApplyColor(e.Item.ForeColor);
            }

        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            //Fields
            var graph = e.Graphics;
            var arrowSize = new Size(5, 12);

            var arrowColor = e.Item.Selected
                    ? LmCor.Bc_Dgv_CellSelected.GetForeColor(LmControlStatus.Selected)
                    : LmCor.Bc_Dgv_CellNormal.GetForeColor(LmControlStatus.Normal);

            var rect = new Rectangle(e.ArrowRectangle.Location.X, (e.ArrowRectangle.Height - arrowSize.Height) / 2,
                arrowSize.Width, arrowSize.Height);
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(arrowColor, 2))
            {
                //Drawing
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + rect.Height / 2);
                path.AddLine(rect.Right, rect.Top + rect.Height / 2, rect.Left, rect.Top + rect.Height);
                graph.DrawPath(pen, path);
            }
        }
    }
}