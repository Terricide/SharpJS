using System;

namespace ExaPhaser.WebForms
{
    public class DelegateCommand : ICommand
    {
        #region Private Fields

        private Action _executeAction;

        #endregion Private Fields

        #region Public Constructors

        public DelegateCommand(Action executeAction)
        {
            _executeAction = executeAction;
        }

        #endregion Public Constructors

        #region Public Methods

        public void Execute(object o)
        {
            if (_executeAction != null)
            {
                _executeAction();
            }
        }

        #endregion Public Methods
    }
}