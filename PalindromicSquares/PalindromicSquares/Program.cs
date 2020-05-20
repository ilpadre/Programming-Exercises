using System;

namespace PalindromicSquares
{
    public class Program
    {
        public static void Main(string[] args)
        {
             FindPSquares(20000);
        }

        public static void FindPSquares(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (IsPSquare(i))
                {
                    Console.WriteLine($"{i}: {i*i}");
                }
            }
        }

        public static bool IsPSquare(int n)
        {
            long[] digits = ParseDigits(n*n);
            bool isPalindrome = true;
            int i=0, j=digits.Length-1;
            do
            {
                isPalindrome = digits[i++] == digits[j--];

            } while (i <= j && isPalindrome);

            
            return isPalindrome;
        }

        public static long[] ParseDigits(long n)
        {
            long numDigits = (long)(Math.Log10(n));
            long[] digits = new long[++numDigits];
            long divisor = 10L;
            long temp = n;
            for (long i = numDigits - 1; i >= 0; i--)
            {
                var r = temp / divisor;
                digits[i] = temp - divisor*r;
                temp = r;
            }
            return digits;
        }
    }
}
