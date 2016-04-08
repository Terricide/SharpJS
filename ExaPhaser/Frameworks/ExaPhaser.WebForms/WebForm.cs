using System;
using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms
{
    public class WebForm : Control
    {
        public WebForm()
        {

        }

        public override void PerformLayout()
        {
            base.PerformLayout();
            InternalElement = new DivElement();
            ContainerElement.AppendChild(InternalElement);
        }
    }
}