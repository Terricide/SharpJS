using JSIL;
using JSIL.Meta;

namespace SharpJS.System.IO.WebStorage
{
    public class StorageBase
    {
        private object _storageHandle;

        public StorageBase(WebStorageType storageType)
        {
            switch (storageType)
            {
                case WebStorageType.LocalStorage:
                    _storageHandle = Verbatim.Expression("window.localStorage");
                    break;
                case WebStorageType.SessionStorage:
                    _storageHandle = Verbatim.Expression("window.sessionStorage");
                    break;
            }
        }

        [JSReplacement("$this._storageHandle.key($keyNum)")]
        public string Key(int keyNum)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._storageHandle.getItem($keyName)")]
        public string GetItem(string keyName)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._storageHandle.setItem($keyName, $keyValue)")]
        public string SetItem(string keyName, string keyValue)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._storageHandle.removeItem($keyName)")]
        public void RemoveItem(string keyName)
        {
        }

        [JSReplacement("$this._storageHandle.clear()")]
        public void Clear()
        {
        }
    }
}