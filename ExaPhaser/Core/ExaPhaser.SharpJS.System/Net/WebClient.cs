using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JSIL.Meta;

namespace System.Net
{
    public class WebClient
    {
        public string DownloadString(string address)
        {
            return this.DownloadString(new Uri(address));
        }

        public string DownloadString(Uri address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("The address parameter in DownloadString cannot be null");
            }
            this._webRequestHelper.DownloadStringCompleted -= new DownloadStringCompletedEventHandler(this.OnDownloadStringCompleted);
            this._webRequestHelper.DownloadStringCompleted += new DownloadStringCompletedEventHandler(this.OnDownloadStringCompleted);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] allKeys = this._headers.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                string text = allKeys[i];
                dictionary.Add(text, this._headers.Get(text));
            }
            return this._webRequestHelper.MakeRequest(address, "GET", dictionary, null, new DownloadStringCompletedEventHandler(this.OnDownloadStringCompleted), false);
        }

        public void DownloadStringAsync(Uri address)
        {
            this.DownloadStringAsync(address, null);
        }

        private void DownloadStringAsync(Uri address, object userToken)
        {
            if (address == null)
            {
                throw new ArgumentNullException("The address parameter in DownloadStringAsync cannot be null");
            }
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] allKeys = this._headers.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                string text = allKeys[i];
                dictionary.Add(text, this._headers.Get(text));
            }
            this._webRequestHelper.MakeRequest(address, "GET", dictionary, null, new DownloadStringCompletedEventHandler(this.OnDownloadStringCompleted), true);
        }

        public Task<string> DownloadStringTaskAsync(string address)
        {
            return this.DownloadStringTaskAsync(new Uri(address));
        }

        public Task<string> DownloadStringTaskAsync(Uri address)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] allKeys = this._headers.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                string text = allKeys[i];
                dictionary.Add(text, this._headers.Get(text));
            }
            TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
            this._webRequestHelper.MakeRequest(address, "GET", dictionary, null, delegate (object sender, DownloadStringCompletedEventArgs args)
            {
                this.TriggerDownloadStringTaskCompleted(taskCompletionSource, args);
            }, true);
            return taskCompletionSource.Task;
        }

        private void INTERNAL_OnUploadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.OnUploadStringCompleted(sender, new UploadStringCompletedEventArgs(e));
        }

        [JSReplacement("$xmlHttpRequest.readyState == 4 && $xmlHttpRequest.status == 200")]
        private bool INTERNAL_TestIfCompletedStatus(object xmlHttpRequest)
        {
            return true;
        }

        private void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (this.DownloadStringCompleted != null)
            {
                this.DownloadStringCompleted(sender, e);
            }
        }

        private void OnUploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (this.UploadStringCompleted != null)
            {
                this.UploadStringCompleted(sender, e);
            }
        }

        [JSReplacement("$e.set_Result($xmlHttpRequest.responseText)")]
        private void SetDownloadStringCompletedEventArgsResultsInJavascript(DownloadStringCompletedEventArgs e, object xmlHttpRequest)
        {
        }

        private void TriggerDownloadStringTaskCompleted(TaskCompletionSource<string> taskCompletionSource, DownloadStringCompletedEventArgs e)
        {
            taskCompletionSource.SetResult(e.Result);
        }

        private void TriggerUploadStringTaskCompleted(TaskCompletionSource<string> taskCompletionSource, DownloadStringCompletedEventArgs e)
        {
            taskCompletionSource.SetResult(e.Result);
        }

        public string UploadString(string address, string data)
        {
            return this.UploadString(new Uri(address), "POST", data);
        }

        public string UploadString(Uri address, string data)
        {
            return this.UploadString(address, "POST", data);
        }

        public string UploadString(string address, string method, string data)
        {
            return this.UploadString(new Uri(address), method, data);
        }

        public string UploadString(Uri address, string method, string data)
        {
            return this.UploadString(address, method, data, null, false);
        }

        private string UploadString(Uri address, string method, string data, DownloadStringCompletedEventHandler onCompleted, bool isAsync)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (data != null && data.Length > 0)
            {
                dictionary.Add("Content-Length", data.Length.ToString());
            }
            string[] allKeys = this._headers.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                string text = allKeys[i];
                dictionary.Add(text, this._headers.Get(text));
            }
            return this._webRequestHelper.MakeRequest(address, method, dictionary, data, onCompleted, isAsync);
        }

        public void UploadStringAsync(Uri address, string data)
        {
            this.UploadStringAsync(address, "POST", data);
        }

        public void UploadStringAsync(Uri address, string method, string data)
        {
            this.UploadString(address, method, data, new DownloadStringCompletedEventHandler(this.INTERNAL_OnUploadStringCompleted), true);
        }

        public Task<string> UploadStringTaskAsync(string address, string data)
        {
            return this.UploadStringTaskAsync(new Uri(address), "POST", data);
        }

        public Task<string> UploadStringTaskAsync(Uri address, string data)
        {
            return this.UploadStringTaskAsync(address, "POST", data);
        }

        public Task<string> UploadStringTaskAsync(string address, string method, string data)
        {
            return this.UploadStringTaskAsync(new Uri(address), method, data);
        }

        public Task<string> UploadStringTaskAsync(Uri address, string method, string data)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (data != null && data.Length > 0)
            {
                dictionary.Add("Content-Length", data.Length.ToString());
            }
            string[] allKeys = this._headers.AllKeys;
            for (int i = 0; i < allKeys.Length; i++)
            {
                string text = allKeys[i];
                dictionary.Add(text, this._headers.Get(text));
            }
            TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
            this._webRequestHelper.MakeRequest(address, method, dictionary, data, delegate (object sender, DownloadStringCompletedEventArgs args)
            {
                this.TriggerUploadStringTaskCompleted(taskCompletionSource, args);
            }, true);
            return taskCompletionSource.Task;
        }

        public Encoding Encoding
        {
            get;

            set;
        }

        public WebHeaderCollection Headers
        {
            get
            {
                return this._headers;
            }

            set
            {
                this._headers = value;
            }
        }

        public event DownloadStringCompletedEventHandler DownloadStringCompleted;

        public event UploadStringCompletedEventHandler UploadStringCompleted;

        private WebHeaderCollection _headers = new WebHeaderCollection();

        private InternalWebRequestHelper _webRequestHelper = new InternalWebRequestHelper();
    }
}