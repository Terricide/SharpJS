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
        private readonly UriKind _uriKind;

        public override string ToString()
        {
            return _textUri;
        }

        public Uri(string address, UriKind uriKind)
        {
            _textUri = address;
            _uriKind = uriKind;
        }
    }

    public enum UriKind
    {
        Relative,
        Absolute
    }
}
