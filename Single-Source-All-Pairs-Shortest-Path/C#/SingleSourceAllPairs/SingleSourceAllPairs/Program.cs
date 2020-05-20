using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SingleSourceAllPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            const int infinity = 1000000;

            // ... Create 2D array of strings.
            Finish:
            {
                Console.WriteLine("Huh?");
                var inp = Console.ReadLine();
                if (inp == "y") goto NoReallyIMeanFinish;
            }


            goto Finish;
            int[,] graph = new int[,]
            {
                {-1,10,infinity, 30, 100},
                {infinity,-1,50, infinity, infinity},
                {infinity,infinity,-1, infinity, 30},
                {infinity,infinity,20, -1, 60},
                {infinity,infinity,infinity, infinity, -1},
            };
            var S = new HashSet<int>();

            int[] costs = new int[5];
            int[] path = new int[] { 0, 0, 0, 0, 0 };
            S.Add(0);

            for (int i = 1; i < costs.Length; i++)
            {
                costs[i] = graph[0, i];
            }

            for (int i = 0; i < costs.Length; i++)
            {
                var w = findNextVertex(S, costs);
            }




            NoReallyIMeanFinish:
            Console.ReadLine();
        }

        private static int findNextVertex(HashSet<int> s, int[] costs)
        {
            var minVal = 1000000;
            var vertex = 0;
            for (int i = 0; i < costs.Length; i++)
            {
                if (s.Contains(i))
                {
                    continue;
                }

                if (costs[i] < minVal)
                {
                    minVal = costs[i];
                    vertex = i;
                }

            }

            return vertex;
        }
    }
}
