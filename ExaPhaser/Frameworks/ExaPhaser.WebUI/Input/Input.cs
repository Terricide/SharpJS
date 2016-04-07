using JSIL.Dom;
using ExaPhaser.WebUI.Mvvm;
using System;

namespace ExaPhaser.WebUI.Input
{
    public abstract class InputBase : Element, INotifyPropertyChanged
    {
        public InputBase()
            : base("input")
        {
            Change += OnChange;
        }

        private void OnChange(object sender, EventArgs args)
        {
            RaisePropertyChanged("Value");
        }

        public string Value
        {
            get { return GetAttributeValue("value"); }
            set { SetAttributeValue("value", value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}