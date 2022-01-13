using NUnit.Framework;

namespace Project.Test
{
    public class ProjectTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenGen0_Population0()
        {
            Assert.AreEqual(1, Program.rabbitPopulation(0));
        }

        [Test]
        public void GivenGen1_Population1()
        {
            Assert.AreEqual(1, Program.rabbitPopulation(1));
        }

        [Test]
        public void GivenGen2_Population2()
        {
            Assert.AreEqual(2, Program.rabbitPopulation(2));
        }

        [Test]
        public void GivenGen3_Population3()
        {
            Assert.AreEqual(3, Program.rabbitPopulation(3));
        }

        [Test]
        public void GivenGen4_Population5()
        {
            Assert.AreEqual(5, Program.rabbitPopulation(4));
        }

        [Test]
        public void GivenGen7_Population21()
        {
            Assert.AreEqual(21, Program.rabbitPopulation(7));
        }

    }
}