using JSIL.Meta;

namespace System.Text.RegularExpressions
{
    [JSStubOnly]
    public class Match : Group
    {
        public static Match Empty
        {
            get { return null; }
        }

        public virtual GroupCollection Groups
        {
            get { return null; }
        }

        public Match NextMatch()
        {
            return null;
        }

        public virtual string Result(string replacement)
        {
            return string.Empty;
        }
    }
}