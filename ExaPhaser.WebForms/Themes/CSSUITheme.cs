
using System;

namespace ExaPhaser.WebForms.Themes
{
	/// <summary>
	/// The UI Theme, based on a CSS Framework
	/// </summary>

	public class CSSUITheme
	{
        CSSFramework _stylesheet;
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
