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
            CopyFrom(collection);
        }

        public ObservableCollection(List<T> list) : base(list != null ? new List<T>(list.Count) : list)
        {
            CopyFrom(list);
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void ClearItems()
        {
            base.ClearItems();
            RaisePropertyChanged("Count");
            RaisePropertyChanged("Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void CopyFrom(IEnumerable<T> collection)
        {
            if (collection != null)
            {
                foreach (var current in collection)
                {
                    Add(current);
                }
            }
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            RaisePropertyChanged("Count");
            RaisePropertyChanged("Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, e);
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected override void RemoveItem(int index)
        {
            var t = base[index];
            base.RemoveItem(index);
            RaisePropertyChanged("Count");
            RaisePropertyChanged("Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, t, index));
        }

        protected override void SetItem(int index, T item)
        {
            var t = base[index];
            base.SetItem(index, item);
            RaisePropertyChanged("Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, t,
                index));
        }
    }
}