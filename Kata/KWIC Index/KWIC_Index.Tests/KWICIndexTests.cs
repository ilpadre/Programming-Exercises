using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace KWIC_Index.Tests
{
    public class Tests
    {
        private List<string> emptyTest = new List<string>();
        public List<string> oneTitleOneWord = new List<string>();
        public List<string> oneTitleMultipleWords = new List<string>();
        public List<string> multipleTitles = new List<string>();
     
        [SetUp]
        public void Setup()
        {
            oneTitleOneWord.Add("Leviathan");

            oneTitleMultipleWords.Add("Gone with the wind");

            multipleTitles.Add("Gone with the wind");
            multipleTitles.Add("The wind in the willows");
            multipleTitles.Add("A Scanner Darkly");
            multipleTitles.Add("The snows of Kilimanjaro");
            multipleTitles.Add("The short happy life of Francis Macomber");
        }

        [Test]
        public void EmptyListProducesEmptyIndex()
        {
            KWICIndex indexObject = new KWICIndex();
            var index = indexObject.CreateIndex(emptyTest);

            Assert.AreEqual(0, index.Count);
        }

        [Test]
        public void OneTitleFourWordsNoStopWordsProducesFourLineIndex()
        {
            KWICIndex indexObject = new KWICIndex();
            var index = indexObject.CreateIndex(oneTitleMultipleWords);

            Assert.AreEqual(4, index.Count);
            Assert.AreEqual("Gone with the wind", index[0]);
            Assert.AreEqual("with the wind Gone", index[1]);
            Assert.AreEqual("the wind Gone with", index[2]);
            Assert.AreEqual("wind Gone with the", index[3]);
        }

        [Test]
        public void MultipleTitlesNoStopWordsTwentyThreeLines()
        {
            KWICIndex indexObject = new KWICIndex();
            var index = indexObject.CreateIndex(multipleTitles);

            Assert.AreEqual(23, index.Count);

        }
    }
}