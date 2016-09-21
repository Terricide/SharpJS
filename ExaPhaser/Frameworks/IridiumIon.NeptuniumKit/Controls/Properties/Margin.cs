namespace IridiumIon.NeptuniumKit.Controls.Properties
{
    /// <summary>
    /// Represents a margin for the element.
    /// </summary>
    public struct Margin
    {
        public Margin(int left, int top) : this(left, top, 0, 0)
        {
        }

        public Margin(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public int Left { get; }
        public int Top { get; }
        public int Right { get; }
        public int Bottom { get; }
    }
}