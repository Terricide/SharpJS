namespace System.IO.WebStorage
{
    public class LocalStorageHandle : StorageBase
    {
        public LocalStorageHandle() : base(WebStorageType.LocalStorage)
        {
        }
    }
}