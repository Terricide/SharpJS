using System;

namespace IridiumIon.NeptuniumKit.ComponentModel
{
    public interface INotifyPropertyChanged
    {
        event EventHandler<string> PropertyChanged;
    }
}