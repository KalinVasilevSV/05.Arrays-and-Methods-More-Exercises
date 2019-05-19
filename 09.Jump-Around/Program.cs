using System;
using System.Linq;

namespace _09.Jump_Around
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

            Console.WriteLine(JumpAround(arr));

        }

        static int JumpAround(int[] arr)
        {
            int step = 0;
            int sum = 0;

            while (true)
            {
                sum += arr[step];

                try
                {
                    if ((step + arr[step]) >= arr.Length) throw new MoveRightIndexException();
                    step += arr[step];

                }
                catch (MoveRightIndexException)
                {
                    try
                    {
                        if ((step - arr[step]) < 0) throw new MoveLeftIndexException();
                        step -= arr[step];
                    }
                    catch (MoveLeftIndexException)
                    {
                        break;
                    }
                }

            }

            return sum;
        }
    }

    class MoveRightIndexException : Exception { }
    class MoveLeftIndexException : Exception { }

}
