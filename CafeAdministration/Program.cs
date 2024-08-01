using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_07_24Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            Table[] tables = { new Table(1, 4), new Table(2, 8), new Table(3, 10) };
            while (isOpen)
            {
                Console.WriteLine("Администрирование кафе.\n");
                for (int i = 0; i < tables.Length; i++)
                {
                    tables[i].ShowInfo();
                }
                Console.Write("\nВведите номер стола: ");
                int wishTable = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("\nВведите количество мест для брони: ");
                int desiredPlaces = Convert.ToInt32(Console.ReadLine());
                bool isReservationCompleted = tables[wishTable].Reserve(desiredPlaces);
                if (isReservationCompleted)
                {
                    Console.WriteLine("Бронь прошла успешно!");
                }
                else
                {
                    Console.WriteLine("Бронь не прошла. Недостаточно мест.");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
    class Table
    {
        public int number;
        public int maxPaces;
        public int freePlaces;

        public Table(int number, int maxPlaces)
        {
            this.number = number;
            this.maxPaces = maxPlaces;
            freePlaces = maxPlaces;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Стол {number}. Свободно мест: {freePlaces} из {maxPaces}.");
        }
        public bool Reserve(int places)
        {
            if (freePlaces >= places)
            {
                freePlaces -= places;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
