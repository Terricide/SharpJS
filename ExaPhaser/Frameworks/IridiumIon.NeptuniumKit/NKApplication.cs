using IridiumIon.NeptuniumKit.Controls;
using SharpJS.JSLibraries.JQuery;

namespace IridiumIon.NeptuniumKit
{
    public abstract class NKApplication
    {
        public NKApplication()
        {
            //Initializer logic
        }

        /// <summary>
        /// This method is called by the bootstrapper when the application object is ready to be created and rendered.
        /// </summary>
        public virtual void Create()
        {
            RootView = new ContainerView();
            HostElement.Append(RootView.UnderlyingElement); //Add the root view to the host element
        }

        public JQElement HostElement { get; set; }
        public ContainerView RootView { get; private set; }
    }
}