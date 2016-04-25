namespace SharpJS.System.IO.WebStorage
{
    public class SessionStorageHandle : StorageBase
    {
        public SessionStorageHandle() : base(WebStorageType.SessionStorage)
        {
        }
    }
}