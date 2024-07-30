using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_07_24Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float rubInWallet;
            float usdInWallet;
            int rubToUsd = 64, usdToRub = 66;
            float exchangeCurrencyCount;
            string desiredOperation;
            Console.WriteLine("Добро пожаловать в обменник валют!");
            Console.Write("Введите баланс рублей: ");
            rubInWallet=Convert.ToSingle(Console.ReadLine());            
            Console.Write("Введите баланс долларов: ");
            usdInWallet=Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Выберите необходимую операцию:");
            Console.WriteLine("1 - обменять рубли на доллары.");
            Console.WriteLine("2 - обменять доллары на рубли.");
            Console.Write("Ваш выбор: ");
            desiredOperation = Console.ReadLine();
            switch (desiredOperation)
            {
                case "1":
                    Console.WriteLine("Обмен рублей на доллары.");
                    Console.WriteLine("Сколько вы хотите обменять?");
                    exchangeCurrencyCount= Convert.ToSingle(Console.ReadLine());
                    if (rubInWallet >= exchangeCurrencyCount)
                    {
                        rubInWallet -= exchangeCurrencyCount;
                        usdInWallet += exchangeCurrencyCount / rubToUsd;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимое количество рублей.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Обмен долларов на рубли.");
                    Console.WriteLine("Сколько вы хотите обменять?");
                    exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                    if (usdInWallet >= exchangeCurrencyCount)
                    {
                        usdInWallet -= exchangeCurrencyCount;
                        rubInWallet += exchangeCurrencyCount * usdToRub;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимое количество долларов.");
                    }
                    break;
                default:
                    Console.WriteLine("Выбрана неверная операция.");
                    break;
            }
            Console.WriteLine($"Ваш баланс: {rubInWallet} рублей, {usdInWallet} долларов.");
        }
    }
}
