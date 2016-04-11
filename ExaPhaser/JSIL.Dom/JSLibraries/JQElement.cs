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

        #endregion Public Events

        #region Private Events

        private event EventHandler _enterKeyPressed;

        private event EventHandler _focus;

        private event EventHandler _click;

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