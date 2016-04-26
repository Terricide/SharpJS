namespace ExaPhaser.WebForms.Drawing
{
    /// <summary>
    /// A point in 2-dimensional space with an X and Y value
    /// </summary>
    public class Point
    {
        #region Public Constructors

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion Public Constructors

        #region Public Properties

        public int X { get; }
        public int Y { get; }

        #endregion Public Properties
    }
}