using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    internal class Program
    {
        struct Worker
        {
            public string name;
            public string position;
            public DateTime startDate;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Worker[] workers = new Worker[5];

            for (int i = 0; i < workers.Length; i++)
            {

                Console.Write("Введіть ім'я: ");
                workers[i].name = Console.ReadLine();
                Console.Write("Введіть посаду: ");
                workers[i].position = Console.ReadLine();

            begin:
                try
                {
                    Console.Write("Введіть дату: ");

                    workers[i].startDate = DateTime.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    goto begin;
                }

                Console.WriteLine(new string('-', 30));
            }

            Array.Sort(workers, (w1, w2) => string.CompareOrdinal(w1.name, w2.name));


            Console.WriteLine("Введіть граничне значення стажу роботи: ");
            int bounderyValue = int.Parse(Console.ReadLine());
            foreach (Worker worker in workers)
            {
                double value = 0;
                if (DateTime.Now.Month > worker.startDate.Month)
                    value = DateTime.Now.Year - worker.startDate.Year;
                else
                    value = DateTime.Now.Year - worker.startDate.Year - 1;

                if (value >= bounderyValue)
                    Console.WriteLine("Стаж роботи працівника {0} більше {1}", worker.name, bounderyValue);
            }

            Console.ReadKey();
        }
    }
}
