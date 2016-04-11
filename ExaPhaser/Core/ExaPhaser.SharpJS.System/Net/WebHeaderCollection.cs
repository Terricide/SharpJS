using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System.Net
{
    [Serializable]
    public class WebHeaderCollection
    {
        public WebHeaderCollection()
        {
            this._headers = new Dictionary<string, string>();
        }

        public void Add(string header)
        {
            int num = header.IndexOf(':');
            if (num <= 0)
            {
                throw new ArgumentException("header must be of the form: \"header:value\".");
            }
            string text = header.Substring(0, num);
            string text2 = header.Substring(num + 1);
            text = text.Trim();
            text2 = text2.Trim();
            this.Add(text, text2);
        }

        public void Add(HttpRequestHeader header, string value)
        {
            this.Add(CSharpHeaderToHtmlHeaderConverter.Convert(header), value);
        }

        public void Add(HttpResponseHeader header, string value)
        {
            this.Add(CSharpHeaderToHtmlHeaderConverter.Convert(header), value);
        }

        public void Add(string name, string value)
        {
            this._headers.Add(name, value);
        }

        public void Clear()
        {
            this._headers.Clear();
        }

        public string Get(string name)
        {
            return this._headers[name];
        }

        public IEnumerator GetEnumerator()
        {
            return this._headers.GetEnumerator();
        }

        internal Dictionary<string, string> GetHeadersAsDictionaryStringString()
        {
            return this._headers;
        }

        public void Remove(HttpRequestHeader header)
        {
            this.Remove(CSharpHeaderToHtmlHeaderConverter.Convert(header));
        }

        public void Remove(HttpResponseHeader header)
        {
            this.Remove(CSharpHeaderToHtmlHeaderConverter.Convert(header));
        }

        public void Remove(string name)
        {
            this._headers.Remove(name);
        }

        public void Set(string name, string value)
        {
            if (this._headers.ContainsKey(name))
            {
                this._headers[name] = value;
            }
            else
            {
                this._headers.Add(name, value);
            }
        }

        public string[] AllKeys
        {
            get
            {
                return this._headers.Keys.ToArray<string>();
            }
        }

        public int Count
        {
            get
            {
                return this._headers.Count;
            }
        }

        public string this[HttpRequestHeader header]
        {
            get
            {
                return this._headers[CSharpHeaderToHtmlHeaderConverter.Convert(header)];
            }

            set
            {
                this._headers[CSharpHeaderToHtmlHeaderConverter.Convert(header)] = value;
            }
        }

        public string this[HttpResponseHeader header]
        {
            get
            {
                return this._headers[CSharpHeaderToHtmlHeaderConverter.Convert(header)];
            }

            set
            {
                this._headers[CSharpHeaderToHtmlHeaderConverter.Convert(header)] = value;
            }
        }

        private Dictionary<string, string> _headers;
    }
}