namespace JSIL.Dom.JSLibraries
{
    /// <summary>
    /// An enhanced version of the Element class that utilizes jQuery.
    /// </summary>
    public class JQElement
    {
        private JQueryObject jqObject;

        public JQueryObject JQueryObjectHandle
        {
            get
            {
                return jqObject;
            }

            set
            {
                jqObject = value;
            }
        }

        public Element DOMRepresentation
        {
            get
            {
                return jqObject.DOMRepresentation;
            }
        }

        public JQElement(Element element)
        {
            jqObject = JQuery.GetJQueryObject(element);
        }

        public void AddClass(string className)
        {
            jqObject.AddClass(className);
        }

        public void RemoveClass(string className)
        {
            jqObject.RemoveClass(className);
        }

        public void Append(string elementHtml)
        {
            jqObject.Append(elementHtml);
        }

        public void Append(JQElement jqElement)
        {
            jqObject.Append(jqElement);
        }
    }
}