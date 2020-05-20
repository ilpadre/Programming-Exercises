
using System;
using System.Text;

namespace FizzBuzz
{
    public class Challenge
    {
        public static string FizzBuzz(int n)
        {
            var fizzBuzz = false;
            var outString = new StringBuilder();

            if (n < 1)
            {
                return "Invalid";
            }
            for (int i = 1; i <= n; i++)
            {
                if (i%3==0)
                {
                    fizzBuzz = true;
                    outString.Append("Fizz");
                    if (i%5==0)
                    {
                        outString.Append("Buzz");
                    }
                    outString.Append("\n");
                }
                else if (i%5==0)
                {
                    fizzBuzz = true;
                    outString.Append("Buzz");
                    outString.Append("\n");
                }
                if (!fizzBuzz)
                {
                    outString.Append(i);
                    outString.Append("\n");
                }
                fizzBuzz = false;
            }
            outString.Remove(outString.Length-1, 1);
            return outString.ToString();
        }
    }
}
