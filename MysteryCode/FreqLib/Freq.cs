using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FreqLib
{
    /// <summary>
    /// Create Frequency Table
    ///     -- Create standard frequency table
    ///     -- Read corpus
    ///     -- accumulate counts for characters
    ///     -- sort character counts by character
    ///     -- compute total characters
    ///     -- compute frequencies and store in frequency table
    ///     -- compare with standard frequency table
    /// </summary>
    public class Freq
    {
        Dictionary<char, int> charCountsTable { get; set; }

        Dictionary<char, double> frequencyTable { get; set; }

        Dictionary<char, double> referenceFrequencyTable { get; set; }

        char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };



        public Freq()
        {
            charCountsTable = new Dictionary<char, int>();
            frequencyTable = new Dictionary<char, double>();
            referenceFrequencyTable = new Dictionary<char, double>();
            CreateReferenceFrequencyTable();
            ReadCorpusAndComputeCharCounts("will.txt");
            CreateFrequencyTableFromCharCounts();
            CompareFrequencyTableWithReference();
        }

        private void CreateReferenceFrequencyTable()
        {
            referenceFrequencyTable.Add('a', 8.167);
            referenceFrequencyTable.Add('b', 1.492);
            referenceFrequencyTable.Add('c', 2.202);
            referenceFrequencyTable.Add('d', 4.253);
            referenceFrequencyTable.Add('e', 12.702);
            referenceFrequencyTable.Add('f', 2.228);
            referenceFrequencyTable.Add('g', 2.015);
            referenceFrequencyTable.Add('h', 6.094);
            referenceFrequencyTable.Add('i', 6.966);
            referenceFrequencyTable.Add('j', .153);
            referenceFrequencyTable.Add('k', 1.292);
            referenceFrequencyTable.Add('l', 4.025);
            referenceFrequencyTable.Add('m', 2.406);
            referenceFrequencyTable.Add('n', 6.749);
            referenceFrequencyTable.Add('o', 7.507);
            referenceFrequencyTable.Add('p', 1.929);
            referenceFrequencyTable.Add('q', 0.095);
            referenceFrequencyTable.Add('r', 5.987);
            referenceFrequencyTable.Add('s', 6.327);
            referenceFrequencyTable.Add('t', 9.356);
            referenceFrequencyTable.Add('u', 2.758);
            referenceFrequencyTable.Add('v', 0.978);
            referenceFrequencyTable.Add('w', 2.560);
            referenceFrequencyTable.Add('x', 0.150);
            referenceFrequencyTable.Add('y', 1.994);
            referenceFrequencyTable.Add('z', 0.077);
            printReferenceFrequencyTable();
        }

        private void ReadCorpusAndComputeCharCounts(string fileName)
        {
            string line;

            StreamReader file =
                new StreamReader(fileName);
            while ((line = file.ReadLine()?.ToLower()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (Char.IsLetter(line[i]))
                    {
                        if (alphabet.ToList<char>().Contains(line[i]))
                        {
                            AddToTable(line[i]);
                        }
                        else
                        {
                           // Console.WriteLine(line[i]);
                        }

                    }
                }
            }
            file.Close();
        }

        private void AddToTable(char c)
        {
            if (!charCountsTable.ContainsKey(c))
            {
                charCountsTable[c] = 0;
            }
            charCountsTable[c]++;
        }

        private void CreateFrequencyTableFromCharCounts()
        {
            var totalCharacters = (double)getTotalCharacters();
            var list = charCountsTable.Keys.ToList();
            list.Sort();
            foreach (var key in list)
            {
                frequencyTable.Add(key, Math.Round((charCountsTable[key] / totalCharacters * 100.0), 3));
            }
            printFrequencyTable();
        }

        private double getTotalCharacters()
        {
            var charCount = 0L;
            foreach (KeyValuePair<char, int> chars in charCountsTable)
            {
                charCount += chars.Value;
            }
            return charCount;
        }

        private void printFrequencyTable()
        {
            foreach (KeyValuePair<char, double> freqs in frequencyTable)
            {
                Console.WriteLine($"{freqs.Key}\t{freqs.Value}");
            }
        }

        private void printReferenceFrequencyTable()
        {
            foreach (KeyValuePair<char, double> freqs in referenceFrequencyTable)
            {
                Console.WriteLine($"{freqs.Key}\t{freqs.Value}");
            }
        }

        private void CompareFrequencyTableWithReference()
        {
            Console.WriteLine();
            Console.WriteLine("Letter\tRef\tCorpus");
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine($"{alphabet[i]}\t{referenceFrequencyTable[alphabet[i]]}\t{frequencyTable[alphabet[i]]}");
            }

        }


    }
}
