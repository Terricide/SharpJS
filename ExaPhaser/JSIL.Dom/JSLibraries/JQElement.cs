using System;

namespace JSIL.Dom.JSLibraries
{
    /// <summary>
    /// An enhanced version of the Element class that utilizes jQuery.
    /// </summary>
    public class JQElement
    {
        #region Private Fields

        private JQueryObject jqObject;

        #endregion Private Fields

        #region Public Constructors

        public JQElement(Element element)
        {
            jqObject = JQuery.GetJQueryObject(element);
        }

        #endregion Public Constructors

        #region Public Properties

        public Element DOMRepresentation
        {
            get
            {
                return jqObject.DOMRepresentation;
            }
        }

        public JQueryObject JQueryObjectHandle
        {
            get
            {
                return jqObject;
            }

            set
            {
                jqObject = value;
            }
        }

        #endregion Public Properties

        #region Public Events

        public event EventHandler Click
        {
            add
            {
                BindEventListener("click", e =>
                {
                    this._click(this, new EventArgs());
                });
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
                BindEventListener("change", e =>
                {
                    this._enterKeyPressed(this, new EventArgs());
                });
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
                BindEventListener("focus", e =>
                {
                    this._focus(this, new EventArgs());
                });
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
            jqObject.AddClass(className);
        }

        public void Append(string elementHtml)
        {
            jqObject.Append(elementHtml);
        }

        public void Append(JQElement jqElement)
        {
            jqObject.Append(jqElement);
        }

        public void BindEventListener(string eventName, Action<object> handler)
        {
            jqObject.Bind(eventName, handler);
        }

        public object Contents()
        {
            return jqObject.Contents();
        }

        public void CSS(string name, string value)
        {
            jqObject.CSS(name, value);
        }

        public string CSS(string name)
        {
            return jqObject.CSS(name);
        }

        public object Find(string selector)
        {
            return jqObject.Find(selector);
        }

        public void HTML(string htmlString)
        {
            jqObject.HTML(htmlString);
        }

        public void Trigger(string eventName)
        {
            jqObject.Trigger(eventName);
        }

        public string HTML()
        {
            return jqObject.HTML();
        }

        public void RemoveClass(string className)
        {
            jqObject.RemoveClass(className);
        }

        public void UnbindEventListener(string eventName)
        {
            jqObject.Unbind(eventName);
        }

        #endregion Public Methods
    }
}