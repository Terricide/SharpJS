using System;

namespace SharpJS.System.Net
{
    public class DownloadStringCompletedEventArgs
    {
        public DownloadStringCompletedEventArgs()
        {
        }

        internal DownloadStringCompletedEventArgs(DownloadStringCompletedEventArgs e)
        {
            Result = e.Result;
            UserState = e.UserState;
            Error = e.Error;
            Cancelled = e.Cancelled;
        }

        public bool Cancelled { get; internal set; }

        public Exception Error { get; internal set; }

        public string Result { get; internal set; }

        public object UserState { get; internal set; }
    }
}