namespace System.Windows.Forms
{
    public struct Padding
    {
        #region Public Fields

        public int Bottom;
        public int Left;
        public int Right;
        public int Top;

        #endregion Public Fields

        #region Public Constructors

        public Padding(int left, int top, int right, int bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        public Padding(int width) : this(width, width, width, width)
        {
        }

        #endregion Public Constructors
    }
}