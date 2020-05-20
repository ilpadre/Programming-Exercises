using System;

namespace ValidParentheses
{
    public class Challenge
    {
        public static bool ValidParentheses(string braces)
        {
            int left = 0, right = 0;
            bool valid = true;
            for (int i = 0; i < braces.Length; i++)
            {
                switch (braces[i])
                {
                    case '(':
                        left++;
                        break;
                    case ')':
                        right++;
                        break;
                    default:
                        System.Console.WriteLine($"Invalid input string: {braces}");
                        break;
                }
                if (right > left)
                {
                    valid = false;
                    break;
                }
            }
            if (left != right)
            {
                valid = false;
            }
            return valid;
        }
    }
}
