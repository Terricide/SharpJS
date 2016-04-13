using System;
using JSIL.Meta;

namespace JSIL.Dom.JSLibraries
{
    /// <summary>
    /// A C# class that represents a jQuery object obtained by $(element) in JS. It redirects managed C# calls to jQuery.
    /// </summary>
    public class JQueryObject
    {
        #region Private Fields

        private object _jqobject;

        #endregion Private Fields

        #region Internal Constructors

        internal JQueryObject(object handle)
        {
            _jqobject = handle;
        }

        #endregion Internal Constructors

        #region Public Properties

        public Element DOMRepresentation
        {
            get
            {
                return new Element(GetDOMHandle());
            }
        }

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

        #endregion Public Properties

        #region Public Methods

        [JSReplacement("$this._jqobject.addClass($className)")]
        public string AddClass(string className)
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

        [JSReplacement("$this._jqobject.on($eventName, $handler)")] //Using on because it is preferred to bind
        public void Bind(string eventName, Action<object> handler)
        {
        }

        [JSReplacement("$this._jqobject.contents()")]
        public object Contents()
        {
            throw new RequiresJSILRuntimeException();
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

        [JSReplacement("$this._jqobject.find($selector)")]
        public object Find(string selector)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._jqobject.html($htmlString)")]
        public void HTML(string htmlString)
        {
        }

        [JSReplacement("$this._jqobject.html()")]
        public string HTML()
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._jqobject.removeClass($className)")]
        public string RemoveClass(string className)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._jqobject.trigger($eventName)")]
        public void Trigger(string eventName)
        {
        }

        [JSReplacement("$this._jqobject.off($eventName)")] //Using off because it is preferred to unbind
        public void Unbind(string eventName)
        {
        }

        #endregion Public Methods

        #region Private Methods

        [JSReplacement("$this._jqobject[0]")]
        private object GetDOMHandle()
        {
            throw new RequiresJSILRuntimeException();
        }

        #endregion Private Methods
    }
}