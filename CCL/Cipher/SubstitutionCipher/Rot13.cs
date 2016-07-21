using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Cipher.SubstitutionCipher
{
    class Rot13 : ShiftCipher<char>
    {
        public Rot13() : base("abcdefghijklmnopqrstuvwxyz", 13)
        {
        }
    }
}
