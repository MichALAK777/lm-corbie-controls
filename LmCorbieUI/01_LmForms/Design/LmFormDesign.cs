using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms.Design;

namespace LmCorbieUI.LmForms.Design
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class LmFormDesign : DocumentDesigner /*where TForm : LmForms.LmForm*/
    {
        public LmFormDesign()
        {
            Trace.WriteLine("LmFormDesign ctor");// Para Fins de Depuração
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            IComponentChangeService cs =
                GetService(typeof(IComponentChangeService))
                as IComponentChangeService;

            if (cs != null)
            {
                cs.ComponentChanged +=
                    new ComponentChangedEventHandler(OnComponentChanged);
            }

            //this.Verbs.Add(new DesignerVerb("Inserir Controles Dinâmicos", new EventHandler(OnVerbRun)));
            // this.Verbs.Add(new DesignerVerb("Stop Test", new EventHandler(OnVerbStopTest)));
        }

        // private LmForms.LmForm form;

        private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            //if (e.Component is LmForms.LmForm)
            //{
            //    form = e.Component as LmForms.LmForm;
            //    this.Control.Refresh();
            //}
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            //properties.Remove("Opacity");

            base.PreFilterProperties(properties);
        }

    }
}
