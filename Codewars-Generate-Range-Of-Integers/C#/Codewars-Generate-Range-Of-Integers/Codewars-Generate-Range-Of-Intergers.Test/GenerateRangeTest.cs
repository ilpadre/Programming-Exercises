using NUnit.Framework;
using Codewars_Generate_Range_Of_Integers;

namespace Codewars_Generate_Range_Of_Integers.Tests
{
    public class GenerateRangeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRange1()
        {
            var success = false;
            var range = Program.GenerateRange(2, 10, 2);
            if (range[0] == 2
                && range[1] == 4
                && range[2] == 6
                && range[3] == 8
                && range[4] == 10)
            {
                success = true;

            }
            Assert.IsTrue(success);

        }

        [Test]
        public void TestRange2()
        {
            var success = false;
            var range = Program.GenerateRange(1, 10, 3);
            if (range[0] == 1
                && range[1] == 4
                && range[2] == 7
                && range[3] == 10)
            {
                success = true;

            }
            Assert.IsTrue(success);

        }

        [Test]
        public void TestRange3()
        {
            var success = false;
            var range = Program.GenerateRange(1, 31, 6);
            if (range[0] == 1
                && range[1] == 7
                && range[2] == 13
                && range[3] == 19
                && range[4] == 25
                && range[5] == 31)
            {
                success = true;

            }
            Assert.IsTrue(success);

        }
    }
}