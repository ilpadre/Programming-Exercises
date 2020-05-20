using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace SpinningWords
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string SpinMyWords(string straight)
        {
            var spun = new StringBuilder();
            if (straight != string.Empty)
            {
                var words = straight.Split(' ');
                foreach (string word in words)
                {
                    string currentWord = word;
                    if (word.Length >= 5)
                    {
                        currentWord = ReverseString(word);
                    }

                    spun.Append(currentWord).Append(' ');
                }

                spun.Remove(spun.Length-1, 1);
            }
            return spun.ToString();
        }

        public static string ReverseString(string forward)
        {
            var backward = new StringBuilder();
            for (int i = forward.Length - 1; i >= 0; i--)
            {
                backward.Append(forward[i]);
            }
            return backward.ToString();
        }

        public static string SpinMyWordsLinq(string words)
        {
            return string.Join(" ",words.Split(' ')
                .Select(w => w.Length < 5 ? w : string.Join("", w.Reverse())));

        }
    }
}
