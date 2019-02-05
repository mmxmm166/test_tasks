using System;
using System.Collections;

namespace AlgorithmsDataStructures
{
    public class QueueStack<T1>
    {
        public Stack<T1> ST1;
        public Stack<T1> ST2;

        int Count;

        public QueueStack()
        {
            // инициализация внутреннего хранилища очереди
            ST1 = new Stack<T1>();
            ST2 = new Stack<T1>();
            Count = 0;
        }

        public void Enqueue(T1 item)
        {
            // вставка в хвост
            ST1.Push(item);
            Count++;
        }

        public T1 Dequeue()
        {
            // выдача из головы
            T1 rezult;
            if (Count == 1)
            {
                rezult = ST1.Pop();
                Count--;
            }
            else if (Count > 0)
            {
                while (ST1.Size() > 1)
                {
                    ST2.Push(ST1.Pop());
                }

                rezult = ST1.Pop();

                while (ST2.Size() > 0)
                {
                    ST1.Push(ST2.Pop());
                }
                Count--;
            }
            else
            {
                return default(T1); // если очередь пустая
            }
            return rezult;
        }

        public int Size()
        {
            return Count; // размер очереди
        }

        public class Stack<T>
        {
            public ArrayList SList;
            int Count;
            public Stack()
            {
                // инициализация внутреннего хранилища стека
                SList = new ArrayList();
                Count = 0;
            }

            public int Size()
            {
                // размер текущего стека		  
                return Count;
            }

            public T Pop()
            {
                // ваш код
                T rezult;
                if (Count > 0)
                {
                    rezult = (T)SList[Count - 1];
                    SList.RemoveAt(Count - 1);
                    Count--;
                }
                else
                {
                    return default(T); // null, если стек пустой
                }
                return rezult;

            }

            public void Push(T val)
            {
                // ваш код
                SList.Add(val);
                Count++;
            }

            public T Peek()
            {
                // ваш код
                T rezult;
                if (Count > 0)
                {
                    rezult = (T)SList[Count - 1];
                }
                else
                {
                    return default(T); // null, если стек пустой
                }
                return rezult;
            }

            public void Print()
            {
                for (int i = Count - 1; i >= 0; i--)
                {
                    Console.WriteLine(SList[i]);
                }
            }

        }

    }
}
