using System;
using JSIL.Meta;

namespace JSIL.Dom.JSLibraries
{
    public class FileReader
    {
        #region Private Fields

        private object _fileReaderHandle;

        private Action<object> OnLoadAction;

        #endregion Private Fields

        #region Public Constructors

        public FileReader()
        {
            bool fileReaderSupported = Builtins.IsTruthy(Verbatim.Expression("'FileReader' in window"));
            if (!fileReaderSupported)
            {
                throw new InvalidOperationException("The browser does not support the HTML5 FileReader API!");
            }
            _fileReaderHandle = Verbatim.Expression("new FileReader()");
            OnLoadAction = (o) =>
            {
                OnLoad(this, new FileLoadedEventArgs()
                {
                    Target = Verbatim.Expression("o.target"),
                });
            };
            Verbatim.Expression("this._fileReaderHandle.onload = this.OnLoadAction");
        }

        #endregion Public Constructors

        #region Public Events

        public event FileLoadedEventHandler Load;

        #endregion Public Events

        #region Public Methods

        [JSReplacement("$this._fileReaderHandle.readAsText($fileHandle)")]
        public void ReadAsText(object fileHandle)
        {
        }

        [JSReplacement("$this._fileReaderHandle.readAsDataURL($fileHandle)")]
        public void ReadAsDataURL(object fileHandle)
        {
        }

        [JSReplacement("$this._fileReaderHandle.readAsArrayBuffer($fileHandle)")]
        public void ReadAsArrayBuffer(object fileHandle)
        {
        }

        #endregion Public Methods

        #region Private Methods

        private void OnLoad(object sender, FileLoadedEventArgs e)
        {
            FileLoadedEventHandler handler = Load;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Private Methods
    }
}