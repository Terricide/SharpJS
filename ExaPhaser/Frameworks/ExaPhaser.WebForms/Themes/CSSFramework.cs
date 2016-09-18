namespace ExaPhaser.WebForms.Themes
{
    /// <summary>
    /// An enumeration representing various CSS frameworks. Each one has been implemented to a certain extent. See the project homepage and wiki for more information.
    /// </summary>
    public enum CSSFramework
    {
        Foundation6,

        /// <summary>
        /// The Bootstrap CSS Framework
        /// </summary>
        Bootstrap,

        /// <summary>
        /// A Material Design framework by FezVrasta based on Bootstrap. Currently, ExaPhaser.WebForms treats this just like Bootstrap,
        /// but as this behavior may change in the future, you are highly encouraged to select one or the other rather than
        /// using them interchangeably.
        /// </summary>
        MaterialBootstrap,

        Materialize,
        PolyUi,
        Kubism,
    }
}