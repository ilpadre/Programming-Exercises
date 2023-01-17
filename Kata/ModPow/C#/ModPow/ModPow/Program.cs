using System;

namespace ModPow
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }

        // compute a^b mod n
        public static double ModPow(double a, double b, double n)
        {
            double c = 1;
            double d = 0;
            do
            {
                d++;
                c = (a * c) % n;

            } while (d < b);

            return c;
        }

        public static double ModPowNaive(double a, double b, double n)
        {

            double x = Math.Pow(a, b);
            return x;
        }
    }
}
