using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSIL.Dom.Elements
{
    public class AnchorElement : Element
    {
        public AnchorElement() : base("a")
        {
            
        }
        public string HREF
        {
            get { return (string)this["href"]; }
            set { this["href"] = value; }
        }
    }
}
