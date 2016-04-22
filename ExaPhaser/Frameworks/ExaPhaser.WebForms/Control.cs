using System;
using System.Collections.ObjectModel;
using JSIL.Dom;
using JSIL.Dom.JSLibraries;

namespace ExaPhaser.WebForms
{
    public abstract class Control
    {
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
            var handler = Loaded;
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
        ///     Docks the control by filling the parent container
        /// </summary>
        public void DockControlInParentContainer()
        {
            InternalJQElement.JQueryObjectHandle.CSS("width", "100%");
            InternalJQElement.JQueryObjectHandle.CSS("height", "100%");
        }

        #endregion Public Methods

        #region Private Fields

        //Identity
        private Element _container;

        private Element _internalElement;

        //Layout

        private Control _parent;
        private ControlCollection _subControls;

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
            get { return (int) InternalElement.Height; }
            set { InternalElement.Height = value; }
        }

        public Element InternalElement
        {
            get { return _internalElement; }
            set { SetInternalElement(value); }
        }

        public JQElement InternalJQElement { get; private set; }

        public int Left { get; set; }

        public int Margin { get; set; }

        public Control Parent
        {
            get { return _parent; }
            set { SetParent(value); }
        }

        public int Top { get; set; }

        public int Width
        {
            get { return (int) InternalElement.Width; }
            set { InternalElement.Width = value; }
        }

        private void SetControls(Collection<Control> value)
        {
            if (_subControls.ParentControl == null)
            {
                //Parent is currently null, update controls
                _subControls.ParentControl = this;
                foreach (var control in value)
                {
                    control.Parent = this;
                }
            }
            foreach (var control in value)
            {
                _subControls.Add(control);
            }
        }

        private void SetInternalElement(Element value)
        {
            _internalElement = value;
            InternalJQElement = new JQElement(_internalElement);
        }

        private void SetParent(Control parentControl)
        {
            if (parentControl != null)
            {
                _parent = parentControl;
                _subControls.ParentControl = _parent;
            }
        }

        #endregion Properties

        #region Abstract Methods

        /// <summary>
        ///     A control should call PerformLayout when it is ready to receive child controls.
        /// </summary>
        public virtual void PerformLayout()
        {
        }

        /// <summary>
        ///     This method is called when the parent control is set.
        /// </summary>
        public virtual void UpdateContent()
        {
        }

        #endregion Abstract Methods
    }
}