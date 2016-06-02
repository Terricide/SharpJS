namespace System
{
    public class Uri
    {
        private readonly string _textUri;
        private readonly UriKind _uriKind;

        public Uri(string address, UriKind uriKind)
        {
            _textUri = address;
            _uriKind = uriKind;
        }

        public override string ToString()
        {
            return _textUri;
        }
    }

    public enum UriKind
    {
        Relative,
        Absolute
    }
}