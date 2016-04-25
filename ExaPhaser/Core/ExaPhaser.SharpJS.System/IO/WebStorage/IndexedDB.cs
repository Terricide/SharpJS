using JSIL;

namespace SharpJS.System.IO.WebStorage
{
    public class IndexedDB
    {
        private static object _indexedDbHandle;

        static IndexedDB()
        {
            _indexedDbHandle =
                Verbatim.Expression(
                    "window.indexedDB || window.mozIndexedDB || window.webkitIndexedDB || window.msIndexedDB");
        }
    }
}