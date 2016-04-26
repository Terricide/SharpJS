using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms
{
    /// <summary>
    /// A class representing a group of controls. A WebForm can be displayed by launching it from a WebApplication instance.
    /// </summary>
    public class WebForm : Control
    {
        public WebForm()
        {
            InternalElement = new DivElement();
            PerformLayout();
        }

        public override void UpdateContent()
        {
            base.UpdateContent();
            ContainerElement.AppendChild(InternalElement);
        }
    }
}