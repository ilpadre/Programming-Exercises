using NUnit.Framework;
using PrimeString;

namespace AllProjects.Test
{
    [TestFixture]
    public class PrimeStringTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldHandleSingleLetters()
        {
            Assert.AreEqual(true, Challenge.PrimeString("a"));
            Assert.AreEqual(true, Challenge.PrimeString("x"));
        }
        [Test]
        public void ShouldDetectDoubleRepeatingStrings()
        {
            Assert.AreEqual(false, Challenge.PrimeString("abab"));
            Assert.AreEqual(false, Challenge.PrimeString("xyzxyz"));
        }
        [Test]
        public void ShouldHandleSimplePrimesOfUniqueLetterCombinations()
        {
            Assert.AreEqual(true, Challenge.PrimeString("xyz"));
            Assert.AreEqual(true, Challenge.PrimeString("abcdef"));
        }
        [Test]
        public void ShouldHandleMoreComplexPrimes()
        {
            Assert.AreEqual(true, Challenge.PrimeString("utdutdtdutd"));
            Assert.AreEqual(true, Challenge.PrimeString("abba"));
        }
        [Test]
        public void ShouldDetectMoreMultipleRepeatingStrings()
        {
            Assert.AreEqual(false, Challenge.PrimeString("zzz"));
            Assert.AreEqual(false, Challenge.PrimeString("abcabcabcabc"));
            Assert.AreEqual(false, Challenge.PrimeString("fdsyffdsyffdsyffdsyffdsyf"));
        }
    }
}

