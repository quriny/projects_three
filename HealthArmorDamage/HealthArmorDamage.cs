using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health;
            int armor;
            int damage;
            int percentConverter = 100;
            Console.Write("Введите количество здоровья: ");
            health = Convert.ToInt32(Console.ReadLine());            
            Console.Write("Введите количество брони: ");
            armor = Convert.ToInt32(Console.ReadLine());            
            Console.Write("Введите количество урона: ");
            damage = Convert.ToInt32(Console.ReadLine());
            health -= damage * armor / percentConverter;
            Console.WriteLine("Вам нанесли " + damage + " урона. У вас осталось " + health + " здоровья.");

        }
    }
}
