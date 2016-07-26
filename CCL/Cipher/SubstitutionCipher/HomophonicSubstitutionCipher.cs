using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Cipher.SubstitutionCipher
{
    public class HomophonicSubstitutionCipher<T>
    {
        private readonly Dictionary<T, List<T>> _lookupTable;
        private readonly Dictionary<T, T> _reverseLookupTable;
        private readonly Dictionary<T, int> _anchorDictionary;
        private readonly SubstitutionPolicy _policy;

        public HomophonicSubstitutionCipher(IDictionary<T, IEnumerable<T>> substitutionTable, SubstitutionPolicy substitutionPolicy)
        {

            Debug.WriteLine("i/a letter: substitute1, substitute2, ...");
            foreach (var kvp in substitutionTable)
            {
                Debug.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
            }

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
        {
            return _lookupTable[letter][_anchorDictionary[letter]++ % _lookupTable[letter].Count];
        }

        private T RandomIndex(T letter)
        {
            return _lookupTable[letter][new Random().Next() % _lookupTable[letter].Count];
        }

        public virtual IEnumerable<T> Encrypt(IEnumerable<T> plainText)
        {
            var cipherText = from letter in plainText
                             let substitute = _policy == SubstitutionPolicy.Sequential ? SequentialIndex(letter) : RandomIndex(letter)
                             select _lookupTable.ContainsKey(letter) ? substitute : letter;
            Debug.WriteLine($"{string.Join(", ", plainText)} -> {string.Join(", ", cipherText)}");
            return cipherText.AsEnumerable();
        }

        public virtual IEnumerable<T> Decrypt(IEnumerable<T> cipherText)
        {
            var plainText = from letter in cipherText
                            select _reverseLookupTable.ContainsKey(letter) ? _reverseLookupTable[letter] : letter;
            Debug.WriteLine($"{string.Join(", ", cipherText)} -> {string.Join(", ", plainText)}");
            return plainText.AsEnumerable();
        }

        public enum SubstitutionPolicy : byte
        {
            Random = 0,
            Sequential = 255
        }
    }
}
