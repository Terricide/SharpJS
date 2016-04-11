using System.Runtime.InteropServices;
using JSIL.Meta;

namespace System.Collections.Generic
{
    [JSStubOnly]
    public class Stack<T> : IEnumerable<T>, ICollection, IEnumerable
    {
        public Stack()
        {
            throw new NotImplementedException();
        }

        public Stack(int capacity)
        {
            throw new NotImplementedException();
        }

        public Stack(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T p0)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public Stack<T>.Enumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public void Push(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            throw new NotImplementedException();
        }

        public void TrimExcess()
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct Enumerator
        {
            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public T Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}