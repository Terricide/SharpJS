namespace JSIL.UI.Input
{
    public class TextInput : InputBase
    {
        public TextInput()
        {
            SetAttributeValue("type", "text");
        }

        public string PlaceHolder
        {
            get { return GetAttributeValue("placeholder"); }
            set { SetAttributeValue("placeholder", value); }
        }
    }
}