using System.Collections;
using JSIL.Meta;

namespace System.Text.RegularExpressions
{
    [JSStubOnly]
    public class MatchCollection : ICollection, IEnumerable
    {
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return null;
        }

        public int Count
        {
            get
            {
                return -1;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual Match this[int i]
        {
            get
            {
                return null;
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}