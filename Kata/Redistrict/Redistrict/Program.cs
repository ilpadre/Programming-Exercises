using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Redistrict
{
    class Program
    {
        static void Main(string[] args)
        {
            string precincts = "precincts.txt"; 
            GenerateTestFile(precincts);
            ProcessFilesMultiPass();
            ProcessFilesFileMerge();
            ProcessFilesBitmap();
            Console.WriteLine("Hello World!");
        }

        private static void GenerateTestFile(string fileName)
        {
            var randomNumbers = GenerateRandomIntegersInARange(27000);
            var intsAsStrings = new StringBuilder();

            foreach (var arrayElement in randomNumbers.ToArray())
            {
                intsAsStrings.AppendLine(arrayElement.ToString());
            }

            File.AppendAllText(fileName, intsAsStrings.ToString());
        }

        public static List<int> GenerateRandomIntegersInARange(int count)
        {
            List<int> randomNumbers = new List<int>();
            Random random = new Random();
            int cnt = 0;

            for (int i = 1; i <= count; i++)
            {
                int number;

                do
                {
                    cnt++;
                    number = random.Next(1, count+1);
                }
                while (number > 0 && number < 27000 && randomNumbers.Contains(number));

                randomNumbers.Add(number);
            }

            return randomNumbers;
        }

        private static void ProcessFilesMultiPass()
        {
            throw new NotImplementedException();
        }

        private static void ProcessFilesFileMerge()
        {
            throw new NotImplementedException();
        }

        private static void ProcessFilesBitmap()
        {
            throw new NotImplementedException();
        }




    }
}
