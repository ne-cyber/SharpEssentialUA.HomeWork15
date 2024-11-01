using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    internal class Program
    {
        static class Calculator
        {
            public static void Add(double a, double b)
            {
                Console.WriteLine("a + b = {0}", a + b);
            }
            public static void Sub(double a, double b)
            {
                Console.WriteLine("a - b = {0}", a - b);
            }
            public static void Mul(double a, double b)
            {
                Console.WriteLine("a * b = {0}", a * b);
            }
            public static void Div(double a, double b)
            {
                if (b == 0)
                    throw new DivideByZeroException("Спроба поділу на нуль!!!");

                Console.WriteLine("a / b = {0}", a / b);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            while (true)
            {
                try
                {
                    double a, b;
                    Console.Write("Ведіть число a: ");
                    a = double.Parse(Console.ReadLine());
                    Console.Write("Ведіть число b: ");
                    b = double.Parse(Console.ReadLine());

                    string operation;
                    Console.Write("Ведіть операцію: ");
                    operation = Console.ReadLine();

                    switch(operation)
                    {
                        case "+":
                            Calculator.Add(a, b);
                            break;
                        case "-":
                            Calculator.Sub(a, b);
                            break;
                        case "*":
                            Calculator.Mul(a, b);
                            break;
                        case "/":
                            Calculator.Div(a, b);
                            break;
                        default:
                            throw new Exception("Невідома операція!");
                            break;
                    }

                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine(new string('-', 30));
                }
            }
        }
    }
}
