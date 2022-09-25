using SortingBySetBIts;

namespace SortingBySetBits.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Number1Has1SetBit()
        {
            int numOnes = Program.CountSetBits(1);
            Assert.That(numOnes, Is.EqualTo(1));
        }


        [Test]
        public void Number7Has3SetBits()
        {
            int numOnes = Program.CountSetBits(7);
            Assert.That(numOnes, Is.EqualTo(3));
        }

        [Test]
        public void Number0Has0SetBits()
        {
            int numOnes = Program.CountSetBits(0);
            Assert.That(numOnes, Is.EqualTo(0));
        }

        [Test]
        public void Number4095Has13SetBits()
        {
            int numOnes = Program.CountSetBits(4095);
            Assert.That(numOnes, Is.EqualTo(12));
        }

        [Test]
        public void EmptyArraySortReturnsEmptyArray()
        {
            int[] arr = Array.Empty<int>();
            int[] returnArr = Program.SortArrayBySetBits(arr);
            Assert.That(arr, Is.EqualTo(returnArr));
        }

        [Test]
        public void SingleElementArraySortReturnsSameArray()
        {
            int[] arr = { 1 };
            int[] returnArr = Program.SortArrayBySetBits(arr);
            bool arraysAreEqual = Enumerable.SequenceEqual(arr, returnArr);
            Assert.IsTrue(arraysAreEqual);
        }

        [Test]
        public void TwoElementArrayDifferentNumberOfSetBitsSortReturnsCorrectArray()
        {
            int[] arr = { 3, 8 };
            int[] returnArr = Program.SortArrayBySetBits(arr);
            bool arraysAreEqual = Enumerable.SequenceEqual(arr, returnArr);
            Assert.IsTrue(arraysAreEqual);
        }

        [Test]
        public void TwoElementArrayDifferentNumberOfSetBitsAlreadySortedSortReturnsSameArray()
        {
            int[] arr = { 8, 3 };
            int[] returnArr = Program.SortArrayBySetBits(arr);
            bool arraysAreEqual = Enumerable.SequenceEqual(arr, returnArr);
            Assert.IsTrue(arraysAreEqual);
        }


        [Test]
        public void TestArraySortReturnsCorrectlySortedArray()
        {
            int[] arr = { 3, 8, 3, 6, 5, 7, 9, 1 };
            int[] sortedArr = { 1, 8, 3, 3, 5, 6, 9, 7 };
            int[] returnArr = Program.SortArrayBySetBits(arr);
            bool arraysAreEqual = Enumerable.SequenceEqual(sortedArr, returnArr);
            Assert.IsTrue(arraysAreEqual);
        }
    }
}