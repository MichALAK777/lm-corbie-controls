using System.Drawing;

namespace LmCorbieUI.Design
{
    public class LmCor
    {
        public static bool IsDarkColor(int R, int G, int B)
        {
            bool _return;

            if (G > 200 && R < 100 && B < 100)
                _return = false;
            else
                _return = R + G + B < 350;

            return _return;
        }

        public static Color GetPercentColor(Color corPrimaria, Color corSecundaria, int percent)
        {
            Color _return = corPrimaria;

            try
            {
                var r1 = corSecundaria.R - corPrimaria.R;
                var g1 = corSecundaria.G - corPrimaria.G;
                var b1 = corSecundaria.B - corPrimaria.B;
                var r2 = (double)r1 / 100;
                var g2 = (double)g1 / 100;
                var b2 = (double)b1 / 100;

                double r = corPrimaria.R + (r2 * percent);
                double g = corPrimaria.G + (g2 * percent);
                double b = corPrimaria.B + (b2 * percent);

                _return = Color.FromArgb((int)r, (int)g, (int)b);
            }
            catch (System.Exception)
            {

            }
            return _return;
        }

        public static Color GetForeColor(LmControlStatus statusCtrl, Color backColorCtrl)
        {
            Color _return = Color.Black;

            var isDark = backColorCtrl.IsDarkColor();

            if (statusCtrl == LmControlStatus.Normal)
                _return = isDark ? Color.FromArgb(255, 255, 255) : Color.FromArgb(43, 41, 38);
            else if (statusCtrl == LmControlStatus.Selected)
                _return = isDark ? Color.FromArgb(225, 225, 235) : Color.FromArgb(23, 21, 18);
            else if (statusCtrl == LmControlStatus.Selected)
                _return = isDark ? Color.FromArgb(129, 129, 129) : Color.FromArgb(85, 85, 90);

            return _return;
        }

        private static Color corPrimaria = Color.FromArgb(13, 71, 161);

        public static Color CorPrimaria
        {
            get { return corPrimaria; }
            set
            {
                corPrimaria = value;
            }
        }

        public static Color CorSecundaria { get; set; } = Color.FromArgb(207, 232, 251);

        #region BackColor

        public static Color Bc_Header => CorPrimaria;
        public static Color Bc_Form => GetPercentColor(CorPrimaria, CorSecundaria, 90);
        public static Color Bc_Txt_Normal => GetPercentColor(CorPrimaria, CorSecundaria, 95);
        public static Color Bc_Txt_Selected => CorSecundaria;
        public static Color Bc_Txt_Disabled => GetPercentColor(CorPrimaria, CorSecundaria, 75);
        public static Color Bc_Btn_Normal => GetPercentColor(CorPrimaria, CorSecundaria, 45);
        public static Color Bc_Btn_Selected => GetPercentColor(CorPrimaria, CorSecundaria, 25);
        public static Color Bc_Btn_Press => GetPercentColor(CorPrimaria, CorSecundaria, 45);
        public static Color Bc_Btn_Disabled => GetPercentColor(CorPrimaria, CorSecundaria, 55);
        public static Color Bc_Dgv_Header => GetPercentColor(CorPrimaria, CorSecundaria, 30);
        public static Color Bc_Dgv_CellSelected => GetPercentColor(CorPrimaria, CorSecundaria, 50);
        public static Color Bc_Dgv_CellNormal => GetPercentColor(CorPrimaria, CorSecundaria, 75);

        #endregion

        #region BorderColor

        // Azul
        public static Color Br_Normal => Color.FromArgb(32, 43, 50);
        public static Color Br_Selected => Bc_Btn_Selected;
        public static Color Br_Disabled => Color.FromArgb(62, 73, 77);

        #endregion

    }
}
