using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_07_24Work4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerHealth = 100;
            int playerDamage = 15;
            int enemyHealth = 100;
            int enemyDamage = 15;

            while (playerHealth>0 && enemyHealth>0)
            {
                playerHealth -= enemyDamage;
                enemyHealth -= playerDamage;

                Console.WriteLine(playerHealth + " игрок.");
                Console.WriteLine(enemyHealth + " враг.");
            }

            if (playerHealth <= 0 && enemyHealth<=0)
            {
                Console.WriteLine("Ничья.");
            }
            else if(enemyHealth<=0){
                Console.WriteLine("Победа игрока.");
            }
            else if(playerHealth<=0)
            {
                Console.WriteLine("Победа врага.");
            }
        }
    }
}
