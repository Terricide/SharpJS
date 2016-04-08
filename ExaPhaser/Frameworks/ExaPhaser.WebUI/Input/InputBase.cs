using System;
using ExaPhaser.WebUI.Mvvm;
using JSIL.Dom;

namespace ExaPhaser.WebUI.Input
{
    public abstract class InputBase : Element, INotifyPropertyChanged
    {
        public InputBase()
            : base("input")
        {
            Change += OnChange;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Value
        {
            get { return GetAttributeValue("value"); }
            set { SetAttributeValue("value", value); }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnChange(object sender, EventArgs args)
        {
            RaisePropertyChanged("Value");
        }
    }
}