using System;
using System.Linq;

namespace _01.Array_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxElement = int.MinValue;
            int minElement = int.MaxValue;

            long sumElements = 0;
            double avgElements = default(double);

            foreach(int num in arr)
            {
                if (num > maxElement) maxElement = num;
                if (num < minElement) minElement = num;

                sumElements += num;
            }

            avgElements = ((double)sumElements) / arr.Length;

            Console.WriteLine($"Min = {minElement}");
            Console.WriteLine($"Max = {maxElement}");
            Console.WriteLine($"Sum = {sumElements}");
            Console.WriteLine($"Average = {avgElements}");
        }
    }
}
