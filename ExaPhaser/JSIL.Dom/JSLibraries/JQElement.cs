namespace JSIL.Dom.JSLibraries
{
    /// <summary>
    /// An enhanced version of the Element class that utilizes jQuery.
    /// </summary>
    public class JQElement : Element
    {
        protected JQueryObject jqObject;

        public JQElement(Element element)
        {
            jqObject = JQuery.GetJQueryObject(element);
        }

        public override void AddClass(string className)
        {
            jqObject.AddClass(className);
        }

        public override void RemoveClass(string className)
        {
            jqObject.RemoveClass(className);
        }
    }
}