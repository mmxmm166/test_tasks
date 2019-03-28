using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        private int step;
        public string[] slots;
        public T[] values;
        private int _primenumber;

        public NativeDictionary(int sz)
        {
            step = 7;
            size = sz;
            slots = new string[size];
            values = new T[size];
            _primenumber = primenumber(size);
        }

        public int HashFun(string key)
        {
            // всегда возвращает корректный индекс слота
            int index = 0;
            if (key != null)
            {
                Char[] arrch = key.ToCharArray();
                for (int i = 0; i < key.Length; i++)
                {
                    index = index + (int)arrch[i];
                }

                if (size > 0)
                {
                    index = ((5 * index + 109) % _primenumber) % size;
                    //                    index = index % size;
                }
                else
                {
                    index = -1;
                }
            }
            return index;
        }

        private int primenumber(int end)
        {
            int result = 0;
            for (int i = 2; i < end * 2; i++)
            {
                bool b = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0 & i % 1 == 0)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    result = i;
                }
            }
            return result;
        }

        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            int index = HashFun(value);
            int i = 0;
            while (i < size)
            {
                if (slots[index] == null)
                {
                    return index;
                }
                else
                {
                    int indexnext = index + step;
                    if ((indexnext) >= size)
                    {
                        index = indexnext - size;
                    }
                    else
                    {
                        index = indexnext;
                        i++;
                    }
                }
            }
            return -1;
        }

        public int Find(string value)
        {
            // находит индекс слота со значением, или -1
            int index = HashFun(value);
            int i = 0;
            if (value != null)
            {
                while (i < size)
                {
                    if (slots[index] == value)
                    {
                        return index;
                    }
                    else
                    {
                        int indexnext = index + step;
                        if ((indexnext) >= size)
                        {
                            index = indexnext - size;
                        }
                        else
                        {
                            index = indexnext;
                            i++;
                        }
                    }
                }
            }
            return -1;
        }
        public bool IsKey(string key)
        {
            // возвращает true если ключ имеется,
            // иначе false
            if (Find(key) == -1)
                return false;
            else
                return true;
        }

        public void Put(string key, T value)
        {
            // гарантированно записываем 
            // значение value по ключу key
            int index = Find(key);
            if (index != -1)
            {
                values[index] = value;
            }
            else
            {
                index = SeekSlot(key);
                if (index != -1)
                {
                    values[index] = value;
                    slots[index] = key;
                }
            }
        }


        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            int index = Find(key);
            if (index != -1)
            {
                return values[index];
            }
            return default(T);
        }
    }
}
