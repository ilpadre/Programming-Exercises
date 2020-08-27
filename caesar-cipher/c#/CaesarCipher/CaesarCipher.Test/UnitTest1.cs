using NUnit.Framework;

namespace CaesarCipher.Test
{
    public class CaesarCipherTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetAlphabet()
        {
            char[] alphabet = Caesar.GetAlphabet();
            Assert.AreEqual('a', alphabet[0], "Error in creating alphabet array");
        }

        [Test]
        public void EncryptOneCharA()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string cipherText = Caesar.Encrypt(3, "a");
            Assert.AreEqual("d", cipherText, "Error in encrypting a single character at beginning of alphabet");
        }

        [Test]
        public void EncryptOneCharZ()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string cipherText = Caesar.Encrypt(3, "z");
            Assert.AreEqual("b", cipherText, "Error in encrypting a single character at end of alphabet");
        }

        [Test]
        public void EncryptTwoCharAB()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string cipherText = Caesar.Encrypt(3, "ab");
            Assert.AreEqual("de", cipherText, "Error in encrypting two characters at beginning of alphabet");
        }

        [Test]
        public void EncryptTwoCharYZ()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string cipherText = Caesar.Encrypt(3, "yz");
            Assert.AreEqual("ab", cipherText, "Error in encrypting two characters at end of alphabet");
        }

        [Test]
        public void EncryptOneWordAllCaps()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string cipherText = Caesar.Encrypt(3, "MOOSEPOOP");
            Assert.AreEqual("prrvhsrrs", cipherText, "Error in encrypting one word all caps");
        }

        [Test]
        public void EncryptPhraseWithShift3()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string cipherText = Caesar.Encrypt(3, "One Love");
            Assert.AreEqual("rqhcoryh", cipherText, "Error in encrypting a phrase with shift 3");
        }

        [Test]
        public void EncryptPhraseWithShift20()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string cipherText = Caesar.Encrypt(20, "One Love");
            Assert.AreEqual("hgytehoy", cipherText, "Error in encrypting a phrase with shift 20");
        }

        [Test]
        public void EncryptPhraseWithShift200()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string cipherText = Caesar.Encrypt(290, "One Love");
            Assert.AreEqual("hgytehoy", cipherText, "Error in encrypting a phrase with shift 20");
        }

        [Test]
        public void DecryptOneCharD()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string cipherText = Caesar.Decrypt(3, "d");
            Assert.AreEqual("a", cipherText, "Error in decrypting a single character at beginning of alphabet");
        }

        [Test]
        public void DecryptAndThenDecryptOneChar()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string decryptedText = Caesar.Decrypt(3, Caesar.Encrypt(3, "d")); 
            Assert.AreEqual("d", decryptedText, "Error in encrypting and then decrypting a single character at beginning of alphabet");
        }

        [Test]
        public void DecryptAndThenDecryptASingleWordFollowedBySpace()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string decryptedText = Caesar.Decrypt(3, Caesar.Encrypt(3, "What "));
            Assert.AreEqual("what ", decryptedText, "Error in encrypting and then decrypting a single word followed by a space");
        }

        [Test]
        public void DecryptAndThenDecryptALongPhrase()
        {
            char[] alphabet = Caesar.GetAlphabet();
            string decryptedText = Caesar.Decrypt(3, Caesar.Encrypt(3, "What is the square root of a duck"));
            Assert.AreEqual("what is the square root of a duck", decryptedText, "Error in encrypting and then decrypting a long phrase");
        }
    }
}