using IridiumIon.NeptuniumKit.Controls.Properties;
using SharpJS.Dom.Elements;

namespace IridiumIon.NeptuniumKit.Controls
{
    /// <summary>
    /// Represents a view that contains child views
    /// </summary>
    public class ContainerView : NKView
    {
        public ContainerView() : base()
        {
            //Any child views will have this view as parent
            Children.ParentView = this;
            UnderlyingElement = new DivElement();
        }

        public void ApplyLayoutStyles()
        {
            switch (LayoutStyle)
            {
                case LayoutStyle.Absolute:
                    UnderlyingJQElement.Css("position", "relative");
                    break;
            }
        }

        public void ApplyChildStyle(NKView childView)
        {
            switch (LayoutStyle)
            {
                case LayoutStyle.Absolute:
                    /*
                    var children = UnderlyingJQElement.DynamicInvoke("children", new string[0]);
                    var layoutChildrenJQueryObject = new JQueryObject(children);
                    layoutChildrenJQueryObject.Css("margin", "0px");
                    layoutChildrenJQueryObject.Css("padding", "0px");
                    */
                    if (childView is TextView && childView.UnderlyingElement is ParagraphElement)
                    {
                        //Remove spacing on <p> elements
                        childView.UnderlyingJQElement.Css("margin", "0px");
                        childView.UnderlyingJQElement.Css("padding", "0px");
                    }
                    break;
            }
        }

        private LayoutStyle layoutStyle;

        /// <summary>
        /// The layout style of the container view. This should be set before adding any child elements, and should not be changed.
        /// </summary>
        public LayoutStyle LayoutStyle
        {
            get
            {
                return layoutStyle;
            }

            set
            {
                layoutStyle = value;
                ApplyLayoutStyles();
            }
        }
    }
}