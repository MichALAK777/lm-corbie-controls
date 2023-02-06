using System.Collections;
using System.Windows.Forms.Design;

namespace LmCorbieUI.Controls.Design
{
    class LmFiltroMultiselecaoDesign : ParentControlDesigner //: ControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("BorderStyle");
            properties.Remove("BackColor");

            base.PreFilterProperties(properties);
        }
    }
}
