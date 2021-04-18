using System;
using System.IO;


namespace DataMunging
{
    internal class Program
    {
        private static void Main(string[] args)
        { 
            var day = MinTemperatureRange();
            Console.WriteLine($"The day with the smallest temperature difference was June {day}");
            var team = MinGoalDifferential();
            Console.WriteLine($"The team with the smallest goal differential was {team} ");
        }



        private static int MinTemperatureRange()
        {
            using var temperatures = new StreamReader("weather.dat.csv");
            if (!temperatures.EndOfStream)
            {
                // skip header line
                temperatures.ReadLine();
            }

            var high = 0;
            var low = 200;
            var diff = 200;
            var day = 0;
            while (!temperatures.EndOfStream)
            {
                var line = temperatures.ReadLine();
                var items = line.Split(',');
                var thisHigh = Convert.ToInt32(items[1]);
                var thisLow = Convert.ToInt32(items[2]);
                if (diff > thisHigh - thisLow)
                {
                    diff = thisHigh - thisLow;
                    day = Convert.ToInt32(items[0]);
                }
            }

            temperatures.Close();

            return day;
        }

        private static string MinGoalDifferential()
        {
            var team = "";
            using var scores = new StreamReader("football.dat.csv");
            if (!scores.EndOfStream)
            {
                // skip header line
                scores.ReadLine();
            }

            var goalsFor = 0;
            var goalsAgainst = 200;
            var goalDifferential = 200;

            while (!scores.EndOfStream)
            {
                var line = scores.ReadLine();
                var teamData = line.Split(',');
                var thisFor = Convert.ToInt32(teamData[6]);
                var thisAgainst = Convert.ToInt32(teamData[7]);
                if (goalDifferential > Math.Abs(thisFor - thisAgainst))
                {
                    goalDifferential = Math.Abs(thisFor - thisAgainst);
                    team = teamData[1];
                }
            }

            scores.Close();
            return team;
        }
    }
}