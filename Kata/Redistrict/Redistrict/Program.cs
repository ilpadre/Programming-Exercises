using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Redistrict
{
    class Program
    {
        private const int maxNumber = 27000;
        static void Main(string[] args)
        {
            int precinctCount = GetPrecinctCount();
            string precincts = "precincts.txt";
            GenerateTestFile(precincts, precinctCount);
            SortInternalWholeFile(precincts, precinctCount);
            SortExternalFileMerge(precincts, precinctCount);
            SortWithBitmap(precincts);           
            // ProcessFilesMultiPass();
        }


        #region Read entire file into memory and sort internally

        private static void SortInternalWholeFile(string fileName, int count)
        {
            var sortedNumbersEntireFile = SortInternalWholeFileImpl(fileName, count);
            Console.WriteLine();
            Console.WriteLine("Output from internal sort of entire array in memory:");
            PrintArray(sortedNumbersEntireFile);
        }

        private static int[] SortInternalWholeFileImpl(string fileName, int count)
        {
            int[] precincts = new int[count];
            int i = 0;
            string num = string.Empty;
            using (TextReader reader = File.OpenText("precincts.txt"))
            {
                while (reader.Peek() != -1)
                {
                    precincts[i++] = int.Parse(reader.ReadLine());
                }

            }
            Array.Sort(precincts);
            return precincts;
        }

        #endregion

        #region MergeSort in files on disk

        private static void SortExternalFileMerge(string fileName, int count)
        {
            SortExternalFileMergeImpl(fileName,count);
        }

        private static void SortExternalFileMergeImpl(string fileName, int count)
        {
            SplitFile(fileName);
            StreamWriter g1 = new StreamWriter("g1");
            StreamWriter g2 = new StreamWriter("g2");
            StreamReader f1 = new StreamReader("f1");
            StreamReader f2 = new StreamReader("f2");

            double numberOfPassesCandidate = Math.Log2(count);
            if (numberOfPassesCandidate % 2 != 0)
            {
                numberOfPassesCandidate++;
            }
            int passes = Convert.ToInt32(numberOfPassesCandidate);
            //int passes = Convert.ToInt32(Math.Pow(2.0, Convert.ToDouble(mergeDepth)));

            int runLength = 1;
            for (int i = 1; i <= passes; i++)
            {
                StreamReader input1 = null;
                StreamReader input2 = null;
                StreamWriter output1 = null;
                StreamWriter output2 = null;
                Merge(runLength, f1, f2, g1, g2);
                if (i%2==1)
                {
                    input1 = new StreamReader("g1");
                    input2 = new StreamReader("g2");
                    output1 = new StreamWriter("f1");
                    output2 = new StreamWriter("f2");
                }
                else
                {
                    input1 = new StreamReader("f1");
                    input2 = new StreamReader("f2");
                    output1 = new StreamWriter("g1");
                    output2 = new StreamWriter("g2");
                }
                f1 = input1;
                f2 = input2;
                g1 = output1;
                g2 = output2;
                runLength *= 2;
            }
        }

        private static void SplitFile(string fileName)
        {
            StreamReader inputFile = new StreamReader(fileName);
            StreamWriter f1 = new StreamWriter("f1");
            StreamWriter f2 = new StreamWriter("f2");
            using (TextReader reader = File.OpenText(fileName))
            {
                while (reader.Peek() != -1)
                {
                    int line = int.Parse(reader.ReadLine());
                    f1.WriteLine(line);
                    if (reader.Peek() == -1)
                    {
                        break;
                    }
                    line = int.Parse(reader.ReadLine());
                    f2.WriteLine(line);
                }
                f1.Close();
                f2.Close();
            }


        }


        private static void Merge(int runLength, StreamReader f1, StreamReader f2, StreamWriter g1, StreamWriter g2)
        {
            bool outSwitch = true;
            int winner;
            int[] used = new int[2];
            bool[] fin = new bool[2];
            int[] current = new int[2];

            void readNextInteger(int i)
            {

                if ((used[i] == runLength)
                    || (i == 0 && f1.EndOfStream)
                    || (i == 1 && f2.EndOfStream))
                {
                    fin[i] = true;
                }
                else if (i == 0)
                {
                    current[0] = Convert.ToInt32(f1.ReadLine());
                }
                else if (i == 1)
                {
                    current[1] = Convert.ToInt32(f2.ReadLine());
                }
                used[i]++;
            }

            while (!f1.EndOfStream || !f2.EndOfStream)
            {
                used[0] = 0;
                used[1] = 0;
                fin[0] = false;
                fin[1] = false;
                readNextInteger(0);
                readNextInteger(1);

                while (!fin[0] || !fin[1]) // merge two runs
                {
                    // select winner
                    if (fin[0])
                    {
                        winner = 1;
                    }
                    else if (fin[1])
                    {
                        winner = 0;
                    }
                    else
                    {
                        if (current[0] < current[1])
                        {
                            winner = 0;
                        }
                        else
                        {
                            winner = 1;
                        }


                    }
                    if (outSwitch)
                    {
                        g1.WriteLine(current[winner]);
                    }
                    else
                    {
                        g2.WriteLine(current[winner]);
                    }
                    readNextInteger(winner);
                }

                outSwitch = !outSwitch;

            }
            f1.Close();
            f2.Close();
            g1.Close();
            g2.Close();
        }

        #endregion



        #region Sort using bit array

        private static void SortWithBitmap(string fileName)
        {
            BitArray bitmap = ProcessFilesBitmap(fileName);
            Console.WriteLine();
            Console.WriteLine("Output from bitmap implementation:");
            PrintBitmap(bitmap);

        }
        private static BitArray ProcessFilesBitmap(string fileName)
        {
            BitArray bitMap = new BitArray(maxNumber);

            int a = 6 * 7;

            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    int line = int.Parse(reader.ReadLine());
                    bitMap[line - 1] = true;
                }
                reader.Close();
            }

            return bitMap;
        }

        #endregion

        #region Sort Internal Multiple Passes

        private static void ProcessFilesMultiPass()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Util methods

        private static int GetPrecinctCount()
        {
            bool validInput = false;
            int inputNumber = -1;
            Console.Write("Enter the number of precincts: ");
            do
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out inputNumber) && inputNumber > 0)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Please enter a number greater than zero: ");
                }
            } while (!validInput);

            return inputNumber;

        }

        private static void GenerateTestFile(string fileName, int count)
        {
            var randomNumbers = GenerateRandomIntegersInARange(count);
            var intsAsStrings = new StringBuilder();

            foreach (var arrayElement in randomNumbers.ToArray())
            {
                intsAsStrings.AppendLine(arrayElement.ToString());
            }

            File.WriteAllText(fileName, intsAsStrings.ToString());
            string dir = Directory.GetCurrentDirectory();
            string wdir = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(dir);
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
                    number = random.Next(1, count + 1);
                }
                while (number > 0 && number <= count && randomNumbers.Contains(number));

                randomNumbers.Add(number);
            }

            return randomNumbers;
        }


        private static void PrintArray(int[] sortedNumbers)
        {
            foreach (int num in sortedNumbers)
            {
                Console.WriteLine(num);
            }
        }

        private static void PrintBitmap(BitArray bitMap)
        {
            for (int i = 0; i < bitMap.Length; i++)
            {
                if (bitMap[i])
                {
                    Console.WriteLine($"{i + 1}");
                }
            }
        }
        #endregion



    }
}
