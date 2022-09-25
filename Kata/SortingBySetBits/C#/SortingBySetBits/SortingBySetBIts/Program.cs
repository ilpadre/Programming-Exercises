using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingBySetBIts
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int CountSetBits(int num)
        {
            /*
             * Initialize count: = 0
   If integer n is not zero
      (a) Do bitwise & with (n-1)
 	and assign the value 
	back to n
          n: = n&(n-1)
      (b) Increment count by 1
      (c) go to step 2
   Else return count
             */
            int count = 0;

            while (num != 0)
            {
                num = num & (num - 1);
                count++;
            }
            return count;
        }

        public static int[] SortArrayBySetBits(int[] origArray)
        {
            int[] newArray = origArray;
            List<int> numList = origArray.ToList();
            numList.Sort(CompareBySetBits);

            return numList.ToArray();
        }

        public static int CompareBySetBits(int First, int Second)
        {
            int numBitsInFirst = CountSetBits(First);
            int numBitsInSecond = CountSetBits(Second);
            int returnVal = 0;
            if (numBitsInFirst > numBitsInSecond)
            {
                returnVal = 1;
            } else if (numBitsInFirst < numBitsInSecond)
            {
                returnVal = -1;
            }
            else
            {
                if (First > Second)
                {
                    returnVal = 1;
                } else if (First < Second)
                {
                    returnVal = -1;
                }
                else
                {
                    returnVal = 0;
                }

            }
            return returnVal;
        }

    }


}


/*

Description
Given an array of 32-bit integers, sort the array in ascending order of the number of set bits (the number of 1s in the binary representation). Note the solution must sort the array in place.

If two numbers have the same number of set bits, use the integer value to determine the order.

e.g. Given [7, 6, 15, 8]

7 has 3 set bits (000…0111)
6 has 2 set bits (000…0110)
15 has 4 set bits (000…1111)
8 has 1 set bit (000…1000)
Test data: [3, 8, 3, 6, 5, 7, 9, 1] => [1, 8, 3, 3, 5, 6, 9, 7]

Algorithms to count set bits
Simple Method: Loop through all bits in an integer, check if a bit is set and if it is, then increment the set bit count.

Brian Kernighan’s Algorithm: Subtracting 1 from a decimal number flips all the bits after the rightmost set bit(which is 1) including the rightmost set bit.

For example :

10 in binary is 00001010 
9 in binary is 00001001 
8 in binary is 00001000 
7 in binary is 00000111 
So if we subtract a number by 1 and do it bitwise & with itself (n & (n-1)), we unset the rightmost set bit. If we do n & (n-1) in a loop and count the number of times the loop executes, we get the set bit count. The beauty of this solution is the number of times it loops is equal to the number of set bits in a given integer.

Pseudocode
Initialize count: = 0
   If integer n is not zero
      (a) Do bitwise & with (n-1)
 	and assign the value 
	back to n
          n: = n&(n-1)
      (b) Increment count by 1
      (c) go to step 2
   Else return count

 */
