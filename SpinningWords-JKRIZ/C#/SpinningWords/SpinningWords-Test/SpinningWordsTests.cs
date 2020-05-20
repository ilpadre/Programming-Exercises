using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using SpinningWords;

namespace SpinningWords_Test
{
    public class SpinningWordsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReverseString()
        {
            var expected = new string("poopesoom");
            var result = SpinningWords.Program.ReverseString("moosepoop");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnEmptyStringForEmptyInput()
        {
            var expected = string.Empty;
            //var result = SpinningWords.Program.SpinMyWords(string.Empty);
            var result = SpinningWords.Program.SpinMyWordsLinq(string.Empty);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseOne5CharWordSingleWordInput()
        {
            var expected = "esoom";
            // result = SpinningWords.Program.SpinMyWords("moose");
            var result = SpinningWords.Program.SpinMyWordsLinq("moose");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DoNotReverseOne4CharWordSingleWordInput()
        {
            var expected = "moos";
            //var result = SpinningWords.Program.SpinMyWords("moos");
            var result = SpinningWords.Program.SpinMyWordsLinq("moos");

            Assert.AreEqual(expected, result);

        }

        [Test]
        public void ReverseOne5CharWordTwoWordInput()
        {
            var expected = "the poopesoom";
            //var result = SpinningWords.Program.SpinMyWords("the moosepoop");
            var result = SpinningWords.Program.SpinMyWordsLinq("the moosepoop");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseTwo5CharWordsTwoWordInput()
        {
            var expected = "esoom spoop";
            //var result = SpinningWords.Program.SpinMyWords("moose poops");
            var result = SpinningWords.Program.SpinMyWordsLinq("moose poops");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DoNotReverseTwo4CharWordsTwoWordInput()
        {
            var expected = "moos poop";
            //var result = SpinningWords.Program.SpinMyWords("moos poop");
            var result = SpinningWords.Program.SpinMyWordsLinq("moos poop");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseTwo5CharWordsThreeWordInput()
        {
            var expected = "the esoom spoop";
            //var result = SpinningWords.Program.SpinMyWords("the moose poops");
            var result = SpinningWords.Program.SpinMyWordsLinq("the moose poops");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReverseTwo5CharWordsFourWordInput()
        {
            var expected = "the big esoom spoop";
            //var result = SpinningWords.Program.SpinMyWords("the big moose poops");
            var result = SpinningWords.Program.SpinMyWordsLinq("the big moose poops");


            Assert.AreEqual(expected, result);
        }
    }
}