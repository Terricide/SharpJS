using SharpJS.JSLibraries;

namespace System.Windows.Forms
{
    public class SaveFileDialog
    {
        public void DownloadJSBlob(object blob, string fileName)
        {
            FileDownloader.SaveJSBlobToFile(blob, fileName);
        }

        public void DownloadText(string text, string fileName)
        {
            FileDownloader.SaveTextToFile(text, fileName);
        }
    }
}