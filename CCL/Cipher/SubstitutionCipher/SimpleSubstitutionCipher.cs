using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CCL.Cipher.SubstitutionCipher
{
    /// <summary>
    ///     Generic Simple Substitution Cipher
    ///     Encrypts plaintext by substituting each character in plaintext with a character in cipher alphabet,
    ///     which corresponds to the respective plaintext character.
    /// </summary>
    /// <typeparam name="T">Type of the Data</typeparam>
    public class SimpleSubstitutionCipher<T>
    {
        private readonly Dictionary<T, T> _lookupTable;
        private readonly Dictionary<T, T> _reverseLookupTable;

        public SimpleSubstitutionCipher(T[] inputAlphabet, T[] outputAlphabet)
        {
            Debug.WriteLine($"i/a: {string.Join(" ", inputAlphabet.Select(t => t.ToString()))}");
            Debug.WriteLine($"o/a: {string.Join(" ", outputAlphabet.Select(t => t.ToString()))}");

            // Both alphabets must not be null.
            if (inputAlphabet == null) throw new ArgumentNullException(nameof(inputAlphabet));
            if (outputAlphabet == null) throw new ArgumentNullException(nameof(outputAlphabet));

            // Length of both alphabets must be same. 
            if (inputAlphabet.Length != outputAlphabet.Length) throw new ArgumentException();

            // Must not contain repeated elements. 
            if (inputAlphabet.Distinct().Count() != inputAlphabet.Length) throw new ArgumentException();
            if (outputAlphabet.Distinct().Count() != outputAlphabet.Length) throw new ArgumentException();

            // Lookup table for encryption.
            _lookupTable = new Dictionary<T, T>();
            // Lookup table for decryption. 
            _reverseLookupTable = new Dictionary<T, T>();
            for (var i = 0; i < inputAlphabet.Length; i++)
            {
                _lookupTable.Add(inputAlphabet[i], outputAlphabet[i]);
                _reverseLookupTable.Add(outputAlphabet[i], inputAlphabet[i]);
            }
        }

        public virtual T[] Encrypt(T[] plainText)
        {
            var cipherText =
                plainText.Select(letter => _lookupTable.ContainsKey(letter) ? _lookupTable[letter] : letter).ToArray();
            Debug.WriteLine($"{string.Join(", ", plainText)} -> {string.Join(", ", cipherText)}");
            return cipherText;
        }

        public virtual T[] Decrypt(T[] cipherText)
        {
            var plainText =
                cipherText.Select(
                    letter => _reverseLookupTable.ContainsKey(letter) ? _reverseLookupTable[letter] : letter).ToArray();
            Debug.WriteLine($"{string.Join(", ", cipherText)} -> {string.Join(", ", plainText)}");
            return plainText;
        }
    }
}