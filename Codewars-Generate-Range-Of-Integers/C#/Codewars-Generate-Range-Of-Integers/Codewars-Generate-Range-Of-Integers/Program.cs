using System;
using System.Collections;
using System.Collections.Generic;

namespace Codewars_Generate_Range_Of_Integers
{
    /*
     * 
        Implement a function named

            generateRange(2, 10, 2) // should return array of [2,4,6,8,10]
            generateRange(1, 10, 3) // should return array of [1,4,7,10]
 
        which takes three arguments and generates a range of integers from min to max, 
        with given step. The first is minimum value, second is maximum of range and the third is step.
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            var range1 = GenerateRange(2, 10, 2);
            var range2 = GenerateRange(1, 10, 3);
            var range3 = GenerateRange(1, 31, 6);
            PrintRange(range1);
            PrintRange(range2);
            PrintRange(range3);
            
            Console.ReadLine();
        }

        public static int[] GenerateRange(int start, int end, int interval)
        {
            var range = new List<int>();
            for (int i = start; i <= end; i += interval)
            {
                range.Add(i);
            }
            return range.ToArray();
        }

        private static void PrintRange(int[] range)
        {
            for (int i = 0; i < range.Length; i++)
            {
                System.Console.Write($" {range[i]} ");
            }

            System.Console.WriteLine();
        }
    }
}
