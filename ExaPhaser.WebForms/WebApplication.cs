using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaPhaser.WebForms.Themes;

namespace ExaPhaser.WebForms
{
    public class WebApplication
    {
    	CSSUITheme _css_uiTheme;
    	public WebApplication(CSSUITheme uitheme)
    	{
			_css_uiTheme = uitheme;
    	}
        public static void Run()
        {

        }
    }
}
