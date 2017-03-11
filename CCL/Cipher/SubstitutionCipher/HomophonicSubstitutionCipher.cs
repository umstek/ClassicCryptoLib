using System;
using System.Collections.Generic;
using System.Linq;

namespace CCL.Cipher.SubstitutionCipher
{
    public class HomophonicSubstitutionCipher<T>
    {
        public enum SubstitutionPolicy : byte
        {
            Random = 0,
            Sequential = 255
        }

        private readonly Dictionary<T, int> _anchorDictionary;
        private readonly Dictionary<T, List<T>> _lookupTable;
        private readonly SubstitutionPolicy _policy;

        private readonly Random _random;
        private readonly Dictionary<T, T> _reverseLookupTable;

        public HomophonicSubstitutionCipher(Dictionary<T, T[]> substitutionTable,
            SubstitutionPolicy substitutionPolicy)
        {
            _random = new Random();

            _policy = substitutionPolicy;
            _anchorDictionary = new Dictionary<T, int>();

            // Every letter must have at least one substitute. 
            if (substitutionTable.Values.Any(en => !en.Any())) throw new ArgumentException();

            // Lookup table for encryption. Yeah, we're copying it. 
            _lookupTable = new Dictionary<T, List<T>>();
            // Lookup table for decryption. 
            _reverseLookupTable = new Dictionary<T, T>();
            foreach (var kvp in substitutionTable)
            {
                _lookupTable[kvp.Key] = kvp.Value.ToList();
                _anchorDictionary[kvp.Key] = 0; // Set last used letter position.
                foreach (var letter in kvp.Value)
                {
                    if (_reverseLookupTable.ContainsKey(letter)) throw new ArgumentException();
                    _reverseLookupTable[letter] = kvp.Key;
                }
            }
        }

        private T SequentialIndex(T letter)
            => _lookupTable[letter][_anchorDictionary[letter]++ % _lookupTable[letter].Count];

        private T RandomIndex(T letter) => _lookupTable[letter][_random.Next() % _lookupTable[letter].Count];

        public virtual T[] Encrypt(T[] plainText) => plainText.Select(letter =>
                new
                {
                    letter,
                    substitute =
                    _policy == SubstitutionPolicy.Sequential ? SequentialIndex(letter) : RandomIndex(letter)
                })
            .Select(t => _lookupTable.ContainsKey(t.letter) ? t.substitute : t.letter).ToArray();

        public virtual T[] Decrypt(T[] cipherText) => cipherText.Select(
            letter => _reverseLookupTable.ContainsKey(letter) ? _reverseLookupTable[letter] : letter).ToArray();
    }
}