using System;
using NUnit.Framework;
using SquareNumber;

namespace AllProjects.Test
{
    [TestFixture]
    public class SquareNumberTests
    {
        [Test]
        public static void ShouldWorkForSomeExamples()
        {
            Assert.AreEqual(false, Challenge.IsSquare(-1), "negative numbers aren't square numbers");
            Assert.AreEqual(false, Challenge.IsSquare(3), "3 isn't a square number");
            Assert.AreEqual(true, Challenge.IsSquare(4), "4 is a square number");
            Assert.AreEqual(true, Challenge.IsSquare(25), "25 is a square number");
            Assert.AreEqual(false, Challenge.IsSquare(26), "26 isn't a square number");
        }

        [Test]
        public static void ShouldWorkForRandomSquareNumbers()
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                int num = r.Next(20) + 1;
                Assert.AreEqual(true, Challenge.IsSquare(num * num), (num * num) + " is a square!");
            }
        }

        [Test]
        public static void ShouldWorkForRandomNumbers()
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                int num = r.Next(1000000) + 1;
                Assert.AreEqual(SquareNumberTests.IsSquare(num), Challenge.IsSquare(num), SquareNumberTests.IsSquare(num) ? num + " is a square!" : num + " isn't a square!");
            }
        }

        private static bool IsSquare(int n)
        {
            return Math.Sqrt(n) % 1 == 0;
        }
    }
}
