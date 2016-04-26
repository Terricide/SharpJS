using System;

namespace ExaPhaser.WebForms
{
	/// <summary>
	/// A command that takes no parameter.
	/// </summary>
    public class DelegateCommand : ICommand
    {
        #region Private Fields

        private readonly Action _executeAction;

        #endregion Private Fields

        #region Public Constructors

        public DelegateCommand(Action executeAction)
        {
            _executeAction = executeAction;
        }

        #endregion Public Constructors

        #region Public Methods

		public void Execute(ICommandParameter param)
        {
			_executeAction?.Invoke();
        }

        #endregion Public Methods
    }
}