using System;
using System.Text;

namespace Initialize
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fullName = CompressSpaces(Console.ReadLine().Trim());

            var names = fullName.Split(' ');

            foreach (string name in names)
            {
                var trimmedName = name.Trim();
                var initial = trimmedName[0];
                Console.Write(initial);
                Console.Write(".");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();
        }

        private static string CompressSpaces(string inputStr)
        {
            var str = new StringBuilder();
            var isFirstSpace = true;

            for (int i = 0; i < inputStr.Length; i++)
            {
                var c = inputStr[i].ToString();
                if (!string.IsNullOrWhiteSpace(c))
                {
                    str.Append(c);
                    isFirstSpace = true;
                }
                else if (string.IsNullOrWhiteSpace(c) && isFirstSpace)
                {
                    str.Append(c);
                    isFirstSpace = false;
                }

            }
            return str.ToString();
        }
    }
}
