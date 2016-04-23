namespace SharpJS.Dom
{
    public class StringStyle : Style
    {
        private readonly string s;

        public StringStyle(string s)
        {
            this.s = s;
        }

        public override string ToString()
        {
            return s;
        }
    }
}