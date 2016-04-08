using System.Collections.Generic;

namespace ExaPhaser.WebForms
{
    public class ControlCollection
    {
        private List<Control> _controls;
        private Control _parentControl;

        public ControlCollection(Control parentControl)
        {
            _parentControl = parentControl;
        }

        public void Add(Control control)
        {
            if (control.Parent == null)
                control.Parent = _parentControl;
            _parentControl.InternalElement.AppendChild(control.InternalElement); //Append internal element
            _controls.Add(control);
        }

        public void Remove(Control control)
        {
            _parentControl.InternalElement.RemoveChild(control.InternalElement); //Remove internal element
            _controls.Remove(control);
        }

        public void Clear()
        {
            _controls.Clear();
        }
    }
}