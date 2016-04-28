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

        #endregion Private Fields

        #region Public Constructors

        protected Control()
        {
            Controls = new ControlCollection { ParentControl = this };
        }

        #endregion Public Constructors

        #region Public Properties

        public Size ClientSize
        {
            get { return _clientSize; }
            set { SetSize(value); }
        }

        public ControlCollection Controls { get; set; }

        public Point Location
        {
            get { return GetLocation(); }
            set { SetLocation(value); }
        }

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
        public int TabIndex { get; set; }

        public virtual string Text { get; set; }

        [WebFormsCompatStubOnly]
        public bool UseVisualStyleBackColor { get; set; }

        public ExaPhaser.WebForms.Control WebFormsControl { get; set; }

        #endregion Public Properties

        #region Public Methods

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

        #endregion Protected Methods

        #region Private Methods

        private Point GetLocation()
        {
            var wfLocation = WebFormsControl.ConstantPosition;
            return new Point(wfLocation.X, wfLocation.Y);
        }

        private void SetLocation(Point location)
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

        #endregion Private Methods
    }
}