using System.Collections;
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace LmCorbieUI.Controls.Design
{
    internal class LmMenuJanelaAbertaDesign  : ControlDesigner
    {

        protected override void PreFilterProperties(IDictionary properties)
        {
            properties.Remove("AccessibleDescription");
            properties.Remove("AccessibleName");
            properties.Remove("AccessibleRole");
            properties.Remove("AutoScroll");
            properties.Remove("AutoScrollMargin");
            properties.Remove("AutoScrollMinSize");
            properties.Remove("AutoSize");
            properties.Remove("AutoSizeMode");
            properties.Remove("AutoValidate");
            properties.Remove("BackgroundImage");
            properties.Remove("BackgroundImageLayout");
            //properties.Remove("BorderStyle");
            properties.Remove("CausesValidation");
            properties.Remove("Font");
            properties.Remove("ForeColor");
            properties.Remove("GenerateMember");
            properties.Remove("ImeMode");
            properties.Remove("Locked");
            properties.Remove("Padding");
            properties.Remove("RightToLeft");

            base.PreFilterProperties(properties);
        }

        protected override void PreFilterEvents(IDictionary events)
        {
            events.Remove("AutoSizeChanged");
            events.Remove("AutoValidateChanged");
            events.Remove("BackColorChanged");
            events.Remove("BackgroundImageChanged");
            events.Remove("BackgroundImageLayoutChanged");
            events.Remove("BindingContextChanged");
            events.Remove("CausesValidationChanged");
            events.Remove("Click");
            events.Remove("ClientSizeChanged");
            events.Remove("ChangeUICues");
            events.Remove("ContextMenuStripChanged");
            events.Remove("ControlAdded");
            events.Remove("ControlRemoved");
            events.Remove("CursorChanged");
            events.Remove("CustomPaint");
            events.Remove("CustomPaintBackground");
            events.Remove("CustomPaintForeground");
            events.Remove("DockChanged");
            events.Remove("EnabledChanged");
            events.Remove("Enter");
            events.Remove("FontChanged");
            events.Remove("ForeColorChanged");
            events.Remove("GiveFeedback");
            events.Remove("HelpRequested");
            events.Remove("ImeModeChanged");
            events.Remove("KeyDown");
            events.Remove("KeyPress");
            events.Remove("KeyUp");
            events.Remove("Layout");
            events.Remove("Leave");
            events.Remove("Load");
            events.Remove("LocationChanged");
            events.Remove("MarginChanged");
            events.Remove("MouseCaptureChanged");
            events.Remove("MouseClick");
            events.Remove("MouseDoubleClick");
            events.Remove("MouseDown");
            events.Remove("MouseEnter");
            events.Remove("MouseHover");
            events.Remove("MouseLeave");
            events.Remove("MouseMove");
            events.Remove("MouseUp");
            events.Remove("Move");
            events.Remove("PaddingChanged");
            events.Remove("Paint");
            events.Remove("ParentChanged");
            events.Remove("PreviewKeyDown");
            events.Remove("QueryAccessibilityHelp");
            events.Remove("QueryContinueDrag");
            events.Remove("RegionChanged");
            events.Remove("Resize");
            events.Remove("RightToLeftChanged");
            events.Remove("Scroll");
            events.Remove("SizeChanged");
            events.Remove("StyleChanged");
            events.Remove("SystemColorsChanged");
            events.Remove("TabIndexChanged");
            events.Remove("TabStopChanged");
            events.Remove("Validated");
            events.Remove("Validating");
            events.Remove("VisibleChanged");

            events.Remove("");
            events.Remove("");

            base.PreFilterEvents(events);
        }
    }
}
