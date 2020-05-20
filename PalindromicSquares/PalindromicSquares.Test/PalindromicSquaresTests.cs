using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using PalindromicSquares;

namespace PalindromicSquares.Test
{
    public class PalindromicSquaresTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestParseDigitsOneDigit()
        {
            int[] expected = {1};
            var result = Program.ParseDigits(1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestParseDigitsTwoDigits()
        {
            int[] expected = { 2, 5 };
            var result = Program.ParseDigits(25);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestIsPSNonPS()
        {
            var expected = false;
            var result = Program.IsPSquare(5);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestIsPSIsPS()
        {
            var expected = true;
            var result = Program.IsPSquare(22);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Test4()
        {
            var expected = false;
            var result = Program.IsPSquare(4);
            Assert.AreEqual(expected, result);
        }
    }
}