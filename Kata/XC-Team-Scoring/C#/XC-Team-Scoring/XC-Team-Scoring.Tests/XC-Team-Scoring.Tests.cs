using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace XC_Team_Scoring.Tests
{
    public class Tests
    {
        private List<Runner> TestRunners { get; set; }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TeamCountsFourRunnersFourTeams()
        {
            TestRunners = LoadFourRunnersFromFourTeams();
            RaceField Field = new RaceField(string.Empty, 5, 7);
            TestRunners.ForEach(x => Field.AddRunner(x));
            Assert.AreEqual(4, Field.TeamCounts.Count);
            foreach (var fieldTeamCount in Field.TeamCounts)
            {
                Assert.AreEqual(1, fieldTeamCount.Value);
            }
        }

        [Test]
        public void TeamCountsFourRunnersThreeTeams()
        {
            TestRunners = LoadFourRunnersFromThreeTeams();
            RaceField Field = new RaceField(string.Empty, 5, 7);
            TestRunners.ForEach(x => Field.AddRunner(x));
            int oneRunner = 0;
            int twoRunners = 0;
            foreach (var fieldTeamCount in Field.TeamCounts)
            {
                if (fieldTeamCount.Value == 1)
                {
                    oneRunner++;
                }

                if (fieldTeamCount.Value == 2)
                {
                    twoRunners++;
                }
            }
            Assert.AreEqual(3, Field.TeamCounts.Count);
            Assert.AreEqual(1, twoRunners);
            Assert.AreEqual(2, oneRunner);
        }

        [Test]
        public void TeamWithTooFewDontCountOneRunner()
        {
            TestRunners = LoadFiveRunnersFromThreeTeams();
            RaceField Field = new RaceField(string.Empty, 2, 7);
            TestRunners.ForEach(x => Field.AddRunner(x));
            Field.AssignPoints();
            Runner lastRunner = Field.Runners[4];

            Assert.AreEqual(4, lastRunner.Points);
            Assert.AreEqual(5, lastRunner.Place);

        }


        [Test]
        public void TeamWithTooFewDontCountTwpRunners()
        {
            TestRunners = LoadSixRunnersFromFourTeams();
            RaceField Field = new RaceField(string.Empty, 2, 7);
            TestRunners.ForEach(x => Field.AddRunner(x));
            Field.AssignPoints();
            Runner lastRunner = Field.Runners[5];

            Assert.AreEqual(4, lastRunner.Points);
            Assert.AreEqual(6, lastRunner.Place);

        }

        private List<Runner> LoadFourRunnersFromFourTeams()
        {
            List<Runner> runners = new List<Runner>
            {
                new Runner("Noah Perry", "Central High", "17:35", 1),
                new Runner("Jake Sandefur", "Hamilton Academy", "17:43", 2),
                new Runner("Sam Gibbs", "Springfield", "17:44", 3),
                new Runner("William Cook", "Gray County", "19:56", 4)
            };
            return runners;
        }

        private List<Runner> LoadFourRunnersFromThreeTeams()
        {
            List<Runner> runners = new List<Runner>
            {
                new Runner("Noah Perry", "Central High", "17:35", 1),
                new Runner("Jake Sandefur", "Springfield", "17:43", 2),
                new Runner("Sam Gibbs", "Springfield", "17:44", 3),
                new Runner("William Cook", "Gray County", "19:56", 4)
            };
            return runners;
        }

        private List<Runner> LoadFiveRunnersFromThreeTeams()
        {
            List<Runner> runners = new List<Runner>
            {
                new Runner("Noah Perry", "Central High", "17:35", 1),
                new Runner("Jake Sandefur", "Springfield", "17:43", 2),
                new Runner("Dylan Hasler", "Central High", "19:10", 3),
                new Runner("William Cook", "Gray County", "19:56", 4),
                new Runner("Hunter Kohlsmith", "Gray County", "19:58", 5)
            };
            return runners;
        }

        private List<Runner> LoadSixRunnersFromFourTeams()
        {
            List<Runner> runners = new List<Runner>
            {
                new Runner("Noah Perry", "Central High", "17:35", 1),
                new Runner("Jake Sandefur", "Hamilton Academy", "17:43", 2),
                new Runner("Sam Gibbs", "Springfield", "17:44", 3),
                new Runner("Dylan Hasler", "Central High", "19:10", 4),
                new Runner("William Cook", "Gray County", "19:56", 5),
                new Runner("Hunter Kohlsmith", "Gray County", "19:58", 6)
            };
            return runners;
        }
    }
}
