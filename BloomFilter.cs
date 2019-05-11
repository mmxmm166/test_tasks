using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;


namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public BitArray bloomFilter;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            // создаём битовый массив длиной f_len ...
            bloomFilter = new BitArray(f_len);
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            // 17
            // реализация 
            int code = 0;
            int randomNumber = 17;
            for (int i = 0; i < str1.Length; i++)
            {
                code = (code * randomNumber + (int)str1[i]) % filter_len;
            }
            return code;
        }
        public int Hash2(string str1)
        {
            // 223
            // реализация ...
            int code = 0;
            int randomNumber = 223;
            for (int i = 0; i < str1.Length; i++)
            {
                code = (code * randomNumber + (int)str1[i]) % filter_len;
            }
            return code;
        }

        public void Add(string str1)
        {
            // добавляем строку str1 в фильтр
            bloomFilter[Hash1(str1)] = true;
            bloomFilter[Hash2(str1)] = true; 
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            if (bloomFilter[Hash1(str1)] && bloomFilter[Hash2(str1)])
                return true;
            else return false;
        }
    }
}
