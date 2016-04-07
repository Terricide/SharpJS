using System;

namespace ExaPhaser.WebUI
{
    public interface ICommand
    {
        event EventHandler CanExecuteChanged;

        bool CanExecute(object o);

        void Execute(object o);
    }
}