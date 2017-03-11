namespace CCL.Cipher.SubstitutionCipher
{
    /// <summary>
    /// </summary>
    public class Rot13Cipher : ShiftCipher<char>
    {
        public Rot13Cipher() : base("abcdefghijklmnopqrstuvwxyz".ToCharArray(), 13)
        {
        }
    }
}