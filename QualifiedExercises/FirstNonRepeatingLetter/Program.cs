using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstNonRepeatingLetter
{
    public class Program
    {
        static void Main(string[] args)
        {
            CandidateTest();
            MyTest();
        }

        public static void CandidateTest()
        {
            string expected;
            string actual;

            expected = "a";
            actual = FirstNonRepeatingLetter("a");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "t";
            actual = FirstNonRepeatingLetter("stress");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "e";
            actual = FirstNonRepeatingLetter("moonmen");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "e";
            actual = FirstNonRepeatingLetter("aaaaaaaaaaae");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "";
            actual = FirstNonRepeatingLetter("abba");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "";
            actual = FirstNonRepeatingLetter("aa");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "#";
            actual = FirstNonRepeatingLetter("~><#~><");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "w";
            actual = FirstNonRepeatingLetter("hello world, eh?");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "T";
            actual = FirstNonRepeatingLetter("sTreSS");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = ",";
            actual = FirstNonRepeatingLetter("Go hang a salami, I\'m a lasagna hog!");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

        }

        public static void MyTest()
        {
            string expected;
            string actual;

            expected = "a";
            actual = MyFirstNonRepeatingLetter("a");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "t";
            actual = MyFirstNonRepeatingLetter("stress");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "e";
            actual = MyFirstNonRepeatingLetter("moonmen");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "e";
            actual = MyFirstNonRepeatingLetter("aaaaaaaaaaae");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "";
            actual = MyFirstNonRepeatingLetter("abba");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "";
            actual = MyFirstNonRepeatingLetter("aa");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "#";
            actual = FirstNonRepeatingLetter("~><#~><");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "w";
            actual = MyFirstNonRepeatingLetter("hello world, eh?");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = "T";
            actual = MyFirstNonRepeatingLetter("sTreSS");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

            expected = ",";
            actual = MyFirstNonRepeatingLetter("Go hang a salami, I\'m a lasagna hog!");
            Console.WriteLine($"Expected = { expected }\t actual = { actual }");

        }



        public static string MyFirstNonRepeatingLetter(string str)
        {
            List<string> repeats = new List<string>();
            
            for (int i = 0; i <= str.Length-1; i++)
            {
                string a = str[i].ToString();
                string aLower = a.ToLower();
                if (repeats.Contains(aLower, StringComparer.OrdinalIgnoreCase))
                {
                    continue;
                }
                if (str.Substring(i+1, str.Length - i - 1).ToLower().Contains(aLower))
                {
                    repeats.Add(aLower);
                    continue;
                }
                return a;
            }
            return string.Empty;
        }

        public static string FirstNonRepeatingLetter(string str)
        {
            string nonRepeat = str;
            string Repeated = "";

            for (int i = 0; i < nonRepeat.Length; i++)
            {
                if (nonRepeat.IndexOf(nonRepeat[i].ToString(), StringComparison.InvariantCultureIgnoreCase) != i)
                    Repeated += str[i].ToString();
            }

            for (int i = 0; i < nonRepeat.Length;)
            {
                if (Repeated.IndexOf(nonRepeat[i].ToString(), StringComparison.InvariantCultureIgnoreCase) > -1)
                    nonRepeat = nonRepeat.Remove(i, 1);
                else
                    i++;
            }

            return String.IsNullOrEmpty(nonRepeat) ? "" : nonRepeat[0].ToString();
        }
    }
}
