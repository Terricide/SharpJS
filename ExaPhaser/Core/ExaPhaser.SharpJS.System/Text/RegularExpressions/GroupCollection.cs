using System.Collections;
using JSIL.Meta;

namespace System.Text.RegularExpressions
{
    [JSStubOnly]
    public class GroupCollection : ICollection, IEnumerable
    {
        public Group this[int groupnum]
        {
            get { return null; }
        }

        public Group this[string groupname]
        {
            get { return null; }
        }

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
            get { return 0; }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
    }
}