using ExaPhaser.WebForms.Controls.Internal;
using JSIL.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    public class HtmlControl : Control
    {
        #region Private Fields

        private HtmlElementCollection _elements;

        #endregion Private Fields

        #region Public Properties

        public ElementGroup Elements
        {
            get { return new ElementGroup(_elements); }
            set { SetElements(value); }
        }

        #endregion Public Properties

        #region Private Methods

        private void SetElements(ElementGroup newElements)
        {
            foreach (var newElement in newElements)
            {
                _elements.Add(newElement);
            }
        }

        #endregion Private Methods

        #region Public Constructors

        public HtmlControl() : base()
        {
            InternalElement = new DivElement();
            _elements = new HtmlElementCollection(InternalElement);
            PerformLayout();
        }

        #endregion Public Constructors
    }
}