using System;
using NUnit.Framework;

namespace ModPow.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NaiveMethodComputesForSmallValue()
        {
            double results = Program.ModPowNaive(2.0, 2.0, 10.0);

            Assert.AreEqual(4, results, "Hmmm...simple one failed. Booooo!");
        }

        [Test]
        public void NaiveMethodComputesForLargerValue()
        {
            double a = 2356;
            double b = 4532;
            double n = 45631;
            double results = Program.ModPowNaive(a, b, n);
            
            Assert.IsTrue(double.IsInfinity(results), "Hmmm...not infinity");
        }

        [Test]
        public void ComputesForSmallValues()
        {
            double results = Program.ModPow(2.0, 2.0, 10.0);

            Assert.AreEqual(4, results, "Hmmm...simple one failed. Booooo!");
        }

        [Test]
        public void ComputesForLargerValues()
        {
            double a = 2356;
            double b = 4532;
            double n = 45631;
            double expected = 44930;
            double results = Program.ModPow(a, b, n);

            Assert.AreEqual(expected, results, "Hmmm...not correct");
        }

        [Test]
        public void ComputesForMuchLargerValues()
        {
            double a = 23563465;
            double b = 17;
            double n = 45632512;
            double expected = 16959305;
            double results = Program.ModPow(a, b, n);

            Assert.AreEqual(expected, results, "Hmmm...not correct");
        }
    }
}