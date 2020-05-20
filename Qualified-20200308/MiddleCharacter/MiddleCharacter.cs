using System;

namespace MiddleCharacter
{
    public class Challenge
    {
        /**
         *      You are going to be given a word. Your job is to
         *      return the middle character of the word. If the
         *      word's length is odd, return the middle character.
         *      If the word's length is even, return the middle 2
         *      characters.
         *
         *      Basic Difficulty
         *      Estimated 10 minutes
         */
        public static string GetMiddle(string s)
        {
            string middleSubstring = string.Empty;
            int mid = s.Length / 2;
            if (s.Length % 2 == 0)
            {
                middleSubstring = s[mid - 1].ToString() + s[mid].ToString();
            }
            else
            {
                middleSubstring = s[mid].ToString();
            }
            return middleSubstring;
        }
    }
}
