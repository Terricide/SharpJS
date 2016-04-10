using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSIL.Dom.Elements;

namespace JSIL.Dom.JSLibraries.JQElements
{
    /// <summary>
    /// A managed wrapper for a DOM element representing a <div> node, with jQuery functionality enabled.
    /// </summary>
    public class JQDivElement : JQElement
    {
        public JQDivElement() : base(new Element("div"))
        {
        }
    }
}
