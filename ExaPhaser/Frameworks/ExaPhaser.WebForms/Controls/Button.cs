using System;
using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public class Button : TextControl
    {
        #region Private Fields

        private string _text;

        #endregion Private Fields

        #region Public Constructors

        public Button() : base()
        {
            InternalElement = new ButtonElement()
            {
                Class = "button",
            };
            InternalElement.Click += OnClick;
            PerformLayout();
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler Click;

        #endregion Public Events

        #region Public Properties

        public string Text
        {
            get { return _text; }
            set { SetText(value); }
        }

        #endregion Public Properties

        #region Private Methods

        private void OnClick(object sender, EventArgs e)
        {
            EventHandler handler = Click;
            if (handler != null)
            {
                handler(this, e);
            }
            if (Command != null)
                Command.Execute(CommandParameter);
        }

        private void SetText(string value)
        {
            InternalElement.TextContent = value;
            _text = value;
        }

        #endregion Private Methods

        #region Command

        private ICommand _command;

        public ICommand Command
        {
            get { return _command; }
            set
            { _command = value; }
        }

        public object CommandParameter { get; set; }

        #endregion Command
    }
}