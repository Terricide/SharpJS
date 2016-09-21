using SharpJS.Dom.Elements;
using SharpJS.JSLibraries.JQuery;

namespace IridiumIon.NeptuniumKit.Controls
{
    public class TextView : NKView
    {
        public TextView() : base()
        {
            //Text = ""; //Don't set text to null?
            //Set underlying element to an INPUT
            UnderlyingElement = new JQElement(new InputElement());
        }

        public string Text { get; set; }
    }
}