using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Controls;
using SharpJS.Dom;
using SharpJS.Dom.Styles;

namespace WebFormsTemplate
{
    /// <summary>
    ///     Main WebForm
    /// </summary>
    public class MainForm : WebForm
    {
        public MainForm()
        {
            Controls = new Layout
            {
                new TextBlock
                {
                    Text = "ExaPhaser.WebForms Demo",
                    TextAlign = TextAlign.Center,
                    FontStyle = new FontStyle
                    {
                        FontSize = 24,
                        FontWeight = FontWeight.Bold
                    }
                },
                new TextBlock
                {
                    Text = "A random TextBox is below"
                },
                new TextBox
                {
                    PlaceholderText = "Placeholder Stuff",
                },
                new Button
                {
                    Text = "OK",
                    Command = new DelegateCommand(() => JSLibrary.Alert("You clicked the button"))
                },
                new TextArea
                {
                    PlaceholderText = "This awesome placeholder!",
                    Rows = 20
                }
            };
        }
    }
}