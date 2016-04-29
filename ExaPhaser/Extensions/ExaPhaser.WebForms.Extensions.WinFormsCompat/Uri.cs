using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class Uri
    {
        private readonly string _textUri;

        public override string ToString()
        {
            return _textUri;
        }

        public Uri(string address)
        {
            _textUri = address;
        }
    }

    public enum UriKind
    {
        Relative,
        Absolute
    }
}
