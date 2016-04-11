using System;
using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Controls;
using JSIL.Dom.Styles;

namespace WebFormsTemplate
{
    /// <summary>
	/// Main WebForm
	/// </summary>
	public class MainForm : WebForm
    {
        #region Private Fields

        private Button button1;
        private PreformattedTextBlock outputBox1;
        private TextBlock textBlock1;
        private TextBox textBox1;
        private TextBlock titleBlock;

        #endregion Private Fields

        #region Public Constructors

        public MainForm()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public void addNameToBox(string name)
        {
            textBox1.Text = "";
            outputBox1.Text += name + "\n";
        }

        public override void PerformLayout()
        {
            base.PerformLayout();
            titleBlock = new TextBlock();
            this.Controls.Add(titleBlock);
            textBlock1 = new TextBlock();
            this.Controls.Add(textBlock1);
            textBox1 = new TextBox();
            textBox1.EnterPressed += (object sender, EventArgs e) => addNameToBox(textBox1.Text);
            this.Controls.Add(textBox1);
            button1 = new Button();
            button1.Click += (object sender, EventArgs e) => addNameToBox(textBox1.Text);
            this.Controls.Add(button1);
            outputBox1 = new PreformattedTextBlock();
            this.Controls.Add(outputBox1);
        }
        public override void UpdateContent()
        {
            base.UpdateContent();
            titleBlock.Text = "ExaPhaser.WebForms Demo";
            titleBlock.FontStyle = new FontStyle()
            {
                FontWeight = FontWeight.Bold,
                FontSize = 24,
            };
            titleBlock.TextAlign = TextAlign.Center;
            textBlock1.Text = "Enter your name:";
            button1.Text = "OK";
            outputBox1.Text = "";
            Console.WriteLine("It Works!");
        }

        #endregion Public Methods
    }
}