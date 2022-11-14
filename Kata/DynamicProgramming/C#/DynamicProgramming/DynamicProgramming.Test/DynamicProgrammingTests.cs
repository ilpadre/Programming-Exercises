using NUnit.Framework;

namespace DynamicProgramming.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComputeFirstFibRecursively()
        {
            int fibNum = Program.FibRecursive(0);
        
            Assert.AreEqual(0, fibNum);
        }

        [Test]
        public void ComputeSecondFibRecursively()
        {
            int fibNum = Program.FibRecursive(1);

            Assert.AreEqual(1, fibNum);
        }

        [Test]
        public void ComputeThirdFibRecursively()
        {
            int fibNum = Program.FibRecursive(2);

            Assert.AreEqual(1, fibNum);
        }

        [Test]
        public void ComputeTenthFibRecursively()
        {
            int fibNum = Program.FibRecursive(10);

            Assert.AreEqual(55, fibNum);
        }

        [Test]
        public void ComputeFirstFibDynamically()
        {
            int fibNum = Program.FibDynamic(0);

            Assert.AreEqual(0, fibNum);
        }

        [Test]
        public void ComputeSecondFibDynamically()
        {
            int fibNum = Program.FibDynamic(1);

            Assert.AreEqual(1, fibNum);
        }

        [Test]
        public void ComputeThirdFibDynamically()
        {
            int fibNum = Program.FibDynamic(2);

            Assert.AreEqual(1, fibNum);
        }

        [Test]
        public void ComputeTenthFibDynamically()
        {
            int fibNum = Program.FibDynamic(10);

            Assert.AreEqual(55, fibNum);
        }

        [Test]
        public void MinCoinsForZeroAmountIsZerRecursive()
        {
            int minCoins = Program.MinCoinsRecursive(new int[] { 25, 10, 5 , 1 }, 4, 0);

            Assert.AreEqual(0, minCoins);
        }

        [Test]
        public void MinCoinsForTwentyFiveAmountIsOneRecursive()
        {
            int minCoins = Program.MinCoinsRecursive(new int[] { 25, 10, 5, 1 }, 4, 25);

            Assert.AreEqual(1, minCoins);
        }

        [Test]
        public void MinCoinsIsTwoRecursive()
        {
            int[] coins = { 9, 6, 5, 1 };
            int m = coins.Length;
            int V = 11;
            int res = Program.MinCoinsRecursive(coins, m, V);

            Assert.AreEqual(2, res);
        }

        [Test]
        public void MinCoinsForZeroAmountIsZerDynamic()
        {
            int minCoins = Program.MinCoinsDynamic(new int[] { 25, 10, 5, 1 }, 4, 0);

            Assert.AreEqual(0, minCoins);
        }

        [Test]
        public void MinCoinsForTwentyFiveAmountIsOneDynamic()
        {
            int minCoins = Program.MinCoinsDynamic(new int[] { 25, 10, 5, 1 }, 4, 25);

            Assert.AreEqual(1, minCoins);
        }

        [Test]
        public void MinCoinsIsTwoDynamic()
        {
            int[] coins = { 9, 6, 5, 1 };
            int m = coins.Length;
            int V = 11;
            int res = Program.MinCoinsDynamic(coins, m, V);

            Assert.AreEqual(2, res);
        }
    }
}