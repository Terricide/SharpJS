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

        public void UnbindEventListener(string eventName)
        {
            jqObject.Unbind(eventName);
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

        private event EventHandler _enterKeyPressed;

        public void RemoveClass(string className)
        {
            jqObject.RemoveClass(className);
        }

        #endregion Public Methods
    }
}