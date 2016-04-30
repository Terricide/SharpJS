using ExaPhaser.WebForms;
using ExaPhaser.WebForms.Controls;

namespace System.Windows.Forms
{
    public class OpenFileDialog
    {
        #region Private Fields

        private readonly FileUploadButton _fileUpload;

        #endregion Private Fields

        #region Public Constructors

        public OpenFileDialog()
        {
            _fileUpload = new FileUploadButton
            {
                UploadType = FileUploadType.TextFile,
                FileEncoding = FileReaderEncoding.ASCII
            };
        }

        #endregion Public Constructors

        #region Public Properties

        public string FileName
        {
            get { return _fileUpload.FileName; }
            set { _fileUpload.FileName = value; }
        }

        public FileUploadButton FileUploadButton => _fileUpload;

        #endregion Public Properties

        #region Public Methods

        public DialogResult ShowDialog()
        {
            _fileUpload.SimulateClick();
            _fileUpload.Command = new ParameterizedCommand((parameter) => FileUploaded?.Invoke(this, new OpenFileDialogEventArgs(parameter.Parameter as FileUploadEventArgs)));
            return DialogResult.Unspecified;
        }

        #endregion Public Methods

        #region Public Events

        public event EventHandler<OpenFileDialogEventArgs> FileUploaded;

        #endregion Public Events
    }

    public class OpenFileDialogEventArgs
    {
        #region Private Fields

        private readonly FileUploadEventArgs _fileUploadEventArgs;

        #endregion Private Fields

        #region Public Constructors

        public OpenFileDialogEventArgs(FileUploadEventArgs fileUploadEventArgs)
        {
            this._fileUploadEventArgs = fileUploadEventArgs;
        }

        #endregion Public Constructors

        #region Public Properties

        public string DataUrl => _fileUploadEventArgs.DataURL;
        public object JSBlob => _fileUploadEventArgs.JSBlob;

        public string TextContent => _fileUploadEventArgs.PlainTextContent;

        #endregion Public Properties
    }
}