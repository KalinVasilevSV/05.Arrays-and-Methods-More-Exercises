using System;

namespace _02.Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            int nCommands = int.Parse(Console.ReadLine());

            for (int command = 1; command <= nCommands; command++)
            {
                string[] currentCommand = Console.ReadLine().Split();

                switch(currentCommand[0])
                {
                    case "Distinct": arr=RemoveUndistinct(arr);
                        break;
                    case "Reverse": ReverseArray(arr);
                        break;
                    case "Replace": ReplaceElement(arr,int.Parse(currentCommand[1]), currentCommand[2]);
                        break;

                    default:break;
                }
            }

            PrintArray(arr);

        }

        //Method for removing undistinct elements of an Array
        private static string[] RemoveUndistinct(string[] arr)
        {
            string newSeries = string.Empty;

            for (int element = 0; element < arr.Length; element++)
            {
                for (int i = element+1; i < arr.Length; i++)
                {
                    if (arr[element] == arr[i])
                        arr[i] = null;
                }
            }

            foreach (string element in arr)
            {
                if (element != null)
                    newSeries += element + " ";
            }

            return newSeries.Trim().Split();
        }

        // Array Reversing Method
        private static void ReverseArray(string[] arr)
        {
            string elementHolder = string.Empty;

            for (int elementLeft = 0, elementRight=arr.Length-1; elementLeft < arr.Length/2; elementLeft++, elementRight--)
            {
                elementHolder = arr[elementLeft];
                arr[elementLeft] = arr[elementRight];
                arr[elementRight] = elementHolder;
            }
        }

        //Method replaciing elements of an Array
        private static void ReplaceElement(string[] arr, int element, string replacement)
        {
            arr[element] = replacement;
        }

        //Method printing an Array
        private static void PrintArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i != arr.Length-1) Console.Write(", ");
            }
        }

    }
}
