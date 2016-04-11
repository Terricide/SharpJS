using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExaPhaser.WebForms
{
    public class ControlCollection : Collection<Control>
    {
        private List<Control> _controls;
        private Control _parentControl;

        public ControlCollection(Control parentControl)
        {
            _parentControl = parentControl;
            _controls = new List<Control>();
        }

        public ControlCollection() : this(null)
        {
        }

        public Control ParentControl
        {
            get
            {
                return _parentControl;
            }

            set
            {
                _parentControl = value;
            }
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            _controls.Clear();
        }

        protected override void InsertItem(int index, Control control)
        {
            base.InsertItem(index, control);
            if (control.Parent == null)
                control.Parent = _parentControl;
            else
            {
                //Parent is not null, so set the outer container as well
                control.ContainerElement = _parentControl.InternalElement;
            }
            _parentControl.InternalElement.AppendChild(control.InternalElement); //Append internal element
            _controls.Add(control);
        }

        protected override void RemoveItem(int index)
        {
            var control = base[index];
            _parentControl.InternalElement.RemoveChild(control.InternalElement); //Remove internal element
            _controls.Remove(control);
            base.RemoveItem(index);
        }
    }
}