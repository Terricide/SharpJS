using System.Collections.Generic;
using JSIL;
using JSIL.Meta;

namespace SharpJS.System.IO.WebStorage
{
    public class StorageBase
    {
        #region Private Fields

        private object _storageHandle;

        #endregion Private Fields

        #region Public Constructors

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

        #endregion Public Constructors

        #region Public Properties

        public string[] Keys => GetKeys();

        public int Length => GetLength();

        #endregion Public Properties

        #region Public Methods

        [JSReplacement("$this._storageHandle.clear()")]
        public void Clear()
        {
        }

        [JSReplacement("$this._storageHandle.getItem($keyName)")]
        public string GetItem(string keyName)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._storageHandle.key($keyNum)")]
        public string Key(int keyNum)
        {
            throw new RequiresJSILRuntimeException();
        }

        [JSReplacement("$this._storageHandle.removeItem($keyName)")]
        public void RemoveItem(string keyName)
        {
        }

        [JSReplacement("$this._storageHandle.setItem($keyName, $keyValue)")]
        public string SetItem(string keyName, string keyValue)
        {
            throw new RequiresJSILRuntimeException();
        }

        #endregion Public Methods

        #region Private Methods

        private string[] GetKeys()
        {
            List<string> keyList = new List<string>();
            for (int i = 0; i < Length; i++)
            {
                keyList.Add(Key(i));
            }
            return keyList.ToArray();
        }

        [JSReplacement("$this._storageHandle.length")]
        // ReSharper disable once MemberCanBeMadeStatic.Local
        private int GetLength()
        {
            throw new RequiresJSILRuntimeException();
        }

        #endregion Private Methods
    }
}