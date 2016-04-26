using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    /// <summary>
    /// A control made specifically for grouping other controls. You can hide all the controls inside the panel by hiding the panel.
    /// </summary>
    public sealed class Panel : Control
    {
        public Panel()
        {
            InternalElement = new DivElement();
            PerformLayout();
        }
    }
}