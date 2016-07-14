﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CCL.Cipher.SubstitutionCipher
{
    public class SimpleSubstitutionCipher<T>
    {
        private readonly Dictionary<T, T> _lookupTable;
        private readonly Dictionary<T, T> _reverseLookupTable;

        public SimpleSubstitutionCipher(IEnumerable<T> inputAlphabet, IEnumerable<T> outputAlphabet)
        {
            // Both alphabets must not be null.
            if (inputAlphabet == null) throw new ArgumentNullException(nameof(inputAlphabet));
            if (outputAlphabet == null) throw new ArgumentNullException(nameof(outputAlphabet));

            // Let's convert these enumerables into arrays. Try and convert if possible. 
            var inputAlphabetArray = inputAlphabet as T[] ?? inputAlphabet.ToArray();
            var outputAlphabetArray = outputAlphabet as T[] ?? outputAlphabet.ToArray();

            // Length of both alphabets must be same. 
            if (inputAlphabetArray.Length != outputAlphabetArray.Length) throw new ArgumentException();

            // Must not contain repeated elements. 
            if (inputAlphabetArray.Distinct().Count() != inputAlphabetArray.Length) throw new ArgumentException();
            if (outputAlphabetArray.Distinct().Count() != outputAlphabetArray.Length) throw new ArgumentException();

            // Lookup table for encryption.
            _lookupTable = new Dictionary<T, T>();
            // Lookup table for decryption. 
            _reverseLookupTable = new Dictionary<T, T>();
            for (var i = 0; i < inputAlphabetArray.Count(); i++)
            {
                _lookupTable.Add(inputAlphabetArray[i], outputAlphabetArray[i]);
                _reverseLookupTable.Add(outputAlphabetArray[i], inputAlphabetArray[i]);
            }
        }

        public IEnumerable<T> Encrypt(IEnumerable<T> plainText)
        {
            var cipherText = from letter in plainText
                             select _lookupTable.ContainsKey(letter) ? _lookupTable[letter] : letter;
            Debug.WriteLine(string.Join(", ", cipherText));
            return cipherText.AsEnumerable();
        }

        public IEnumerable<T> Decrypt(IEnumerable<T> cipherText)
        {
            var plainText = from letter in cipherText
                            select _reverseLookupTable.ContainsKey(letter) ? _reverseLookupTable[letter] : letter;
            Debug.WriteLine(string.Join(", ", plainText));
            return plainText.AsEnumerable();
        }

    }
}