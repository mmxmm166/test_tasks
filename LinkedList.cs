using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            // здесь будет ваш код поиска всех узлов по заданному значению
            Node node = head;
            int countValue = 0;
            while (node != null)
            {
                if (node.value == _value)
                {
                    countValue++;
                }
                node = node.next;
            }

            node = head;
            int i = 0;
            if (countValue > 0)
            {
                while (node != null)
                {
                    if (node.value == _value)
                    {
                        nodes.Add(node);
                    }
                    node = node.next;
                }
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            // здесь будет ваш код удаления одного узла по заданному значению
            Node prev = null;
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    if (head == tail)
                    {
                        head = null;
                        tail = null;
                        return true;
                    }
                    if (node == head)
                    {
                        head = node.next;
                        return true;
                    }
                    if (node == tail)
                    {
                        tail = prev;
                    }
                    prev.next = node.next;
                    node = null;
                    return true;
                }
                prev = node;
                node = node.next;
            }
            return false;
        }
        public void RemoveAll(int _value)
        {
            // здесь будет ваш код удаления всех узлов по заданному значению
            if (this.Remove(_value))
            {
               this.RemoveAll(_value);
            }
        }

        public void Clear()
        {
            // здесь будет ваш код очистки всего списка
            head = null;
            tail = null;
        }

        public int Count()
        {
            // здесь будет ваш код подсчёта количества элементов в списке
            Node node = head;
            int countValue = 0;
            while (node != null)
            {
                countValue++;
                node = node.next;
            }
            return countValue;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // здесь будет ваш код вставки узла после заданного

            // если _nodeAfter = null и список пустой, 
            // добавьте новый элемент первым в списке 
            // Node nodeAdd = new Node(val);
            if ((_nodeAfter == tail) || (_nodeAfter == null) && (this.head == null))
            {
                this.AddInTail(_nodeToInsert);
                return;
            }
            else if (_nodeAfter != null)
            {
                Node nodeTemp = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
                _nodeToInsert.next = nodeTemp;
                return;
            }
        }

    }
}
