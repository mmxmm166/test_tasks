using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T>
    {

        private List<T> ps;

        public PowerSet()
        {
            // ваша реализация хранилища
            ps = new List<T>();
        }

        public int Size()
        {
            // количество элементов в множестве
            return ps.Count;
        }

        public void Put(T value)
        {
            // всегда срабатывает
            if (!ps.Contains(value) && value != null)
            {
                ps.Add(value);
            }
        }

        public bool Get(T value)
        {
            // возвращает true если value имеется в множестве,
            // иначе false
            return ps.Contains(value);
        }

        public bool Remove(T value)
        {
            // возвращает true если value удалено
            // иначе false
            if (ps.Contains(value))
            {
                ps.Remove(value);
                return true;
            }
            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            // пересечение текущего множества и set2
            PowerSet<T> intersect = new PowerSet<T>();

            foreach (var item in ps)
            {
                if (set2.Get(item))
                {
                    intersect.Put(item);
                }
            }
            return intersect;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            // объединение текущего множества и set2
            PowerSet<T> union_set = new PowerSet<T>();

            foreach (var item in ps)
            {
                union_set.Put(item);
            }
            foreach (var item in set2.ps)
            {
                union_set.Put(item);
            }
            return union_set;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            // разница текущего множества и set2
            // пересечение текущего множества и set2
            PowerSet<T> difset = new PowerSet<T>();

            foreach (var item in ps)
            {
                if (!set2.Get(item))
                {
                    difset.Put(item);
                }
            }
            return difset;
        }
        public bool IsSubset(PowerSet<T> set2)
        {
            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
            if (set2 != null)
            {
                foreach (var item in set2.ps)
                {
                    if (!ps.Contains(item))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
