using System;

namespace AlmostEven
{
    public class Challenge
    {
        /**
         *      In this challenge,you will write a function to
         *      divide an integer into a number of even parts,
         *      which will be returned in a result array. Summing
         *      the integers in this result array will produce the
         *      original number.
         *
         *      Intermediate Difficulty
         *      Estimated 30 minutes
         */
        public static int[] SplitInteger(int num, int parts)
        {
            int[] partitions = new int[parts];
            int size = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(num / parts)));
            int remainder = num % parts;
            for (int i = 0; i < partitions.Length; i++)
            {
                partitions[i] = size;
            }

            for (int i = 0; i < remainder; i++)
            {
                partitions[partitions.Length - 1 - i] += 1;
            }

            return partitions;
        }

    }
}
