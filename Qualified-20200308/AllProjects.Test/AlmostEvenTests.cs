using NUnit.Framework;
using AlmostEven;

namespace AllProjects.Test
{
    [TestFixture]
    public class AlmostEvenTests
    {
        [Test]
        public void SimpleFunctionality()
        {
            Assert.AreEqual(new int[] { 10 }, Challenge.SplitInteger(10, 1));
            Assert.AreEqual(new int[] { 1, 1 }, Challenge.SplitInteger(2, 2));
            Assert.AreEqual(new int[] { 4, 4, 4, 4, 4 }, Challenge.SplitInteger(20, 5));
        }
        [Test]
        public void UnevenTests()
        {
            Assert.AreEqual(new int[] { 3, 3, 3, 3, 4, 4 }, Challenge.SplitInteger(20, 6));
            Assert.AreEqual(new int[] { 3, 4, 4 }, Challenge.SplitInteger(11, 3));
        }
        [Test]
        public void BigTest()
        {
            Assert.AreEqual(new int[] { 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 108, 109, 109, 109, 109 }, Challenge.SplitInteger(4000, 37));
        }
    }
}
