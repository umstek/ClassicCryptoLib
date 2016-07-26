using System.Collections.Generic;
using CCL.Cipher.SubstitutionCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLTest.CipherTest.SubstitutionCipherTest
{
    /// <summary>
    ///     Summary description for HomophonicSubstitutionCipherTest
    /// </summary>
    [TestClass]
    public class HomophonicSubstitutionCipherTest
    {
        private readonly HomophonicSubstitutionCipher<char> _cipherR;
        private readonly HomophonicSubstitutionCipher<char> _cipherS;

        public HomophonicSubstitutionCipherTest()
        {
            _cipherS = new HomophonicSubstitutionCipher<char>( // Arbitrary shop-cipher. lol. 
                new Dictionary<char, IEnumerable<char>>
                {
                    {'0', "aku"},
                    {'1', "blv"},
                    {'2', "cmw"},
                    {'3', "dnx"},
                    {'4', "eoy"},
                    {'5', "fpz"},
                    {'6', "gq"},
                    {'7', "hr"},
                    {'8', "is"},
                    {'9', "jt"}
                },
                HomophonicSubstitutionCipher<char>.SubstitutionPolicy.Sequential
                );

            _cipherR = new HomophonicSubstitutionCipher<char>( // Arbitrary shop-cipher. Random.
                new Dictionary<char, IEnumerable<char>>
                {
                    {'0', "aku"},
                    {'1', "blv"},
                    {'2', "cmw"},
                    {'3', "dnx"},
                    {'4', "eoy"},
                    {'5', "fpz"},
                    {'6', "gq"},
                    {'7', "hr"},
                    {'8', "is"},
                    {'9', "jt"}
                },
                HomophonicSubstitutionCipher<char>.SubstitutionPolicy.Random
                );
        }

        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestRandomED()
        {
            var plaintext1 = "0123456789";
            var plaintext2 = string.Join("", _cipherR.Decrypt(_cipherR.Encrypt(plaintext1)));
            Assert.AreEqual(plaintext1, plaintext2);
        }

        [TestMethod]
        public void TestSequentialED()
        {
            var plaintext1 = "0123456789";
            var plaintext2 = string.Join("", _cipherS.Decrypt(_cipherS.Encrypt(plaintext1)));
            Assert.AreEqual(plaintext1, plaintext2);
        }
    }
}