using System;
using System.Collections.Generic;

namespace WordleCheat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class WordleCheat
    {
        public static List<string> Cheat(List<string> wordList, List<List<string>> guesses, int wordLength)
        {
            List<string> result = new List<string>();
            if (wordList.Count == 0)
            {
                result.Add("Word list cannot be empty");
                return result;
            }

            List<string> guess = guesses[^1];

            return GetCheatSuggestions(guess, wordList);


        }

        private static List<string> GetCheatSuggestions(List<string> guess, List<string> wordList)
        {
            List<string> cheats = new List<string>();
            string myGuess = guess[0];
            string hint = guess[1];


            foreach (var word in wordList)
            {
                bool candidate = true;
                for (int i = 0; i < myGuess.Length; i++)
                {
                    char c = hint[i];
                    char guessLetter = myGuess[i];
                    switch (c)
                    {
                        case 'G':
                            if (word[i] != guessLetter)
                            {
                                candidate = false;
                            }
                            break;
                        case 'Y':
                            if (!(word.Contains(guessLetter)))
                            {
                                candidate = false;
                            }
                            break;
                        case '-':
                            if (word.Contains(guessLetter))
                            {
                                candidate = false;
                            }
                            break;
                        default:
                            throw new Exception("WTF?");
                    }

                    if (!candidate)
                    {
                        break;
                    }

                }

                if (candidate)
                { 
                    cheats.Add(word);
                }

            }



            return cheats;

        }
    }


}
