using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;
        private int _count;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
            _count = 0;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                // версия для лексикографического сравнения строк
                string strv1 = v1.ToString().Replace(" ", "");
                string strv2 = v2.ToString().Replace(" ", "");

                result = strv1.CompareTo(strv2);
            }
            else
            {
                // универсальное сравнение
                double vd1 = Convert.ToDouble(v1);
                double vd2 = Convert.ToDouble(v2);

                if (Math.Abs(vd1 - vd2) <= 0.00000001)
                    result = 0;
                else if (vd1 < vd2)
                    result = -1;
                else
                    result = 1;
            }

            return result;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        public void Add(T value)
        {
            // автоматическая вставка value 
            // в нужную позицию
            Node<T> node = head;
            // Node<T> nodeAfter = null;

            if (node == null)
            {
                AddInTail(new Node<T>(value));
                return;
            }
            while (node != null)
            {
                if (_ascending)
                {
                    int _compare = Compare(value, node.value);

                    if (node == head && node == tail)
                    {
                        if (_compare < 0)
                        {
                            AddInHead(new Node<T>(value));
                            return;
                        }
                        else
                        {
                            InsertAfter(node, new Node<T>(value));
                            return;
                        }
                    }

                    if (_compare >= 0 && (node == tail))
                    {
                        InsertAfter(node, new Node<T>(value));
                        return;
                    }
                    if (_compare == 0)
                    {
                        {
                            InsertAfter(node, new Node<T>(value));
                            return;
                        }
                    }
                    if (_compare < 0)
                    {
                        InsertAfter(node.prev, new Node<T>(value));
                        return;
                    }
                }

                if (!_ascending)
                {
                    int _compare = Compare(value, node.value);

                    if (node == head && node == tail)
                    {
                        if (_compare > 0)
                        {
                            AddInHead(new Node<T>(value));
                            return;
                        }
                        else
                        {
                            InsertAfter(node, new Node<T>(value));
                            return;
                        }
                    }

                    if (_compare <= 0 && (node == tail))
                    {
                        InsertAfter(node, new Node<T>(value));
                        return;
                    }
                    if (_compare == 0)
                    {
                        {
                            InsertAfter(node, new Node<T>(value));
                            return;
                        }
                    }
                    if (_compare > 0)
                    {
                        InsertAfter(node.prev, new Node<T>(value));
                        return;
                    }
                }
                node = node.next;
            }
        }

        public Node<T> Find(T val)
        {
            Node<T> node = head;
            while (node != null)
            {
                int _compare = Compare(node.value, val);
                if (!_ascending)
                {
                    _compare= _compare * -1;
                }
                    if (_compare == 0)
                    {
                        return node;
                    }
                    if (_compare > 0)
                    {
                        return null;
                    }
                node = node.next;
            }
            return null; // здесь будет ваш код
        }
        private void AddInHead(Node<T> _item)
        {
            Node<T> oldhead = head;
            head = _item;
            head.next = oldhead;
            oldhead.prev = _item;
            head.prev = null;
            _count++;
        }
        private void AddInTail(Node<T> _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
            _count++;
        }
        private void InsertAfter(Node<T> _nodeAfter, Node<T> _nodeToInsert)
        {
            // здесь будет ваш код вставки узла после заданного

            // если _nodeAfter = null и список пустой, 
            // добавьте новый элемент первым в списке 

            if ((_nodeAfter == tail) || (_nodeAfter == null) && (head == null))
            {
                AddInTail(_nodeToInsert);
                return;
            }
            else if (_nodeAfter == null)
            {
                AddInHead(_nodeToInsert);
                return;
            }
            else if (_nodeAfter != null)
            {
                Node<T> nodeTemp = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
                _nodeToInsert.next = nodeTemp;
                _nodeToInsert.prev = _nodeAfter;
                nodeTemp.prev = _nodeToInsert;
                _count++;
                return;
            }
        }
        public void Delete(T val)
        {
            // здесь будет ваш код
            Node<T> node = Find(val);

            if (node != null)
            {
                if (head == tail)
                {
                    head = null;
                    tail = null;
                }
                else if (node == head)
                {
                    head = node.next;
                    head.prev = null;
                }
                else if (node == tail)
                {
                    tail = node.prev;
                    tail.next = null;
                }
                else
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                }
                _count--;
            }

        }

        public void Clear(bool asc)
        {
            // здесь будет ваш код
            _ascending = asc;
            head = null;
            tail = null;
            _count = 0;
        }

        public int Count()
        {
            return _count; // здесь будет ваш код подсчёта количества элементов в списке
        }

        List<Node<T>> GetAll() // выдать все элементы упорядоченного 
                               // списка в виде стандартного списка
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
    }

}
