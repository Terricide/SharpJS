using System;
using JSIL.Dom;
using JSIL.Dom.JSLibraries;

namespace ExaPhaser.WebForms
{
    public abstract class Control
    {
        #region Private Fields

        //Identity
        private Element _container;

        private Element _internalElement;
        private JQElement _internaljqElement;

        //Layout
        private int _left;

        private int _margin;
        private Control _parent;
        private ControlCollection _subControls;
        private int _top;

        #endregion Private Fields

        #region Constructors

        public Control()
        {
            InitializeControl();
        }

        private void InitializeControl()
        {
            _subControls = new ControlCollection(this);
        }

        #endregion Constructors

        #region Properties

        public WebApplication ApplicationContext { get; internal set; }

        public Element ContainerElement
        {
            get { return _container; }
            set { SetContainer(value); }
        }

        public ControlCollection Controls
        {
            get { return _subControls; }
        }

        public int Height
        {
            get { return (int)InternalElement.Height; }
            set { InternalElement.Height = value; }
        }

        public Element InternalElement
        {
            get { return _internalElement; }
            set { SetInternalElement(value); }
        }

        public JQElement InternalJQElement
        {
            get { return _internaljqElement; }
        }

        public int Left
        {
            get
            {
                return _left;
            }

            set
            {
                _left = value;
            }
        }

        public int Margin
        {
            get
            {
                return _margin;
            }

            set
            {
                _margin = value;
            }
        }

        public Control Parent
        {
            get { return _parent; }
            set { SetParent(value); }
        }

        public int Top
        {
            get
            {
                return _top;
            }

            set
            {
                _top = value;
            }
        }

        public int Width
        {
            get { return (int)InternalElement.Width; }
            set { InternalElement.Width = value; }
        }

        private void SetInternalElement(Element value)
        {
            _internalElement = value;
            _internaljqElement = new JQElement(_internalElement);
        }

        private void SetParent(Control value)
        {
            _parent = value;
            ApplicationContext = _parent.ApplicationContext;
        }

        #endregion Properties

        #region Abstract Methods

        public virtual void PerformLayout()
        {
        }

        public virtual void UpdateContent()
        {
        }

        #endregion Abstract Methods

        #region Internal Logic

        protected void SetContainer(Element value)
        {
            if (_container == null)
            {
                _container = value;
                OnLoaded(EventArgs.Empty);
            }
            else
            {
                throw new InvalidOperationException("The control has already been added to a container.");
            }
        }

        #endregion Internal Logic

        #region Events

        private void OnLoaded(EventArgs e)
        {
            EventHandler handler = Loaded;
            if (handler != null)
            {
                handler(this, e);
            }
            PerformLayout();
            UpdateContent();
        }

        #endregion Events

        #region Public Events

        public event EventHandler Loaded;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        /// Docks the control by filling the parent container
        /// </summary>
        public void DockInParentContainer()
        {
            InternalJQElement.JQueryObjectHandle.CSS("width", "100%");
            InternalJQElement.JQueryObjectHandle.CSS("height", "100%");
        }

        #endregion Public Methods
    }
}