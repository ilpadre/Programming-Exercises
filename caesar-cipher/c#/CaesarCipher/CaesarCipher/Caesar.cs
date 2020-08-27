using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CaesarCipher
{
    public class Caesar
    {
        private static char[] alphabet =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
            'v', 'w', 'x', 'y', 'z', ' '
        };
        public static void Main(string[] args)
        {
            Console.WriteLine(alphabet[0]);
        }

        public static string Encrypt(int shift, string plainText)
        {
            StringBuilder cipherText = new StringBuilder();
            for (int i=0; i < plainText.Length; i++)
            {
                char currentChar = plainText.ToLower()[i];
                int charIndex = indexOf(currentChar);
                int cipherIndex = (charIndex + shift) % alphabet.Length;
                char cipherChar = alphabet[cipherIndex];
                cipherText.Append(cipherChar);
            }
            return cipherText.ToString();
        }

        public static string Decrypt(int shift, string cipherText)
        {
            StringBuilder plainText = new StringBuilder();
            for (int i = 0; i < cipherText.Length; i++)
            {
                char currentChar = cipherText.ToLower()[i];
                int cipherIndex = indexOf(currentChar);
                int plainIndex = mod(cipherIndex - shift, alphabet.Length);
                char plainChar = alphabet[plainIndex];
                plainText.Append(plainChar);
            }
            return plainText.ToString();
        }

        public static int mod(int k, int n)
        {
            return ((k %= n) < 0) ? k + n : k;
        }

        public static char[] GetAlphabet()
        {
            return alphabet;
        }

        public static int indexOf(char c)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
