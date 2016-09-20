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
        }

        public JQElement HostElement { get; set; }
        public INKView RootView { get; private set; }
    }
}