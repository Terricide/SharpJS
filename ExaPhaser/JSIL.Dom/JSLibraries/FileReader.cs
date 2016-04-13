using System;

namespace JSIL.Dom.JSLibraries
{
    public class FileReader
    {
        public FileReader()
        {
            object _fileReaderHandle;
            bool fileReaderSupported = Builtins.IsTruthy(Verbatim.Expression("'FileReader' in window"));
            if (!fileReaderSupported)
            {
                throw new InvalidOperationException("The browser does not support the HTML5 FileReader API!");
            }
            _fileReaderHandle = Verbatim.Expression("new FileReader()");
        }

        private void OnLoad(object sender, FileLoadedEventArgs e)
        {
            FileLoadedEventHandler handler = Load;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event FileLoadedEventHandler Load;
    }
}