namespace ExaPhaser.WebForms.Drawing
{
    /// <summary>
    /// Represents a Point with values that are CSS relative positioning values. For example, myRelativePoint = new RelativePoint("50%", "50%")
    /// </summary>
    public class RelativePoint
    {
        #region Public Constructors

        public RelativePoint(string x, string y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion Public Constructors

        #region Public Properties

        public string X { get; }
        public string Y { get; }

        #endregion Public Properties
    }
}