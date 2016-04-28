using System;
using JSIL;
using JSIL.Meta;
using SharpJS.Dom;

namespace SharpJS.JSLibraries.JQuery
{
    /// <summary>
    ///     A C# class that represents a jQuery object obtained by $(element) in JS. It redirects managed C# calls to jQuery.
    /// </summary>
    public class JQueryObject
    {
        #region Internal Constructors

        internal JQueryObject(object handle)
        {
            JQObject = handle;
        }

        #endregion Internal Constructors

        #region Private Methods

        [JSReplacement("$this.JQObject[0]")]
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

        public object JQObject { get; set; }

        #endregion Public Properties

        #region Public Methods

        [JSReplacement("$this.JQObject.addClass($className)")]
        public string AddClass(string className)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.append($elementHtml)")]
        public void Append(string elementHtml)
        {
        }

        [JSReplacement("$this.JQObject.append($jqElement.JQueryObjectHandle.JQObject)")]
        public void Append(JQElement jqElement)
        {
        }

        [JSReplacement("$this.JQObject.append($element.DOMRepresentation)")]
        public void Append(Element element)
        {
        }

        [JSReplacement("$this.JQObject.appendTo($elementHtml)")]
        public void AppendTo(string elementHtml)
        {
        }

        [JSReplacement("$this.JQObject.appendTo($jqElement.JQueryObjectHandle.JQObject)")]
        public void AppendTo(JQElement jqElement)
        {
        }

        [JSReplacement("$this.JQObject.appendTo($element.DOMRepresentation)")]
        public void AppendTo(Element element)
        {
        }

        [JSReplacement("$this.JQObject.attr($name)")]
        public string Attr(string name)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.attr($name)")]
        public T Attr<T>(string name)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.attr($name, $value)")]
        public void Attr(string name, string value)
        {
        }

        [JSReplacement("$this.JQObject.attr($name, $value)")]
        public void Attr<T>(string name, T value)
        {
        }

        [JSReplacement("$this.JQObject.on($eventName, $handler)")] //Using on because it is preferred to bind
        public void Bind(string eventName, Action<object> handler)
        {
        }

        [JSReplacement("$this.JQObject.contents()")]
        public object Contents()
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.css($name, $value)")]
        public void Css(string name, string value)
        {
        }

        [JSReplacement("$this.JQObject.css($name, $value)")]
        public void Css<T>(string name, T value)
        {
        }

        [JSReplacement("$this.JQObject.css($name)")]
        public string Css(string name)
        {
            throw new RequiresJSILRuntimeException();
        }

        public T Css<T>(string name)
        {
            return (T)Verbatim.Expression("this.JQObject.css(name)");
        }

        [JSReplacement("$this.JQObject.fadeIn()")]
        public void FadeIn()
        {
        }

        [JSReplacement("$this.JQObject.fadeIn($timeout)")]
        public void FadeIn(int timeout)
        {
        }

        [JSReplacement("$this.JQObject.fadeIn($timeout, $finishedCallback)")]
        public void FadeIn(int timeout, Action finishedCallback)
        {
        }

        [JSReplacement("$this.JQObject.fadeOut()")]
        public void FadeOut()
        {
        }

        [JSReplacement("$this.JQObject.fadeOut($timeout)")]
        public void FadeOut(int timeout)
        {
        }

        [JSReplacement("$this.JQObject.fadeOut($timeout, $finishedCallback)")]
        public void FadeOut(int timeout, Action finishedCallback)
        {
        }

        [JSReplacement("$this.JQObject.find($selector)")]
        public object Find(string selector)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.height($value)")]
        public void Height(int value)
        {
        }

        [JSReplacement("$this.JQObject.height()")]
        public int Height()
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.hide()")]
        public void Hide()
        {
        }

        [JSReplacement("$this.JQObject.html($htmlString)")]
        public void Html(string htmlString)
        {
        }

        [JSReplacement("$this.JQObject.html()")]
        public string Html()
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.is($query)")]
        public bool Is(string query)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.removeClass($className)")]
        public string RemoveClass(string className)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.show()")]
        public void Show()
        {
        }

        [JSReplacement("$this.JQObject.trigger($eventName)")]
        public void Trigger(string eventName)
        {
        }

        [JSReplacement("$this.JQObject.off($eventName)")] //Using off because it is preferred to unbind
        public void Unbind(string eventName)
        {
        }

        [JSReplacement("$this.JQObject.width()")]
        public int Width()
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.width($value)")]
        public void Width(int value)
        {
        }

        #endregion Public Methods
    }
}