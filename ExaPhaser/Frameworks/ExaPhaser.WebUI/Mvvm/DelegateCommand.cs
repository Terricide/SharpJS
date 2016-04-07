using System;

namespace ExaPhaser.WebUI.Mvvm
{
    public class DelegateCommand : ICommand
    {
        private Action _executeAction;
        private Func<bool> _canExecuteFunc;

        public DelegateCommand(Action executeAction, Func<bool> canExecuteFunc)
        {
            _executeAction = executeAction;
            _canExecuteFunc = canExecuteFunc;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object o)
        {
            if (_canExecuteFunc != null)
            {
                return _canExecuteFunc();
            }
            else
            {
                return true;
            }
        }

        public void Execute(object o)
        {
            if (_executeAction != null)
            {
                _executeAction();
            }
        }
    }
}