namespace System.IO.WebStorage
{
    public class SessionStorage : StorageBase
    {
        public SessionStorage() : base("window.sessionStorage")
        {
        }
    }
}