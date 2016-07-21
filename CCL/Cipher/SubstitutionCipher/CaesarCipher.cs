using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Cipher.SubstitutionCipher
{
    class CaesarCipher : ShiftCipher<char>
    {
        public CaesarCipher() : base("abcdefghijklmnopqrstuvwxyz", 3)
        {
        }
    }
}
