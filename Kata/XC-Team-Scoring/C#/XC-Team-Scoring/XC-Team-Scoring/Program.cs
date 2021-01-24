using System;
using System.Collections.Generic;

namespace XC_Team_Scoring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Runner
    {
        public Runner(string name, string school, string elapsedTime, int place)
        {
            Name = name;
            School = school;
            ElapsedTime = elapsedTime;
            Place = place;
            IncludeInTeamScore = true;
        }
        public  string Name { get; set; }
        public string School { get; set; }
        public string ElapsedTime { get; set; }
        public bool IncludeInTeamScore { get; set; }
        public int TeamRank { get; set; }
        public int Place { get; set; }
        public int Points { get; set; }
    }

    public class RaceField
    {
        private string ResultsFile { get; set; }
        private int MinTeamSize { get; set; }
        private int MaxRunnersReceivingPoints { get; set; }
        public Dictionary<string, int> TeamCounts { get; set; }

        public Dictionary<string, List<int>> TeamPlacers { get; set; }
        public List<Runner> Runners { get; set; }

        public RaceField(string resultsFile, int minTeamSize, int maxReceivingPoints)
        {
            ResultsFile = resultsFile;
            MinTeamSize = minTeamSize;
            MaxRunnersReceivingPoints = maxReceivingPoints;
            TeamCounts = new Dictionary<string, int>();
            TeamPlacers = new Dictionary<string, List<int>>();
            Runners = new List<Runner>();
        }

        public void AddRunner(Runner runner)
        {
            string team = runner.School;
            IncrementTeamCount(team);
            runner.TeamRank = GetTeamCount(team);
            Runners.Add(runner);

        }

        public void IncrementTeamCount(string teamName)
        {
            if (TeamCounts.ContainsKey(teamName))
            {
                TeamCounts[teamName]++;
            }
            else
            {
                TeamCounts.Add(teamName, 1);
            }
        }

        public int GetTeamCount(string teamName)
        {
            return TeamCounts[teamName];
        }

        public void AssignPoints()
        {
            int numberToSkip = 0;
            foreach (var runner in Runners)
            {
                if (GetTeamCount(runner.School) >= MinTeamSize)
                {
                    runner.Points = runner.Place - numberToSkip;
                }
                else
                {
                    numberToSkip += 1;
                }
            }
        }

        public void ComputeScore()
        {

        }
        public void ReadRunners(string fileName)
        {

        }

        public void SortRunners()
        {

        }

        public void PrintResults()
        {

        }

    }

    
}
