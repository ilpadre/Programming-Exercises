using System;
using System.Collections.Generic;
using System.Dynamic;


namespace BinarySearch
{
    public class Program
    {
        public static int[] inputArray =
        {
            10, 12, 13, 13, 14, 14, 14, 15, 18, 20, 21, 21, 22, 22, 22, 22, 23, 24, 25, 28, 30, 30, 32, 33, 33, 34, 35,
            35, 35, 36, 36, 37, 39, 40, 42, 44, 46, 47, 47, 47, 48, 49, 49, 49, 50, 53, 54, 54, 55, 56, 58, 58, 58, 58,
            59, 59, 62, 62, 62, 62, 63, 64, 65, 66, 66, 68, 68, 68, 69, 71, 71, 75, 77, 78, 79, 81, 82, 86, 87, 87, 87,
            89, 89, 89, 89, 90, 92, 92, 93, 93, 96, 96, 96, 96, 98, 98, 99, 99, 99, 99
        };

        //public static int[] inputArray { get; set; }

        public static void Main(string[] args)
        {
            Console.WriteLine("Ubiquitous Binary Search!");
            Console.WriteLine();
            PrintArray(inputArray);
            Console.WriteLine($"Search for 66; it appears at {BSearch(66)}");
            Console.WriteLine($"{inputArray[BSearch(66)]}");
            Console.WriteLine($"");
            Console.WriteLine();

            Console.WriteLine($"Search for 12; it appears at {BSearch(12)}");
            Console.WriteLine($"{inputArray[BSearch(12)]}");
            Console.WriteLine();

            Console.WriteLine($"Search for 12; it appears at {BSearch(12)}");
            Console.WriteLine($"{inputArray[BSearch(12)]}");
            Console.WriteLine();

            Console.WriteLine($"Search for 67; it appears at {BSearch(67)}");
            Console.WriteLine();
        }

        public static int BSearch(int numToFind)
        {
            int pos = -1;

            if (inputArray.Length != 0)
            {

                int lower = 0;
                int upper = inputArray.Length-1;
                do
                {
                    int middle = (upper + lower) / 2;

                    if (numToFind < inputArray[middle])
                    {
                        upper = --middle;
                    } 
                    else if (inputArray[middle] == numToFind)
                    {
                        pos = middle;
                        break;
                    } 
                    else if (numToFind > inputArray[middle])
                    {
                        lower = ++middle;
                    }

                } while (lower <= upper);
            }

            return pos;
        }

        public static int BSearchReturnFirst(int numToFind)
        {
            int index = BSearch(numToFind);
            while (index >= 0 && index < inputArray.Length && inputArray[index] == numToFind)
            {
                if ((index-1 >= 0 && inputArray[index - 1] == numToFind))
                {
                    index--;
                }
                else
                {
                    break;
                }
            };
            return index;
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}, ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}