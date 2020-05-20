using System;
using System.Numerics;

namespace SquareNumber
{
    public class Challenge
    {
        public static bool IsSquare(int n)
        {
            int root = (int)Math.Sqrt(n);
            if (root*root == n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
