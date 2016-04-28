using System.Collections.ObjectModel;

namespace System.Windows.Forms
{
    public class ControlCollection : Collection<Control>
    {
        public Control ParentControl { get; set; }

        protected override void InsertItem(int index, Control item)
        {
            base.InsertItem(index, item);
            item.Parent = ParentControl;
            item.WebFormsControl.Parent.Controls.Add(item.WebFormsControl);
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            var item = this[index];
            item.WebFormsControl.Parent.Controls.Remove(item.WebFormsControl);
        }
    }
}