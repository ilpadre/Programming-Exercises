using NUnit.Framework;
using PICAD;

namespace PICAD.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ZeroSuspect_Max0_Min0()
        {
            int[] crimeData = { 3, 10 };
            var count = Program.DetermineSuspects(crimeData);
            Assert.AreEqual(0, count.min);
            Assert.AreEqual(0, count.max);
        }

        [Test]
        public void OneSuspectOutOfRangePrior_Max0_Min0()
        {
            int[] crimeData = { 3, 10, 1, 1, 2 };
            var count = Program.DetermineSuspects(crimeData);
            Assert.AreEqual(0, count.min);
            Assert.AreEqual(0, count.max);
        }

        [Test]
        public void OneSuspectOutOfRangeAfter_Max0_Min0()
        {
            int[] crimeData = { 1, 8, 1, 9, 10 };
            var count = Program.DetermineSuspects(crimeData);
            Assert.AreEqual(0, count.min);
            Assert.AreEqual(0, count.max);
        }

        [Test]
        public void OneSuspectInRange_Max1_Min0()
        {
            int[] crimeData = {3, 10, 1, 1, 4};
            var count = Program.DetermineSuspects(crimeData);
            Assert.AreEqual(0, count.min);
            Assert.AreEqual(1, count.max);
        }


        [Test]
        public void FourSuspectsInRange_Max4_Min1()
        {
            int[] crimeData = { 5, 10, 4, 1, 8, 5, 8, 7, 10, 8, 9 };
            var count = Program.DetermineSuspects(crimeData);
            Assert.AreEqual(1, count.min);
            Assert.AreEqual(4, count.max);
        }
    }
}