using JSIL.Meta;

namespace System.Xml
{
    [JSStubOnly]
    public abstract class XmlNameTable
    {
        protected XmlNameTable()
        {
            throw new NotImplementedException();
        }

        public abstract string Add(string array);

        public abstract string Add(char[] array, int offset, int length);

        public abstract string Get(string array);

        public abstract string Get(char[] array, int offset, int length);
    }
}