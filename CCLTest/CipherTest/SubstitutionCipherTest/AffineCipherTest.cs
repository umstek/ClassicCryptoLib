using System.Linq;
using CCL.Cipher.SubstitutionCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLTest.CipherTest.SubstitutionCipherTest
{
    /// <summary>
    ///     Summary description for AffineCipherTest
    /// </summary>
    [TestClass]
    public class AffineCipherTest
    {
        private readonly AffineCipher<char> _cipher;

        public AffineCipherTest()
        {
            _cipher = new AffineCipher<char>("abcdefghijklmnopqrstuvwxyz", 5, 8);
        }

        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestEncrypt()
        {
            {
                CollectionAssert.AreEqual("ihhwvc swfrcp".ToArray(), _cipher.Encrypt("affine cipher").ToArray());
            }
        }

        [TestMethod]
        public void TestDecrypt()
        {
            {
                CollectionAssert.AreEqual("affine cipher".ToArray(), _cipher.Decrypt("ihhwvc swfrcp").ToArray());
            }
        }
    }
}