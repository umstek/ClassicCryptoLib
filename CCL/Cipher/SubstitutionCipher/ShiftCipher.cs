namespace CCL.Cipher.SubstitutionCipher
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ShiftCipher<T> : AffineCipher<T>
    {
        public ShiftCipher(T[] inputAlphabet, int b) : base(inputAlphabet, 1, b)
        {
        }
    }
}