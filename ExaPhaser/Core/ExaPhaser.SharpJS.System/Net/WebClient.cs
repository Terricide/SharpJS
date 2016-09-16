using JSIL;
using JSIL.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpJS.System.Net
{
    public class WebClient
    {
        private readonly InternalWebRequestHelper _webRequestHelper = new InternalWebRequestHelper();

        public Encoding Encoding { get; set; }

        public WebHeaderCollection Headers { get; set; } = new WebHeaderCollection();

        public string DownloadString(string address)
        {
            return DownloadString(new Uri(address));
        }

        public string DownloadString(Uri address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            _webRequestHelper.DownloadStringCompleted -= OnDownloadStringCompleted;
            _webRequestHelper.DownloadStringCompleted += OnDownloadStringCompleted;
            var allKeys = Headers.AllKeys;
            var dictionary = allKeys.ToDictionary(text => text, text => Headers.Get(text));
            return _webRequestHelper.MakeRequest(address, "GET", dictionary, null, OnDownloadStringCompleted, false);
        }

        public void DownloadStringAsync(Uri address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            DownloadStringAsync(address, null);
        }

        private void DownloadStringAsync(Uri address, object userToken)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            var dictionary = new Dictionary<string, string>();
            var allKeys = Headers.AllKeys;
            for (var i = 0; i < allKeys.Length; i++)
            {
                var text = allKeys[i];
                dictionary.Add(text, Headers.Get(text));
            }
            _webRequestHelper.MakeRequest(address, "GET", dictionary, null, OnDownloadStringCompleted, true);
        }

        public Task<string> DownloadStringTaskAsync(string address)
        {
            return DownloadStringTaskAsync(new Uri(address));
        }

        public Task<string> DownloadStringTaskAsync(Uri address)
        {
            if (address == null) throw new ArgumentNullException(nameof(address));
            if (address == null) throw new ArgumentNullException(nameof(address));
            var dictionary = new Dictionary<string, string>();
            var allKeys = Headers.AllKeys;
            for (var i = 0; i < allKeys.Length; i++)
            {
                var text = allKeys[i];
                dictionary.Add(text, Headers.Get(text));
            }
            var taskCompletionSource = new TaskCompletionSource<string>();
            _webRequestHelper.MakeRequest(address, "GET", dictionary, null,
                delegate (object sender, DownloadStringCompletedEventArgs args)
                {
                    TriggerDownloadStringTaskCompleted(taskCompletionSource, args);
                }, true);
            return taskCompletionSource.Task;
        }

        private void InternalOnUploadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            OnUploadStringCompleted(sender, new UploadStringCompletedEventArgs(e));
        }

        [JSReplacement("$xmlHttpRequest.readyState == 4 && $xmlHttpRequest.status == 200")]
        private bool InternalTestIfCompletedStatus(object xmlHttpRequest)
        {
            throw new RequiresJSILRuntimeException();
        }

        private void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            DownloadStringCompleted?.Invoke(sender, e);
        }

        private void OnUploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            UploadStringCompleted?.Invoke(sender, e);
        }

        [JSReplacement("$e.set_Result($xmlHttpRequest.responseText)")]
        private void SetDownloadStringCompletedEventArgsResultsInJavascript(DownloadStringCompletedEventArgs e,
            object xmlHttpRequest)
        {
        }

        private void TriggerDownloadStringTaskCompleted(TaskCompletionSource<string> taskCompletionSource,
            DownloadStringCompletedEventArgs e)
        {
            taskCompletionSource.SetResult(e.Result);
        }

        private void TriggerUploadStringTaskCompleted(TaskCompletionSource<string> taskCompletionSource,
            DownloadStringCompletedEventArgs e)
        {
            taskCompletionSource.SetResult(e.Result);
        }

        public string UploadString(string address, string data)
        {
            return UploadString(new Uri(address), "POST", data);
        }

        public string UploadString(Uri address, string data)
        {
            return UploadString(address, "POST", data);
        }

        public string UploadString(string address, string method, string data)
        {
            return UploadString(new Uri(address), method, data);
        }

        public string UploadString(Uri address, string method, string data)
        {
            return UploadString(address, method, data, null, false);
        }

        private string UploadString(Uri address, string method, string data,
            DownloadStringCompletedEventHandler onCompleted, bool isAsync)
        {
            var dictionary = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(data))
            {
                dictionary.Add("Content-Length", data.Length.ToString());
            }
            var allKeys = Headers.AllKeys;
            for (var i = 0; i < allKeys.Length; i++)
            {
                var text = allKeys[i];
                dictionary.Add(text, Headers.Get(text));
            }
            return _webRequestHelper.MakeRequest(address, method, dictionary, data, onCompleted, isAsync);
        }

        public void UploadStringAsync(Uri address, string data)
        {
            UploadStringAsync(address, "POST", data);
        }

        public void UploadStringAsync(Uri address, string method, string data)
        {
            UploadString(address, method, data, InternalOnUploadStringCompleted, true);
        }

        public Task<string> UploadStringTaskAsync(string address, string data)
        {
            return UploadStringTaskAsync(new Uri(address), "POST", data);
        }

        public Task<string> UploadStringTaskAsync(Uri address, string data)
        {
            return UploadStringTaskAsync(address, "POST", data);
        }

        public Task<string> UploadStringTaskAsync(string address, string method, string data)
        {
            return UploadStringTaskAsync(new Uri(address), method, data);
        }

        public Task<string> UploadStringTaskAsync(Uri address, string method, string data)
        {
            var dictionary = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(data))
            {
                dictionary.Add("Content-Length", data.Length.ToString());
            }
            var allKeys = Headers.AllKeys;
            for (var i = 0; i < allKeys.Length; i++)
            {
                var text = allKeys[i];
                dictionary.Add(text, Headers.Get(text));
            }
            var taskCompletionSource = new TaskCompletionSource<string>();
            _webRequestHelper.MakeRequest(address, method, dictionary, data,
                delegate (object sender, DownloadStringCompletedEventArgs args)
                {
                    TriggerUploadStringTaskCompleted(taskCompletionSource, args);
                }, true);
            return taskCompletionSource.Task;
        }

        public event DownloadStringCompletedEventHandler DownloadStringCompleted;

        public event UploadStringCompletedEventHandler UploadStringCompleted;
    }
}