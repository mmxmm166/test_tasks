using System;
using System.Collections;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        public ArrayList SList;
        public int Count;

        public Deque()
        {
            // инициализация внутреннего хранилища
            SList = new ArrayList();
            Count = 0;
        }

        public void AddFront(T item)
        {
            // добавление в голову
            SList.Insert(0, item);
            Count++;
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            SList.Add(item);
            Count++;
        }

        public T RemoveFront()
        {
            // удаление из головы
            T rezult;
            if (Count > 0)
            {
                rezult = (T)SList[0];
                SList.RemoveAt(0);
                Count--;
            }
            else
            {
                return default(T); // если очередь пустая
            }
            return rezult;
        }

        public T RemoveTail()
        {
            // удаление из хвоста
            T rezult;
            if (Count > 0)
            {
                rezult = (T)SList[Count-1];
                SList.RemoveAt(Count-1);
                Count--;
            }

            else
            {
                return default(T); // если очередь пустая
            }
            return rezult;
         }

        public int Size()
        {
            return Count; // размер очереди
        }
    }

}
