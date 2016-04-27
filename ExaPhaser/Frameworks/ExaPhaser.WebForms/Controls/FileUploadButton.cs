using System;
using System.Collections.Generic;
using JSIL;
using SharpJS.Dom.Elements;
using SharpJS.JSLibraries;

namespace ExaPhaser.WebForms.Controls
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

        public FileReaderEncoding FileEncoding { get; set; } = FileReaderEncoding.UTF8;

        public override void PerformLayout()
        {
            base.PerformLayout();
            Action<object, string> fileOpenAction = (jsBlob, textContent) =>
            {
                var eventArgs = new FileUploadEventArgs(jsBlob, textContent);
                FileOpened?.Invoke(this, eventArgs);
                Command?.Execute(new ICommandParameter(eventArgs));
            };

            Action<object> changeAction = (object evt) =>
            {
                var input = Verbatim.Expression("evt.target");
                var file = Verbatim.Expression("$0.files[0]", input);
                var reader = Verbatim.Expression("new FileReader()");
                Action onLoadAction = () =>
                {
                    object jsBlob = Verbatim.Expression("$0.result", reader);
                    //string fileMimeType = (string)Verbatim.Expression("$0.type", file);
                    string textContent = "";
                    switch (FileEncoding)
                    {
                        case FileReaderEncoding.UTF8:
                            textContent = BufferConverter.ArrayBufferToStringUTF8(jsBlob);
                            break;
                        case FileReaderEncoding.UTF16:
                            textContent = BufferConverter.ArrayBufferToStringUTF16(jsBlob);
                            break;
                    }
                    fileOpenAction(jsBlob, textContent);
                };
                Verbatim.Expression("$0.onload = $1", reader, onLoadAction);
                Verbatim.Expression("$0.readAsArrayBuffer($1);", reader, file);
            };
            InternalJQElement.BindEventListener("change", changeAction);
        }

        private void SetFilter(string filter)
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

    public enum FileReaderEncoding
    {
        UTF8,
        UTF16,
    }

    public class FileUploadEventArgs : EventArgs
    {
        /// <summary>
        /// Only available if file is of type Plain Text.
        /// </summary>
        public readonly string PlainTextContent;

        public readonly object JavaScriptBlob;

        public FileUploadEventArgs(object javaScriptBlob, string plainTextContent)
        {
            this.JavaScriptBlob = javaScriptBlob;
            this.PlainTextContent = plainTextContent;
        }
    }
}