using System.Collections;
using System.Windows.Forms.Design;

namespace LmCorbieUI.Controls.Design
{
    internal class LmMenuItemDesign : ControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("BackColor");
            properties.Remove("ForeColor");
            properties.Remove("FlatAppearance");
            properties.Remove("Font");

            base.PreFilterProperties(properties);
        }
    }
}
