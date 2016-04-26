using System.Linq;
using JSIL;
using JSIL.Meta;

namespace SharpJS.Dom
{
    public class Document
    {
        public static Element Body
        {
            get
            {
                return GetElementsByTagName("body")[0]; //There should only be one body
            }
        }

        public static Element GetElementById(string id)
        {
            return Element.GetById(id);
        }

        public static Element[] GetElementsByTagName(string tagName)
        {
            return
                ((object[]) Verbatim.Expression("Array.prototype.slice.call(document.getElementsByTagName(tagName))"))
                    .Select(element => Element.GetElement(element)).ToArray();
        }

        public static Element[] GetElementsByClassName(string tagName)
        {
            return
                ((object[]) Verbatim.Expression("Array.prototype.slice.call(document.getElementsByClassName(tagName))"))
                    .Select(element => Element.GetElement(element)).ToArray();
        }

        public static Element[] GetElementsByTag<T>() where T : Element, new()
        {
            var elementInstance = new T();
            return
                ((object[])
                    Verbatim.Expression(
                        "Array.prototype.slice.call(document.getElementsByTagName(elementInstance.TagName))")).Select(
                            element => Element.GetElement(element)).ToArray();
        }

        public static Element CreateElement(string elementNodeName)
        {
            return new Element(elementNodeName);
        }

        [JSReplacement("document.appendChild($node.ElementHandle)")]
        public static void AppendChild(Element node)
        {
        }

        [JSReplacement("document.insertBefore($node.ElementHandle, $existingNode_element)")]
        public static void InsertBefore(Element node, Element existingNode)
        {
        }
    }
}