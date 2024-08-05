using System;

namespace PriceCalculation
{
    class Program
    {
        public static void CalcPrices(double inputPriceWithNDS, int procNDS, out double correctedPriceWithNDS, out double correctedPriceWithoutNDS)
        {
            double minDifference = double.MaxValue;
            correctedPriceWithNDS = 0;
            correctedPriceWithoutNDS = 0;

            for (double priceWithoutNDS = 0.01; priceWithoutNDS <= inputPriceWithNDS; priceWithoutNDS += 0.01)
            {
                double priceWithNDS = priceWithoutNDS * (1 + procNDS / 100.0);
                priceWithNDS = Math.Floor(priceWithNDS * 100) / 100.0;  // Убираем дробную часть, оставляя 2 знака после запятой

                double difference = Math.Abs(priceWithNDS - inputPriceWithNDS);
                if (difference < minDifference)
                {
                    minDifference = difference;
                    correctedPriceWithNDS = priceWithNDS;
                    correctedPriceWithoutNDS = priceWithoutNDS;
                }
            }
        }

        static void Main(string[] args)
        {
            CalcPrices(1.81, 20, out double correctedPriceWithNDS1, out double correctedPriceWithoutNDS1);
            Console.WriteLine($"InputPriceWithNDS: 1.81, ProcNDS: 20");
            Console.WriteLine($"CorrectedPriceWithNDS: {correctedPriceWithNDS1}");
            Console.WriteLine($"CorrectedPriceWithoutNDS: {correctedPriceWithoutNDS1}");
            Console.WriteLine();

            CalcPrices(1.81, 18, out double correctedPriceWithNDS2, out double correctedPriceWithoutNDS2);
            Console.WriteLine($"InputPriceWithNDS: 1.81, ProcNDS: 18");
            Console.WriteLine($"CorrectedPriceWithNDS: {correctedPriceWithNDS2}");
            Console.WriteLine($"CorrectedPriceWithoutNDS: {correctedPriceWithoutNDS2}");
            Console.WriteLine();

            CalcPrices(5.05, 27, out double correctedPriceWithNDS3, out double correctedPriceWithoutNDS3);
            Console.WriteLine($"InputPriceWithNDS: 5.05, ProcNDS: 27");
            Console.WriteLine($"CorrectedPriceWithNDS: {correctedPriceWithNDS3}");
            Console.WriteLine($"CorrectedPriceWithoutNDS: {correctedPriceWithoutNDS3}");
        }
    }
}
