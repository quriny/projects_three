﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_fights
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            float health1 = rand.Next(90, 100);
            int damage1 = rand.Next(5, 20);
            int armor1 = rand.Next(25, 65);

            float health2 = rand.Next(80, 150);
            int damage2 = rand.Next(20, 40);
            int armor2 = rand.Next(65, 100);

            Console.WriteLine($"Гладиатор 1 - {health1} здоровья, {damage1} наносимый урок, {armor1} броня.");
            Console.WriteLine($"Гладиатор 2 - {health2} здоровья, {damage2} наносимый урок, {armor2} броня.");

            while (health1 > 0 && health2 > 0)
            {
                health1 -= Convert.ToSingle(rand.Next(0, damage2 + 1)) / 100 * armor1;
                health2 -= Convert.ToSingle(rand.Next(0, damage1 + 1)) / 100 * armor2;

                Console.WriteLine("Здоровье гладиатора 1: " +  health1);
                Console.WriteLine("Здоровье гладиатора 2: " + health2);
            }

            if (health1<=0 && health2 <= 0)
            {
                Console.WriteLine("Ничья. Оба гладиатора погибли.");
            }
            else if (health1 <= 0)
            {
                Console.WriteLine("Гладиатор 1 пал.");
            }
            else if (health2 <= 0)
            {
                Console.WriteLine("Гладиатор 2 пал.");
            }
        }
    }
}
