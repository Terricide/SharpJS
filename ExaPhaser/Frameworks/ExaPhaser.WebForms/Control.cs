using System;
using System.Collections.ObjectModel;
using ExaPhaser.WebForms.Drawing;
using SharpJS.Dom;
using SharpJS.Dom.JSLibraries;

namespace ExaPhaser.WebForms
{
    /// <summary>
    /// The base class for all ExaPhaser.WebForms controls. Contains basic functionality that can be customized in inheriting controls.
    /// </summary>
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
        /// Docks the control by filling the parent container
        /// </summary>
        public void DockControlInParentContainer()
        {
            InternalJQElement.JQueryObjectHandle.Css("width", "100%");
            InternalJQElement.JQueryObjectHandle.Css("height", "100%");
        }

		/// <summary>
		/// Fades in the control. For more control over the animation, call an overload of Control.InternalJQElement.FadeIn
		/// </summary>
		public void FadeIn() => InternalJQElement.FadeIn();

        /// <summary>
        /// Fades out the control. For more control over the animation, call an overload of Control.InternalJQElement.FadeOut
        /// </summary>
		public void FadeOut() => InternalJQElement.FadeOut();

		/// <summary>
		/// Hides the control. Is equivalent to settings Visible to False
		/// </summary>
		public void Hide() => InternalJQElement.Hide();

		/// <summary>
		/// Shows the control. Is equivalent to settings Visible to True
		/// </summary>
        public void Show() => InternalJQElement.Show();

		/// <summary>
		/// Triggers the click event on the control
		/// </summary>
		public void SimulateClick() => InternalJQElement.Trigger("click");

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

        /// <summary>
        /// Sets the position of an element with a Point with constant values. For example, myControl.ConstantPosition = new Point(50, 50)
        /// </summary>
        public Point ConstantPosition
        {
            set { SetConstantPosition(value); }
        }

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

        public JQElement InternalJQElement { get; private set; }

        public int Margin { get; set; }

        public Control Parent
        {
            get { return _parent; }
            set { SetParent(value); }
        }

        public PositioningType PositioningType
        {
            set { SetPositioningType(value); }
        }

        /// <summary>
        /// Sets the position of an element with a Point with relative values. For example, myControl.RelativePosition = new RelativePoint("20%", "20%")
        /// </summary>
        public RelativePoint RelativePosition
        {
            set { SetRelativePosition(value); }
        }

        public bool Visible
        {
            get { return InternalJQElement.Is(":visible"); }
            set { if (value) InternalJQElement.Show(); else InternalJQElement.Hide(); }
        }

        public int Width
        {
            get { return (int)InternalElement.Width; }
            set { InternalElement.Width = value; }
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

        #region Private Methods

        private void SetConstantPosition(Point position)
        {
            InternalJQElement.Css("left", position.X);
            InternalJQElement.Css("top", position.Y);
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

        private void SetPositioningType(PositioningType positioningType)
        {
            string cssPositionType;
            switch (positioningType)
            {
                case PositioningType.Absolute:
                    cssPositionType = "absolute";
                    break;

                case PositioningType.Fixed:
                    cssPositionType = "fixed";
                    break;

                case PositioningType.Relative:
                    cssPositionType = "relative";
                    break;

                case PositioningType.Static:
                    cssPositionType = "static";
                    break;

                default:
                    cssPositionType = "static";
                    break;
            }
            InternalJQElement.Css("position", cssPositionType);
        }

        private void SetRelativePosition(RelativePoint position)
        {
            InternalJQElement.Css("left", position.X);
            InternalJQElement.Css("top", position.Y);
        }

        #endregion Private Methods
    }
}