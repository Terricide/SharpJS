using System;
using JSIL.Dom;

namespace ExaPhaser.WebForms
{
    public abstract class Control
    {
        //Identity
        private Element _container;

        private Element _internalElement;

        //Layout
        private int _left;

        private int _margin;
        private Control _parent;
        private ControlCollection _subControls;
        private int _top;

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

        public ControlCollection Controls
        {
            get { return _subControls; }
        }

        public Element InternalElement
        {
            get { return _internalElement; }
            set { _internalElement = value; }
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
            set { _parent = value; }
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

        #endregion Properties

        #region Abstract Methods

        public virtual void PerformLayout() { }

        public virtual void UpdateContent() { }

        #endregion Virtual Methods

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

        public event EventHandler Loaded;
    }
}