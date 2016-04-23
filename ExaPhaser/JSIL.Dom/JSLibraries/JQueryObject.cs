using System;
using JSIL;
using JSIL.Meta;

namespace SharpJS.Dom.JSLibraries
{
    /// <summary>
    ///     A C# class that represents a jQuery object obtained by $(element) in JS. It redirects managed C# calls to jQuery.
    /// </summary>
    public class JQueryObject
    {
        #region Internal Constructors

        internal JQueryObject(object handle)
        {
            JavaScriptJQueryHandle = handle;
        }

        #endregion Internal Constructors

        #region Private Methods

        [JSReplacement("$this._jqobject[0]")]
        private object GetDomHandle()
        {
            throw new RequiresJSILRuntimeException();
        }

        #endregion Private Methods

        #region Public Properties

        public Element DomRepresentation
        {
            get { return new Element(GetDomHandle()); }
        }

        public object JavaScriptJQueryHandle { get; set; }

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
        public void Append(JqElement jqElement)
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
        public void Css(string name, string value)
        {
        }

        [JSReplacement("$this._jqobject.css($name)")]
        public string Css(string name)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._jqobject.find($selector)")]
        public object Find(string selector)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._jqobject.html($htmlString)")]
        public void Html(string htmlString)
        {
        }

        [JSReplacement("$this._jqobject.html()")]
        public string Html()
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

        [JSReplacement("$this._jqobject.fadeIn()")]
        public void FadeIn()
        {
        }

        [JSReplacement("$this._jqobject.fadeIn($timeout)")]
        public void FadeIn(int timeout)
        {
        }

        [JSReplacement("$this._jqobject.fadeIn($timeout, $finishedCallback)")]
        internal void FadeIn(int timeout, Action finishedCallback)
        {
        }

        [JSReplacement("$this._jqobject.fadeOut()")]
        public void FadeOut()
        {
        }

        [JSReplacement("$this._jqobject.fadeOut($timeout)")]
        public void FadeOut(int timeout)
        {
        }

        [JSReplacement("$this._jqobject.fadeOut($timeout, $finishedCallback)")]
        internal void FadeOut(int timeout, Action finishedCallback)
        {
        }

        #endregion Public Methods
    }
}