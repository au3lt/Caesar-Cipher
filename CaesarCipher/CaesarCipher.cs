using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherProject
{
    public class CaesarCipher
    {
        static void Main(string[] args)
        {
            CaesarCipher p = new CaesarCipher();

            string text = "ABCabcZz#!0139";
            int lettersKey = 15;
            int digitsKey = 4;

            string encryptedText = p.GetEncrypedText(text, lettersKey, digitsKey);
            string decryptedText = p.GetDecryptedText(encryptedText, lettersKey, digitsKey);

            Console.WriteLine($"Your text: {text}");
            Console.WriteLine($"Encryped text: {encryptedText}");
            Console.WriteLine($"Decrypted text: {decryptedText}");
        }

        public string GetEncrypedText(string text, int lettersKey, int digitsKey)
        {
            return GetText(text, lettersKey, digitsKey);
        }

        public string GetDecryptedText(string encryptedText, int lettersKey, int digitsKey)
        {

            return GetText(encryptedText, 26 - lettersKey, 10 - digitsKey);
        }

        public Char getChangedLetter(char letter, int key)
        {
            char offset = Char.IsUpper(letter) ? 'A' : 'a';

            return (char)((((letter + key) - offset) % 26) + offset);
        }

        public Char getChangedDigit(char digit, int key)
        {
            char offset = '0';

            return (char)((((digit + key) - offset) % 10) + offset);
        }

        public string GetText(string text, int lettersKey, int digitsKey)
        {
            string newText = "";

            foreach (char symbol in text)
            {
                switch (symbol)
                {
                    case char c when Char.IsLetter(c):
                        newText += getChangedLetter(c, lettersKey);
                        break;
                    case char c when Char.IsDigit(c):
                        newText += getChangedDigit(c, digitsKey);
                        break;
                    default:
                        newText += symbol;
                        break;
                }
            }
            return newText;
        }
    }
}

