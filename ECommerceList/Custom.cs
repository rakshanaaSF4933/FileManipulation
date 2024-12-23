using System.Collections;
namespace ECommerceList
{
    /// <summary>
    /// <see cref="CustomList<Type>:IEnumerable,IEnumerator"/> used to use foreach functionality
    /// </summary>
    /// <typeparam name="Type"></typeparam>
    public partial class CustomList<Type>:IEnumerable,IEnumerator
    {
        int position;
        public IEnumerator GetEnumerator()
        {
            position = -1;
            return this;
        }
        public bool MoveNext()
        {
            if(position < _count-1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current{get{return _array[position];}}
    }
}