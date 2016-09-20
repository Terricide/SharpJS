using SharpJS.JSLibraries.JQuery;
using System.Collections.Generic;

namespace IridiumIon.NeptuniumKit.Controls
{
    public interface INKView
    {
        List<INKView> Children { get; set; }
        JQElement UnderlyingElement;
    }
}