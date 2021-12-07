using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {

            // ======= LINQ =======

            if (EmployeeCollection.Employees.Count == 0)
            {
                EmployeeCollection.SetEmployees();
            }
            Console.WriteLine("====== Average ======");
            foreach (var item in EmployeeCollection.AverageAgeForEachCompany())
            {
                Console.WriteLine($"Key (Company) : {item.Key} ; Value (Average Age) : {item.Value}");
            }
            Console.WriteLine("====== Count ======");
            foreach (var item in EmployeeCollection.CountOfEmployeesForEachCompany())
            {
                Console.WriteLine($"Key (Company) : {item.Key} ; Value (Count) : {item.Value}");
            }
            Console.WriteLine("====== OldestAge ======");
            foreach (var item in EmployeeCollection.OldestAgeForEachCompany())
            {
                Console.WriteLine($"Key (Company) : {item.Key} ; Value (Count) : {item.Value}");
            }


            List<string> names = new List<string>{ "One", "Two", "Three", "Four" };

            LinkedListExample linkedListExample = new LinkedListExample(names);
            linkedListExample.Run();

            QueueExample queueExample = new QueueExample(names);
            queueExample.Run();

            StackExample stackExample = new StackExample(names);
            stackExample.Run();

            Console.WriteLine("======= Stack is balanced ======");

            Console.WriteLine(stackExample.isBalanced("{[(])}")); // {[(])}  {[()]}  {{[[(())]]}}
            Console.WriteLine(stackExample.isBalanced("{{[[(())]]}}"));


            Console.WriteLine("================");

            string expr = "122+3+5-(25-4+17)"; // 92

            int resultMathCalculate = MathCalculate("2 * 2");


            string expr2 = "100 + 10-6+1+5 + 2";

            int resultgetValueFromExpression = getValueFromExpression(expr2);
            Console.WriteLine(resultgetValueFromExpression);

            Console.WriteLine("===== Evaluate RPN {Reverse Polish Notation} ======");
            // https://leetcode.com/explore/learn/card/queue-stack/230/usage-stack/1394/

            string[] tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };

            Console.WriteLine(stackExample.EvalRPN(tokens));

            Console.ReadLine();
        }



        public static int getValueFromExpression(string str)
        {
            string trimExpr = str.Replace(" ", String.Empty);
            Stack<int> numStack = new Stack<int>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < trimExpr.Length; i++)
            {
                char sign = (i > 0) ? trimExpr[i-1] : '_';
                while ((Char.IsDigit(trimExpr[i])) && i < trimExpr.Length - 1)
                {
                    sb.Append(trimExpr[i]);
                    i++;
                }

                if (i == trimExpr.Length - 1)
                    sb.Append(trimExpr[i]);

                int intvar = Int32.Parse(sb.ToString());
                sb.Clear();
                if (numStack.Count == 0)
                {
                    numStack.Push(intvar);
                }
                else
                {
                    int prev = numStack.Pop();
                    numStack.Push(MathExecOperator(sign, prev, intvar));
                }
            }
            return numStack.Pop();
        }

        public static int MathCalculate(string expression)
        {
            string trimmedExpression = expression.Replace(" ", String.Empty); // remove whitespaces
            char[] signArray = { '+', '-', '*', '/' };
            int IndexOfSign = trimmedExpression.IndexOfAny(signArray);
            char sign = trimmedExpression[IndexOfSign];
            string var1 = trimmedExpression.Substring(0, IndexOfSign);
            string var2 = trimmedExpression.Substring(IndexOfSign+1);
            int intvar1;
            int intvar2;
            var parseIntVar1 = Int32.TryParse(var1, out intvar1);
            var parseIntVar2 = Int32.TryParse(var2, out intvar2);
            if (parseIntVar1 && parseIntVar2)
            {
                return MathExecOperator(sign, intvar1, intvar2);
            }
            return 0;
        }

        public static int MathExecOperator(char sign, int var1, int var2)
        {
            int res = 0;
            switch (sign)
            {
                case '+': res = var1 + var2; break;
                case '-': res = var1 - var2; break;
                case '*': res = var1 * var2; break;
                case '/': res = var1 / var2; break;
                default: res = 0; break;
            }
            return res;
        }

        public static void getValueFromParenthesis(string str)
        {
            Stack<string> resultStack = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            string numprev, num, sign, calcresult, s;
            s = str.Replace(" ", String.Empty);
            for (int i = 0; i < s.Length; i++)
            {
                while (Char.IsDigit(s[i]) && i < s.Length - 1)
                {
                    sb.Append(s[i]);
                    i++;
                }
                char ch = s[i];
                if (i == s.Length - 1 && Char.IsDigit(ch)) sb.Append(ch);
                num = sb.ToString();
                if (sb.Length > 0) resultStack.Push(num);
                sb.Clear();

                if (ch.Equals('(') || ch.Equals('+') || ch.Equals('-') || ch.Equals(')')) resultStack.Push(ch.ToString());

                if (ch.Equals(')') && resultStack.Count > 2)
                {
                    while (resultStack.Count > 2)
                    {
                        if (resultStack.Count > 0 && resultStack.Peek().Equals(")"))
                        {
                            resultStack.Pop();
                        }
                        num = resultStack.Pop();
                        sign = resultStack.Pop();
                        numprev = resultStack.Pop();
                        calcresult = StackExample.Calculate(sign, numprev, num);
                        if (resultStack.Count > 0 && resultStack.Peek().Equals("("))
                        {
                            resultStack.Pop();
                        }
                        resultStack.Push(calcresult);
                    }
                }
            }

            while (resultStack.Count > 2)
            {
                num = resultStack.Pop();
                sign = resultStack.Pop();
                numprev = resultStack.Pop();
                calcresult = StackExample.Calculate(sign, numprev, num);
                resultStack.Push(calcresult);
            }

            int stackLength = resultStack.Count;
            for (int i = 0; i < stackLength; i++)
            {
                Console.WriteLine(resultStack.Pop());
            }
        }

    }

}
