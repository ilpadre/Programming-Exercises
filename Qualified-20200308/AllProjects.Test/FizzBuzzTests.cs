using NUnit.Framework;
using FizzBuzz;

namespace AllProjects.Test
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void ShouldWorkFor1()
        {
            Assert.AreEqual("1", Challenge.FizzBuzz(1));
        }
        [Test]
        public void ShouldWorkFor2()
        {
            Assert.AreEqual("1\n2", Challenge.FizzBuzz(2));
        }
        [Test]
        public void ShouldWorkFor3()
        {
            Assert.AreEqual("1\n2\nFizz", Challenge.FizzBuzz(3));
        }
        [Test]
        public void ShouldWorkFor5()
        {
            Assert.AreEqual("1\n2\nFizz\n4\nBuzz", Challenge.FizzBuzz(5));
        }
        [Test]
        public void ShouldWorkFor20()
        {
            Assert.AreEqual("1\n2\nFizz\n4\nBuzz\nFizz\n7\n8\nFizz\nBuzz\n11\nFizz\n13\n14\nFizzBuzz\n16\n17\nFizz\n19\nBuzz", Challenge.FizzBuzz(20));
        }
        [Test]
        public void ShouldWorkFor200()
        {
            Assert.AreEqual("1\n2\nFizz\n4\nBuzz\nFizz\n7\n8\nFizz\nBuzz\n11\nFizz\n13\n14\nFizzBuzz\n16\n17\nFizz\n19\nBuzz\nFizz\n22\n23\nFizz\nBuzz\n26\nFizz\n28\n29\nFizzBuzz\n31\n32\nFizz\n34\nBuzz\nFizz\n37\n38\nFizz\nBuzz\n41\nFizz\n43\n44\nFizzBuzz\n46\n47\nFizz\n49\nBuzz\nFizz\n52\n53\nFizz\nBuzz\n56\nFizz\n58\n59\nFizzBuzz\n61\n62\nFizz\n64\nBuzz\nFizz\n67\n68\nFizz\nBuzz\n71\nFizz\n73\n74\nFizzBuzz\n76\n77\nFizz\n79\nBuzz\nFizz\n82\n83\nFizz\nBuzz\n86\nFizz\n88\n89\nFizzBuzz\n91\n92\nFizz\n94\nBuzz\nFizz\n97\n98\nFizz\nBuzz\n101\nFizz\n103\n104\nFizzBuzz\n106\n107\nFizz\n109\nBuzz\nFizz\n112\n113\nFizz\nBuzz\n116\nFizz\n118\n119\nFizzBuzz\n121\n122\nFizz\n124\nBuzz\nFizz\n127\n128\nFizz\nBuzz\n131\nFizz\n133\n134\nFizzBuzz\n136\n137\nFizz\n139\nBuzz\nFizz\n142\n143\nFizz\nBuzz\n146\nFizz\n148\n149\nFizzBuzz\n151\n152\nFizz\n154\nBuzz\nFizz\n157\n158\nFizz\nBuzz\n161\nFizz\n163\n164\nFizzBuzz\n166\n167\nFizz\n169\nBuzz\nFizz\n172\n173\nFizz\nBuzz\n176\nFizz\n178\n179\nFizzBuzz\n181\n182\nFizz\n184\nBuzz\nFizz\n187\n188\nFizz\nBuzz\n191\nFizz\n193\n194\nFizzBuzz\n196\n197\nFizz\n199\nBuzz", Challenge.FizzBuzz(200));
        }
        [Test]
        public void ShouldReturnInvalidOn0()
        {
            Assert.AreEqual("Invalid", Challenge.FizzBuzz(0));
        }
        [Test]
        public void ShouldReturnInvalidOnNegativeInput()
        {
            Assert.AreEqual("Invalid", Challenge.FizzBuzz(-3));
        }
    }
}
