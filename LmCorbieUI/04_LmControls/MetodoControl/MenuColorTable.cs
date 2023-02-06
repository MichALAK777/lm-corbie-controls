using LmCorbieUI.Design;
using System.Drawing;
using System.Windows.Forms;

namespace LmCorbieUI.Controls
{
    public class MenuColorTable : ProfessionalColorTable
    {
        //Fields
        private Color backColor;
        private Color imageColorBegin;
        private Color imageColorMidle;
        private Color imageColorEnd;
        private Color borderColor;
        private Color menuItemBorderColor;
        private Color menuItemSelectedColor;

        //Constructor
        public MenuColorTable()
        {
            backColor = LmCor.Bc_Dgv_CellNormal ;
            menuItemSelectedColor = LmCor.Bc_Dgv_CellSelected;
            borderColor = LmCor.Bc_Header;

            imageColorBegin = LmCor.Bc_Dgv_CellSelected;// LmPaint.BackColor.MenuStrip.ImageMarginGradientBegin(lmTheme);
            imageColorMidle = LmCor.Bc_Dgv_CellNormal;// LmPaint.BackColor.MenuStrip.ImageMarginGradientMiddle(lmTheme);
            imageColorEnd = LmCor.Bc_Dgv_CellNormal;  // LmPaint.BackColor.MenuStrip.ImageMarginGradientEnd(lmTheme);

            menuItemBorderColor = LmCor.Bc_Dgv_CellSelected;
        }

        //Overrides
        public override Color ToolStripDropDownBackground { get { return backColor; } }
        public override Color MenuBorder { get { return borderColor; } }
        public override Color MenuItemBorder { get { return menuItemBorderColor; } }
        public override Color MenuItemSelectedGradientBegin { get { return menuItemSelectedColor; } }
        public override Color MenuItemSelectedGradientEnd { get { return menuItemSelectedColor; } }
        public override Color ImageMarginGradientBegin { get { return imageColorBegin; } }
        public override Color ImageMarginGradientMiddle { get { return imageColorMidle; } }
        public override Color ImageMarginGradientEnd { get { return imageColorEnd; } }
    }
}