using System;
using System.Collections;
using System.Collections.Generic;

namespace IridiumIon.NeptuniumKit.Controls
{
    public class NKViewCollection : IList<NKView>
    {
        public NKView ParentView;

        //Default constructor
        public NKViewCollection()
        {
        }

        public NKViewCollection(NKView parentView)
        {
            ParentView = parentView;
        }

        private List<NKView> _list = new List<NKView>();

        public NKView this[int index]
        {
            get
            {
                return _list[index];
            }

            set
            {
                _list[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public bool IsReadOnly => false;

        public void Add(NKView item) //TODO: Maybe a visualizer using a TreeView could be implemented in the future?
        {
            item.Parent = ParentView; //Set the parent of the child view
            item.Parent.UnderlyingElement.Append(item.UnderlyingElement); //Add the child underlying element to DOM tree
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(NKView item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(NKView[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<NKView> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(NKView item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, NKView item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(NKView item)
        {
            //TODO: ?
            item.UnderlyingElement.Remove(); //Remove the underlying element of the item from DOM
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.Remove(_list[index]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}