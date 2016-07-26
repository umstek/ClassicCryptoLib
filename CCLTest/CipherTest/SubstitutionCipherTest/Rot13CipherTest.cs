using System.Linq;
using CCL.Cipher.SubstitutionCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLTest.CipherTest.SubstitutionCipherTest
{
    /// <summary>
    ///     Summary description for Rot13CipherTest
    /// </summary>
    [TestClass]
    public class Rot13CipherTest
    {
        private readonly Rot13Cipher _cipher;

        public Rot13CipherTest()
        {
            _cipher = new Rot13Cipher();
        }

        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestEncrypt()
        {
            CollectionAssert.AreEqual("puvpxra".ToCharArray(), _cipher.Encrypt("chicken").ToArray());
        }

        [TestMethod]
        public void TestDecrypt()
        {
            CollectionAssert.AreEqual("chicken".ToCharArray(), _cipher.Decrypt("puvpxra").ToArray());
        }
    }
}