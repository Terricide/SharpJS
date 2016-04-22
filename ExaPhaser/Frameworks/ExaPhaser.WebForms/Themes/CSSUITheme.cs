namespace ExaPhaser.WebForms.Themes
{
    /// <summary>
    ///     The UI Theme, based on a CSS Framework
    /// </summary>
    public class CSSUITheme
    {
        public CSSUITheme(CSSFramework stylesheet)
        {
            Stylesheet = stylesheet;
        }

        public CSSFramework Stylesheet { get; }
    }
}