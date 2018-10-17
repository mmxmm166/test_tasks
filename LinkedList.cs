using System;

namespace myLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList s_list = new LinkedList();
            test1(s_list);
            test2(s_list);
            test3(s_list);
            test4(s_list);
            test5(s_list);
            test6(s_list);
            test7(s_list);
            Console.ReadLine();
        }

        public static void fillLinkedList(LinkedList s_list)
        {
            s_list.RemoveNodeAll();
            s_list.AddInTail(new Node(12));
            s_list.AddInTail(new Node(55));
            s_list.AddInTail(new Node(55));
            s_list.AddInTail(new Node(33));
            s_list.AddInTail(new Node(55));
            s_list.AddInTail(new Node(128));
            s_list.AddInTail(new Node(55));
            s_list.AddInTail(new Node(56));
            Console.WriteLine("начальный список");
            s_list.print();
        }

        public static void test1(LinkedList s_list)
        {
            Console.WriteLine("1. метод удаления одного узла по его значению.");
            fillLinkedList(s_list);
            Console.WriteLine("после удаления элементов 12, 56 и 33");
            s_list.RemoveNodeValue(12);
            s_list.RemoveNodeValue(56);
            s_list.RemoveNodeValue(33);
            s_list.print();
        }

        public static void test2(LinkedList s_list)
        {
            Console.WriteLine("2. метод удаления всех узлов по конкретному значению.");
            fillLinkedList(s_list);
            Console.WriteLine("после удаления всех элементов 55 ");
            s_list.RemoveNodeAllValue(55);
            s_list.print();
        }

        public static void test3(LinkedList s_list)
        {
            Console.WriteLine("3. метод очистки всего содержимого(создание пустого списка).");
            fillLinkedList(s_list);
            s_list.RemoveNodeAll();
            Console.WriteLine("после удаления всех элементов");
            s_list.print();
        }

        public static void test4(LinkedList s_list)
        {
            Console.WriteLine("4. метод поиска всех узлов по конкретному значению(возвращается список/массив найденных узлов).");
            fillLinkedList(s_list);
            Node [] nodeList = s_list.FindAllValue(55);
            Console.WriteLine("cписок элементов со значением 55" );
            for (int i = 0; i < nodeList.Length; i++)
            {
                Console.WriteLine(nodeList[i].Value + " значение Next " + nodeList[i].Next.Value);
            }
        }

        public static void test5(LinkedList s_list)
        {
            Console.WriteLine("5. метод вычисления длины списка.");
            fillLinkedList(s_list);
            Console.WriteLine("количество элементов " + s_list.Count());
        }
        
        public static void test6(LinkedList s_list)
        {
            Console.WriteLine("6. метод вставки узла после заданного узла.");

            fillLinkedList(s_list);
            Console.WriteLine("вставляем 128 после узла со значением 33");
            Console.WriteLine("вставляем 48 после узла со значением 56");
            s_list.AddNode(s_list.find(33), 128);
            s_list.AddNode(s_list.find(56), 48);
            s_list.print();
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
            sListSumm = additionList(s_list, sList2);
            Console.WriteLine("список после суммирования");
            sListSumm.print();
        }

        static LinkedList additionList(LinkedList sList1, LinkedList SList2)
        {
            LinkedList sListSumm = new LinkedList();
            if (sList1.Count() == SList2.Count() && sList1.Count() > 0)
            {
                Node node1 = sList1.head;
                Node node2 = SList2.head;
                while (node1 != null)
                {
                    sListSumm.AddInTail(new Node(node1.Value + node2.Value));
                    node1 = node1.Next;
                    node2 = node2.Next;
                }
            }
            return sListSumm;
        }

        public class LinkedList
        {
            public Node head { get; set; }
            public Node tail { get; set; }

            public void AddInTail(Node item)
            {
                if (head == null)
                {
                    head = item;
                }
                else
                {
                    tail.Next = item;
                }
                tail = item;
            }
            public int Count()
            {
                Node node = head;
                int countValue = 0;
                while (node != null)
                {
                    countValue++;
                    node = node.Next;
                }
                return countValue;
            }

            //удалить все элементы списка
            public void RemoveNodeAll()
            {
                head = null;
                tail = null;
            }

            //вставка узла после заданного узла
            public void AddNode(Node nodeBefore, int val)
            {
                Node nodeAdd = new Node(val);
                if (nodeBefore == tail)
                {
                    this.AddInTail(nodeAdd);
                    return; 
                }
                Node nodeTemp = nodeBefore.Next;
                nodeBefore.Next = nodeAdd;
                nodeAdd.Next = nodeTemp;
                return;
            }

            //находит все элементы с одинаковым значением и выдает массив этих эллементов
            public Node[] FindAllValue(int val)
            {
                Node node = head;
                int countValue = 0;
                while (node != null)
                {
                    if (node.Value == val)
                    {
                        countValue++;
                    }
                    node = node.Next;
                }

                node = head;
                int i = 0;
                Node[] NodeArray = new Node[countValue];
                if (countValue > 0)
                {
                    while (node != null)
                    {
                        if (node.Value == val)
                        {
                            NodeArray[i] = node;
                            i++;
                        }
                        node = node.Next;
                    }
                }
                return NodeArray;
            }

            //удалить все элементы с определенным значением
            public void RemoveNodeAllValue(int val)
            {
                if (this.find(val) != null)
                {
                    this.RemoveNodeValue(val);
                    this.RemoveNodeAllValue(val);
                }
            }


            //удалить элемент с определенным значением
            public void RemoveNodeValue(int val)
            {
                Node prev = null;
                Node node = head;

                while (node != null)
                {
                    if (node.Value == val)
                    {
                        if (head == tail)
                        {
                            head = null;
                            tail = null;
                            return;
                        }
                        if (node == head)
                        {
                            head = node.Next;
                            return;
                        }
                        if (node == tail)
                        {
                            tail = prev;
                        }
                        prev.Next = node.Next;
                        node = null;
                        return;
                    }
                    prev = node;
                    node = node.Next;
                }
                return;
            }

            public LinkedList()
            {
                head = null;
                tail = null;
            }
            public void print()
            {
                Node node = head;
                while (node != null)
                {
                    Console.WriteLine("элемент " + node.Value);
                    node = node.Next;
                }
            }
            public Node find(int val)
            {
                Node node = head;
                while (node != null)
                {
                    if (node.Value == val)
                    {
                        return node;
                    }
                    node = node.Next;
                }
                return null;
            }
        }

        public class Node
        {
            public int Value;
            public Node Next;
            public Node(int value)
            {
                Value = value;
            }
        }
    }
}

