namespace ExaPhaser.WebForms
{
    public interface ICommand
    {
        #region Public Methods

        void Execute(object o);

        #endregion Public Methods
    }
}