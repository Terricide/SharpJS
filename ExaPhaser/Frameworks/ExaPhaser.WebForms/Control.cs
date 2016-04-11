using System;
using System.Collections.ObjectModel;
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

        public Collection<Control> Controls
        {
            get { return _subControls; }
            set { SetControls(value); }
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

        private void SetControls(Collection<Control> value)
        {
            if (_subControls.ParentControl == null)
            {
                //Parent is currently null, update controls
                _subControls.ParentControl = this;
                foreach (Control control in value)
                {
                    control.Parent = this;
                }
            }
            foreach (Control control in value)
            {
                _subControls.Add(control);
            }
        }

        private void SetInternalElement(Element value)
        {
            _internalElement = value;
            _internaljqElement = new JQElement(_internalElement);
        }

        private void SetParent(Control parentControl)
        {
            if (parentControl != null)
            {
                _parent = parentControl;
                _subControls.ParentControl = _parent;
                ApplicationContext = _parent.ApplicationContext;
            }
        }

        #endregion Properties

        #region Abstract Methods

        /// <summary>
        /// A control should call PerformLayout when it is ready to receive child controls.
        /// </summary>
        public virtual void PerformLayout()
        {
        }

        /// <summary>
        /// This method is called when the parent control is set.
        /// </summary>
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
        public void DockControlInParentContainer()
        {
            InternalJQElement.JQueryObjectHandle.CSS("width", "100%");
            InternalJQElement.JQueryObjectHandle.CSS("height", "100%");
        }

        #endregion Public Methods
    }
}