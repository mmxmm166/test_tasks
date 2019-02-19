using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            // всегда возвращает корректный индекс слота
            int result = 0;
            if (value != null)
            {
                Char[] arrch = value.ToCharArray();
                for (int i = 0; i < value.Length; i++)
                {
                    result = result + (int)arrch[i];
                }

                if (size > 0)
                {
                    result = result % size;
                }
                else
                {
                    result = -1;
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

        public int Put(string value)
        {
            // записываем значение по хэш-функции

            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            if (value != null)
            {
                int index = SeekSlot(value);
                if (index != -1)
                {
                    slots[index] = value;
                    return index;
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
    }
}
