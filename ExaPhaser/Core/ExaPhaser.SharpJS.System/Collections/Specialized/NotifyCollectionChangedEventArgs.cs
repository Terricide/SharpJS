using System.Collections.Generic;

namespace System.Collections.Specialized
{
    public class NotifyCollectionChangedEventArgs : EventArgs
    {
        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action)
        {
            Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems)
        {
            Action = action;
            if (action == NotifyCollectionChangedAction.Reset || action == NotifyCollectionChangedAction.Remove)
            {
                OldItems = changedItems;
            }
            else if (action == NotifyCollectionChangedAction.Add)
            {
                NewItems = changedItems;
            }
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem)
        {
            if ((action != NotifyCollectionChangedAction.Add && action != NotifyCollectionChangedAction.Remove &&
                 action != NotifyCollectionChangedAction.Reset) ||
                (action == NotifyCollectionChangedAction.Reset && changedItem != null))
            {
                throw new ArgumentException();
            }
            if (action == NotifyCollectionChangedAction.Add)
            {
                NewItems = new List<object>();
                NewItems.Add(changedItem);
            }
            if (action == NotifyCollectionChangedAction.Remove || action == NotifyCollectionChangedAction.Reset)
            {
                OldItems = new List<object>();
                OldItems.Add(changedItem);
            }
            Action = action;
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
            NewItems = newItems;
            OldItems = oldItems;
            Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems,
            int startingIndex)
        {
            if ((action != NotifyCollectionChangedAction.Add && action != NotifyCollectionChangedAction.Remove &&
                 action != NotifyCollectionChangedAction.Reset) ||
                (action == NotifyCollectionChangedAction.Reset && (changedItems != null || startingIndex != -1)) ||
                ((action == NotifyCollectionChangedAction.Add || action == NotifyCollectionChangedAction.Remove) &&
                 startingIndex < 0))
            {
                throw new ArgumentException();
            }
            if ((action == NotifyCollectionChangedAction.Add || action == NotifyCollectionChangedAction.Remove) &&
                changedItems == null)
            {
                throw new ArgumentNullException();
            }
            if (action == NotifyCollectionChangedAction.Add)
            {
                NewItems = changedItems;
                NewStartingIndex = startingIndex;
            }
            else
            {
                OldItems = changedItems;
                OldStartingIndex = startingIndex;
            }
            Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index)
        {
            if ((action != NotifyCollectionChangedAction.Add && action != NotifyCollectionChangedAction.Remove &&
                 action != NotifyCollectionChangedAction.Reset) ||
                (action == NotifyCollectionChangedAction.Reset && (changedItem != null || index != -1)))
            {
                throw new ArgumentException();
            }
            if (action == NotifyCollectionChangedAction.Add)
            {
                NewItems = new List<object>();
                NewItems.Add(changedItem);
                NewStartingIndex = index;
            }
            if (action == NotifyCollectionChangedAction.Remove || action == NotifyCollectionChangedAction.Reset)
            {
                OldItems = new List<object>();
                OldItems.Add(changedItem);
                OldStartingIndex = index;
            }
            Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem)
        {
            if (action != NotifyCollectionChangedAction.Replace)
            {
                throw new ArgumentException();
            }
            NewItems = new List<object>();
            NewItems.Add(newItem);
            OldItems = new List<object>();
            OldItems.Add(oldItem);
            Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList newItems, IList oldItems,
            int startingIndex)
        {
            if (action != NotifyCollectionChangedAction.Replace)
            {
                throw new ArgumentException();
            }
            NewItems = newItems;
            OldItems = oldItems;
            OldStartingIndex = startingIndex;
            Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, IList changedItems, int index,
            int oldIndex)
        {
            if (action != NotifyCollectionChangedAction.Move || index < 0)
            {
                throw new ArgumentException();
            }
            OldItems = changedItems;
            NewStartingIndex = index;
            OldStartingIndex = oldIndex;
            Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object changedItem, int index,
            int oldIndex)
        {
            if (action != NotifyCollectionChangedAction.Move || index < 0)
            {
                throw new ArgumentException();
            }
            OldItems = new List<object>();
            OldItems.Add(changedItem);
            NewStartingIndex = index;
            OldStartingIndex = oldIndex;
            Action = action;
        }

        public NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction action, object newItem, object oldItem,
            int index)
        {
            if (action != NotifyCollectionChangedAction.Replace)
            {
                throw new ArgumentException();
            }
            NewItems = new List<object>();
            NewItems.Add(newItem);
            OldItems = new List<object>();
            OldItems.Add(oldItem);
            OldStartingIndex = index;
            Action = action;
        }

        public NotifyCollectionChangedAction Action { get; internal set; }

        public IList NewItems { get; internal set; }

        public int NewStartingIndex { get; internal set; }

        public IList OldItems { get; internal set; }

        public int OldStartingIndex { get; internal set; }
    }
}