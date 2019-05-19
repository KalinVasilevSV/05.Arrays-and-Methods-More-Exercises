using System;
using System.Linq;

namespace _04.Grab_and_Go
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            int lastOccuranceIndex = FindLastOccurance(arr,n);

            long? sumTillLastOccuranceN =SumTillLastOccuranceN(arr, lastOccuranceIndex);

            if (sumTillLastOccuranceN==null)
            {
                Console.WriteLine("No occurrences were found!");
            }
            else
            {
                Console.WriteLine(sumTillLastOccuranceN);
            }
        }

        static int FindLastOccurance(int[] arr, int n)
        {
            int lastOccuranceIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == n) lastOccuranceIndex = i;
            }

            return lastOccuranceIndex;
        }

        static long? SumTillLastOccuranceN(int[] arr, int lastOccuranceIndex)
        {       
            try
            {
                if (lastOccuranceIndex < 0) throw new IndexOutOfRangeException();

                long sumTillLastOccuranceN = 0;

                for (int i = 0; i < lastOccuranceIndex; i++)
                {
                    sumTillLastOccuranceN += arr[i];
                }

                return sumTillLastOccuranceN;
            }
            catch(IndexOutOfRangeException)
            {
                return null;
            }
        }
    }
}
