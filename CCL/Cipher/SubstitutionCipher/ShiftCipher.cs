using System.Collections.Generic;

namespace CCL.Cipher.SubstitutionCipher
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ShiftCipher<T> : AffineCipher<T>
    {
        public ShiftCipher(IEnumerable<T> inputAlphabet, int b) : base(inputAlphabet, 1, b)
        {
        }
    }
}