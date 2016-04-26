using JSIL;
using System;
using System.Collections.Generic;
using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms
{
	/// <summary>
	/// A control that represents a file upload button
	/// </summary>
	public sealed class FileUploadButton : Control
	{
		public event EventHandler<FileUploadEventArgs> FileOpened;
		public FileUploadButton()
		{
			InternalElement = new InputElement
			{
				Type = "file",
			};
			PerformLayout();
		}

		public override void UpdateContent()
		{
			base.UpdateContent();
			Action<object, string> fileOpenAction = (jsBlob, textContent) =>
			{
				var eventArgs = new FileUploadEventArgs(jsBlob, textContent);
				FileOpened?.Invoke(this, eventArgs);
				Command?.Execute(new ICommandParameter(eventArgs));
			};
			Action<object> changeAction = (object evt) =>
			{
				var input = Verbatim.Expression("evt.target");
				var file = Verbatim.Expression("input.files[0]");
				var reader = Verbatim.Expression("new FileReader()");
				Verbatim.Expression(@"
				reader.onload = function(){
                      var callback = $1;
                      var plainTextContentIfAny = '';
                      var jsBlob = reader.result;
                      if (file.type == 'text/plain'){
                        plainTextContentIfAny = reader.result;
                      }
                      callback(jsBlob, plainTextContentIfAny);
                    };
                    reader.readAsText(file);
				", InternalElement.DOMRepresentation, fileOpenAction);
			};
			InternalJQElement.BindEventListener("change", changeAction);
		}

		void SetFilter(string filter)
		{
			// Process the filter list to convert the syntax from C# standard filter syntax to HTML5:
			// Windows application filter syntax: Image Files (*.bmp, *.jpg)|*.bmp;*.jpg|All Files (*.*)|*.*
			// HTML5 filter syntax: .gif, .jpg, .png, .doc
			string[] fileTypes = filter.Split('|');
			List<string> htmlFileTypes = new List<string>();
			if (fileTypes.Length == 1)
			{
				htmlFileTypes.Add(fileTypes[0]);
			}
			else
			{
				for (int i = 1; i < fileTypes.Length; i += 2)
				{
					htmlFileTypes.Add(fileTypes[i]);
				}
			}
			string htmlFilter = String.Join(",", htmlFileTypes).Replace("*", "").Replace(";", ",");

			// Apply the filter:
			if (!string.IsNullOrWhiteSpace(htmlFilter))
			{
				Verbatim.Expression(@"$0.accept = $1", InternalElement.DOMRepresentation, htmlFilter);
			}
			else
			{
				Verbatim.Expression(@"$0.accept = """"", InternalElement.DOMRepresentation);
			}
		}

		public string Filter
		{
			set { SetFilter(value); }
		}

		#region Command

		/// <summary>
		/// The command fired when a file is uploaded
		/// </summary>
		/// <value>The command.</value>
		public ICommand Command { get; set; }

		#endregion Command
	}

	public class FileUploadEventArgs : EventArgs
	{
		/// <summary>
		/// Only available if file is of type Plain Text.
		/// </summary>
		public readonly string PlainTextContent;

		public readonly object JavaScriptBlob;

		public FileUploadEventArgs(object javaScriptBlob, string plainTextContentIfAny)
		{
			this.JavaScriptBlob = javaScriptBlob;
			this.PlainTextContent = plainTextContentIfAny;
		}
	}
}

