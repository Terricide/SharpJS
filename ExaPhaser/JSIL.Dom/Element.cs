using JSIL.Meta;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JSIL.Dom
{
    /// <summary>
    /// The base Element class for a managed C# interface to DOM.
    /// </summary>
    public class Element
    {
        #region Events

        public event EventHandler Change
        {
            add
            {
                AddNativeHandler("change", e =>
                {
                    this._change(this, new EventArgs());
                });
                _change += value;
            }
            remove
            {
                RemoveNativehandler("change");
                _change -= value;
            }
        }

        public event EventHandler Click
        {
            add
            {
                AddNativeHandler("click", e =>
                {
                    this._click(this, new EventArgs());
                });
                _click += value;
            }
            remove
            {
                RemoveNativehandler("click");
                _click -= value;
            }
        }

        public event EventHandler KeyDown
        {
            add
            {
                AddNativeHandler("keydown", e =>
                {
                    this._mouseOver(this, new EventArgs());
                });
                _mouseOver += value;
            }
            remove
            {
                RemoveNativehandler("keydown");
                _mouseOver -= value;
            }
        }

        public event EventHandler MouseOut
        {
            add
            {
                AddNativeHandler("mouseout", e =>
                {
                    this._mouseOut(this, new EventArgs());
                });
                _mouseOut += value;
            }
            remove
            {
                RemoveNativehandler("mouseout");
                _mouseOut -= value;
            }
        }

        public event EventHandler MouseOver
        {
            add
            {
                AddNativeHandler("mouseover", e =>
                {
                    this._mouseOver(this, new EventArgs());
                });
                _mouseOver += value;
            }
            remove
            {
                RemoveNativehandler("mouseover");
                _mouseOver -= value;
            }
        }

        private event EventHandler _change;

        private event EventHandler _click;

        private event EventHandler _keyDown;

        private event EventHandler _mouseOut;

        private event EventHandler _mouseOver;

        #endregion Events

        #region Generic event handling

        private Dictionary<object, Proxy> _handlers = new Dictionary<object, Proxy>();

        protected void AddNativeHandler(string eventName, Action<object> handler)
        {
            if (!_handlers.ContainsKey(eventName) || _handlers[eventName] == null)
            {
                var proxy = new Proxy
                {
                    Handler = handler
                };
                AddEventListener(eventName, proxy.Handler);
                _handlers[eventName] = proxy;
            }
            else
            {
                _handlers[eventName].Counter++;
            }
        }

        protected void RemoveNativehandler(string eventName)
        {
            var handler = _handlers[eventName];
            handler.Counter--;
            if (handler.Counter <= 0)
            {
                RemoveEventListener(eventName, handler.Handler);
                _handlers[eventName] = null;
            }
        }

        [JSReplacement("$this._element.addEventListener($name, $handler)")]
        private void AddEventListener(string name, Action<object> handler)
        {
        }

        [JSReplacement("$this._element.removeEventListener($name, $handler)")]
        private void RemoveEventListener(string name, Action<object> handler)
        {
        }

        private class Proxy
        {
            public int Counter = 0;
            public Action<object> Handler;
        }

        #endregion Generic event handling

        #region Properties

        public string Class
        {
            get { return this["className"]; }
            set { this["className"] = value; }
        }

        public bool Enabled
        {
            get { return (bool)Verbatim.Expression("!this._element.disabled"); }
            set { Verbatim.Expression("this._element.disabled = !value"); }
        }

        public double Height
        {
            get { return (double)Verbatim.Expression("this._element.height"); }
            set { Verbatim.Expression("this._element.height = value"); }
        }

        public string Id
        {
            get { return (string)Verbatim.Expression("this._element.id"); }
            set { Verbatim.Expression("this._element.id = value"); }
        }

        public string TagName
        {
            get { return (string)Verbatim.Expression("this._element.tagName"); }
            set { Verbatim.Expression("this._element.tagName = value"); }
        }

        public double Width
        {
            get { return (double)Verbatim.Expression("this._element.width"); }
            set { Verbatim.Expression("this._element.width = value"); }
        }

        #endregion Properties

        protected object _element;

        protected Element _selfReference;

        // this is a horrible thing: a flag that is used to prevent a call to TemplateApplied
        // in the constructor while creating elements from templates
        private static bool _creatingTemplate = false;

        public Element(string type)
            : this(Verbatim.Expression("document.createElement(type)"))
        {
        }

        protected Element()
        {
        }

        internal Element(object element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            _element = element;
            _selfReference = this;
            Style = new StyleCollection(this);

            if (!_creatingTemplate)
                TemplateApplied();
        }

        public Element[] Children
        {
            get
            {
                return ((object[])Verbatim.Expression("Array.prototype.slice.call(this._element.children)")).Select(elementObject => GetElement(elementObject)).ToArray();
            }
        }

        public object DOMRepresentation
        {
            get { return _element; }
        }

        public Element FirstChild
        {
            get
            {
                return GetElement(Verbatim.Expression("this._element.firstChild"));
            }
        }

        public string InnerHtml
        {
            get { return (string)Verbatim.Expression("this._element.innerHTML"); }
            set { Verbatim.Expression("this._element.innerHTML = value"); }
        }

        public Element NextSibling
        {
            get
            {
                return GetElement(Verbatim.Expression("this._element.nextSibling"));
            }
        }

        [JSReplacement("$this._element.nodeType")]
        public int NodeType
        {
            get;
            private set;
        }

        public string OuterHtml
        {
            get { return (string)Verbatim.Expression("this._element.outerHTML"); }
            set { Verbatim.Expression("this._element.outerHTML = value"); }
        }

        public Element Parent
        {
            get
            {
                return GetElement(Verbatim.Expression("this._element.parent"));
            }
        }

        public StyleCollection Style
        {
            get;
            private set;
        }

        public string TextContent
        {
            get { return (string)Verbatim.Expression("this._element.textContent"); }
            set { Verbatim.Expression("this._element.textContent = value"); }
        }

        public string this[string index]
        {
            get
            {
                return GetAttributeValue(index);
            }
            set
            {
                SetAttributeValue(index, value);
            }
        }

        public static T CreateFromTemplate<T>(string templateId) where T : Element, new()
        {
            _creatingTemplate = true;
            var element = new T();
            _creatingTemplate = false;
            element._element = Verbatim.Expression("document.getElementById(templateId)");
            element._selfReference = element;
            element.TemplateApplied();
            return element;
        }

        [JSReplacement("$this._element.className += \" \" + $className")]
        public virtual void AddClass(string className)
        {
        }

        [JSReplacement("$this._element.appendChild($childElement._element)")]
        public virtual void AppendChild(Element childElement)
        {
        }

        [JSReplacement("$this._element.blur()")]
        public virtual void Blur()
        {
        }

        [JSReplacement("$this._element[$attributeName]")]
        public virtual string GetAttributeValue(string attributeName)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._element.removeChild($child._element)")]
        public virtual void RemoveChild(Element child)
        {
        }

        public virtual void RemoveClass(string className)
        {
            var classNames = GetAttributeValue("className")
                .Split(' ', '\t')
                .Where(s => s != className);

            var names = string.Empty;

            foreach (var name in classNames)
            {
                names += " " + name;
            }

            SetAttributeValue("className", names);
        }

        [JSReplacement("$this._element.style[$styleName]=$value")]
        public void SetStyle(string styleName, string value)
        {
        }

        internal static Element GetById(string id)
        {
            var element = GetElement(Verbatim.Expression("document.getElementById(id)"));

            if (element == null)
            {
                throw new ArgumentOutOfRangeException("id");
            }
            else
            {
                return element;
            }
        }

        internal static Element GetElement(object handle)
        {
            if (handle == null)
            {
                return null;
            }

            object element = Verbatim.Expression("handle._selfReference");

            if (element == null || element == Verbatim.Expression("undefined"))
            {
                return new Element(handle);
            }
            else
            {
                return (Element)element;
            }
        }

        internal static T GetElement<T>(object handle) where T : Element, new()
        {
            if (handle == null)
            {
                return null;
            }

            object element = Verbatim.Expression("handle._selfReference");

            if (element == null || element == Verbatim.Expression("undefined"))
            {
                return (T)Activator.CreateInstance(typeof(T), new object[] { handle }); // equivalent to: new T(handle);
            }
            else
            {
                return (T)element;
            }
        }

        [JSReplacement("$this._element[$attributeName] = $value")]
        protected virtual void SetAttributeValue(string attributeName, string value)
        {
        }

        protected virtual void TemplateApplied()
        {
        }
    }
}