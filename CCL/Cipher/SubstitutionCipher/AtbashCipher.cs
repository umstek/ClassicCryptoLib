using System.Collections.Generic;
using System.Linq;

namespace CCL.Cipher.SubstitutionCipher
{
    public class AtbashCipher<T> : AffineCipher<T>
    {
        public AtbashCipher(IEnumerable<T> inputAlphabet)
            : base(inputAlphabet, inputAlphabet.Count() - 1, inputAlphabet.Count() - 1)
        {
        }
    }
}