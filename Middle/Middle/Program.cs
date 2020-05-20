using System;

namespace Middle
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(Test("A", "A"));
            Console.WriteLine(Test("b", "b"));
            Console.WriteLine(Test("1", "1"));


            Console.WriteLine(Test("ab", "ab"));
            Console.WriteLine(Test("Of", "Of"));
            Console.WriteLine(Test("42", "42"));

            Console.WriteLine(Test("dd", "middle"));
            Console.WriteLine(Test("yb", "turkeyburger"));
            Console.WriteLine(Test("pp", "yippppppeeee"));


            Console.WriteLine(Test("t", "testing"));
            Console.WriteLine(Test("i", "smile"));
            Console.WriteLine(Test("E", "CHEEEEEEEEESE"));




        }



        public static string GetMiddle(string s)
        {
            //Code goes here!
            var len = s.Length;
            if (len <= 2)
            {
                return s;
            }
            else if (len % 2 == 0)
            {
                return s.Substring((len/2)-1, 2);
            }
            else
            {
                return s.Substring(len/2, 1);
            }
        }

        public static bool Test(string expected, string input)
        {
            var actual = GetMiddle(input);
            if (expected == actual)
                return true;
            return false;
        }

    }


}
