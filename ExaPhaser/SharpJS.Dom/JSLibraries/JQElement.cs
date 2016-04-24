using System;

namespace SharpJS.Dom.JSLibraries
{
    /// <summary>
    ///     An enhanced version of the Element class that utilizes jQuery.
    /// </summary>
    public class JqElement
    {
        #region Public Constructors

        public JqElement(Element element)
        {
            JQueryObjectHandle = JQuery.GetJQueryObject(element);
        }

        #endregion Public Constructors

        #region Public Properties

        public Element DomRepresentation => JQueryObjectHandle.DomRepresentation;

        public JQueryObject JQueryObjectHandle { get; set; }

        #endregion Public Properties

        #region Public Events

        public event EventHandler Click
        {
            add
            {
                BindEventListener("click", e => { _click?.Invoke(this, new EventArgs()); });
                _click += value;
            }
            remove
            {
                UnbindEventListener("click");
                _click -= value;
            }
        }

        public event EventHandler EnterKeyPressed
        {
            add
            {
                BindEventListener("change", e => { _enterKeyPressed?.Invoke(this, new EventArgs()); });
                _enterKeyPressed += value;
            }
            remove
            {
                UnbindEventListener("change");
                _enterKeyPressed -= value;
            }
        }

        public event EventHandler Focus
        {
            add
            {
                BindEventListener("focus", e => { _focus?.Invoke(this, new EventArgs()); });
                _focus += value;
            }
            remove
            {
                UnbindEventListener("focus");
                _focus -= value;
            }
        }

        #endregion Public Events

        #region Private Events

        private event EventHandler _click;

        private event EventHandler _enterKeyPressed;

        private event EventHandler _focus;

        #endregion Private Events

        #region Public Methods

        public void AddClass(string className) => JQueryObjectHandle.AddClass(className);

        public void Append(string elementHtml) => JQueryObjectHandle.Append(elementHtml);

        public void Append(JqElement jqElement) => JQueryObjectHandle.Append(jqElement);

        public string Attr(string name) => JQueryObjectHandle.Attr(name);

        public void Attr(string name, string value) => JQueryObjectHandle.Attr(name, value);

        public void BindEventListener(string eventName, Action<object> handler) => JQueryObjectHandle.Bind(eventName, handler);

        public object Contents() => JQueryObjectHandle.Contents();

        public void Css(string name, string value) => JQueryObjectHandle.Css(name, value);

        public string Css(string name) => JQueryObjectHandle.Css(name);

        public void FadeIn() => JQueryObjectHandle.FadeIn();

        public void FadeIn(int timeout) => JQueryObjectHandle.FadeIn(timeout);

        public void FadeIn(int timeout, Action finishedCallback) => JQueryObjectHandle.FadeIn(timeout, finishedCallback);

        public void FadeOut() => JQueryObjectHandle.FadeOut();

        public void FadeOut(int timeout) => JQueryObjectHandle.FadeOut(timeout);

        public void FadeOut(int timeout, Action finishedCallback) => JQueryObjectHandle.FadeOut(timeout, finishedCallback);

        public object Find(string selector) => JQueryObjectHandle.Find(selector);

        public void Html(string htmlString) => JQueryObjectHandle.Html(htmlString);

        public string Html() => JQueryObjectHandle.Html();

        public void RemoveClass(string className) => JQueryObjectHandle.RemoveClass(className);

        public void Trigger(string eventName) => JQueryObjectHandle.Trigger(eventName);

        public void UnbindEventListener(string eventName)
        {
            JQueryObjectHandle.Unbind(eventName);
        }

        #endregion Public Methods
    }
}