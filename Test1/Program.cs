using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N");
            int n = Convert.ToInt32(Console.ReadLine());
            int outputCounter = 0;
            int number = 0;
            while (outputCounter != n)
            {
                if (number % NumberOfDigits(number) == 0)
                {
                    Console.Write(number + " ");
                    outputCounter++;
                }
                number++;
            }

        }
        public static int NumberOfDigits(int input)
        {
            if (input == 0)
            {
                return 1;
            }
            int output = 0;
            while (input != 0)
            {
                input /= 10;
                output++;
            }
            return output;
        }
    }
}
