using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace BinarySearch.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyArrayReturnsNotFound()
        {
            int[] inputArray = { };
            int numToFind = 11;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(-1, retVal, "Wrong return");
        }


        [Test]
        public void SingleElementSearchSuccess()
        {
            int[] inputArray = { 5 };
            int numToFind = 5;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(0, retVal, "Wrong return");
        }

        [Test]
        public void SingleElementSearchFailsNumGreater()
        {
            int[] inputArray = { 5 };
            int numToFind = 6;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(-1, retVal, "Wrong return");
        }

        [Test]
        public void SingleElementSearchFailsNumLess()
        {
            int[] inputArray = { 5 };
            int numToFind = 4;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(-1, retVal, "Wrong return");
        }

        [Test]
        public void TwoElementsFirstElementMatches()
        {
            int[] inputArray = { 5, 6 };
            int numToFind = 5;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(0, retVal, "Wrong return");
        }

        [Test]
        public void TwoElementsSecondElementMatches()
        {
            int[] inputArray = { 5, 6 };
            int numToFind = 6;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(1, retVal, "Wrong return");
        }

        [Test]
        public void ThreeElementsSecondElementMatches()
        {
            int[] inputArray = { 5, 6, 7 };
            int numToFind = 6;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(1, retVal, "Wrong return");
        }

        [Test]
        public void ThreeElementsFirstElementMatches()
        {
            int[] inputArray = { 5, 6, 7 };
            int numToFind = 5;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(0, retVal, "Wrong return");
        }

        [Test]
        public void ThreeElementsThirdElementMatches()
        {
            int[] inputArray = { 5, 6, 7 };
            int numToFind = 7;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(2, retVal, "Wrong return");
        }

        [Test]
        public void ThreeElementsNoMatchesNumLower()
        {
            int[] inputArray = { 5, 6, 7 };
            int numToFind = 4;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(-1, retVal, "Wrong return");
        }

        [Test]
        public void ThreeElementsNoMatchesNumHigher()
        {
            int[] inputArray = { 5, 6, 7 };
            int numToFind = 8;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(-1, retVal, "Wrong return");
        }

        [Test]
        public void FourElementsFirstElementMatches()
        {
            int[] inputArray = { 5, 6, 7, 8 };
            int numToFind = 5;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(0, retVal, "Wrong return");
        }

        [Test]
        public void FourElementsSecondElementMatches()
        {
            int[] inputArray = { 5, 6, 7, 8 };
            int numToFind = 6;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(1, retVal, "Wrong return");
        }

        public void FourElementsThirdElementMatches()
        {
            int[] inputArray = { 5, 6, 7, 8 };
            int numToFind = 7;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(2, retVal, "Wrong return");
        }

        public void FourElementsFourthElementMatches()
        {
            int[] inputArray = { 5, 6, 7, 8 };
            int numToFind = 8;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(2, retVal, "Wrong return");
        }

        [Test]
        public void FourElementsNoMatchesNumLower()
        {
            int[] inputArray = { 5, 6, 7, 8 };
            int numToFind = 4;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(-1, retVal, "Wrong return");
        }

        [Test]
        public void FourElementsNoMatchesNumHigher()
        {
            int[] inputArray = { 5, 6, 7, 8 };
            int numToFind = 9;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(-1, retVal, "Wrong return");
        }

        [Test]
        public void FourElementsNoMatchesNumInBetween()
        {
            int[] inputArray = { 5, 6, 8, 9 };
            int numToFind = 7;
            Program.inputArray = inputArray;
            int retVal = Program.BSearch(numToFind);
            Assert.AreEqual(-1, retVal, "Wrong return");
        }

        [Test]
        public void ReturnFirstOfDuplicate()
        {
            int[] inputArray = { 5, 6, 8, 9, 10, 10, 10, 11 };
            int numToFind = 10;
            Program.inputArray = inputArray;
            int retVal = Program.BSearchReturnFirst(numToFind);
            Assert.AreEqual(4, retVal, "Wrong return");
        }

        [Test]
        public void EmptyArrayReturnsNotFoundCallingReturnFirst()
        {
            int[] inputArray = { };
            int numToFind = 11;
            Program.inputArray = inputArray;
            int retVal = Program.BSearchReturnFirst(numToFind);
            Assert.AreEqual(-1, retVal, "Wrong return");
        }


        [Test]
        public void SingleElementSearchSuccessCallingReturnFirst()
        {
            int[] inputArray = { 5 };
            int numToFind = 5;
            Program.inputArray = inputArray;
            int retVal = Program.BSearchReturnFirst(numToFind);
            Assert.AreEqual(0, retVal, "Wrong return");
        }


    }
}