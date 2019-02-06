using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    class Program
    {
        public static bool pallindrom(String str)
        {
            Deque<char> deq = new Deque<Char>();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] != ' ')
                    deq.AddTail(str[i]);
            }
            while (deq.Size() / 2 > 0)
            {
                if (deq.RemoveTail() != deq.RemoveFront())
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            String[] sss = { "а роза упала на лапу азора", "12321", "оно", "у дезертира жена не жарит резеду", "y", "онто", "ано", "123221" };
            for (int i = 0; i < sss.Length; i++)
            {
                Console.Write(sss[i]);

                if (pallindrom(sss[i]))
                    Console.WriteLine(" - палиндром ");
                else
                    Console.WriteLine(" - не палиндром");
            }
            testDeque();
            Console.ReadLine();
        }

        static void testDeque()
        {
            Deque<int> deq = new Deque<int>();
            deq.AddFront(1);
            deq.AddFront(2);
            deq.AddFront(3);
            deq.AddTail(4);
            deq.AddTail(5);

            Console.WriteLine("размер" + deq.Size());

            while (deq.Size()>0)
            {
                Console.WriteLine(deq.RemoveFront());
                Console.WriteLine("размер " + deq.Size());

                Console.WriteLine(deq.RemoveTail());
                Console.WriteLine("размер " + deq.Size());
            }
        }



    }
}
