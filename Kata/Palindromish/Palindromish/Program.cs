using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.VisualBasic;

namespace Palindromish
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<String> originalWords = ReadWords();

            List<String> nineCharacterWords = originalWords.Where(w => w.Length == 9).ToList();

            List<String> matchingWords = nineCharacterWords.Where(w => IsMatchBasic(w)).ToList();

            string pattern = "fred";
            List<String> matchingWordsForFred = originalWords.Where(w => IsMatchEnancement2(w, pattern)).ToList();

            pattern = "fart";
            List<String> matchingWordsForApi = originalWords.Where(w => IsMatchEnancement2(w, pattern)).ToList();


        }

        #region BasicRequirements

        public static bool IsMatchBasic(string word)
        {
            // Original requirement: 9-letter word with 'eli' in the center
            string lcWord = word.ToLower();
            bool match = false;
            string pattern = "eli";
            if (lcWord.Length == 9)
            {
                string eli = lcWord.Substring(3, 3);
                if (eli.Equals("eli"))
                {
                    string prefix = lcWord.Substring(0, 3);
                    string suffix = lcWord.Substring(6, 3);
                    string reversedSuffix = StringReverse(suffix);
                    if (prefix.Equals(reversedSuffix))
                    {
                        match = true;
                    }
                }
            }

            return match;
        }

        #endregion


        #region Enhancement1

        public static bool IsMatchEnancement1(string word)
        {
            // Enhancement 1: removes 9-letter requirement, but keeps 'eli' in the center

            string pattern = "eli";

            if (word.Length < 3)
            {
                return false;
            }
            else if (word.Length == 3)
            {
                return word.Equals(pattern);
            }
            else if (word.Length == 4)
            {
                return false;
            }
            string lcWord = word.ToLower();
            bool match = false;

            int index = lcWord.IndexOf(pattern);
            if (index > 0)
            {
                int beginPatt = index;
                int endPatt = index + 2;
                string prefix = lcWord.Substring(0, beginPatt);
                string suffix = lcWord.Substring(endPatt + 1);
                if (prefix.Length == suffix.Length)
                {
                    if (prefix.Equals(StringReverse(suffix)))
                    {
                        match = true;
                    }
                }
            }   

            return match;
        }


        #endregion

        #region Enhancement2

        public static bool IsMatchEnancement2(string word, string pattern)
        {
            // Enhancement 1: removes 9-letter requirement and hardcoded pattern.
            int patternLen = pattern.Length;
            if (word.Length < patternLen)
            {
                return false;
            }
            else if (word.Length == patternLen)
            {
                return word.Equals(pattern);
            }
            else if (word.Length < patternLen + 2)
            {
                return false;
            }
            string lcWord = word.ToLower();
            bool match = false;

            int index = lcWord.IndexOf(pattern);
            if (index > 0)
            {
                int beginPatt = index;
                int endPatt = index + pattern.Length-1;
                string prefix = lcWord.Substring(0, beginPatt);
                string suffix = lcWord.Substring(endPatt + 1);
                if (prefix.Length == suffix.Length)
                {
                    if (prefix.Equals(StringReverse(suffix)))
                    {
                        match = true;
                    }
                }
            }

            return match;
        }


        #endregion
        private static string StringReverse(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length; i > 0; i--)
            {
                sb.Append(s[i - 1]);
            }

            return sb.ToString();
        }

        private static List<string> ReadWords()
        {
            List<String> words = new List<String>();
            string word;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"words.txt");
            while ((word = file.ReadLine()) != null)
            {
                words.Add(word);
            }

            return words;
        }
    }
}
