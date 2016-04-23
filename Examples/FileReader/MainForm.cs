/*
 */
using System;
using SharpJS.Dom;
using SharpJS.Dom.Elements;
using SharpJS.Dom.JSLibraries;
using SharpJS.Dom.Styles;
using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Controls;
using System.IO.WebStorage;

namespace webformsttest
{
	/// <summary>
	/// Main WebForm
	/// </summary>
	public class MainForm : WebForm
	{
		TextArea textArea1;
		LocalStorageHandle localStorage;
		public MainForm()
		{
			localStorage = new LocalStorageHandle();
			textArea1 = new TextArea()
			{
				Rows = 20,
			};
			Controls = new Layout()
			{
				new TextBlock()
				{
					Text = "SharpJS Demo Application",
					TextAlign = TextAlign.Center,
					FontStyle = new FontStyle()
					{
						FontWeight = FontWeight.Bold,
						FontSize = 24,
					},
				},
				new TextBlock()
				{
					Text = "Please upload something.",
				},
				new Button()
				{
					Text = "Upload",
					Command = new DelegateCommand((Action)UploadButtonClicked),
				},
				new HtmlControl()
				{
					Elements = new ElementGroup()
					{
						new InputElement()
						{
							Type = "file",
							Id = "fileuploadbtn",
							Style = "display:none;",
						}
					}
				},				
				textArea1,
			};
		}
		public override void UpdateContent()
		{
			base.UpdateContent();
			var uploadBtn = new JqElement(Document.GetElementById("fileuploadbtn"));
			uploadBtn.BindEventListener("change", (object o) => 
			{
            	object[] files = (object[])JSLibrary.ObjectToArray(JSIL.Verbatim.Expression("o.target.files"));
				var reader = new FileReader();
				reader.Load += (object sender, FileLoadedEventArgs e) => {
					var fileLoadTarget = e.Target;
					string dR = (string)JSIL.Verbatim.Expression("fileLoadTarget.result");
					textArea1.Text = dR;
				};
				reader.ReadAsText(files[0]);
			});
		}
		void UploadButtonClicked()
		{
			var uploadBtn = new JqElement(Document.GetElementById("fileuploadbtn"));
			uploadBtn.Trigger("click");
		}
	}
}