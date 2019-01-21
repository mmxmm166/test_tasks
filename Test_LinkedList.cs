using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList s_list = new LinkedList();
            fillLinkedList(s_list);
            test1(s_list);
            fillLinkedListNone(s_list);
            test1(s_list);
            fillLinkedListOne(s_list);
            test1(s_list);

            test2(s_list);

            test3(s_list);

            test4(s_list);

            test5(s_list);
   
            fillLinkedList(s_list);
            test6(s_list);
            fillLinkedListNone(s_list);
            test6(s_list);
            fillLinkedListOne(s_list);
            test6(s_list);
           
            test7(s_list); // суммирование двух списков одинаковой длины
            Console.ReadLine();
        }
        public static void print(LinkedList _linklist)
        {
            Node node = _linklist.head;
            while (node != null)
            {
                Console.WriteLine("элемент " + node.value);
                node = node.next;
            }
            if (_linklist.head != null)
            {
                Console.WriteLine("элемент заголовок " + _linklist.head.value);
                Console.WriteLine("элемент конец " + _linklist.tail.value);
            }
        }

        public static void fillLinkedList(LinkedList s_list)
        {
            s_list.Clear();
            s_list.AddInTail(new Node(12));
            s_list.AddInTail(new Node(55));
            s_list.AddInTail(new Node(55));
            s_list.AddInTail(new Node(33));
            s_list.AddInTail(new Node(55));
            s_list.AddInTail(new Node(128));
            s_list.AddInTail(new Node(55));
            s_list.AddInTail(new Node(56));
            Console.WriteLine("начальный список");
            print(s_list);
        }
        public static void fillLinkedListOne(LinkedList s_list)
        {
            s_list.Clear();
            s_list.AddInTail(new Node(12));
         //   Console.WriteLine("начальный список");
           // print(s_list);
        }
        public static void fillLinkedListNone(LinkedList s_list)
        {
            s_list.Clear();
         //   Console.WriteLine("начальный список - нет элементов");
           // print(s_list);
        }

        public static void test1(LinkedList s_list)
        {
            Console.WriteLine("1. метод удаления одного узла по его значению.");
            Console.WriteLine("после удаления элементов 12, 56 и 33");
            s_list.Remove(12);
            s_list.Remove(56);
            s_list.Remove(33);
            print(s_list);
        }

        public static void test2(LinkedList s_list)
        {
            Boolean rezult=true;
            fillLinkedList(s_list);
            Console.WriteLine("2. метод удаления всех узлов по конкретному значению.");
            Console.WriteLine("после удаления всех элементов 55 ");

            List<Node> nodeList = s_list.FindAll(55);
            Console.WriteLine("cписок элементов со значением 55 - 4 элемента");
            if (nodeList.Count == 4)
            {
                s_list.RemoveAll(55);
                List<Node> nodeList1 = s_list.FindAll(55);
                if (nodeList1.Count != 0)
                    rezult = false;
            }
            if (rezult)
                Console.WriteLine("тест пройден");
            else
                Console.WriteLine("тест НЕ пройден");
            //print(s_list);
        }

        public static void test3(LinkedList s_list)
        {
            Console.WriteLine("3. метод очистки всего содержимого(создание пустого списка).");
            s_list.Clear();
            Console.WriteLine("после удаления всех элементов");
            if (s_list.head == null && s_list.tail == null)
                Console.WriteLine("Тест пройден"); 
            //print(s_list);
        }

        public static void test4(LinkedList s_list)
        {
            fillLinkedList(s_list);
            Console.WriteLine("4. метод поиска всех узлов по конкретному значению(возвращается список/массив найденных узлов).");
            List < Node > nodeList = s_list.FindAll(55);
            Console.WriteLine("cписок элементов со значением 55 - 4 элемента" );
            if (nodeList.Count==4) Console.WriteLine("тест пройден");
            else Console.WriteLine("тест НЕ пройден");
        }

        public static void test5(LinkedList s_list)
        {
            Boolean rezult=true;
            Console.WriteLine("5. метод вычисления длины списка.");
            fillLinkedList(s_list);
            if (s_list.Count() != 8)
                rezult = false;
            fillLinkedListNone(s_list);
            if (s_list.Count() != 0)
                rezult = false;
            fillLinkedListOne(s_list);
            if (s_list.Count() != 1)
                rezult = false;
            if (rezult)
                Console.WriteLine("тест пройден");
            else
                Console.WriteLine("тест НЕ пройден");
        }

        public static void test6(LinkedList s_list)
        {
            Console.WriteLine("6. метод вставки узла после заданного узла.");
            Console.WriteLine("вставляем 128 после узла со значением 33");
            Console.WriteLine("вставляем 48 после узла со значением 56");
 
            s_list.InsertAfter(s_list.Find(33), new Node(128));
            s_list.InsertAfter(s_list.Find(56), new Node(48));
            print(s_list);
        }

        public static void test7(LinkedList s_list)
        {
            Console.WriteLine("тест 7 суммируем два списка");
            Console.WriteLine("список1");
            fillLinkedList(s_list);

            LinkedList sList2 = new LinkedList();
            Console.WriteLine("список2");
            fillLinkedList(sList2);
            LinkedList sListSumm = new LinkedList();
            sListSumm = AdditionList(s_list, sList2);
            Console.WriteLine("список после суммирования");
            print(sListSumm);
        }

//суммирование списков одной длины 
        static LinkedList AdditionList(LinkedList sList1, LinkedList SList2)
        {
            LinkedList sListSumm = new LinkedList();
            if (sList1.Count() == SList2.Count() && sList1.Count() > 0)
            {
                Node node1 = sList1.head;
                Node node2 = SList2.head;
                while (node1 != null)
                {
                    sListSumm.AddInTail(new Node(node1.value + node2.value));
                    node1 = node1.next;
                    node2 = node2.next;
                }
            }
            return sListSumm;
        }
    }
}

