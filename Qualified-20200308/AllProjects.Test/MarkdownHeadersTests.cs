using NUnit.Framework;
using MarkdownHeaders;

namespace AllProjects.Test
{
    public class MarkdownHeadersTests
    {
        [Test]
        public void BasicValidCases()
        {
            Assert.AreEqual("<h1>Big</h1>", Challenge.MarkdownParser("# Big"));
            Assert.AreEqual("<h2>Not As Big</h2>", Challenge.MarkdownParser("## Not As Big"));
            Assert.AreEqual("<h3>Smaller Still</h3>", Challenge.MarkdownParser("### Smaller Still"));
            Assert.AreEqual("<h6>So Tiny For a Header</h6>", Challenge.MarkdownParser("###### So Tiny For a Header"));
        }
        [Test]
        public void BasicInvalidCases()
        {
            Assert.AreEqual("#NoSpace", Challenge.MarkdownParser("#NoSpace"));
            Assert.AreEqual("#NoS", Challenge.MarkdownParser("#NoS"));
            Assert.AreEqual("Behind # The Scenes", Challenge.MarkdownParser("Behind # The Scenes"));
            Assert.AreEqual("Wizard# Behind The Curtain", Challenge.MarkdownParser("Wizard# Behind The Curtain"));
        }
        [Test]
        public void EdgeCases()
        {
            Assert.AreEqual("<h3>### Double Triple Header</h3>", Challenge.MarkdownParser("### ### Double Triple Header"));
            Assert.AreEqual("####### Snow White and the Seven Hashtags", Challenge.MarkdownParser("####### Snow White and the Seven Hashtags"));
            Assert.AreEqual("<h4>Space Jam</h4>", Challenge.MarkdownParser("  #### Space Jam"));
            Assert.AreEqual("<h2>Lost In Space</h2>", Challenge.MarkdownParser("  ##          Lost In Space      "));
            Assert.AreEqual("<h1>Far      Out, Dude</h1>", Challenge.MarkdownParser("# Far      Out, Dude"));
        }
    }
}
