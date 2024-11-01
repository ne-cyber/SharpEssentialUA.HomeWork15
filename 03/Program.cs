using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    internal class Program
    {
        struct Price
        {
            public string name;
            public string shop;
            public double price;

            public void Out()
            {
                Console.WriteLine("назва товару: {0}, магазин: {1}, ціна: {2} (грв.)", name, shop, price);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Price[] price = new Price[2];
            //price[0].name = "Ruchka";
            //price[0].shop = "TiD";
            //price[0].price = 100.50;

            //price[1].name = "Ruchka";
            //price[1].shop = "TiD";
            //price[1].price = 150.50;

            for (int i = 0; i < price.Length; i++)
            {
                Console.Write("Введіть назву товару: ");
                price[i].name = Console.ReadLine();
                Console.Write("Введіть назву магазину: ");
                price[i].shop = Console.ReadLine();

            price_double:
                try
                {
                    Console.Write("Введіть ціну: ");
                    price[i].price = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto price_double;
                }
                Console.WriteLine(new string('-', 10));
            }


            Array.Sort(price, (p1, p2) => string.CompareOrdinal(p1.shop, p2.shop));
            Console.WriteLine(new string('-', 30));


            while (true)
            {

                try
                {
                    Console.Write("Введіть назву магазину: ");
                    string shop = Console.ReadLine();

                    Price[] filteredPrice = price.Where((p) => p.shop == shop).ToArray();

                    if (filteredPrice.Length == 0)
                        throw new Exception("Такого магазину немає!");

                    foreach (Price p in filteredPrice)
                    {
                        if (p.shop == shop)
                            p.Out();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine(new string('-', 30));
                }
            }

            Console.ReadKey();
        }
    }
}
