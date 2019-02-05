using System;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void CicleQueue(Queue<int> qu, int n)
        {
            if ((n <= qu.Size()) && (qu.Size() > 0))
            {
                for (int i = 0; i < n; i++)
                {
                    qu.Enqueue(qu.Dequeue());
                }
            }
        }
        static void CicleQueue(QueueStack<int> qu, int n)
        {
            if ((n <= qu.Size()) && (qu.Size() > 0))
            {
                for (int i = 0; i < n; i++)
                {
                    qu.Enqueue(qu.Dequeue());
                }
            }
        }
        static void Main(string[] args)
        {
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(1);
            qu.Enqueue(2);
            qu.Enqueue(3);
            qu.Enqueue(4);
            CicleQueue(qu, 3);

            while (qu.Size() > 0)
                Console.WriteLine(qu.Dequeue());

            Console.WriteLine("-------");
            QueueStack<int> qu2 = new QueueStack<int>();
            qu2.Enqueue(1);
            qu2.Enqueue(2);
            qu2.Enqueue(3);
            qu2.Enqueue(4);
            CicleQueue(qu2, 3);

            while (qu2.Size() > 0)
                Console.WriteLine(qu2.Dequeue());

            Console.ReadLine();
        }

    }

}
