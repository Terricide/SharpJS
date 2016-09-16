using System;
using System.Collections.Generic;
using JSIL.Meta;
using SharpJS.System.Net;

namespace SharpJS.System
{
    public class InternalWebRequestHelper
    {
        private dynamic _xmlHttpRequest;

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
            return _xmlHttpRequest;
        }

        public string MakeRequest(Uri address, string method, Dictionary<string, string> headers, string body,
            DownloadStringCompletedEventHandler callbackMethod, bool isAsync)
        {
            _xmlHttpRequest = GetWebRequest();
            if (callbackMethod != null)
            {
                DownloadStringCompleted -= callbackMethod;
                DownloadStringCompleted += callbackMethod;
            }
            this.SetCallbackMethod(_xmlHttpRequest,
                new Action<object, DownloadStringCompletedEventArgs>(OnDownloadStringCompleted));
            this.CreateRequest(_xmlHttpRequest, address.OriginalString, method, isAsync);
            if (headers != null && headers.Count > 0)
            {
                foreach (var current in headers.Keys)
                {
                    this.SetRequestHeader(_xmlHttpRequest, current, headers[current]);
                }
            }
            InternalWebRequestHelper.SendRequest(_xmlHttpRequest, body);
            return InternalWebRequestHelper.GetResult(_xmlHttpRequest);
        }

        private void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            e = new DownloadStringCompletedEventArgs();
            SetEventArgs(e);
            DownloadStringCompleted?.Invoke(sender, e);
        }

        [JSReplacement("$xmlHttpRequest.send($body)")]
        internal static void SendRequest(object xmlHttpRequest, string body)
        {
        }

        [JSReplacement("$xmlHttpRequest.onload = $OnDownloadStatusCompleted")]
        internal void SetCallbackMethod(object xmlHttpRequest,
            Action<object, DownloadStringCompletedEventArgs> onDownloadStatusCompleted)
        {
        }

        private void SetEventArgs(DownloadStringCompletedEventArgs e)
        {
            int currentReadyState = InternalWebRequestHelper.GetCurrentReadyState(_xmlHttpRequest);
            int currentStatus = InternalWebRequestHelper.GetCurrentStatus(_xmlHttpRequest);
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
                e.Error =
                    new Exception(
                        "An Error occured. The target domain may be forbiding Cross-Origin requests. If you own the domain, consider adding the header \"Access-Control-Allow-Origin\" to enable cross-origin requests to this domain.");
            }
            else if (currentReadyState != 4)
            {
                e.Error = new Exception("An Error has occured while submitting your request.");
            }
            e.Result = InternalWebRequestHelper.GetResult(_xmlHttpRequest);
        }

        [JSReplacement("$xmlHttpRequest.setRequestHeader($key,$header)")]
        private void SetRequestHeader(dynamic xmlHttpRequest, string key, string header)
        {
            throw new NotImplementedException();
        }

        public event DownloadStringCompletedEventHandler DownloadStringCompleted;
    }
}