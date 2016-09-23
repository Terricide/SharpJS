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

        /// <summary>
        /// We call the standard update size layout, but we also need to add some padding
        /// to the top/?bottom too???? of the button to keep it looking normal
        /// Also take into account the text style and size.
        /// </summary>
        protected override void UpdateSizeLayout()
        {
            base.UpdateSizeLayout();

            //Add padding to the button to make it look less weird
            var topSpacing = Size.Height / 2 - Style.TextSize / 2; //optimal top padding
            UnderlyingJQElement.Css("padding-top", topSpacing);
        }

        public override void UpdateStyles(object sender, string propertyName)
        {
            base.UpdateStyles(sender, propertyName);

            UpdateSizeLayout(); //The text size affects size layout
        }
    }
}