using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MysteryApp
{
    class Program
    {


        static void Main(string[] args)
        {

            Mystery.WTF();
        }
    }

    class Mystery
    {



        public static void WTF()
        {

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            goto label1;
            label2:
            Console.WriteLine("Label 2");
            Dictionary<char, int> charCountsTable = new Dictionary<char, int>();
            Dictionary<char, double>  frequencyTable = new Dictionary<char, double>();
            Dictionary<char, double> referenceFrequencyTable = new Dictionary<char, double>();
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
            foreach (KeyValuePair<char, double> freqs in referenceFrequencyTable)
            {
                Console.WriteLine($"{freqs.Key}\t{freqs.Value}");
            }
            string line;
            StreamReader file = new StreamReader("will.txt");
            while ((line = file.ReadLine()?.ToLower()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (Char.IsLetter(line[i]))
                    {
                        if (alphabet.ToList<char>().Contains(line[i]))
                        {
                            if (!charCountsTable.ContainsKey(line[i]))
                            {
                                charCountsTable[line[i]] = 0;
                            }
                            charCountsTable[line[i]]++;
                        }
                    }
                }
            }
            file.Close();
            foreach (KeyValuePair<char, int> freqs in charCountsTable)
            {
                Console.WriteLine($"{freqs.Key}\t{freqs.Value}");
            }
            var totalCharacters = 0.0;
            foreach (KeyValuePair<char, int> chars in charCountsTable)
            {
                totalCharacters += chars.Value;
            }
            var list = charCountsTable.Keys.ToList();
            list.Sort();
            foreach (var key in list)
            {
                frequencyTable.Add(key, Math.Round((charCountsTable[key] / totalCharacters * 100.0), 3));
            }
            foreach (KeyValuePair<char, double> freqs in frequencyTable)
            {
                Console.WriteLine($"{freqs.Key}\t{freqs.Value}");
            }
            Console.WriteLine();
            Console.WriteLine("Letter\tRef\tCorpus");
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine($"{alphabet[i]}\t{referenceFrequencyTable[alphabet[i]]}\t{frequencyTable[alphabet[i]]}");
            }

            goto label10;
            label1:
            Console.WriteLine("Label 1");
            goto label2;
            label10: ;
        }
    }
}

