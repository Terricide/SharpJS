using System.Drawing;

namespace System.Windows.Forms
{
    /// <summary>
    /// Represents the base class for controls on the SharpJS WinForms Compatibility Layer
    /// </summary>
    public abstract class Control
    {
        #region Public Properties

        public Size ClientSize { get; set; }
        public ControlCollection Controls { get; set; }
        public Point Location { get; set; }

        [WebFormsCompatStubOnly]
        public string Name { get; set; }

        public Size Size { get; set; }
        [WebFormsCompatStubOnly]
        public int TabIndex { get; set; }

        public virtual string Text { get; set; }

        [WebFormsCompatStubOnly]
        public bool UseVisualStyleBackColor { get; set; }
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
    }
}