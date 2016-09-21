using IridiumIon.NeptuniumKit.ComponentModel;
using IridiumIon.NeptuniumKit.Controls.Properties;
using SharpJS.Dom;
using SharpJS.JSLibraries.JQuery;

namespace IridiumIon.NeptuniumKit.Controls
{
    public abstract class NKView
    {
        private Margin margin;

        public NKView()
        {
            UpdateMarginLayout();
        }

        public NKView Parent { get; set; }
        public NKViewCollection Children { get; set; } = new NKViewCollection();
        public Element UnderlyingElement { get; set; }// = new JQElement(JQuery.FromSelector("<div />").DomRepresentation);
        public JQElement UnderlyingJQElement { get { return new JQElement(UnderlyingElement); } }
        public INotifyPropertyChanged DataContext { get; set; }

        /// <summary>
        /// The margin for this View. This property only has an effect in an Absolute layout.
        /// In order for the styles to update, you should create a new Margin object rather than manipulating it.
        /// </summary>
        public Margin Margin
        {
            get
            {
                return margin;
            }

            set
            {
                margin = value;
                UpdateMarginLayout();
            }
        }

        /// <summary>
        /// Updates the element's layout styles
        /// </summary>
        private void UpdateMarginLayout()
        {
            UnderlyingJQElement.Css("position", "absolute");
            UnderlyingJQElement.Css("left", margin.Left);
            UnderlyingJQElement.Css("top", margin.Top);
            UnderlyingJQElement.Css("right", margin.Right);
            UnderlyingJQElement.Css("bottom", margin.Bottom);
        }
    }
}