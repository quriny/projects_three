using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_07_24Work2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fighter[] fighters =
            {
                new Fighter("Джон", 500, 50, 0),
                new Fighter("Марк", 250, 25, 20),
                new Fighter("Алекс", 150, 100, 10),
                new Fighter("Джек", 300, 75, 5)
            };
            int fighterNumber;
            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write(i + 1 + " ");
                fighters[i].ShowStats();
            }
            Console.WriteLine("\n** " + new string('-', 25) + " **");
            Console.Write("\nВыберите номер первого бойца: ");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter firstFighter = fighters[fighterNumber];
            Console.Write("\nВыберите номер второго бойца: ");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter secondFighter = fighters[fighterNumber];
            Console.WriteLine("\n** " + new string('-', 25) + " **");
            while (firstFighter.Health>0 && secondFighter.Health > 0)
            {
                firstFighter.TakeDamage(secondFighter.Damage);
                secondFighter.TakeDamage(firstFighter.Damage);
                firstFighter.ShowCurrentHealth();
                secondFighter.ShowCurrentHealth();

            }

        }
    }
    class Fighter
    {
        private string name;
        private int health;
        private int damage;
        private int armor;
        public int Health
        {
            get
            {
                return health;
            }
        }
        public int Damage
        {
            get
            {
                return damage;
            }
        }
        public Fighter(string name, int health, int damage, int armor)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.armor = armor;
        }
        public void ShowStats()
        {
            Console.WriteLine($"Боец - {name}, здоровье: {health}, наносимый урок: {damage}, броня: {armor}");
        }
        public void ShowCurrentHealth()
        {
            Console.WriteLine($"{name} здоровье: {health}");
        }
        public void TakeDamage(int damage)
        {
            health -= damage - armor;
        }
    }
}
