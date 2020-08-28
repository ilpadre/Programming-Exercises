using NUnit.Framework;
using RotateArray;

namespace RotateArray.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RotateArrayWith4Items()
        {
            int[] inputArr = new int[] {1, 2, 3, 4};
            int[] expected = new int[] {4, 1, 2, 3};
            int[] actual = RotateArrayLib.Rotate(inputArr);
            bool isEqual = arraysAreEqual(actual, expected);
            Assert.IsTrue(isEqual);
        }

        [Test]
        public void RotateArrayWith8Items()
        {
            int[] inputArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8};
            int[] expected = new int[] { 8, 1, 2, 3, 4, 5, 6, 7};
            int[] actual = RotateArrayLib.Rotate(inputArr);
            bool isEqual = arraysAreEqual(actual, expected);
            Assert.IsTrue(isEqual);
        }

        [Test]
        public void RotateArrayWith4ItemsTwice()
        {
            int[] inputArr = new int[] { 1, 2, 3, 4 };
            int[] expected = new int[] { 3, 4, 1, 2 };
            int[] actual = RotateArrayLib.RotateN(inputArr, 2);
            bool isEqual = arraysAreEqual(actual, expected);
            Assert.IsTrue(isEqual);
        }

        [Test]
        public void RotateArrayWith8ItemsFourTimes()
        {
            int[] inputArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] expected = new int[] { 5, 6, 7, 8, 1, 2, 3, 4 };
            int[] actual = RotateArrayLib.RotateN(inputArr, 4);
            bool isEqual = arraysAreEqual(actual, expected);
            Assert.IsTrue(isEqual);
        }

        [Test]
        public void RotateArrayWith8ItemsEightTimes()
        {
            int[] inputArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] actual = RotateArrayLib.RotateN(inputArr, 8);
            bool isEqual = arraysAreEqual(actual, expected);
            Assert.IsTrue(isEqual);
        }

        private bool arraysAreEqual(int[] actual, int[] expected)
        {
            bool areEqual = true;
            if (actual.Length != expected.Length)
            {
                areEqual = false;
            }
            else
            {
                 for (int i = 0; i < actual.Length; i++)
                 {
                    if (actual[i] != expected[i])
                    {
                        areEqual = false;
                        break;
                    }
                 }               
            }


            return areEqual;
        }
    }
}