using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Cipher.SubstitutionCipher
{
    class AugustusCipher : ShiftCipher<char>
    {
        public AugustusCipher(IEnumerable<char> inputAlphabet, int b) : base(inputAlphabet, b)
        {
        }

        public override IEnumerable<char> Encrypt(IEnumerable<char> plainText)
        {
            return ((string)base.Encrypt(plainText)).Replace("a", "aa");
        }

        public override IEnumerable<char> Decrypt(IEnumerable<char> cipherText)
        {
            return base.Decrypt(((string)cipherText).Replace("aa", "a"));
        }
    }
}
