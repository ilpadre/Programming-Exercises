using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace MilitaryTime.Test
{
    public class Tests
    {

        [Test]
        public void AmTestPassesThrough()
        {
            string convertedTime = Program.TimeConversion("08:24:00AM");
            Assert.AreEqual("08:24:00", convertedTime);
        }

        [Test]
        public void PMTestPasses()
        {
            string convertedTime = Program.TimeConversion("08:24:00PM");
            Assert.AreEqual("20:24:00", convertedTime);
        }
    }
}