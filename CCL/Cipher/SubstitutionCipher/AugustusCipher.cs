namespace CCL.Cipher.SubstitutionCipher
{
    /// <summary>
    ///     The Augustus Cipher
    ///     The Augustus Cipher was invented by Julius Caesar's nephew, Augustus who thought Caesar Cipher was too complex.
    ///     This Cipher features a shift cipher with a shift of +1, but replaces 'z' with 'aa' instead of just 'a'.
    /// </summary>
    public class AugustusCipher : ShiftCipher<char>
    {
        public AugustusCipher() : base("abcdefghijklmnopqrstuvwxyz".ToCharArray(), 1)
        {
        }

        public override char[] Encrypt(char[] plainText)
            => new string(base.Encrypt(plainText)).Replace("a", "aa").ToCharArray();

        public override char[] Decrypt(char[] cipherText)
            => base.Decrypt(new string(cipherText).Replace("aa", "a").ToCharArray());
    }
}