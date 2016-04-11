using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace System.Collections.ObjectModel
{
    public class ObservableCollection<T> : Collection<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public ObservableCollection()
        {
        }

        public ObservableCollection(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            this.CopyFrom(collection);
        }

        public ObservableCollection(List<T> list) : base((list != null) ? new List<T>(list.Count) : list)
        {
            this.CopyFrom(list);
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            this.RaisePropertyChanged("Count");
            this.RaisePropertyChanged("Item[]");
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void CopyFrom(IEnumerable<T> collection)
        {
            if (collection != null)
            {
                foreach (T current in collection)
                {
                    base.Add(current);
                }
            }
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            this.RaisePropertyChanged("Count");
            this.RaisePropertyChanged("Item[]");
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, e);
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected override void RemoveItem(int index)
        {
            T t = base[index];
            base.RemoveItem(index);
            this.RaisePropertyChanged("Count");
            this.RaisePropertyChanged("Item[]");
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, t, index));
        }

        protected override void SetItem(int index, T item)
        {
            T t = base[index];
            base.SetItem(index, item);
            this.RaisePropertyChanged("Item[]");
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, t, index));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}