using System;
using SharpJS.Dom;

namespace SharpJS.JSLibraries.JQuery
{
    /// <summary>
    ///     An enhanced version of the Element class that utilizes jQuery.
    /// </summary>
    public class JQElement
    {
        #region Public Constructors

        public JQElement(Element element)
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

        public event EventHandler LostFocus
        {
            add
            {
                BindEventListener("focusout", e => { _focusout?.Invoke(this, new EventArgs()); });
                _focusout += value;
            }
            remove
            {
                UnbindEventListener("focusout");
                _focusout -= value;
            }
        }

        #endregion Public Events

        #region Private Events

        private event EventHandler _click;

        private event EventHandler _enterKeyPressed;

        private event EventHandler _focus;

        private event EventHandler _focusout;

        #endregion Private Events

        #region Public Methods

        public void AddClass(string className) => JQueryObjectHandle.AddClass(className);

        public void Append(string elementHtml) => JQueryObjectHandle.Append(elementHtml);

        public void Append(JQElement jqElement) => JQueryObjectHandle.Append(jqElement);

        public void Append(Element element) => JQueryObjectHandle.Append(element);

        public void AppendTo(string elementHtml) => JQueryObjectHandle.AppendTo(elementHtml);

        public void AppendTo(JQElement jqElement) => JQueryObjectHandle.AppendTo(jqElement);

        public void AppendTo(Element element) => JQueryObjectHandle.AppendTo(element);

        public string Attr(string name) => JQueryObjectHandle.Attr(name);

        public T Attr<T>(string name) => JQueryObjectHandle.Attr<T>(name);

        public void Attr(string name, string value) => JQueryObjectHandle.Attr(name, value);

        public void Attr<T>(string name, T value) => JQueryObjectHandle.Attr<T>(name, value);

        public void BindEventListener(string eventName, Action<object> handler) => JQueryObjectHandle.Bind(eventName, handler);

        public object Contents() => JQueryObjectHandle.Contents();

        public void Css(string name, string value) => JQueryObjectHandle.Css(name, value);

        public void Css<T>(string name, T value) => JQueryObjectHandle.Css<T>(name, value);

        public T Css<T>(string name) => JQueryObjectHandle.Css<T>(name);

        public void Draggable() => JQueryObjectHandle.Draggable();

        public void FadeIn() => JQueryObjectHandle.FadeIn();

        public void FadeIn(int timeout) => JQueryObjectHandle.FadeIn(timeout);

        public void FadeIn(int timeout, Action finishedCallback) => JQueryObjectHandle.FadeIn(timeout, finishedCallback);

        public void FadeOut() => JQueryObjectHandle.FadeOut();

        public void FadeOut(int timeout) => JQueryObjectHandle.FadeOut(timeout);

        public void FadeOut(int timeout, Action finishedCallback) => JQueryObjectHandle.FadeOut(timeout, finishedCallback);

        public object Find(string selector) => JQueryObjectHandle.Find(selector);

        public void Height(int value) => JQueryObjectHandle.Height(value);

        public int Height() => JQueryObjectHandle.Height();

        public void Hide() => JQueryObjectHandle.Hide();

        public void Html(string htmlString) => JQueryObjectHandle.Html(htmlString);

        public string Html() => JQueryObjectHandle.Html();

        public bool Is(string query) => JQueryObjectHandle.Is(query);

        public void Remove() => JQueryObjectHandle.Remove();

        public void RemoveClass(string className) => JQueryObjectHandle.RemoveClass(className);

        public void Resizable() => JQueryObjectHandle.Resizable();

        public void ResizableAnimated() => JQueryObjectHandle.ResizableAnimated();

        public void Show() => JQueryObjectHandle.Show();

        public void Trigger(string eventName) => JQueryObjectHandle.Trigger(eventName);

        public void UnbindEventListener(string eventName) => JQueryObjectHandle.Unbind(eventName);

        public int Width() => JQueryObjectHandle.Width();

        public void Width(int value) => JQueryObjectHandle.Width(value);

        public int ZIndex() => JQueryObjectHandle.ZIndex();

        public void ZIndex(int value) => JQueryObjectHandle.ZIndex(value);

        #endregion Public Methods
    }
}