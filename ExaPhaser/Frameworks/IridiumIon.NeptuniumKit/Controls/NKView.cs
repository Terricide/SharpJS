using IridiumIon.NeptuniumKit.ComponentModel;
using SharpJS.Dom;
using SharpJS.JSLibraries.JQuery;

namespace IridiumIon.NeptuniumKit.Controls
{
    public abstract class NKView
    {
        public NKView Parent { get; set; }
        public NKViewCollection Children { get; set; } = new NKViewCollection();
        public Element UnderlyingElement { get; set; }// = new JQElement(JQuery.FromSelector("<div />").DomRepresentation);
        public JQElement UnderlyingJQElement { get { return new JQElement(UnderlyingElement); } }
        public INotifyPropertyChanged DataContext { get; set; }
    }
}