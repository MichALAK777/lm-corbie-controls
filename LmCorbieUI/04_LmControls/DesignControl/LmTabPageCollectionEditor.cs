using System;
using System.ComponentModel.Design;

namespace LmCorbieUI.Controls.Design
{
    internal class LmTabPageCollectionEditor : CollectionEditor
    {
        protected override CollectionForm CreateCollectionForm()
        {
            var baseForm = base.CreateCollectionForm();
            baseForm.Text = "LmTabPage Collection Editor";
            return baseForm;
        }

        public LmTabPageCollectionEditor(Type type)
            : base(type)
        { }

        protected override Type CreateCollectionItemType()
        {
            return typeof(LmTabPage);
        }

        protected override Type[] CreateNewItemTypes()
        {
            return new[] { typeof(LmTabPage) };
        }
    }
}
