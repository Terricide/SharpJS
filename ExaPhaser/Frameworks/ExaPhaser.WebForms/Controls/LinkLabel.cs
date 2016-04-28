using System;
using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    /// <summary>
    /// A link label is very similar to a label; however, it usually has a hyperlink destination.
    /// </summary>
    public sealed class LinkLabel : TextControl
    {
        #region Private Fields

        private string _text;

        #endregion Private Fields

        #region Public Constructors

        public LinkLabel()
        {
            InternalElement = new AnchorElement();
            InternalElement.Click += OnClick;
            PerformLayout();
        }

        #endregion Public Constructors

        #region Public Properties

        public string LinkLocation
        {
            get { return InternalElement["href"]; }
            set { InternalElement["href"] = value; }
        }

        public string Text
        {
            get { return _text; }
            set { SetText(value); }
        }

        #endregion Public Properties

        #region Public Events

        public event EventHandler Click;

        #endregion Public Events

        #region Private Methods

        private void OnClick(object sender, EventArgs e)
        {
            Click?.Invoke(this, e);
            Command?.Execute(new ICommandParameter(e));
        }

        private void SetText(string value)
        {
            InternalElement.TextContent = value;
            _text = value;
        }

        #endregion Private Methods

        #region Command

        /// <summary>
        /// The command fired when the button is clicked
        /// </summary>
        /// <value>The command.</value>
        public ICommand Command { get; set; }

        #endregion Command
    }
}