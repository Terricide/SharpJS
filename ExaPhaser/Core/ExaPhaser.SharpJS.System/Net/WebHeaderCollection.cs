using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharpJS.System.Net
{
    [Serializable]
    public class WebHeaderCollection
    {
        private readonly Dictionary<string, string> _headers;

        public WebHeaderCollection()
        {
            _headers = new Dictionary<string, string>();
        }

        public string[] AllKeys
        {
            get { return _headers.Keys.ToArray(); }
        }

        public int Count
        {
            get { return _headers.Count; }
        }

        public string this[HttpRequestHeader header]
        {
            get { return _headers[HeaderConverter.Convert(header)]; }

            set { _headers[HeaderConverter.Convert(header)] = value; }
        }

        public string this[HttpResponseHeader header]
        {
            get { return _headers[HeaderConverter.Convert(header)]; }

            set { _headers[HeaderConverter.Convert(header)] = value; }
        }

        public void Add(string header)
        {
            var num = header.IndexOf(':');
            if (num <= 0)
            {
                throw new ArgumentException("header must be of the form: \"header:value\".");
            }
            var text = header.Substring(0, num);
            var text2 = header.Substring(num + 1);
            text = text.Trim();
            text2 = text2.Trim();
            Add(text, text2);
        }

        public void Add(HttpRequestHeader header, string value)
        {
            Add(HeaderConverter.Convert(header), value);
        }

        public void Add(HttpResponseHeader header, string value)
        {
            Add(HeaderConverter.Convert(header), value);
        }

        public void Add(string name, string value)
        {
            _headers.Add(name, value);
        }

        public void Clear()
        {
            _headers.Clear();
        }

        public string Get(string name)
        {
            return _headers[name];
        }

        public IEnumerator GetEnumerator()
        {
            return _headers.GetEnumerator();
        }

        internal Dictionary<string, string> GetHeadersAsDictionaryStringString()
        {
            return _headers;
        }

        public void Remove(HttpRequestHeader header)
        {
            Remove(HeaderConverter.Convert(header));
        }

        public void Remove(HttpResponseHeader header)
        {
            Remove(HeaderConverter.Convert(header));
        }

        public void Remove(string name)
        {
            _headers.Remove(name);
        }

        public void Set(string name, string value)
        {
            if (_headers.ContainsKey(name))
            {
                _headers[name] = value;
            }
            else
            {
                _headers.Add(name, value);
            }
        }
    }
}