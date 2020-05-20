using NUnit.Framework;
using MiddleCharacter;

namespace AllProjects.Test
{
    [TestFixture]
    public class MiddleCharacterTests
    {
        [Test]
        public void ShouldHandleASingleCharacter()
        {
            Assert.AreEqual("A", Challenge.GetMiddle("A"));
            Assert.AreEqual("b", Challenge.GetMiddle("b"));
            Assert.AreEqual("1", Challenge.GetMiddle("1"));
        }
        [Test]
        public void ShouldHandleTwoCharacters()
        {
            Assert.AreEqual("ab", Challenge.GetMiddle("ab"));
            Assert.AreEqual("Of", Challenge.GetMiddle("Of"));
            Assert.AreEqual("42", Challenge.GetMiddle("42"));
        }
        [Test]
        public void ShouldHandleLongEvenStrings()
        {
            Assert.AreEqual("dd", Challenge.GetMiddle("middle"));
            Assert.AreEqual("yb", Challenge.GetMiddle("turkeyburger"));
            Assert.AreEqual("pp", Challenge.GetMiddle("yippppppeeee"));
        }
        [Test]
        public void ShouldHandleLongOddStrings()
        {
            Assert.AreEqual("t", Challenge.GetMiddle("testing"));
            Assert.AreEqual("i", Challenge.GetMiddle("smile"));
            Assert.AreEqual("E", Challenge.GetMiddle("CHEEEEEEEEESE"));
        }
    }
}
