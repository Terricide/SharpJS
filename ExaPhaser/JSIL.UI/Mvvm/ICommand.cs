using System;

namespace JSIL.UI
{
    public interface ICommand
    {
        event EventHandler CanExecuteChanged;

        bool CanExecute(object o);

        void Execute(object o);
    }
}