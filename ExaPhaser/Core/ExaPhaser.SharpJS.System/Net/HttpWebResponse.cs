using System;
using System.IO;
using JSIL.Meta;

namespace SharpJS.System.Net
{
    [Serializable]
    public class HttpWebResponse : WebResponse
    {
        private dynamic _xmlHttpRequest;

        internal HttpWebResponse(object xmlHttpRequest)
        {
            _xmlHttpRequest = xmlHttpRequest;
        }

        [JSReplacement("$xmlHttpRequest.status")]
        public virtual HttpStatusCode StatusCode
        {
            get { throw new NotImplementedException(); }
        }

        [JSReplacement("$xmlHttpRequest.responseText")]
        private string GetResponseAsString(object xmlHttpRequest)
        {
            return null;
        }

        public Stream GetResponseStream()
        {
            return null;
        }
    }
}