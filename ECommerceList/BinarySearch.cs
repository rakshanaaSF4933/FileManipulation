using System.Reflection;

namespace ECommerceList
{
    public class BinarySearch<Type>
    {
        public int Search(CustomList<Type> list,string ID, out Type obj)
        {
            obj=list[0];
            PropertyInfo[] properties = typeof(Type).GetProperties();
            int low = 0, mid;
            int high = list.Count - 1;
            while (low <= high)
            {
                mid = (low + high) / 2;
                var id = properties[0].GetValue(list[mid]).ToString();
                if (ID.CompareTo(id) > 0)
                {
                    low = mid + 1;
                }
                else if (ID.CompareTo(id) == 0)
                {
                    obj = list[mid];
                    return mid;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
    }
}