using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            // ваш код
            if (array == null)
            {
                array = new T[new_capacity];
                capacity = 16;
                return;
            }
            if (capacity != new_capacity)
            {
                T[] old_array = new T[array.Length];
                array.CopyTo(old_array, 0);
                array = new T[new_capacity];
                int newsize = array.Length < old_array.Length ? array.Length : old_array.Length;
                Array.Copy(old_array, array, newsize);
                capacity = new_capacity;    
            }
        }

        public T GetItem(int index)
        {
            if (index >= count)
            {
                throw new System.ArgumentException("индекс выходит за пределы массива", "original");
            }
            // ваш код
            if (array !=null)
                return array[index];
            else
                return default(T);
        }

        public void Append(T itm)
        {
            // ваш код
            if (count < capacity) 
            {
                array[count] = itm;
            }
            else
            {
                MakeArray(new_capacity());
                array[count] = itm;
            }
            count++;
        }
        private int new_capacity()
        {
            int rezult = capacity;
            if (count==0)
            {
                return 16;
            }
            if (count >= capacity)
            {
                rezult = capacity * 2;
            }
            if (count <= capacity/2)
            {
                rezult = (int)(capacity/1.5);
                if (rezult < 16)
                    rezult = 16;
            }
            return rezult;
        }
        public void Insert(T itm, int index)
        {
            // ваш код
            // если индекс 0 то вставляем в начало
            if (index > count)
            {
                throw new System.ArgumentException("индекс выходит за пределы массива", "original");
            }
            if (((index == count-1)|| (index == count)) && (count >0 ))  
            {
                Append(itm);
                return;
            }
                count++;
                MakeArray(new_capacity());
                Array.Copy(array, index, array, index + 1, count-index);
                array[index] = itm;
        }

        public void Remove(int index)
        {
            // ваш код
            // если индекс 0 то вставляем в начало
            if (index >= count)
            {
                throw new System.ArgumentException("индекс выходит за пределы массива", "original");
            }
            count--;
            MakeArray(new_capacity());

            if (index < count - 1)
            {
                Array.Copy(array, index+1, array, index, count - index);
            }
            array[count] = default(T);
            return;
        }
        public void Clear()
        {
            array = null;
            count = 0;
            MakeArray(16);
        }

    }
}
