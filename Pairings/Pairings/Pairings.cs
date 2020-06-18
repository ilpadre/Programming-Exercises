using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Pairings
{
    public class Pairings
    {
        static void Main(string[] args)
        {
            // var pairGen = new PairingLib();
            // pairGen.GenerateCombinations(8);
            // pairGen.PrintCombinations();

            var pairGen = new PairingLib();
            pairGen.GeneratePairings("names.txt");

        }
    }

    public class PairingLib
    {
        private Dictionary<int, string> Participants { get; set; }
        private List<int[]> Combinations { get; set; }
        private List<int[]> Round { get; set; }
        private List<List<int[]>> Rounds { get; set; }

        private int numberOfParticipants { get; set; }
        private int pairingsPerRound { get; set; }
        private int numberOfRounds { get; set; }

        // Read in list of names
        // Get number of names = n
        // Map names to a number 1..n
        // Compute combinations of n choose k, with k=2
        // Compute pairings per round: ppr = n/2
        // Compute all possible rounds of ppr pairings
        // Print out all rounds in random order

        public PairingLib()
        {
            Participants = new Dictionary<int, string>();
            Combinations = new List<int[]>();
            Rounds = new List<List<int[]>>();
        }

        public void GeneratePairings(string fileOfNames)
        {
            ReadParticipantsFromFile(fileOfNames);
            GenerateCombinations(numberOfParticipants);
            CreateRounds();
            PrintRounds();

        }

        private void ReadParticipantsFromFile(string fileName)
        {
            string line;
            int countNames = 0;
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                Participants.Add(++countNames, line);
            }

            numberOfParticipants = countNames;
            pairingsPerRound = numberOfParticipants / 2;
            numberOfRounds = numberOfParticipants / pairingsPerRound;

            //PrintParticipants();
        }

        public void GenerateCombinations(int n)
        {
            int k = 2;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int[] arr2 = {i + 1, j + 1};
                    Combinations.Add(arr2);
                }
            }
        }

        public void CreateRounds()
        {
            int currentRound = 1;
            int currentPair = 1;
            List<int[]> round = new List<int[]>();
            for (var i = 0; i < Combinations.Count; i++)
            {
                var pair = Combinations[i];
                if (ParticipantsInRound(round, pair))
                {
                    continue;
                }

                if (PairingInRounds(pair))
                {
                    continue;
                }
                round.Add(pair);
                if (currentPair >= pairingsPerRound)
                {

                    Rounds.Add(round);
                    round = new List<int[]>();
                    currentPair = 1;
                }
                else
                {
                    currentPair++;
                }
            }
        }

        private bool ParticipantsInRound(List<int[]> round, int[] pair)
        {
            bool found = false;
            round.ForEach(x=>
            {
                if (x[0] == pair[0] || x[1] == pair[1])
                {
                    found =  true;
                }
                    
            });
            return found;
        }

        private bool PairingInRounds(int[] pairing)
        {
            bool found = false;
            Rounds.ForEach(x =>
            {
                x.ForEach(y =>
                {
                    if (y == pairing)
                    {
                        found = true;
                    }
                });
            });


            return found;
        }

        public void PrintCombinations()
        {
            List<int[]> combList = Combinations.ToList();
            int count = 1;
            foreach (int[] a in combList)
            {
                Console.WriteLine($"{count++}. {a[0]} {a[1]}");
            }
        }

        public void PrintParticipants()
        {
            foreach (var participant in Participants.ToList())
            {
                Console.WriteLine($"{participant.Key} {participant.Value}");
            }
        }

        private void PrintRounds()
        {
            Rounds.ForEach((x)=> x.ForEach((y) =>
            {
                Console.WriteLine($"{y[0]} {y[1]}");
            }));
        }
    }
}
