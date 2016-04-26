using System;
using JSIL;

namespace SharpJS.JSLibraries
{
    public class OnErrorEventArgs : EventArgs
    {
        #region Public Fields

        public readonly string Data;

        #endregion Public Fields

        #region Public Constructors

        public OnErrorEventArgs(string data)
        {
            Data = data;
        }

        #endregion Public Constructors
    }

    public class OnMessageEventArgs : EventArgs
    {
        #region Public Fields

        public readonly string Data;

        #endregion Public Fields

        #region Public Constructors

        public OnMessageEventArgs(string data)
        {
            Data = data;
        }

        #endregion Public Constructors
    }

    public class WebSocket
    {
        #region Private Fields

        private readonly object _webSocketObjectHandle;

        #endregion Private Fields

        #region Public Constructors

        public WebSocket(string uri)
        {
            _webSocketObjectHandle = Verbatim.Expression("new WebSocket($0)", uri);

            Verbatim.Expression(
                @"$0.onopen = $1;
                      $0.onclose = $2;
                      $0.onmessage = $3;
                      $0.onerror = $4",
                _webSocketObjectHandle,
                (Action<object>) OnOpenCallback,
                (Action<object>) OnCloseCallback,
                (Action<object>) OnMessageCallback,
                (Action<object>) OnErrorCallback);
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler OnClose;

        public event EventHandler<OnErrorEventArgs> OnError;

        public event EventHandler<OnMessageEventArgs> OnMessage;

        public event EventHandler OnOpen;

        #endregion Public Events

        #region Public Methods

        public void Close()
        {
            Verbatim.Expression("$0.close()", _webSocketObjectHandle);
        }

        public void Send(string message)
        {
            Verbatim.Expression("$0.send($1)", _webSocketObjectHandle, message);
        }

        #endregion Public Methods

        #region Private Methods

        private void OnCloseCallback(object e)
        {
            if (OnClose != null)
                OnClose(this, new EventArgs());
        }

        private void OnErrorCallback(object e)
        {
            var data = Convert.ToString(Verbatim.Expression("$0.data", e));

            if (OnError != null)
                OnError(this, new OnErrorEventArgs(data));
        }

        private void OnMessageCallback(object e)
        {
            var data = Convert.ToString(Verbatim.Expression("$0.data", e));

            if (OnMessage != null)
                OnMessage(this, new OnMessageEventArgs(data));
        }

        private void OnOpenCallback(object e)
        {
            if (OnOpen != null)
                OnOpen(this, new EventArgs());
        }

        #endregion Private Methods
    }
}