using System.Drawing;
using ExaPhaser.WebForms;

namespace System.Windows.Forms
{
    /// <summary>
    /// Represents the base class for controls on the SharpJS WinForms Compatibility Layer
    /// </summary>
    public abstract class Control
    {
        #region Private Fields

        private Size _clientSize;
        private Control _parent;
        private ExaPhaser.WebForms.Control _webFormsControl;

        #endregion Private Fields

        #region Public Constructors

        protected Control()
        {
            Controls = new ControlCollection { ParentControl = this };
        }

        #endregion Public Constructors

        #region Public Properties

        [WebFormsCompatStubOnly]
        public bool AutoSize { get; set; }

        public Size ClientSize
        {
            get { return _clientSize; }
            set { SetSize(value); }
        }

        public ControlCollection Controls { get; set; }

        public virtual Font Font { get; set; }

        public Point Location
        {
            get { return GetLocation(); }
            set { SetLocation(value); }
        }

        [WebFormsCompatStubOnly]
        public Padding Margin { get; set; }

        [WebFormsCompatStubOnly]
        public string Name { get; set; }

        public Control Parent { get { return _parent; } set { SetParent(value); } }

        [WebFormsCompatStubOnly]
        public Size Size
        {
            get { return ClientSize; }
            set { ClientSize = value; }
        }

        [WebFormsCompatStubOnly]
        public Size MinimumSize
        {
            get { return ClientSize; }
            set { ClientSize = value; }
        }

        [WebFormsCompatStubOnly]
        public int TabIndex { get; set; }

        [WebFormsCompatStubOnly]
        public bool TabStop { get; set; }

        public virtual string Text { get; set; }

        [WebFormsCompatStubOnly]
        public bool UseVisualStyleBackColor { get; set; }

        public ExaPhaser.WebForms.Control WebFormsControl
        {
            get { return _webFormsControl; }
            set { SetWebFormsControl(value); }
        }

        #endregion Public Properties

        #region Public Methods

        public void OnInitialized()
        {
            Load?.Invoke(this, EventArgs.Empty);
        }

        [WebFormsCompatStubOnly]
        public void PerformLayout()
        {
        }

        [WebFormsCompatStubOnly]
        public void ResumeLayout(bool none)
        {
        }

        [WebFormsCompatStubOnly]
        public void SuspendLayout()
        {
        }

        #endregion Public Methods

        #region Protected Methods

        [WebFormsCompatStubOnly]
        protected virtual void Dispose(bool performLayout)
        {
        }

        protected virtual void OnClick(object sender, EventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnGotFocus(object sender, EventArgs e)
        {
            Activated?.Invoke(this, EventArgs.Empty);
            Enter?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLostFocus(object sender, EventArgs e)
        {
            Deactivate?.Invoke(this, EventArgs.Empty);
            Leave?.Invoke(this, EventArgs.Empty);
        }

        #endregion Protected Methods

        #region Private Methods

        private Point GetLocation()
        {
            var wfLocation = WebFormsControl.ConstantPosition;
            return new Point(wfLocation.X, wfLocation.Y);
        }

        protected virtual void SetLocation(Point location)
        {
            WebFormsControl.PositioningType = PositioningType.Absolute;
            WebFormsControl.ConstantPosition = new ExaPhaser.WebForms.Drawing.Point(location.X, location.Y);
        }

        private void SetParent(Control control)
        {
            _parent = control;
            WebFormsControl.Parent = _parent.WebFormsControl;
        }

        private void SetSize(Size newSize)
        {
            _clientSize = newSize;
            //Set client size through CSS
            this.WebFormsControl.Height = newSize.Height;
            this.WebFormsControl.Width = newSize.Width;
        }

        private void SetWebFormsControl(ExaPhaser.WebForms.Control wfControl)
        {
            _webFormsControl = wfControl;
            WebFormsControl.Focus += OnGotFocus;
            WebFormsControl.LostFocus += OnLostFocus;
            WebFormsControl.Click += OnClick;
        }

        #endregion Private Methods

        #region Public Events

        [WebFormsCompatStubOnly]
        public event EventHandler Activated;

        public virtual event EventHandler Click;

        [WebFormsCompatStubOnly]
        public event EventHandler Deactivate;

        public event EventHandler Enter;

        public event EventHandler Leave;

        public event EventHandler Load;

        #endregion Public Events
    }
}