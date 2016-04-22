namespace System.IO.WebStorage
{
    public class LocalStorage : StorageBase
    {
        public LocalStorage() : base("window.localStorage")
        {
        }
    }
}