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
                Array.Copy(old_array, array, old_array.Length);
                capacity = new_capacity;    
            }
        }

        public T GetItem(int index)
        {
            // ваш код
            return default(T);
        }

        public void Append(T itm)
        {
            // ваш код
            // размер м
            
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
            if (count > capacity)
            {
                rezult = capacity * 2;
            }
            if (count < capacity/2)
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
            if (index == count-1) && (count >0 )  
            {
                this.Append(itm);
                return;
            }
            if (index == 0)
            {
                count++;
                this.MakeArray(new_capacity());
                array.CopyTo(array, index + 1);
                array[index] = itm;
            }
        }

        public void Remove(int index)
        {
            // ваш код
            // если индекс 0 то вставляем в начало
            if (index == 0)
            {

            }
            if (index == count - 1)
            {
                count--;

                return;
            }
            if (index == 0)
            {
                count++;
                this.MakeArray(new_capacity());
                array.CopyTo(array, index + 1);
                array[index] = itm;
            }

        }

    }
}
