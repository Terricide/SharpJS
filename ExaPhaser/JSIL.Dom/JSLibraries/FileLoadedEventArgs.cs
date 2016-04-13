using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSIL.Dom.JSLibraries
{
    public class FileLoadedEventArgs : EventArgs
    {
        public object Target;
    }

    public delegate void FileLoadedEventHandler(object sender, FileLoadedEventArgs e);
}
