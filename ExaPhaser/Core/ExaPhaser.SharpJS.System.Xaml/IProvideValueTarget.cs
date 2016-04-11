namespace System.Windows.Markup
{
    public interface IProvideValueTarget
    {
        object TargetObject
        {
            get;
        }

        object TargetProperty
        {
            get;
        }
    }
}