using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CCL.Cipher
{
    public class SimpleSubstitutionCipher<T1, T2>
    {
        private readonly Dictionary<T1, T2> _lookupTable;
        private readonly Dictionary<T2, T1> _reverseLookupTable;

        public SimpleSubstitutionCipher(IEnumerable<T1> inputAlphabet, IEnumerable<T2> outputAlphabet)
        {
            // Both alphabets must not be null.
            if (inputAlphabet == null) throw new ArgumentNullException(nameof(inputAlphabet));
            if (outputAlphabet == null) throw new ArgumentNullException(nameof(outputAlphabet));

            // Let's convert these enumerables into arrays. Try and convert if possible. 
            var inputAlphabetArray = inputAlphabet as T1[] ?? inputAlphabet.ToArray();
            var outputAlphabetArray = outputAlphabet as T2[] ?? outputAlphabet.ToArray();

            // Length of both alphabets must be same. 
            if (inputAlphabetArray.Length != outputAlphabetArray.Length) throw new ArgumentException();

            // Must not contain repeated elements. 
            if (inputAlphabetArray.Distinct().Count() != inputAlphabetArray.Length) throw new ArgumentException();
            if (outputAlphabetArray.Distinct().Count() != outputAlphabetArray.Length) throw new ArgumentException();

            // Lookup table for encryption.
            _lookupTable = new Dictionary<T1, T2>();
            // Lookup table for decryption. 
            _reverseLookupTable = new Dictionary<T2, T1>();
            for (var i = 0; i < inputAlphabetArray.Count(); i++)
            {
                _lookupTable.Add(inputAlphabetArray[i], outputAlphabetArray[i]);
                _reverseLookupTable.Add(outputAlphabetArray[i], inputAlphabetArray[i]);
            }
        }

        public IEnumerable<T2> Encrypt(IEnumerable<T1> plainText)
        {
            var cipherText = from letter in plainText select _lookupTable[letter];
            Debug.WriteLine(string.Join(", ", cipherText));
            return cipherText.AsEnumerable();
        }

        public IEnumerable<T1> Decrypt(IEnumerable<T2> cipherText)
        {
            var plainText = from letter in cipherText select _reverseLookupTable[letter];
            Debug.WriteLine(string.Join(", ", plainText));
            return plainText.AsEnumerable();
        }

    }
}