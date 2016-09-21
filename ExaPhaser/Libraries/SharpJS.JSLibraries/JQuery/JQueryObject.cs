using JSIL;
using JSIL.Meta;
using SharpJS.Dom;
using System;

namespace SharpJS.JSLibraries.JQuery
{
    /// <summary>
    ///     A C# class that represents a jQuery object obtained by $(element) in JS. It redirects managed C# calls to jQuery.
    /// </summary>
    public class JQueryObject
    {
        #region Internal Constructors

        /// <summary>
        /// Creates a JQueryObject from a native JS jQuery object
        /// </summary>
        /// <param name="handle"></param>
        public JQueryObject(object handle)
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

        public Element DomElement
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

        [JSReplacement("$this.JQObject.append($element.DomObjectHandle)")]
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

        [JSReplacement("$this.JQObject.appendTo($element.DomObjectHandle)")]
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

        [JSReplacement("$this.JQObject.draggable()")]
        public void Draggable()
        {
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

        [JSReplacement("$this.JQObject.remove()")]
        public void Remove()
        {
        }

        [JSReplacement("$this.JQObject.removeClass($className)")]
        public string RemoveClass(string className)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.resizable()")]
        public void Resizable()
        {
        }

        [JSReplacement("$this.JQObject.resizable({animate: true})")]
        public void ResizableAnimated()
        {
        }

        internal object DynamicInvoke(string methodName, object[] parameters)
        {
            object targetMethod = Verbatim.Expression("$0[$1]", JQObject, methodName);
            return Verbatim.Expression("$0.apply($1, $2)", null, parameters);
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

        [JSReplacement("$this.JQObject.zIndex()")]
        public int ZIndex()
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this.JQObject.zIndex($value)")]
        public void ZIndex(int value)
        {
        }

        #endregion Public Methods
    }
}