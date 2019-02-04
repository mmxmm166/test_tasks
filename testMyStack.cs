using System;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<object> stack = new Stack<object>();
            stack.Push(1);
            stack.Push("второй");
            stack.Push(3.5);
            Console.WriteLine("печатаем и извлекаем содержимое стека ");

            while (stack.Size() > 0)
            {
                Console.WriteLine(stack.Pop());
            }
            stack.Print();
            String sss = "((((";
            Console.Write("скобки в " + sss + " ");

            if (AnalizeParentheses(sss))
                Console.WriteLine("сбалансированы ");
            else
                Console.WriteLine("несбалансированы");

            sss = "8 2 + 5 * 9 +";
            Console.WriteLine("результат " + sss + " = " + calc(sss));

            Console.ReadLine();
        }

        static String calc(String str)
        {
            Stack<string> s1 = new Stack<string>();
            Stack<string> s2 = new Stack<string>();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] != ' ')
                    s1.Push(Convert.ToString(str[i]));
            }

            while (s1.Size() > 0)
            {
                string ch;
                ch = s1.Pop();
                if ((ch != "+") && (ch != "*"))
                {
                    s2.Push(ch);
                }
                else if (ch == "+")
                {
                    while (s2.Size() > 1)
                    {
                        int num1 = Convert.ToInt32(s2.Pop());
                        int num2 = Convert.ToInt32(s2.Pop());
                        s2.Push(Convert.ToString(num1 + num2));
                    }
                }
                else if (ch == "*")
                {
                    while (s2.Size() > 1)
                    {
                        int num1 = Convert.ToInt32(s2.Pop());
                        int num2 = Convert.ToInt32(s2.Pop());
                        s2.Push(Convert.ToString(num1 * num2));
                    }
                }
            }
            return s2.Pop();
        }

        static bool AnalizeParentheses(string s)
        {
            Stack<char> s1 = new Stack<char>();
            Stack<char> s2 = new Stack<char>();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                s1.Push(s[i]);
            }
            if (s1.Size() > 1 && s1.Size() % 2 == 0)
            {
                while (s1.Size() > 1)
                {
                    if (s1.Peek() == '(')
                    {
                        s2.Push(s1.Pop());
                    }
                    else if (s1.Peek() == ')')
                    {
                        if (s2.Size() > 0)
                        {
                            s2.Pop();
                            s1.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }

            if (s2.Size() > 0)
                return false;
            else
                return true;
        }
    }
}


 


 

