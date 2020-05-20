using System;

namespace PrimeString
{
    public class Challenge
    {
        public static bool PrimeString(string s)
        {
            var isPrime = true;
            var substring = string.Empty;
            if (s.Length > 1)
            {
                for (int i = 0; i < s.Length / 2; i++)
                {
                    substring += s[i].ToString();
                    var patternSize = substring.Length;
                    for (int j = patternSize; j < s.Length; j += patternSize)
                    {
                        var testString = s.Substring(j, patternSize);
                        if (!testString.Equals(substring))
                        {
                            isPrime = true;
                            break;
                        }
                        isPrime = false;
                    }
                    if (!isPrime)
                    {
                        break;
                    }
                }
            }
            return isPrime;
        }
    }
}
