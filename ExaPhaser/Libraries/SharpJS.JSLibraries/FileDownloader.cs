using System;
using JSIL;

namespace SharpJS.JSLibraries
{
    public static class FileDownloader
    {
        #region Public Methods

        public static void SaveJSBlobToFile(object javaScriptBlob, string filename)
        {
            if (javaScriptBlob == null) throw new ArgumentNullException(nameof(javaScriptBlob));
            if (filename == null) throw new ArgumentNullException(nameof(filename));
            Verbatim.Expression(@"saveAs($0, $1)", javaScriptBlob, filename);
        }

        public static void SaveTextToFile(string text, string fileName)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            Verbatim.Expression(@"
                var blob = new Blob([$0], { type: ""text/plain;charset=utf-8""});
                saveAs(blob, $1)
            ", text, fileName);
        }

        #endregion Public Methods
    }
}