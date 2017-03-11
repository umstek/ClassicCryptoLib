namespace CCL.Cipher.SubstitutionCipher
{
    /// <summary>
    /// </summary>
    public class CaesarCipher : ShiftCipher<char>
    {
        public CaesarCipher() : base("abcdefghijklmnopqrstuvwxyz".ToCharArray(), 3)
        {
        }
    }
}