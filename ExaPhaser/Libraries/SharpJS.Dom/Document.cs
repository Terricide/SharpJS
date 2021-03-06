﻿using System.Linq;
using JSIL;
using JSIL.Meta;

namespace SharpJS.Dom
{
    public class Document
    {
        public static Element Body => GetElementsByTagName("body")[0];

        public static Element GetElementById(string id)
        {
            return Element.GetById(id);
        }

        public static Element[] GetElementsByTagName(string tagName)
        {
            return
                ((object[])Verbatim.Expression("Array.prototype.slice.call(document.getElementsByTagName(tagName))"))
                    .Select(Element.GetElement).ToArray();
        }

        public static Element[] GetElementsByClassName(string tagName)
        {
            return
                ((object[])Verbatim.Expression("Array.prototype.slice.call(document.getElementsByClassName(tagName))"))
                    .Select(Element.GetElement).ToArray();
        }

        public static Element[] GetElementsByTag<T>() where T : Element, new()
        {
            var elementInstance = new T();
            return
                ((object[])
                    Verbatim.Expression(
                        "Array.prototype.slice.call(document.getElementsByTagName(elementInstance.TagName))")).Select(
                            Element.GetElement).ToArray();
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

        /// <summary>
        /// Represents the title of the web page
        /// </summary>
        public static string Title
        {
            get { return (string)Verbatim.Expression("document.title"); }
            set { Verbatim.Expression("document.title = $0", value); }
        }

        public static int ClientWidth => (int)Verbatim.Expression("document.documentElement.clientWidth");

        public static int ClientHeight => (int)Verbatim.Expression("document.documentElement.clientHeight");
    }
}