using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Project
{
    public class Program
    {
        class RabbitPair
        {
            public int id;
            public int age;

            public RabbitPair(int pairId, int pairAge)
            {
                id = pairId;
                age = pairAge;
            }
        }


        public static void Main(string[] args)
        {
            Console.WriteLine(rabbitPopulation(1));
            Console.WriteLine(rabbitPopulation(2));
            Console.WriteLine(rabbitPopulation(3));
            Console.WriteLine(rabbitPopulation(4));
            Console.WriteLine(rabbitPopulation(5));
            Console.WriteLine(rabbitPopulation(6));
            Console.WriteLine(rabbitPopulation(7));
            Console.WriteLine(rabbitPopulation(8));
            Console.WriteLine(rabbitPopulation(9));
            Console.WriteLine(rabbitPopulation(10));
            Console.WriteLine(rabbitPopulation(11));
            Console.WriteLine(rabbitPopulation(12));


        }

        public static int rabbitPopulation(int generations)
        {
            int pairId = 0;

            List<RabbitPair> pairs = new List<RabbitPair>();
            pairs.Add(new RabbitPair(++pairId, 0));

            for (int i = 0; i < generations; i++)
            {
                List<RabbitPair> newBorns = new List<RabbitPair>();
                foreach (RabbitPair pair in pairs)
                {
                    if (pair.age > 0)
                    {
                        newBorns.Add(new RabbitPair(++pairId, 0));
                    }

                    pair.age++;
                }

                foreach (RabbitPair newBorn in newBorns)
                {
                    pairs.Add(newBorn);
                }

            }

            return pairs.Count;
        }
    }
}
