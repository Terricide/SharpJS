using System;
using System.Collections;
using System.Collections.Generic;
using JSIL;

namespace SharpJS.Dom
{
    public class StyleCollection : IEnumerable<object>
    {
        private Element _parent;

        public StyleCollection(Element element)
        {
            _parent = element;
        }

        public IEnumerator<object> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //[JSReplacement("$this._parent._element.style[$name] = $value")]
        public void Add(string name, string value)
        {
            Verbatim.Expression("this._parent._element.style[name] = value");
        }
    }
}