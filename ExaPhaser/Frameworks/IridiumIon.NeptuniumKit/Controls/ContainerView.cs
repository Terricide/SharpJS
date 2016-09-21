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
    }
}