using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_07_24Work2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int triesCount = 5;
            string password = "123456";
            string userInput;
            for (int i=0; i<triesCount; i++)
            {
                Console.WriteLine("Введите пароль: ");
                userInput = Console.ReadLine();
                if (userInput == password)
                {
                    Console.WriteLine("Секретики.");
                    break;
                }
                else
                {
                    Console.WriteLine("Введен неверный пароль.");
                    Console.WriteLine("У вас осталось попыток: " + (triesCount - i - 1));
                }
            }
        }
    }
}
