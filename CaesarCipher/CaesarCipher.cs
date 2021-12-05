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
         * It works on English letters and digits from 0-9
         * Letters or keys digits greater than number of letters or digits should not be used or negative keys too
         * You can change text variable in Main() method to enter your own text to encrypt
         * You can change letterKey variable in Main() method to customize your key to shift letters to the right
         * You can change digits variable in Main() method to customize your key to shift digits to the right
         * Program will print your text variable, encrypted text and decrypted text
         */
        static void Main()
        {
            CaesarCipher p = new CaesarCipher();


            string text = "ABCabcZz#!0139"; // text to encrypt
            int lettersKey = 15; // shift number to right for letters
            int digitsKey = 4; // shift number to right for digits

            // gets encrypted text
            string encryptedText = p.GetEncrypedText(text, lettersKey, digitsKey);

            // gets decrypted text
            string decryptedText = p.GetDecryptedText(encryptedText, lettersKey, digitsKey);

            // printing initial text, encrypted and decrypted text (decrypted text and initial must be the same
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
            string newText = "";

            foreach (char symbol in text)
            {
                switch (symbol)
                {
                    case char c when char.IsLetter(c):
                        newText += GetChangedLetter(c, lettersKey);
                        break;
                    case char c when char.IsDigit(c):
                        newText += GetChangedDigit(c, digitsKey);
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

