using SharpJS.JSLibraries.JQuery;

namespace IridiumIon.NeptuniumKit.Controls
{
    public abstract class NKView
    {
        public NKView Parent { get; set; }
        public NKViewCollection Children { get; set; } = new NKViewCollection();
        public JQElement UnderlyingElement { get; set; }// = new JQElement(JQuery.FromSelector("<div />").DomRepresentation);
    }
}