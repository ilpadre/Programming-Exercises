using System;
using System.Linq;

namespace MergeStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestCandidate();
            Console.WriteLine(MyMergeStrings("abc", "defghijk"));
        }

        public static void TestCandidate()
        {
            Console.WriteLine(MergeStrings("abc", "defghijk"));
            Console.WriteLine(MergeStrings("abc", ""));
            Console.WriteLine(MergeStrings("", "defghijk"));
            Console.WriteLine(MergeStrings("ace", "bdf"));

        }

        public static string MergeStrings(string a, string b)
        {
            int shortestLength = a.Length > b.Length ? b.Length : a.Length;
            string merger = "";

            for (int i = 0; i < shortestLength; i++)
                merger += String.Join("", a[i], b[i]);

            if (shortestLength < b.Length)
                merger += b.Substring(shortestLength, b.Length - shortestLength);
            else if (shortestLength < a.Length)
                merger += a.Substring(shortestLength, a.Length - shortestLength);

            return merger;
        }

        public static string MyMergeStrings(string a, string b)
        {
            String mergedString = "";
            int i = 0;
            // parse the string a/b and for each letter in a/b, add the corresponding letter in b/a//
            // Also additional check if either string is larger than the other//
            for (; i < a.Length && i < b.Length; i++)
            {
                mergedString += a.ElementAt(i) + "" + b.ElementAt(i);
            }
            for (; i < a.Length; i++)
            {
                mergedString += a.ElementAt(i);
            }
            for (; i < b.Length; i++)
            {
                mergedString += b.ElementAt(i);
            }
            Console.WriteLine(i);
            return mergedString;

        }

    }
}
