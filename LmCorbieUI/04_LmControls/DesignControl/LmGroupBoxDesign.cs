using System.Collections;
using System.Windows.Forms.Design;

namespace LmCorbieUI.Controls.Design
{
    class LmGroupBoxDesign:ParentControlDesigner //: ControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("BackgroundImage");
            properties.Remove("ImeMode");
            //properties.Remove("Padding");
            properties.Remove("BackgroundImageLayout");
            properties.Remove("Font");
            properties.Remove("BorderStyle");

            base.PreFilterProperties(properties);
        }
    }
}
