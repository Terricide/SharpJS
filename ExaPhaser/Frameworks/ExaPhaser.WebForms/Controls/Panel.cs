using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public sealed class Panel : Control
    {
        public Panel()
        {
            InternalElement = new DivElement();
            PerformLayout();
        }
    }
}