using ExaPhaser.WebForms.Controls.Internal;
using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    /// <summary>
    /// A special control used for building custom controls from HTML elements from the SharpJS.Dom namespace.
    /// </summary>
    public sealed class HtmlControl : Control
    {
        #region Private Fields

        private readonly HtmlElementCollection _elements;

        #endregion Private Fields

        #region Public Constructors

        public HtmlControl()
        {
            InternalElement = new DivElement();
            _elements = new HtmlElementCollection(InternalElement);
            PerformLayout();
        }

        #endregion Public Constructors

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
    }
}