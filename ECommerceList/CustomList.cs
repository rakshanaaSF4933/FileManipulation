using System.Collections.Generic;

namespace ECommerceList
{
    public partial class CustomList<Type>
    {
        private int _count;
        private int _capacity;
        private Type[] _array;
        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        public int Count { get { return _count; } }
        public int Capacity { get { return _capacity; } }

        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }
        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }

        public void Add(Type element)
        {
            //check if capacity is enough to add elements to list
            if (_count == _capacity)
            {
                GrowSize();
            }
            //Add element to list
            _array[_count] = element;
            _count++;
        }

        public void GrowSize()
        {
            //Increase list size
            _capacity *= 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

        public void AddRange(CustomList<Type> list)
        {
            //Increase capacity
            _capacity = _count + list.Count + 4;
            Type[] temp = new Type[_capacity];
            //Add existing list elements to temporary list
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            //Add new list to temporary list
            int k = 0;
            for (int i = _count; i < _count + list.Count; i++)
            {
                temp[i] = list[k++];
            }
            _array = temp;
            _count += list.Count;
        }

        public bool Contains(Type element)
        {
            //Check if element is found in list
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(Type element)
        {
            //Return index of the element
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int position, Type element)
        {
            //Insert element at position in list
            _capacity = _capacity + 1 + 4;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count + 1; i++)
            {
                if (i < position)
                {
                    temp[i] = _array[i];
                }
                else if (i == position)
                {
                    temp[i] = element;
                }
                else
                {
                    temp[i] = _array[i - 1];
                }
            }
            _count++;
            _array = temp;

        }

        public void RemoveAt(int position)
        {
            //Remove element at position
            for (int i = 0; i < _count; i++)
            {
                if (i >= position)
                {
                    _array[i] = _array[i + 1];
                }
            }
            _count--;
        }

        public bool Remove(Type element)
        {
            //Remove element from the list
            int position = IndexOf(element);
            if (position >= 0)
            {
                RemoveAt(position);
                return true;
            }
            return false;
        }

        public void Reverse()
        {
            //Reverse the element in the list
            Type[] temp = new Type[_capacity];
            int k = 0;
            for (int i = _count - 1; i >= 0; i--)
            {
                temp[k++] = _array[i];
            }
            _array = temp;
        }

        public void InsertRange(int position, CustomList<Type> list)
        {
            //Insert list in existing list at position
            _capacity = _count + list.Count + 4;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < position; i++)
            {
                temp[i] = _array[i];
            }
            int j = 0;
            for (int i = position; i < (position + list.Count); i++)
            {
                temp[i] = list[j++];
            }
            int k = position;
            for (int i = position + list.Count; i < (_count + list.Count); i++)
            {
                temp[i] = _array[k++];
            }
            _array = temp;
            _count += list.Count;
        }

        public void Sort()
        {
            //Sort the list
            for (int i = 0; i < _count - 1; i++)
            {
                for (int j = 0; j < _count - 1; j++)
                {
                    if (IsGreater(_array[j],_array[j+1]))
                    {
                        Type temp = _array[j];
                        _array[j] =_array[j+1];
                        _array[j+1] = temp;
                    }
                }
            }
        }

        public bool IsGreater(Type value1, Type value2)
        {
            //Find greater value of value1 and value2
            int result = Comparer<Type>.Default.Compare(value1, value2);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}