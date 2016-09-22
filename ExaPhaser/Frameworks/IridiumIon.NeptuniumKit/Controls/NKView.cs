using IridiumIon.NeptuniumKit.ComponentModel;
using IridiumIon.NeptuniumKit.Controls.Properties;
using SharpJS.Dom;
using SharpJS.JSLibraries.JQuery;

namespace IridiumIon.NeptuniumKit.Controls
{
    public abstract class NKView
    {
        private Margin _margin;
        private Size _size;

        /// <summary>
        /// Represents the parent view of this view. This may be null if this view
        /// has not been added to a container.
        /// </summary>
        public NKView Parent { get; set; }

        /// <summary>
        /// A collection of child views. Note that this is designed for use with ContainerView,
        /// but some other views might also be allowed to have chidlren in the future.
        /// Note that this property may be moved to the ContainerView class in the future
        /// </summary>
        public NKViewCollection Children { get; set; } = new NKViewCollection();

        /// <summary>
        /// A SharpJS.Dom Element class that represents the element that represents this view
        /// </summary>
        public Element UnderlyingElement { get; set; }// = new JQElement(JQuery.FromSelector("<div />").DomRepresentation);

        /// <summary>
        /// A JQElement instance of the underlying element that can be used to call jQuery methods.
        /// </summary>
        public JQElement UnderlyingJQElement { get { return new JQElement(UnderlyingElement); } }

        /// <summary>
        /// This property is currently TODO- it doesn't really do anything.
        /// </summary>
        public INotifyPropertyChanged DataContext { get; set; }

        /// <summary>
        /// Specifies the sizing mode for the view.
        /// </summary>
        public SizeMode SizeMode { get; set; }

        /// <summary>
        /// Specifies the size constraints of the view. This only has an effect if SizeMode is set to Fixed.
        /// </summary>
        public Size Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
                if (SizeMode != SizeMode.Automatic) //Redirect all manual sizemodes to the update size layout
                    UpdateSizeLayout();
            }
        }

        /// <summary>
        /// The margin for this View. This property only has an effect if this view's parent is a container with Absolute layout.
        /// In order for the styles to update, you should create a new Margin object rather than manipulating it.
        /// </summary>
        public Margin Margin
        {
            get
            {
                return _margin;
            }

            set
            {
                _margin = value;
                UpdateMarginLayout();
            }
        }

        /// <summary>
        /// Updates the element's layout styles
        /// </summary>
        protected virtual void UpdateMarginLayout()
        {
            UnderlyingJQElement.Css("position", "absolute");
            UnderlyingJQElement.Css("left", _margin.Left);
            UnderlyingJQElement.Css("top", _margin.Top);
            UnderlyingJQElement.Css("right", _margin.Right);
            UnderlyingJQElement.Css("bottom", _margin.Bottom);
        }

        protected virtual void UpdateSizeLayout()
        {
            UnderlyingJQElement.Css("width", Size.Width);
            UnderlyingJQElement.Css("height", Size.Height);
        }
    }
}