using SharpJS.JSLibraries.JQuery;
using System.Collections.Generic;

namespace IridiumIon.NeptuniumKit.Controls
{
    public abstract class NKView : INKView
    {
        public List<INKView> Children { get; set; } = new List<INKView>();
        public JQElement UnderlyingElement;// = new JQElement(JQuery.FromSelector("<div />").DomRepresentation);
    }
}