using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Cipher.SubstitutionCipher
{
    class ShiftCipher<T> : AffineCipher<T>
    {
        public ShiftCipher(IEnumerable<T> inputAlphabet, int b) : base(inputAlphabet, 0, b)
        {
        }
    }
}
