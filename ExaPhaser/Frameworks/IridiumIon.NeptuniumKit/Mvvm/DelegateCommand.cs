using IridiumIon.NeptuniumKit.ComponentModel;
using System;

namespace IridiumIon.NeptuniumKit.Mvvm
{
    public class DelegateCommand : ICommand
    {
        public Action<object> ExecuteAction { get; set; }
        public Predicate<object> CanExecuteAction { get; set; }

        public DelegateCommand(Action<object> executeAction) : this(executeAction, null)
        {
        }

        public DelegateCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            ExecuteAction = executeAction;
            CanExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteAction != null)
            {
                return CanExecuteAction(parameter);
            }
            else //If there's no condition, then you can execute by default.
            {
                return true;
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            ExecuteAction(parameter);
        }
    }
}