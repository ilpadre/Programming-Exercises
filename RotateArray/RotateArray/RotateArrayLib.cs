using System;

namespace RotateArray
{
    public class RotateArrayLib
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int[] Rotate(int[] arr)
        {
            int lengthOfArray = arr.Length;
            int[] copy = new int[lengthOfArray];
            for (int i = 0; i < lengthOfArray; i++)
            {
                copy[(i + 1) % lengthOfArray] = arr[i];
            }
            return copy;
        }

        public static int[] RotateN(int[] arr, int times)
        {
            int lengthOfArray = arr.Length;
            int[] copy = new int[arr.Length];
            for (int i = 0; i < lengthOfArray; i++)
            {
                copy[(i + times) % lengthOfArray] = arr[i];
            }
            return copy;
        }
    }
}
