using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SubstLib
{
    /// <summary>
    ///     -- Read training file
    ///     -- count characters
    ///     -- compute frequencies
    /// Create Histogram
    /// Set Cipher
    /// Get Plaintext
    /// Encrypt Ciphertext
    /// Decrypt Ciphertext
    /// Compare PT with CT
    /// Create Decrypt Key
    /// </summary>
    public class Subst
    {
        Dictionary<char, int> charCountsTable { get; set; }

        Dictionary<char, int> cipherCharCountsTable { get; set; }
        Dictionary<char, double> frequencyTable { get; set; }

        Dictionary<char, double> cipherTextFrequencyTable { get; set; }

        Dictionary<char, char> cipherTable { get; set; }

        char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        string plainText { get; set; }
        string cipherText { get; set; }

        public Subst(string trainingFileName)
        {
            charCountsTable = new Dictionary<char, int>();
            cipherCharCountsTable = new Dictionary<char, int>();
            frequencyTable = new Dictionary<char, double>();
            cipherTable = new Dictionary<char, char>();
            cipherTextFrequencyTable = new Dictionary<char, double>();
            InitializeFrequencyTable(trainingFileName);
            int shift = getShift();
            setCipher(shift);
            plainText = getPlainText();
            cipherText = encryptPlainText();
            CreateCipherTextFrequencyTable(cipherTextFrequencyTable);
            Console.WriteLine(cipherText);

        }

        public int getShift()
        {
            Console.WriteLine("Enter a shift");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void setCipher(int shift)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                char plain = alphabet[i];
                char cipher = alphabet[(i + shift) % (alphabet.Length)];
                cipherTable.Add(plain, cipher);
            }
        }

        private string getPlainText()
        {
            Console.WriteLine("Enter message to encrypt:");
            return Console.ReadLine().ToLower(); ;
        }

        private string encryptPlainText()
        {
            StringBuilder cipherText = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                char plainChar = plainText[i];
                if (Char.IsLetter(plainChar))
                {
                    cipherText.Append(cipherTable[plainChar]);
                }
            }
            return cipherText.ToString();
        }

        private void CreateCipherTextFrequencyTable(Dictionary<Char, double> table)
        {
            CreateCipherTextCharCountsTable();
            CreateFrequencyTable(cipherTextFrequencyTable);
        }

        private void CreateCipherTextCharCountsTable()
        {
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (Char.IsLetter(cipherText[i]))
                {
                    AddToCipherTextCountsTable(cipherText[i]);

                }
            }
        }

        private void AddToCipherTextCountsTable(char c)
        {
            if (!cipherCharCountsTable.ContainsKey(c))
            {
                cipherCharCountsTable[c] = 0;
            }
            cipherCharCountsTable[c]++;
        }

        public void InitializeFrequencyTable(string trainingFileName)
        {
            ReadTrainingFile(trainingFileName);
            CreateFrequencyTable(frequencyTable);
        }

        private void ReadTrainingFile(string fileName)
        {
            var charCounts = new Dictionary<char, int>();
            string line;

            StreamReader file =
                new StreamReader(fileName);
            while ((line = file.ReadLine()?.ToLower()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (Char.IsLetter(line[i]))
                    {
                        AddToTable(line[i]);

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


        private void CreateFrequencyTable(Dictionary<char, double> table)
        {
            var totalCharacters = (double)getTotalCharacters();
            var list = table.Keys.ToList();
            list.Sort();
            foreach (var key in list)
            {
                frequencyTable.Add(key, (table[key] / totalCharacters * 100.0));
            }
            //printFrequencyTable();
        }

        private long getTotalCharacters()
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

        private void printCipherTable()
        {
            foreach (KeyValuePair<char, char> mapping in cipherTable)
            {
                Console.WriteLine($"{mapping.Key}\t{mapping.Value}");
            }
        }

    }
}
