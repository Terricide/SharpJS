using System;

namespace SharpJS.Dom.JSLibraries
{
    /// <summary>
    ///     An enhanced version of the Element class that utilizes jQuery.
    /// </summary>
    public class JQElement
    {
        #region Private Fields

        #endregion Private Fields

        #region Public Constructors

        public JQElement(Element element)
        {
            JQueryObjectHandle = JQuery.GetJQueryObject(element);
        }

        #endregion Public Constructors

        #region Public Properties

        public Element DOMRepresentation
        {
            get { return JQueryObjectHandle.DOMRepresentation; }
        }

        public JQueryObject JQueryObjectHandle { get; set; }

        #endregion Public Properties

        #region Public Events

        public event EventHandler Click
        {
            add
            {
                BindEventListener("click", e => { _click(this, new EventArgs()); });
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
                BindEventListener("change", e => { _enterKeyPressed(this, new EventArgs()); });
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
                BindEventListener("focus", e => { _focus(this, new EventArgs()); });
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

        public void AddClass(string className)
        {
            JQueryObjectHandle.AddClass(className);
        }

        public void Append(string elementHtml)
        {
            JQueryObjectHandle.Append(elementHtml);
        }

        public void Append(JQElement jqElement)
        {
            JQueryObjectHandle.Append(jqElement);
        }

        public void BindEventListener(string eventName, Action<object> handler)
        {
            JQueryObjectHandle.Bind(eventName, handler);
        }

        public object Contents()
        {
            return JQueryObjectHandle.Contents();
        }

        public void CSS(string name, string value)
        {
            JQueryObjectHandle.CSS(name, value);
        }

        public string CSS(string name)
        {
            return JQueryObjectHandle.CSS(name);
        }

        public object Find(string selector)
        {
            return JQueryObjectHandle.Find(selector);
        }

        public void HTML(string htmlString)
        {
            JQueryObjectHandle.HTML(htmlString);
        }

        public void Trigger(string eventName)
        {
            JQueryObjectHandle.Trigger(eventName);
        }

        public string HTML()
        {
            return JQueryObjectHandle.HTML();
        }

        public void RemoveClass(string className)
        {
            JQueryObjectHandle.RemoveClass(className);
        }

        public void UnbindEventListener(string eventName)
        {
            JQueryObjectHandle.Unbind(eventName);
        }

        #endregion Public Methods
    }
}