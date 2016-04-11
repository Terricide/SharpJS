using JSIL.Dom.Styles;

namespace ExaPhaser.WebForms
{
    public class FontStyle
    {
        private FontWeight _fontWeight = FontWeight.Normal;
        private int _fontSize = 16;

        public FontWeight FontWeight
        {
            get
            {
                return _fontWeight;
            }

            set
            {
                _fontWeight = value;
            }
        }

        public int FontSize
        {
            get
            {
                return _fontSize;
            }

            set
            {
                _fontSize = value;
            }
        }
    }
}