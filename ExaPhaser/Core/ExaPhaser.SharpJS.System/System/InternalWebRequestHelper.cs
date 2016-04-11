using System.Collections.Generic;
using System.Net;
using JSIL.Meta;

namespace System
{
    public class InternalWebRequestHelper
    {
        [JSReplacement("$xmlHttpRequest.open($method, $address, $isAsync)")]
        private void CreateRequest(object xmlHttpRequest, string address, string method, bool isAsync)
        {
            throw new NotImplementedException();
        }

        [JSReplacement("$xmlHttpRequest.readyState")]
        private static int GetCurrentReadyState(object xmlHttpRequest)
        {
            throw new NotImplementedException();
        }

        [JSReplacement("$xmlHttpRequest.status")]
        private static int GetCurrentStatus(object xmlHttpRequest)
        {
            throw new NotImplementedException();
        }

        [JSReplacement("$xmlHttpRequest.responseText")]
        private static string GetResult(object xmlHttpRequest)
        {
            throw new NotImplementedException();
        }

        [JSReplacement("new XMLHttpRequest()")]
        internal static dynamic GetWebRequest()
        {
            return null;
        }

        internal object GetXmlHttpRequest()
        {
            return this._xmlHttpRequest;
        }

        public string MakeRequest(Uri address, string Method, Dictionary<string, string> headers, string body, DownloadStringCompletedEventHandler callbackMethod, bool isAsync)
        {
            this._xmlHttpRequest = InternalWebRequestHelper.GetWebRequest();
            if (callbackMethod != null)
            {
                this.DownloadStringCompleted -= callbackMethod;
                this.DownloadStringCompleted += callbackMethod;
            }
            this.SetCallbackMethod(this._xmlHttpRequest, new Action<object, DownloadStringCompletedEventArgs>(this.OnDownloadStringCompleted));
            this.CreateRequest(this._xmlHttpRequest, address.OriginalString, Method, isAsync);
            if (headers != null && headers.Count > 0)
            {
                foreach (string current in headers.Keys)
                {
                    this.SetRequestHeader(this._xmlHttpRequest, current, headers[current]);
                }
            }
            InternalWebRequestHelper.SendRequest(this._xmlHttpRequest, body);
            return InternalWebRequestHelper.GetResult(this._xmlHttpRequest);
        }

        private void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            e = new DownloadStringCompletedEventArgs();
            this.SetEventArgs(e);
            if (this.DownloadStringCompleted != null)
            {
                this.DownloadStringCompleted(sender, e);
            }
        }

        [JSReplacement("$xmlHttpRequest.send($body)")]
        internal static void SendRequest(object xmlHttpRequest, string body)
        {
        }

        [JSReplacement("$xmlHttpRequest.onload = $OnDownloadStatusCompleted")]
        internal void SetCallbackMethod(object xmlHttpRequest, Action<object, DownloadStringCompletedEventArgs> OnDownloadStatusCompleted)
        {
        }

        private void SetEventArgs(DownloadStringCompletedEventArgs e)
        {
            int currentReadyState = InternalWebRequestHelper.GetCurrentReadyState(this._xmlHttpRequest);
            int currentStatus = InternalWebRequestHelper.GetCurrentStatus(this._xmlHttpRequest);
            if (currentStatus == 404)
            {
                e.Error = new Exception("Page not found");
            }
            else if (currentReadyState == 0 && !e.Cancelled)
            {
                e.Error = new Exception("Request not initialized");
            }
            else if (currentReadyState == 1 && !e.Cancelled)
            {
                e.Error = new Exception("An Error occured. Cross-Site Http Request might not be allowed at the target Url. If you own the domain of the Url, consider adding the header \"Access-Control-Allow-Origin\" to enable requests to be done at this Url.");
            }
            else if (currentReadyState != 4)
            {
                e.Error = new Exception("An Error has occured while submitting your request.");
            }
            e.Result = InternalWebRequestHelper.GetResult(this._xmlHttpRequest);
        }

        [JSReplacement("$xmlHttpRequest.setRequestHeader($key,$header)")]
        private void SetRequestHeader(dynamic xmlHttpRequest, string key, string header)
        {
            throw new NotImplementedException();
        }

        public event DownloadStringCompletedEventHandler DownloadStringCompleted;

        private dynamic _xmlHttpRequest;
    }
}