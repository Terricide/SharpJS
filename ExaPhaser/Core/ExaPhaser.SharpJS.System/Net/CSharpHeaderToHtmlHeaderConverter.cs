using System.Collections.Generic;

namespace System.Net
{
    internal static class CSharpHeaderToHtmlHeaderConverter
    {
        internal static string Convert(HttpRequestHeader header)
        {
            string header2 = header.ToString();
            return CSharpHeaderToHtmlHeaderConverter.Convert(header2);
        }

        internal static string Convert(HttpResponseHeader header)
        {
            string header2 = header.ToString();
            return CSharpHeaderToHtmlHeaderConverter.Convert(header2);
        }

        private static string Convert(string header)
        {
            string result = header;
            if (CSharpHeaderToHtmlHeaderConverter._headerStringEquivalence.ContainsKey(header))
            {
                result = CSharpHeaderToHtmlHeaderConverter._headerStringEquivalence[header];
            }
            return result;
        }

        private static Dictionary<string, string> _headerStringEquivalence = new Dictionary<string, string>
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
    }
}