namespace System.Net
{
    public class UploadStringCompletedEventArgs
    {
        public UploadStringCompletedEventArgs()
        {
        }

        internal UploadStringCompletedEventArgs(DownloadStringCompletedEventArgs e)
        {
            Result = e.Result;
            UserState = e.UserState;
            Error = e.Error;
            Cancelled = e.Cancelled;
        }

        public UploadStringCompletedEventArgs(Exception error, bool cancelled, object userState)
        {
            Error = error;
            Cancelled = cancelled;
            UserState = userState;
        }

        public bool Cancelled { get; private set; }

        public Exception Error { get; private set; }

        public string Result { get; internal set; }

        public object UserState { get; private set; }
    }
}