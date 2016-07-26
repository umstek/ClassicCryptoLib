using System;
using System.Collections.Generic;
using System.Linq;

namespace CCL.Cipher.SubstitutionCipher
{
    /// <summary>
    ///     The Affine Cipher
    /// </summary>
    /// <typeparam name="T">Type of the data being encrypted. </typeparam>
    public class AffineCipher<T> : SimpleSubstitutionCipher<T>
    {
        public AffineCipher(IEnumerable<T> inputAlphabet, int a, int b)
            : base(inputAlphabet, AffineAlphabet(inputAlphabet, a, b))
        {
        }

        private static IEnumerable<T> AffineAlphabet(IEnumerable<T> inputAlphabet, int a, int b)
        {
            if (a <= 0 || b < 0) throw new ArgumentException();
            if (!AreCoprime(a, 26)) throw new ArgumentException();

            var enumerable = inputAlphabet as T[] ?? inputAlphabet.ToArray();
            return from index in Enumerable.Range(0, enumerable.Length)
                select enumerable[(a*index + b)%enumerable.Length];
        }

        private static bool AreCoprime(int a, int b)
        {
            if (a%2 == 0 && b%2 == 0) return false;
            for (var i = 3; i <= Math.Min(a, b); i += 2) if (a%i == 0 && b%i == 0) return false;

            return true;
        }
    }
}