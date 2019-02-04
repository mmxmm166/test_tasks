using System;
using System.Collections;

namespace AlgorithmsDataStructures
{

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
                rezult = (T)SList[Count-1];
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
                rezult = (T)SList[Count-1];
            }
            else
            {
                return default(T); // null, если стек пустой
            } 
            return rezult;
        }

        public void Print()
        {
            for (int i = Count-1; i >=0 ; i--)
            {
                Console.WriteLine(SList[i]);
            }
        }
    }

}
