using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherProject
{
    public class CaesarCipher
    {
        /* This is the Caesar's cypher program
         * Program is made with the right shift
         * It works on English letters and digits
         * Letters key should be in range between 0-26
         * Digits key should be in range between 0-10
         * You can change text variable in Main() method to enter your own text to encrypt
         * You can change lettersKey variable's value in Main() method for custom letters key
         * You can change digitsKey variable's value in Main() method for custom digits key
         * Program will print your text variable's value, encrypted and decrypted texts
         */
        static void Main()
        {
            CaesarCipher p = new CaesarCipher();


            string text = "ABCabcZz#!0139"; // text to encrypt
            int lettersKey = 1; // shift number to right for letters (0-26)
            int digitsKey = 1; // shift number to right for digits (0-10)

            // gets encrypted text
            string encryptedText = p.GetEncrypedText(text, lettersKey, digitsKey);

            // gets decrypted text
            string decryptedText = p.GetDecryptedText(encryptedText, lettersKey, digitsKey);

            // printing initial text, encrypted and decrypted texts (decrypted and initial texts must be the same)
            Console.WriteLine($"Your text: {text}");
            Console.WriteLine($"Encryped text: {encryptedText}");
            Console.WriteLine($"Decrypted text: {decryptedText}");
        }

        // Method that gets encrypted text
        public string GetEncrypedText(string text, int lettersKey, int digitsKey)
        {
            return GetText(text, lettersKey, digitsKey);
        }

        // Method that gets decrypted text
        public string GetDecryptedText(string encryptedText, int lettersKey, int digitsKey)
        {

            return GetText(encryptedText, 26 - lettersKey, 10 - digitsKey);
        }

        // Method that returns changed letter by key
        public char GetChangedLetter(char letter, int key)
        {
            char offset = char.IsUpper(letter) ? 'A' : 'a';

            return (char)((((letter + key) - offset) % 26) + offset);
        }

        // Method that returns changed digit by key
        public char GetChangedDigit(char digit, int key)
        {
            char offset = '0';

            return (char)((((digit + key) - offset) % 10) + offset);
        }

        // Method that gets corresponding text - encrypted or decrypted, depends on keys providen
        public string GetText(string text, int lettersKey, int digitsKey)
        {
            StringBuilder newText = new StringBuilder();

            foreach (char symbol in text)
            {
                switch (symbol)
                {
                    case char c when char.IsLetter(c):
                        newText.Append(GetChangedLetter(c, lettersKey));
                        break;
                    case char c when char.IsDigit(c):
                        newText.Append(GetChangedDigit(c, digitsKey));
                        break;
                    default:
                        newText.Append(symbol);
                        break;
                }
            }
            return newText.ToString();
        }
    }
}

