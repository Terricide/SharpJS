namespace System.Net
{
    public class UploadStringCompletedEventArgs
    {
        public UploadStringCompletedEventArgs()
        {
        }

        internal UploadStringCompletedEventArgs(DownloadStringCompletedEventArgs e)
        {
            this.Result = e.Result;
            this.UserState = e.UserState;
            this.Error = e.Error;
            this.Cancelled = e.Cancelled;
        }

        public UploadStringCompletedEventArgs(Exception error, bool cancelled, object userState)
        {
            this.Error = error;
            this.Cancelled = cancelled;
            this.UserState = userState;
        }

        public bool Cancelled
        {
            get;

            private set;
        }

        public Exception Error
        {
            get;

            private set;
        }

        public string Result
        {
            get;

            internal set;
        }

        public object UserState
        {
            get;

            private set;
        }
    }
}