using System;

namespace JSIL.Dom.JSLibraries
{
    public class FileLoadedEventArgs : EventArgs
    {
        public object Target;
    }

    public delegate void FileLoadedEventHandler(object sender, FileLoadedEventArgs e);
}