using SharpJS.JSLibraries.JQuery;

namespace IridiumIon.NeptuniumKit.Controls
{
    public class TextView : NKView
    {
        public TextView() : base()
        {
            //Text = ""; //Don't set text to null?
            //Set underlying element to an INPUT
            UnderlyingElement = new JQElement(JQuery.FromSelector("<input />").DomRepresentation);
        }

        public string Text { get; set; }
    }
}