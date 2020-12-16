
using NUnit.Framework;
using Palindromish;

namespace Palindromish_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BasicSpecWordIsNotNineLong_ReturnsFalse()
        {
            string word = "blah";
            bool isMatch = Program.IsMatchBasic(word);
            Assert.IsFalse(isMatch);
        }


        [Test]
        public void BasicSpecWordIsNineLongAndDoesNotContainELI_ReturnsFalse()
        {
            string word = "blahblaha";
            bool isMatch = Program.IsMatchBasic(word);
            Assert.IsFalse(isMatch);
        }


        [Test]
        public void BasicSpecWordIsNineLongAndContainsELIAndNoPalindrome_ReturnsFalse()
        {
            string word = "blaeliaha";
            bool isMatch = Program.IsMatchBasic(word);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void BasicSpecWordIsNineLongAndContainsELIAndIsPalindrome_ReturnsTrue()
        {
            string word = "blaelialb";
            bool isMatch = Program.IsMatchBasic(word);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void BasicSpecWordKnownSolution_ReturnsTrue()
        {
            string word = "timelimit";
            bool isMatch = Program.IsMatchBasic(word);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void EnhancementOneEmptyword_ReturnsFalse()
        {
            string word = string.Empty;
            bool isMatch = Program.IsMatchEnancement1(word);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void EnhancementOneWordLessThanThree_ReturnsFalse()
        {
            string word = "ab";
            bool isMatch = Program.IsMatchEnancement1(word);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void EnhancementOneWordEqualsThreeNotELI_ReturnsFalse()
        {
            string word = "abc";
            bool isMatch = Program.IsMatchEnancement1(word);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void EnhancementOneWordEqualsThreeIsELI_ReturnsTrue()
        {
            string word = "eli";
            bool isMatch = Program.IsMatchEnancement1(word);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void EnhancementOneWordEqualsFour_ReturnsFalse()
        {
            string word = "elia";
            bool isMatch = Program.IsMatchEnancement1(word);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void EnhancementOneWordLongEnoughButwordNotFound_ReturnsFalse()
        {
            string word = "abcba";
            bool isMatch = Program.IsMatchEnancement1(word);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void EnhancementOneWordFiveContainswordNoPalindromish_ReturnsFalse()
        {
            string word = "aelib";
            bool isMatch = Program.IsMatchEnancement1(word);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void EnhancementOneWordFiveContainswordIsPalindromish_ReturnsTrue()
        {
            string word = "aelia";
            bool isMatch = Program.IsMatchEnancement1(word);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void EnhancementOneWordIsSolution_ReturnsTrue()
        {
            string word = "timelimit";
            bool isMatch = Program.IsMatchEnancement1(word);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void EnhancementTwoWordIsSolution_ReturnsTrue()
        {
            string word = "timelimit";
            string pattern = "eli";
            bool isMatch = Program.IsMatchEnancement2(word, pattern);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void EnhancementTwoPatternLengthFiveIsPalindromish_ReturnsTrue()
        {
            string word = "timelimit";
            string pattern = "melim";
            bool isMatch = Program.IsMatchEnancement2(word, pattern);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void EnhancementTwoPatternLengthFiveIsNotPalindromish_ReturnsFalse()
        {
            string word = "tiamelimita";
            string pattern = "melim";
            bool isMatch = Program.IsMatchEnancement2(word, pattern);
            Assert.IsFalse(isMatch);
        }

    }
}