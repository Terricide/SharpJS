using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSIL.UI
{
    public interface ICommand
    {
        event EventHandler CanExecuteChanged;
        bool CanExecute(object o);
        void Execute(object o);
    }
}
