using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace RockPaperScissors.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComputerPlayIsValid()
        {
            string play = RPS.ComputerPlays();
            Assert.IsTrue(RPS.Plays.Contains(play), "Computer play is illegal" );
        }

        [Test]
        public void ComputerPlayIsPassedIn()
        {
            string play = RPS.ComputerPlays("Rock");
            Assert.AreEqual("Rock", play);
        }

        [Test]
        public void HumanPlayIsValid()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("Rock");
            Console.SetIn(input);

            string play = RPS.HumanPlays();
            Console.WriteLine(output);
            Assert.IsTrue(RPS.Plays.Contains(play), "Human play is illegal");
        }

        [Test]
        public void PlayOneGameHumanWins()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("Paper");
            Console.SetIn(input);

            string result = RPS.PlayOneGame("Rock");

            Assert.AreEqual("Win", result);
        }

        [Test]
        public void PlayOneGameComputerWins()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("Paper");
            Console.SetIn(input);

            string result = RPS.PlayOneGame("Scissors");

            Assert.AreEqual("Lose", result);
        }

        [Test]
        public void PlayOneGameDraw()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("Paper");
            Console.SetIn(input);

            string result = RPS.PlayOneGame("Paper");

            Assert.AreEqual("Draw", result);
        }

        [Test]
        public void RockBeatsScissors()
        {
            string result = RPS.DecideOutcome("Rock", "Scissors");
            Assert.AreEqual("Win", result);
        }

        [Test]
        public void RockLosesToPaper()
        {
            string result = RPS.DecideOutcome("Rock", "Paper");
            Assert.AreEqual("Lose", result);
        }

        [Test]
        public void ScissorsBeatsPaper()
        {
            string result = RPS.DecideOutcome("Scissors", "Paper");
            Assert.AreEqual("Win", result);
        }

        [Test]
        public void ScissorsLosesToRock()
        {
            string result = RPS.DecideOutcome("Scissors", "Rock");
            Assert.AreEqual("Lose", result);
        }

        [Test]
        public void PaperBeatsRock()
        {
            string result = RPS.DecideOutcome("Paper", "Rock");
            Assert.AreEqual("Win", result);
        }

        [Test]
        public void PaperLosesToScissors()
        {
            string result = RPS.DecideOutcome("Paper", "Scissors");
            Assert.AreEqual("Lose", result);
        }

        [Test]
        public void PaperVsPaperIsADraw()
        {
            string result = RPS.DecideOutcome("Paper", "Paper");
            Assert.AreEqual("Draw", result);
        }

        [Test]
        public void RockVsRockIsADraw()
        {
            string result = RPS.DecideOutcome("Rock", "Rock");
            Assert.AreEqual("Draw", result);
        }

        [Test]
        public void ScissorsVsScissorsIsADraw()
        {
            string result = RPS.DecideOutcome("Scissors", "Scissors");
            Assert.AreEqual("Draw", result);
        }

        [Test]
        public void TestRandomNumberGen()
        {
            var nums = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                int num = RPS.GetRandomNum(0, 3);
                if (num > 2 || num < 0)
                {
                    nums.Add(num);
                }
            }
            Assert.True(nums.Count == 0);
        }






    }
}