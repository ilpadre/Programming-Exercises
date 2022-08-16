using System;
using System.Collections.Generic;
using System.Linq;

namespace OneHundredPrisoners
{
    public class HundredPrisoners
    {
        public static void Main(string[] args)
        {
            int numPrisoners = 100;
            int numTrials = 10000;
            int numSuccesses = 0;
            int numFailures = 0;
            for (int i = 1; i <= numTrials; i++)
            {
                PrisonersParole parole = new PrisonersParoleCyclicStrategy(numPrisoners);
                if (parole.Play())
                {
                    numSuccesses++;
                }
                else
                {
                    numFailures++;
                }
            }

            Console.WriteLine($"Successes: {numSuccesses}");

            Console.WriteLine($"Failures: {numFailures}");

            Console.WriteLine($"Success Rate = {(numSuccesses/(double)numTrials)*100.0}%");
        }




    }

    public abstract class PrisonersParole
    {
        public int[] drawers { get; set; }
        public int numDrawers;
        protected int maxDrawersToOpen;

        public PrisonersParole(int numPrisoners)
        {
            drawers = GenerateRandom(numPrisoners);
            numDrawers = drawers.Length;
            maxDrawersToOpen = numDrawers / 2;
        }

        public PrisonersParole(int[] prisonerDrawers)
        {
            drawers = prisonerDrawers;
            numDrawers = drawers.Length;
            maxDrawersToOpen = numDrawers / 2;

        }

        public virtual bool FindMyNumber(int prisonerNumber)
        {
            return false;
        }



        public bool Play()
        {
            int numPrisoners = numDrawers;
            bool isSuccessful = true;

            for (int i = 1; i <= numPrisoners; i++)
            {
                isSuccessful = FindMyNumber(i);
                if (!isSuccessful)
                {
                    break;
                }

            }

            return isSuccessful;
        }

        protected int[] GenerateArrayInOrder(int num)
        {
            int[] arr = new int[num];
            for (int i = 0; i < num; i++)
            {
                arr[i] = i + 1;
            }

            return arr;
        }

        protected int[] GenerateRandom(int numDrawers)
        {
            int[] temp = GenerateArrayInOrder(numDrawers);

            Random rnd = new Random();

            GenerateArrayInOrder(numDrawers);

            int[] MyRandomArray = temp.OrderBy(x => rnd.Next()).ToArray();

            return MyRandomArray;
        }



    }

    public class PrisonersParoleRandomStrategy: PrisonersParole
    {
        public PrisonersParoleRandomStrategy(int numPrisoners) : base(numPrisoners)
        {
        }


        public override bool FindMyNumber(int prisonerNum)
        {
            Random rnd = new Random();
            List<int> drawersTried = new List<int>();
            int numDrawersTried = 0;
            bool found = false;
            do
            {
                numDrawersTried++;
                int drawerToTry = rnd.Next(numDrawers);
                if (drawersTried.Contains(drawerToTry))
                {
                    continue;
                }
                drawersTried.Add(drawerToTry);
                if (drawers[drawerToTry] == prisonerNum)
                {
                    found = true;
                    break;
                }
            } while (!found && numDrawersTried <= maxDrawersToOpen);

            return found;
        }



    }

    public class PrisonersParoleCyclicStrategy : PrisonersParole
    {
        public PrisonersParoleCyclicStrategy(int numPrisoners) : base(numPrisoners)
        {
        }

        public PrisonersParoleCyclicStrategy(int[] drawers) : base(drawers)
        {
        }

        public override bool FindMyNumber(int prisonerNum)
        {
            int numDrawersTried = 0;
            bool found = false;
            int drawer = prisonerNum-1;
            do
            {
                numDrawersTried++;
                int drawerContents = drawers[drawer];
                if (drawerContents == prisonerNum)
                {
                    found = true;
                    break;
                }

                drawer = drawerContents-1;

            } while (!found && numDrawersTried < maxDrawersToOpen);

            return found;
        }
    }
}
