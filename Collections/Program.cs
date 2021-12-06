using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

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

            Console.WriteLine("================");

            string expr = "122+3+5-(25-4+17)"; // 92

            int resultMathCalculate = MathCalculate("2 * 2");


            string expr2 = "100 + 10-6+1+5 + 2";

            int resultgetValueFromExpression = getValueFromExpression(expr2);
            Console.WriteLine(resultgetValueFromExpression);

            Console.ReadLine();
        }


        public static int getValueFromString(string str)
        {
            string trimExpr = str.Replace(" ", String.Empty);
            Stack<int> numStack = new Stack<int>();
            int j = 0;
            for (int i = 0; i < trimExpr.Length; i++)
            {
                if (trimExpr[i].Equals(")"))
                {
                    int closedBracketIndex = i;
                    int openBracketIndex = trimExpr.Substring(j, i).LastIndexOf("(");
                    int resultInBrackets = getValueFromExpression(trimExpr.Substring(openBracketIndex + 1, closedBracketIndex - openBracketIndex));
                    numStack.Push(resultInBrackets);
                }
            }
            return numStack.Peek();
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
    }

}
