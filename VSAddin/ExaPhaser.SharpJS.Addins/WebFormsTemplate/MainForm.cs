using System;
using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Controls;
using JSIL.Dom;
using JSIL.Dom.Styles;

namespace WebFormsTemplate
{
    /// <summary>
	/// Main WebForm
	/// </summary>
	public class MainForm : WebForm
    {
        public MainForm()
        {
            Controls = new Layout()
            {
                new TextBlock()
                {
                    Text = "ExaPhaser.WebForms Demo",
                    TextAlign = TextAlign.Center,
                    FontStyle = new FontStyle()
                    {
                        FontSize = 24,
                        FontWeight = FontWeight.Bold,
                    }
                },
                new TextBlock()
                {
                    Text = "A random TextBox is below",
                },
                new TextBox()
                {
                    Text = "Some text",
                },
                new Button()
                {
                    Text = "OK",
                    CommandParameter = null,
                    Command = new DelegateCommand(()=>JSLibrary.Alert("You clicked the button")),
                }
            };
        }
        
    }
}