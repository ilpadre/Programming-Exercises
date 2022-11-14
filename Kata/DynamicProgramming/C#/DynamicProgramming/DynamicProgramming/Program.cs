using System;

namespace DynamicProgramming
{

    /*
     * Results for Fibonacci:
     *
     *
     * Recursive Algorithm
       
       10th Fib Num: 55
       Number of calls: 177
       
       20th Fib Num: 6765
       Number of calls: 21,891
       
       25th Fib Num: 75,025
       Number of calls: 242,785
       
       30th Fib Num: 832,040
       Number of calls: 2,692,537
       
       35th Fib Num: 9,227,465
       Number of calls: 29,860,703
       
       40th Fib Num: 102,334,155
       Number of calls: 331,160,281
       
       
    
       Dynamic Algorithm
       
       Called FibDynamic(10)
       10th Fib Num: 55
       Number of calls: 1
       Number of additions: 9
       
       Called FibDynamic(20)
       20th Fib Num: 6765
       Number of calls: 1
       Number of additions: 19
       
       Called FibDynamic(25)
       25th Fib Num: 75,025
       Number of calls: 1
       Number of additions: 24
       
       Called FibDynamic(40)
       40th Fib Num: 102,334,155
       Number of calls: 1
       Number of additions: 39
       
       Called FibDynamic(100000)
       100000th Fib Num: 873,876,091
       Number of calls: 1
       Number of additions: 99999
       
     */
    public class Program
    {
        public static int numCalls = 0;
        public static int numAdditions = 0;

        public static void Main(string[] args)
        {
            RunFibonacci();
;
        }

        private static void RunFibonacci()
        {
            Console.WriteLine("Recursive Algorithm");
            Console.WriteLine();
            int fibNum = FibRecursive(10);
            Console.WriteLine($"10th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            numCalls = 0;
            Console.WriteLine();

            fibNum = FibRecursive(20);
            Console.WriteLine($"20th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            numCalls = 0;
            Console.WriteLine();

            fibNum = FibRecursive(25);
            Console.WriteLine($"25th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            numCalls = 0;
            Console.WriteLine();

            fibNum = FibRecursive(30);
            Console.WriteLine($"30th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            numCalls = 0;
            Console.WriteLine();

            fibNum = FibRecursive(35);
            Console.WriteLine($"35th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            numCalls = 0;
            Console.WriteLine();

            fibNum = FibRecursive(40);
            Console.WriteLine($"40th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            numCalls = 0;
            Console.WriteLine();

            Console.WriteLine("Dynamic Algorithm");
            Console.WriteLine();

            fibNum = FibDynamic(10);
            Console.WriteLine($"10th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            Console.WriteLine($"Number of additions: {numAdditions}");
            numCalls = 0;
            numAdditions = 0;
            Console.WriteLine();

            fibNum = FibDynamic(20);
            Console.WriteLine($"20th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            Console.WriteLine($"Number of additions: {numAdditions}");
            numCalls = 0;
            numAdditions = 0;
            Console.WriteLine();

            fibNum = FibDynamic(25);
            Console.WriteLine($"25th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            Console.WriteLine($"Number of additions: {numAdditions}");
            numCalls = 0;
            numAdditions = 0;
            Console.WriteLine();

            fibNum = FibDynamic(40);
            Console.WriteLine($"40th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            Console.WriteLine($"Number of additions: {numAdditions}");
            numCalls = 0;
            numAdditions = 0;
            Console.WriteLine();

            fibNum = FibDynamic(100000);
            Console.WriteLine($"100000th Fib Num: {fibNum}");
            Console.WriteLine($"Number of calls: {numCalls}");
            Console.WriteLine($"Number of additions: {numAdditions}");
            numCalls = 0;
            numAdditions = 0;
            Console.WriteLine();

        }

        public static int MinCoinsRecursive(int[] coins, int m, int amount)
        {
            if (amount == 0) return 0;

            // Initialize result
            int res = int.MaxValue;

            // Try every coin that has
            // smaller value than V
            for (int i = 0; i < m; i++)
            {
                if (coins[i] <= amount)
                {
                    int sub_res = MinCoinsRecursive(coins, m,
                        amount - coins[i]);

                    // Check for INT_MAX to
                    // avoid overflow and see
                    // if result can minimized
                    if (sub_res != int.MaxValue &&
                        sub_res + 1 < res)
                        res = sub_res + 1;
                }
            }
            return res;
        }

        public static int MinCoinsDynamic(int[] coins, int m, int amount)
        {
            // table[i] will be storing
            // the minimum number of coins
            // required for i value. So
            // table[V] will have result
            int[] table = new int[amount + 1];

            // Base case (If given
            // value V is 0)
            table[0] = 0;

            // Initialize all table
            // values as Infinite
            for (int i = 1; i <= amount; i++)
                table[i] = int.MaxValue;

            // Compute minimum coins
            // required for all
            // values from 1 to amount
            for (int i = 1; i <= amount; i++)
            {
                // Go through all coins
                // smaller than i
                for (int j = 0; j < m; j++)
                    if (coins[j] <= i)
                    {
                        int sub_res = table[i - coins[j]];
                        if (sub_res != int.MaxValue &&
                            sub_res + 1 < table[i])
                            table[i] = sub_res + 1;
                    }
            }

            return table[amount];
        }

        public static int FibRecursive(int fibNum)
        {
            numCalls++;
            //Console.WriteLine($"Called FibRecursive({fibNum})");
            switch (fibNum)
            {
                case 0: return 0;
                case 1: return 1;
                default: return FibRecursive(fibNum - 1) + FibRecursive(fibNum - 2);
            }
        }

        public static int FibDynamic(int fibNum)
        {
            numCalls++;
            Console.WriteLine($"Called FibDynamic({fibNum})");
            switch (fibNum)
            {
                case 0: return 0;
                case 1: return 1;
                default:
                    int nthFib = 0;
                    int nthFibMinusTwo = 0;
                    int nthFibMinusOne = 1;
                    for (int i = 2; i <= fibNum; i++)
                    {
                        nthFib = nthFibMinusOne + nthFibMinusTwo;
                        numAdditions++;
                        nthFibMinusTwo = nthFibMinusOne;
                        nthFibMinusOne = nthFib;
                    }

                    return nthFib;
            }
        }

    }

}
