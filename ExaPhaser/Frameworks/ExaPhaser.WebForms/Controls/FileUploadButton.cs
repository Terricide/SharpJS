using System;
using System.Collections.Generic;
using JSIL;
using SharpJS.Dom.Elements;
using SharpJS.JSLibraries;

namespace ExaPhaser.WebForms.Controls
{
    /// <summary>
    ///     A control that represents a file upload button
    /// </summary>
    public sealed class FileUploadButton : Control
    {
        public FileUploadButton()
        {
            InternalElement = new InputElement
            {
                Type = "file"
            };
            PerformLayout();
        }

        /// <summary>
        /// Sets the file encoding if the UploadType is TextFile. The upload button must be reinitialized in order to change this property.
        /// </summary>
        public FileReaderEncoding FileEncoding { get; set; } = FileReaderEncoding.ASCII;

        /// <summary>
        /// Sets the type of the file being uploaded, and consequently, the type of parsing. The upload button must be reinitialized in order to change this property.
        /// </summary>
        public FileUploadType UploadType { get; set; } = FileUploadType.TextFile;

        public string Filter
        {
            set { SetFilter(value); }
        }

        #region Command

        /// <summary>
        ///     The command fired when a file is uploaded
        /// </summary>
        /// <value>The command.</value>
        public ICommand Command { get; set; }

        #endregion Command

        public event EventHandler<FileUploadEventArgs> FileOpened;

        public override void PerformLayout()
        {
            base.PerformLayout();
            Action<object, string, string> fileOpenAction = (jsBlob, textContent, dataUrl) =>
            {
                var eventArgs = new FileUploadEventArgs(jsBlob, textContent, dataUrl);
                FileOpened?.Invoke(this, eventArgs);
                Command?.Execute(new ICommandParameter(eventArgs));
            };

            Action<object> changeAction = evt =>
            {
                var input = Verbatim.Expression("evt.target");
                var file = Verbatim.Expression("$0.files[0]", input);
                var reader = Verbatim.Expression("new FileReader()");
                Action onLoadAction = () =>
                {
                    var jsBlob = Verbatim.Expression("$0.result", reader);
                    //string fileMimeType = (string)Verbatim.Expression("$0.type", file);
                    string textContent = null;
                    string dataUrl = null;
                    switch (UploadType)
                    {
                        case FileUploadType.TextFile:
                            switch (FileEncoding)
                            {
                                case FileReaderEncoding.ASCII:
                                    textContent = jsBlob as string;
                                    break;
                                case FileReaderEncoding.UTF8:
                                    textContent = BufferConverter.ArrayBufferToStringUTF8(jsBlob);
                                    break;

                                case FileReaderEncoding.UTF16:
                                    textContent = BufferConverter.ArrayBufferToStringUTF16(jsBlob);
                                    break;
                            }
                            break;
                        case FileUploadType.ImageFile:
                            dataUrl = jsBlob as string;
                            break;
                    }
                    fileOpenAction(jsBlob, textContent, dataUrl);
                };
                Verbatim.Expression("$0.onload = $1", reader, onLoadAction);
                switch (UploadType)
                {
                    case FileUploadType.TextFile:
                    case FileUploadType.BinaryFile:
                        if (FileEncoding == FileReaderEncoding.ASCII)
                        {
                            Verbatim.Expression("$0.readAsText($1);", reader, file);
                        }
                        else
                        {
                            Verbatim.Expression("$0.readAsArrayBuffer($1);", reader, file);
                        }
                        break;

                    case FileUploadType.ImageFile:
                        Verbatim.Expression("$0.readAsDataURL($1);", reader, file);
                        break;
                }
            };
            InternalJQElement.BindEventListener("change", changeAction);
        }

        private void SetFilter(string filter)
        {
            // Process the filter list to convert the syntax from C# standard filter syntax to HTML5:
            // Windows application filter syntax: Image Files (*.bmp, *.jpg)|*.bmp;*.jpg|All Files (*.*)|*.*
            // HTML5 filter syntax: .gif, .jpg, .png, .doc
            var fileTypes = filter.Split('|');
            var htmlFileTypes = new List<string>();
            if (fileTypes.Length == 1)
            {
                htmlFileTypes.Add(fileTypes[0]);
            }
            else
            {
                for (var i = 1; i < fileTypes.Length; i += 2)
                {
                    htmlFileTypes.Add(fileTypes[i]);
                }
            }
            var htmlFilter = string.Join(",", htmlFileTypes).Replace("*", "").Replace(";", ",");

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
    }

    public enum FileUploadType
    {
        TextFile,
        ImageFile,
        BinaryFile
    }

    public enum FileReaderEncoding
    {
        ASCII,
        UTF8,
        UTF16
    }

    /// <summary>
    /// Contains the data from a file upload. If the upload and resulting parse succeeded, its properties contain the results of the uploaded file depending on the UploadType.
    /// </summary>
    public class FileUploadEventArgs : EventArgs
    {
        /// <summary>
        ///     If the UploadType of the UploadButton was ImageFile, this contains the data URL representation of the file
        ///     uploaded. Otherwise, it is null.
        /// </summary>
        public readonly string DataURL;

        /// <summary>
        ///     This object contains the JavaScript Blob object
        /// </summary>
        public readonly object JSBlob;

        /// <summary>
        ///     If the UploadType of the UploadButton was TextFile, this contains the text representation of the file uploaded.
        ///     Otherwise, it is null.
        /// </summary>
        public readonly string PlainTextContent;

        public FileUploadEventArgs(object jsBlob, string plainTextContent, string dataUrl)
        {
            JSBlob = jsBlob;
            PlainTextContent = plainTextContent;
            DataURL = dataUrl;
        }
    }
}