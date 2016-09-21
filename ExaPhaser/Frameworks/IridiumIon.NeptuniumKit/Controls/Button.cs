using SharpJS.Dom.Elements;

namespace IridiumIon.NeptuniumKit.Controls
{
    public class Button : TextView
    {
        public Button() : base()
        {
            UnderlyingElement = new AnchorElement();
            //Add Materialize Button classes
            UnderlyingJQElement.AddClass("waves-effect waves-light btn");
            Create();
        }
    }
}