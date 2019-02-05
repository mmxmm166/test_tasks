using System;
using System.Collections;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        public ArrayList SList;
        int Count;

        public Queue()
        {
            // инициализация внутреннего хранилища очереди
            SList = new ArrayList();
            Count = 0;
        }

        public void Enqueue(T item)
        {
            // вставка в хвост
            SList.Add(item);
            Count++;
        }

        public T Dequeue()
        {
            // выдача из головы
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

        public int Size()
        {
            return Count; // размер очереди
        }

    }
}
