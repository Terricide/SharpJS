using System.IO;
using JSIL.Meta;

namespace System.Net
{
    [Serializable]
    public class HttpWebResponse : WebResponse
    {
        internal HttpWebResponse(object xmlHttpRequest)
        {
            this._xmlHttpRequest = xmlHttpRequest;
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

        [JSReplacement("$xmlHttpRequest.status")]
        public virtual HttpStatusCode StatusCode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private dynamic _xmlHttpRequest;
    }
}