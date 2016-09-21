using IridiumIon.NeptuniumKit.ComponentModel;
using SharpJS.Dom.Elements;
using System;

namespace IridiumIon.NeptuniumKit.Controls
{
    public class Button : TextView
    {
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }

        public Button() : base()
        {
            UnderlyingElement = new AnchorElement();
            //Add Materialize Button classes
            UnderlyingJQElement.AddClass("waves-effect waves-light btn");
            Create();
            UnderlyingJQElement.Click += OnClick;
        }

        /// <summary>
        /// Called when a Click event is received from the DOM/jQuery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, EventArgs e)
        {
            Command?.Execute(CommandParameter);
        }
    }
}