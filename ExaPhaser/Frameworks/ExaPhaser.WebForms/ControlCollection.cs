using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExaPhaser.WebForms
{
    public class ControlCollection : Collection<Control>
    {
        private readonly List<Control> _controls;

        public ControlCollection(Control parentControl)
        {
            ParentControl = parentControl;
            _controls = new List<Control>();
        }

        public ControlCollection() : this(null)
        {
        }

        public Control ParentControl { get; set; }

        protected override void ClearItems()
        {
            base.ClearItems();
            _controls.Clear();
        }

        protected override void InsertItem(int index, Control control)
        {
            base.InsertItem(index, control);
            if (ParentControl != null)
            {
                if (control.Parent == null)
                    control.Parent = ParentControl;
                else
                {
                    //Parent is not null, so set the outer container as well
                    control.ContainerElement = ParentControl.InternalElement;
                }
                ParentControl.InternalElement.AppendChild(control.InternalElement); //Append internal element
            }
            _controls.Add(control);
        }

        protected override void RemoveItem(int index)
        {
            var control = base[index];
            ParentControl?.InternalElement.RemoveChild(control.InternalElement); //Remove internal element
            _controls.Remove(control);
            base.RemoveItem(index);
        }
    }
}