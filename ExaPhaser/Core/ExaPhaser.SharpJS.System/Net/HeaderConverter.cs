using System.Collections.Generic;

namespace SharpJS.System.Net
{
    internal static class HeaderConverter
    {
        #region Lookup Table
        private static readonly Dictionary<string, string> HeaderStringLookupTable = new Dictionary<string, string>
        {
            {
                "CacheControl",
                "Cache-Control"
            },
            {
                "Connection",
                "Connection"
            },
            {
                "KeepAlive",
                "Keep-Alive"
            },
            {
                "TransferEncoding",
                "Transfer-Encoding"
            },
            {
                "ContentLength",
                "Content-Length"
            },
            {
                "ContentType",
                "Content-Type"
            },
            {
                "ContentEncoding",
                "Content-Encoding"
            },
            {
                "ContentLanguage",
                "Content-Language"
            },
            {
                "ContentLocation",
                "Content-Location"
            },
            {
                "ContentMd5",
                "Content-MD5"
            },
            {
                "ContentRange",
                "Content-Range"
            },
            {
                "LastModified",
                "Last-Modified"
            },
            {
                "AcceptCharset",
                "Accept-Charset"
            },
            {
                "AcceptEncoding",
                "Accept-Encoding"
            },
            {
                "AcceptLanguage",
                "Accept-Language"
            },
            {
                "IfMatch",
                "If-Match"
            },
            {
                "IfModifiedSince",
                "If-Modified-Since"
            },
            {
                "IfNoneMatch",
                "If-None-Match"
            },
            {
                "IfRange",
                "If-Range"
            },
            {
                "IfUnmodifiedSince",
                "If-Unmodified-Since"
            },
            {
                "MaxForwards",
                "Max-Forwards"
            },
            {
                "ProxyAuthorization",
                "Proxy-Authorization"
            },
            {
                "UserAgent",
                "User-Agent"
            },
            {
                "AcceptRanges",
                "Accept-Ranges"
            },
            {
                "ProxyAuthenticate",
                "Proxy-Authenticate"
            },
            {
                "RetryAfter",
                "Retry-After"
            },
            {
                "SetCookie",
                "Set-Cookie"
            }
        };
        #endregion

        internal static string Convert(HttpRequestHeader header)
        {
            var header2 = header.ToString();
            return Convert(header2);
        }

        internal static string Convert(HttpResponseHeader header)
        {
            var header2 = header.ToString();
            return Convert(header2);
        }

        private static string Convert(string header)
        {
            var result = header;
            if (HeaderStringLookupTable.ContainsKey(header))
            {
                result = HeaderStringLookupTable[header];
            }
            return result;
        }
    }
}