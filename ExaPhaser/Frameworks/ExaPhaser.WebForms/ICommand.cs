namespace ExaPhaser.WebForms
{
    public interface ICommand
    {
        #region Public Methods

		void Execute(ICommandParameter args);

        #endregion Public Methods
    }
}