using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms
{
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