using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WordleCheat.test
{
    public class Tests
    {
        private List<string> wordList = new List<string> { "SHEEP", "STEEP", "RADIO", "MOTOR", "PARTY", "MUNCH", "GLASS", "FRUIT", "DRIVE", "MATCH", "MACHO" };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyWordlistReturnsError()
        {
            var guess = new List<List<string>>();
            var newWordList = new List<string>();
            var result = WordleCheat.Cheat(newWordList, guess, 5);
            Assert.IsTrue(result[0] == "Word list cannot be empty", "Word list cannot be empty");
        } 
   
          [Test]
        public void FirstLetterMatchesNothingElseReturnCorrectCheat()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("MIFIA");
            myGuess.Add("G----");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "MOTOR",
                "MUNCH"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void FirstTwoLettersMatchReturnCorrectCheat()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("MAKER");
            myGuess.Add("GG---");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "MATCH",
                "MACHO"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void FirstThreeLettersMatchReturnCorrectCheat()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("MATER");
            myGuess.Add("GGG--");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "MATCH"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void FirstFourLettersMatchReturnCorrectCheat()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("MATCL");
            myGuess.Add("GGGG-");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "MATCH"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void AllFiveLettersMatchReturnCorrectCheat()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("MATCH");
            myGuess.Add("GGGGG");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "MATCH"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void AllFiveLettersMatchReturnCorrectCheat2()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("STEEP");
            myGuess.Add("GGGGG");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "STEEP"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void FirstLetterMatchesSecondLetterContainedReturnCorrectCheat()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("MOTES");
            myGuess.Add("GY---");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "MACHO"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void FirstLetterMatchesSecondAndThirdLettersContainedReturnCorrectCheat()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("MOHES");
            myGuess.Add("GYY--");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "MACHO"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void FirstLetterMatchesSecondContainsThirdMissingFourthContainsReturnCorrectCheat()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("MOSCE");
            myGuess.Add("GY-Y-");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "MACHO"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }


        [Test]
        public void FirstLetterMatchesSecondContainsThirdMissingFourthContainsFifthMatchesReturnCorrectCheat()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("MHSCO");
            myGuess.Add("GY-YG");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "MACHO"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void ThirdLetterMatchesNoOthersMatchReturnCorrectCheat()
        {
            var guesses = new List<List<string>>();
            var myGuess = new List<string>();
            myGuess.Add("LICKS");
            myGuess.Add("--G--");
            guesses.Add(myGuess);
            List<string> expected = new List<string>
            {
                "MACHO"
            };
            List<string> result = WordleCheat.Cheat(wordList, guesses, 5);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

    }
}