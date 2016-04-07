using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSIL.Dom
{
    public class Document
    {
        public static Element GetElementById(string id)
        {
            return Element.GetById(id);
        }
        public static Element[] GetElementsByTagName(string tagName)
        {
            return ((object[])Verbatim.Expression("Array.prototype.slice.call(document.getElementsByTagName(tagName))")).Select(element => Element.GetElement(element)).ToArray();
        }

        public static Element[] GetElementsByTag<T>() where T : Element, new()
        {
            var elementInstance = new T();
            return ((object[])Verbatim.Expression("Array.prototype.slice.call(document.getElementsByTagName(elementInstance.TagName))")).Select(element => Element.GetElement(element)).ToArray();
        }
    }
}
