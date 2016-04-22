using System.Collections.ObjectModel;
using JSIL.Dom;

namespace ExaPhaser.WebForms.Controls.Internal
{
    internal class HtmlElementCollection : Collection<Element>
    {
        #region Private Fields

        private readonly Element _parentElement;

        #endregion Private Fields

        #region Public Constructors

        public HtmlElementCollection(Element parentElement)
        {
            _parentElement = parentElement;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void InsertItem(int index, Element item)
        {
            base.InsertItem(index, item);
            _parentElement.AppendChild(item);
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            _parentElement.RemoveChild(item);
            base.RemoveItem(index);
        }

        #endregion Protected Methods
    }
}