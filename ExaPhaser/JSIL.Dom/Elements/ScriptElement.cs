using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSIL.Dom.Elements
{
    public class ScriptElement : Element
    {
        public ScriptElement() : base("script")
        {

        }
        public string Source
        {
            get { return (string)this["src"]; }
            set { this["src"] = value; }
        }
    }
}
