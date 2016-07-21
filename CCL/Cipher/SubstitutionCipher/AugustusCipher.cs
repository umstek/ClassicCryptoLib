using System.Collections.Generic;
using System.Linq;

namespace CCL.Cipher.SubstitutionCipher
{
    /// <summary>
    ///     The Augustus Cipher
    ///     The Augustus Cipher was invented by Julius Caesar's nephew, Augustus who thought Caesar Cipher was too complex.
    ///     This Cipher features a shift cipher with a shift of +1, but replaces 'z' with 'aa' instead of just 'a'.
    /// </summary>
    public class AugustusCipher : ShiftCipher<char>
    {
        public AugustusCipher() : base("abcdefghijklmnopqrstuvwxyz", 1)
        {
        }

        public override IEnumerable<char> Encrypt(IEnumerable<char> plainText)
        {
            return new string(base.Encrypt(plainText).ToArray()).Replace("a", "aa");
        }

        public override IEnumerable<char> Decrypt(IEnumerable<char> cipherText)
        {
            return base.Decrypt(new string(cipherText.ToArray()).Replace("aa", "a"));
        }
    }
}