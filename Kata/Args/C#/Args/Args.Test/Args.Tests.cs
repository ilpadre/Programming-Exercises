using NUnit.Framework;

namespace Args.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetValForOneBool()
        {
            string[] args = {"l", "true"};
            Args.Parse("l", args);
            var val = Args.GetValForArg('l');
            Assert.AreEqual("true", val, "Incorrect value returned");
        }
    }
}