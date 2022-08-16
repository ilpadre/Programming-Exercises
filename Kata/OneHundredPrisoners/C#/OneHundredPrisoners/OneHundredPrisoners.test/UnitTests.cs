using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace OneHundredPrisoners.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerifyDrawersCorrectlyVerifiesDrawers()
        {
            int[] drawers = GenerateArrayInOrder(100);
            bool generatedCorrectly = verifyDrawers(drawers);
            Assert.AreEqual(true, generatedCorrectly);
        }


        [Test]
        public void OneHundredRandomPrisonerNumbersGenerated_1To100_NoDuplicates_NoneMissing()
        {
            PrisonersParoleRandomStrategy parole = new PrisonersParoleRandomStrategy(100);
            bool areUniqueAndInSequence = verifyDrawers(parole.drawers);
            Assert.AreEqual(true, areUniqueAndInSequence);
        }

        [Test]
        public void OnePrisonerFollowsChainUsingRandomStrategyWithEightDrawers()
        {
            PrisonersParole parole = new PrisonersParoleRandomStrategy(8);
            int prisonerNum = 4;
            bool foundNumber = parole.FindMyNumber(prisonerNum);
            Assert.IsTrue(true);
        }

        [Test]
        public void OnePrisonerFollowsChainUsingRandomStrategyWithOneHundredDrawers()
        {
            PrisonersParole parole = new PrisonersParoleRandomStrategy(100);
            int prisonerNum = 4;
            bool foundNumber = parole.FindMyNumber(prisonerNum);
            Assert.IsTrue(true);
        }

        [Test]
        public void EightPrisonersFollowsChainUsingRandomStrategyWithEightdDrawers()
        {
            PrisonersParole parole = new PrisonersParoleRandomStrategy(8);
            for (int i = 0; i < 1000; i++)
            {
                bool allFound = true;
                for (int j = 0; j < 8; j++)
                {
                    if (!parole.FindMyNumber(j+1))
                    {
                        allFound = false;
                        break;
                    }
                    else
                    {
                        allFound = true;
                    }
                }

                if (allFound)
                {
                    Console.WriteLine($"{i} : allFound = {allFound}");
                }
            }
            Assert.IsTrue(true);
        }

        [Test]
        public void OnePrisonerFollowsCyclicChainWithEightDrawersTwoCyclesOfFour()
        {
            int[] drawers = { 3, 4, 7, 8, 1, 2, 5, 6 };
            PrisonersParole parole = new PrisonersParoleCyclicStrategy(drawers);
            int prisonerNum = 4;
            bool foundNumber = parole.FindMyNumber(prisonerNum);
            Assert.IsTrue(foundNumber);
        }

        [Test]
        public void OnePrisonerFollowsCyclicChainWithEightDrawersOneCycleOfFiveReturnsFalse()
        {
            int[] drawers = { 6, 7, 1, 2, 3, 8, 4, 5 };
            PrisonersParole parole = new PrisonersParoleCyclicStrategy(drawers);
            int prisonerNum = 1;
            bool foundNumber = parole.FindMyNumber(prisonerNum);
            Assert.IsFalse(foundNumber);
        }

        [Test]
        public void ParolePLayCyclicChainWithEightDrawersOneCycleOfFiveReturnsFalse()
        {
            int[] drawers = { 6, 7, 1, 2, 3, 8, 4, 5 };
            PrisonersParole parole = new PrisonersParoleCyclicStrategy(drawers);
            bool foundNumber = parole.Play();
            Assert.IsFalse(foundNumber);
        }

        [Test]
        public void ParolePLayCyclicChainWithEightRandomDrawersSucceedsAtLeastOnce()
        {
            int numTrials = 1000;
            int numPrisoners = 8;
            int numSuccesses = 0;
            int numFailures = 0;
            for (int i = 1; i <= numTrials; i++)
            {
                PrisonersParole parole = new PrisonersParoleCyclicStrategy(numPrisoners);
                int[] drawers = parole.drawers;
                if (parole.Play())
                {
                    numSuccesses++;
                }
                else
                {
                    numFailures++;
                }
            }
            bool succeededAtLeastOnce = numSuccesses > 0;
            Assert.IsTrue(succeededAtLeastOnce);
        }

        [Test]
        public void ParolePLayCyclicChainWith100RandomDrawersSucceedsAtLeastOnce()
        {
            int numTrials = 1000;
            int numPrisoners = 100;
            int numSuccesses = 0;
            int numFailures = 0;
            for (int i = 1; i <= numTrials; i++)
            {
                PrisonersParole parole = new PrisonersParoleCyclicStrategy(numPrisoners);
                int[] drawers = parole.drawers;
                if (parole.Play())
                {
                    numSuccesses++;
                }
                else
                {
                    numFailures++;
                }
            }
            bool succeededAtLeastOnce = numSuccesses > 0;
            Assert.IsTrue(succeededAtLeastOnce);
        }



        private bool verifyDrawers(int[] drawers)
        {
            bool verified = false;
            List<int> temp = drawers.ToList();
            temp.Sort();

            var duplicates = temp.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => new { Item = y.Key, Count = y.Count() })
                .ToList();

            if (duplicates.Count == 0 && temp[0] == 1 && temp[temp.Count-1] == temp.Count)
            {
                verified = true;
            }

            return verified;
        }


        private int[] GenerateArrayInOrder(int num)
        {
            int[] arr = new int[num];
            for (int i = 0; i < 100; i++)
            {
                arr[i] = i + 1;
            }

            return arr;
        }
    }
}