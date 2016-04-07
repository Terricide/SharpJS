namespace ExaPhaser.WebForms.Themes
{
    /// <summary>
    /// The UI Theme, based on a CSS Framework
    /// </summary>

    public class CSSUITheme
    {
        private CSSFramework _stylesheet;

        public CSSFramework Stylesheet
        {
            get
            {
                return _stylesheet;
            }
        }

        public CSSUITheme(CSSFramework stylesheet)
        {
            _stylesheet = stylesheet;
        }
    }
}