using System;
using JSIL;
using JSIL.Meta;

namespace SharpJS.Dom.JSLibraries
{
    public class FileReader
    {
        #region Public Constructors

        public FileReader()
        {
            var fileReaderSupported = Builtins.IsTruthy(Verbatim.Expression("'FileReader' in window"));
            if (!fileReaderSupported)
            {
                throw new InvalidOperationException("The browser does not support the HTML5 FileReader API!");
            }
            _fileReaderHandle = Verbatim.Expression("new FileReader()");
            _onLoadAction = o =>
            {
                OnLoad(this, new FileLoadedEventArgs
                {
                    Target = Verbatim.Expression("o.target")
                });
            };
            Verbatim.Expression("this._fileReaderHandle.onload = this._onLoadAction");
        }

        #endregion Public Constructors

        #region Public Events

        public event FileLoadedEventHandler Load;

        #endregion Public Events

        #region Private Methods

        private void OnLoad(object sender, FileLoadedEventArgs e)
        {
            var handler = Load;
            handler?.Invoke(this, e);
        }

        #endregion Private Methods

        #region Private Fields

        private object _fileReaderHandle;

        private Action<object> _onLoadAction;

        #endregion Private Fields

        #region Public Methods

        [JSReplacement("$this._fileReaderHandle.readAsText($fileHandle)")]
        public void ReadAsText(object fileHandle)
        {
        }

        [JSReplacement("$this._fileReaderHandle.readAsDataURL($fileHandle)")]
        public void ReadAsDataUrl(object fileHandle)
        {
        }

        [JSReplacement("$this._fileReaderHandle.readAsArrayBuffer($fileHandle)")]
        public void ReadAsArrayBuffer(object fileHandle)
        {
        }

        #endregion Public Methods
    }
}