using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CaesarCipherProject;

namespace CaesarCipherTesting
{
    [TestClass]
    public class CaesarCipherUnitTests
    {
        [DataTestMethod]
        [DataRow("ABCabcZz#!0139", 1, 1, "BCDbcdAa#!1240")]
        [DataRow("ABCabcZz#!0139", 2, 3, "CDEcdeBb#!3462")]
        [DataRow("ABCabcZz#!0139", 26, 10, "ABCabcZz#!0139")]
        [DataRow("ABCabcZz#!0139", 15, 4, "PQRpqrOo#!4573")]
        public void GetEncryptedTextTest(string text, int lettersKey, int digitsKey, string expected)
        {
            CaesarCipher caesarCipher = new CaesarCipher();
            string encryptedText = caesarCipher.GetEncrypedText(text, lettersKey, digitsKey);
            Assert.AreEqual(expected, encryptedText);
        }

        [DataTestMethod]
        [DataRow("BCDbcdAa#!1240", 1, 1, "ABCabcZz#!0139")]
        [DataRow("CDEcdeBb#!3462", 2, 3, "ABCabcZz#!0139")]
        [DataRow("ABCabcZz#!0139", 26, 10, "ABCabcZz#!0139")]
        [DataRow("PQRpqrOo#!4573", 15, 4, "ABCabcZz#!0139")]
        public void GetDecryptedTextTest(string text, int lettersKey, int digitsKey, string expected)
        {
            CaesarCipher caesarCipher = new CaesarCipher();
            string decryptedText = caesarCipher.GetDecryptedText(text, lettersKey, digitsKey);
            Assert.AreEqual(expected, decryptedText);
        }
    }
}
