using System.Collections.Generic;

namespace System.Collections.Specialized
{
    public class NotifyCollectionChangedEventArgs : EventArgs
    {
        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action)
        {
            this.Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems)
        {
            this.Action = action;
            if (action == NotifyCollectionChangedAction.Reset || action == NotifyCollectionChangedAction.Remove)
            {
                this.OldItems = changedItems;
            }
            else if (action == NotifyCollectionChangedAction.Add)
            {
                this.NewItems = changedItems;
            }
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem)
        {
            if ((action != NotifyCollectionChangedAction.Add && action != NotifyCollectionChangedAction.Remove && action != NotifyCollectionChangedAction.Reset) || (action == NotifyCollectionChangedAction.Reset && changedItem != null))
            {
                throw new ArgumentException();
            }
            if (action == NotifyCollectionChangedAction.Add)
            {
                this.NewItems = new List<object>();
                this.NewItems.Add(changedItem);
            }
            if (action == NotifyCollectionChangedAction.Remove || action == NotifyCollectionChangedAction.Reset)
            {
                this.OldItems = new List<object>();
                this.OldItems.Add(changedItem);
            }
            this.Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems)
        {
            if (action != NotifyCollectionChangedAction.Replace)
            {
                throw new ArgumentException();
            }
            if (oldItems == null || newItems == null)
            {
                throw new ArgumentNullException();
            }
            this.NewItems = newItems;
            this.OldItems = oldItems;
            this.Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems, int startingIndex)
        {
            if ((action != NotifyCollectionChangedAction.Add && action != NotifyCollectionChangedAction.Remove && action != NotifyCollectionChangedAction.Reset) || (action == NotifyCollectionChangedAction.Reset && (changedItems != null || startingIndex != -1)) || ((action == NotifyCollectionChangedAction.Add || action == NotifyCollectionChangedAction.Remove) && startingIndex < 0))
            {
                throw new ArgumentException();
            }
            if ((action == NotifyCollectionChangedAction.Add || action == NotifyCollectionChangedAction.Remove) && changedItems == null)
            {
                throw new ArgumentNullException();
            }
            if (action == NotifyCollectionChangedAction.Add)
            {
                this.NewItems = changedItems;
                this.NewStartingIndex = startingIndex;
            }
            else
            {
                this.OldItems = changedItems;
                this.OldStartingIndex = startingIndex;
            }
            this.Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index)
        {
            if ((action != NotifyCollectionChangedAction.Add && action != NotifyCollectionChangedAction.Remove && action != NotifyCollectionChangedAction.Reset) || (action == NotifyCollectionChangedAction.Reset && (changedItem != null || index != -1)))
            {
                throw new ArgumentException();
            }
            if (action == NotifyCollectionChangedAction.Add)
            {
                this.NewItems = new List<object>();
                this.NewItems.Add(changedItem);
                this.NewStartingIndex = index;
            }
            if (action == NotifyCollectionChangedAction.Remove || action == NotifyCollectionChangedAction.Reset)
            {
                this.OldItems = new List<object>();
                this.OldItems.Add(changedItem);
                this.OldStartingIndex = index;
            }
            this.Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem)
        {
            if (action != NotifyCollectionChangedAction.Replace)
            {
                throw new ArgumentException();
            }
            this.NewItems = new List<object>();
            this.NewItems.Add(newItem);
            this.OldItems = new List<object>();
            this.OldItems.Add(oldItem);
            this.Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems, int startingIndex)
        {
            if (action != NotifyCollectionChangedAction.Replace)
            {
                throw new ArgumentException();
            }
            this.NewItems = newItems;
            this.OldItems = oldItems;
            this.OldStartingIndex = startingIndex;
            this.Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems, int index, int oldIndex)
        {
            if (action != NotifyCollectionChangedAction.Move || index < 0)
            {
                throw new ArgumentException();
            }
            this.OldItems = changedItems;
            this.NewStartingIndex = index;
            this.OldStartingIndex = oldIndex;
            this.Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index, int oldIndex)
        {
            if (action != NotifyCollectionChangedAction.Move || index < 0)
            {
                throw new ArgumentException();
            }
            this.OldItems = new List<object>();
            this.OldItems.Add(changedItem);
            this.NewStartingIndex = index;
            this.OldStartingIndex = oldIndex;
            this.Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem, int index)
        {
            if (action != NotifyCollectionChangedAction.Replace)
            {
                throw new ArgumentException();
            }
            this.NewItems = new List<object>();
            this.NewItems.Add(newItem);
            this.OldItems = new List<object>();
            this.OldItems.Add(oldItem);
            this.OldStartingIndex = index;
            this.Action = action;
        }

        public NotifyCollectionChangedAction Action
        {
            get
            {
                return this._action;
            }

            internal set
            {
                this._action = value;
            }
        }

        public IList NewItems
        {
            get
            {
                return this._newItems;
            }

            internal set
            {
                this._newItems = value;
            }
        }

        public int NewStartingIndex
        {
            get
            {
                return this._newStartingIndex;
            }

            internal set
            {
                this._newStartingIndex = value;
            }
        }

        public IList OldItems
        {
            get
            {
                return this._oldItems;
            }

            internal set
            {
                this._oldItems = value;
            }
        }

        public int OldStartingIndex
        {
            get
            {
                return this._oldStartingIndex;
            }

            internal set
            {
                this._oldStartingIndex = value;
            }
        }

        private NotifyCollectionChangedAction _action;

        private IList _newItems;

        private int _newStartingIndex;

        private IList _oldItems;

        private int _oldStartingIndex;
    }
}