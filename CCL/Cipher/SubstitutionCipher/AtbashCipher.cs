namespace CCL.Cipher.SubstitutionCipher
{
    public class AtbashCipher<T> : AffineCipher<T>
    {
        public AtbashCipher(T[] inputAlphabet)
            : base(inputAlphabet, inputAlphabet.Length - 1, inputAlphabet.Length - 1)
        {
        }
    }
}