using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class StackExample
    {

        private List<string> _names;
        public StackExample(List<string> names)
        {
            _names = names;
        }
        public void Run()
        {

            Console.WriteLine("==== Stack structure ====");

            Stack<Person> personsStack = new Stack<Person>();

            foreach (string name in _names)
            {
                personsStack.Push(new Person() { Name = name });
            }

            int i = 1;
            foreach (Person p in personsStack)
            {
                Console.WriteLine("Pushed person " + i + " : " + p.Name);
                i++;
            }

            Console.WriteLine($"There are {personsStack.Count} persons in the queue");

            // get first element from queue without removing
            Person peekedPerson = personsStack.Peek();
            Console.WriteLine("Peeked person (1-st element) w/o removing from queue is " + peekedPerson.Name);

            while (personsStack.Count > 0)
            {
                Person poppedPerson = personsStack.Pop();
                Console.WriteLine($"Dequeued person is {poppedPerson.Name}. Persons left in queue : {personsStack.Count}.");
            }

        }

        public string isBalanced(string s)
        {
            /*
            int n = -1;
            while (s.Length != n)
            {
                n = s.Length;
                s = s.Replace("()", String.Empty);
                s = s.Replace("[]", String.Empty);
                s = s.Replace("{}", String.Empty);
            }

            if (s.Length == 0)
                return "YES";
            return "NO";
            */

            Stack<Char> stack = new Stack<Char>();

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch == '{' || ch == '(' || ch == '[')
                {
                    stack.Push(ch);
                }
                else if (stack.Count == 0)
                {
                    return "NO";
                }
                else if (ch == '}')
                {
                    if (stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                    else { return "NO"; }

                }
                else if (ch == ']')
                {
                    if (stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                    else { return "NO"; }

                }
                else if (ch == ')')
                {
                    if (stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else { return "NO"; }

                }
            }
            if (stack.Count == 0)
            {
                return "YES";
            }
            return "NO";
        }

        public int EvalRPN(string[] tokens)
        {
            Stack<string> stack = new Stack<string>();
            string varA, varB, res;
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Equals("+") || tokens[i].Equals("*") || tokens[i].Equals("-") || tokens[i].Equals("/"))
                {
                    varB = stack.Pop();
                    varA = stack.Pop();
                    res = Calculate(tokens[i], varA, varB);
                    stack.Push(res);
                }
                else
                {
                    stack.Push(tokens[i]);
                }
            }
            return Int32.Parse(stack.Pop());
        }

        public static string Calculate(string sign, string var1, string var2)
        {
            int res = 0;
            switch (sign)
            {
                case "*": res = Int32.Parse(var1) * Int32.Parse(var2); break;
                case "/": res = Int32.Parse(var1) / Int32.Parse(var2); break;
                case "+": res = Int32.Parse(var1) + Int32.Parse(var2); break;
                case "-": res = Int32.Parse(var1) - Int32.Parse(var2); break;
                default: res = 0; break;
            }
            return res.ToString();
        }


    }
}
