namespace System.Net
{
    public class DownloadStringCompletedEventArgs
    {
        public DownloadStringCompletedEventArgs()
        {
        }

        internal DownloadStringCompletedEventArgs(DownloadStringCompletedEventArgs e)
        {
            this.Result = e.Result;
            this.UserState = e.UserState;
            this.Error = e.Error;
            this.Cancelled = e.Cancelled;
        }

        public bool Cancelled
        {
            get;

            internal set;
        }

        public Exception Error
        {
            get;

            internal set;
        }

        public string Result
        {
            get;

            internal set;
        }

        public object UserState
        {
            get;

            internal set;
        }
    }
}