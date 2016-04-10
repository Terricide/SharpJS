using JSIL.Meta;

namespace JSIL.Dom.JSLibraries
{
    /// <summary>
    /// A C# class that represents a jQuery object obtained by $(element) in JS. It redirects managed C# calls to jQuery.
    /// </summary>
    public class JQueryObject
    {
        private object _jqobject;

        public object JavaScriptJQueryHandle
        {
            get
            {
                return _jqobject;
            }

            set
            {
                _jqobject = value;
            }
        }

        public Element DOMRepresentation
        {
            get
            {
                return new Element(GetDOMHandle());
            }
        }

        [JSReplacement("$this._jqobject[0]")]
        private object GetDOMHandle()
        {
            throw new RequiresJSILRuntimeException();
        }

        internal JQueryObject(object handle)
        {
            _jqobject = handle;
        }

        [JSReplacement("$this._jqobject.css($name, $value)")]
        public void CSS(string name, string value)
        {
        }

        [JSReplacement("$this._jqobject.css($name)")]
        public string CSS(string name)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._jqobject.addClass($className)")]
        public string AddClass(string className)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._jqobject.removeClass($className)")]
        public string RemoveClass(string className)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._jqobject.append($elementHtml)")]
        public void Append(string elementHtml)
        {
        }

        [JSReplacement("$this._jqobject.append($jqElement.JQueryObjectHandle.JavaScriptJQueryHandle)")]
        public void Append(JQElement jqElement)
        {
        }

        [JSReplacement("$this._jqobject.append($element.DOMRepresentation)")]
        public void Append(Element element)
        {
        }
    }
}