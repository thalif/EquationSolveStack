using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationSolveStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numberStack = new Stack<int>();
            Stack<char> operatorStack = new Stack<char>();
            char[] Operators = new char[] { '+', '-', '*' };

            string Equation = "(1+((2+3)*(4*5)))";
            for (int i = 0; i < Equation.Length; i++)
            {
                string number = string.Empty;
                while (IsInteger(Equation[i]))
                {
                    number += Equation[i++];
                }
                if (number != string.Empty)
                {
                    numberStack.Push(int.Parse(number));
                    i--;
                }
                else if(Operators.Contains(Equation[i]))
                {
                    operatorStack.Push(Equation[i]);
                }
                else if(Equation[i] == ')')
                {
                    int n1 = numberStack.Pop();
                    int n2 = numberStack.Pop();
                    char op = operatorStack.Pop();
                    numberStack.Push(Calc(n1, n2, op));
                }
            }
            int Value = numberStack.Pop();
            Console.WriteLine(Value);
            Console.ReadKey();
        }


        public static int Calc(int number1, int number2, char Operator)
        {
            if(Operator == '+')
            {
                return number1 + number2;
            }
            else if(Operator == '*')
            {
                return number1 * number2;
            }
            else if (Operator == '-')
            {
                return number1 - number2;
            }
            return 0;
        }
        public static bool IsInteger(char c)
        {
            try
            {
                int check = int.Parse(c.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
