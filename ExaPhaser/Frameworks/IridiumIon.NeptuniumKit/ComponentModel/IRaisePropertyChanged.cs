namespace IridiumIon.NeptuniumKit.ComponentModel
{
    public interface IRaisePropertyChanged : INotifyPropertyChanged
    {
        void OnPropertyChanged(string propertyName);
    }
}