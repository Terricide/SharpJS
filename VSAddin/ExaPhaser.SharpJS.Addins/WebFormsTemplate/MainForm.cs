using System;
using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Controls;

namespace WebFormsTemplate
{
    /// <summary>
	/// Main WebForm
	/// </summary>
	public class MainForm : WebForm
    {
        TextBlock textBlock1;
        TextBox textBox1;
        public MainForm()
        {

        }

        public override void PerformLayout()
        {
            base.PerformLayout();
            textBlock1 = new TextBlock();
            this.Controls.Add(textBlock1);
            textBox1 = new TextBox();
            this.Controls.Add(textBox1);
        }

        public override void UpdateContent()
        {
            base.UpdateContent();
            textBlock1.Text = "I like pie!";
        }
    }
}