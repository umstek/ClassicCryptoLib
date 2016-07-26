using System.Linq;
using CCL.Cipher.SubstitutionCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLTest.CipherTest.SubstitutionCipherTest
{
    /// <summary>
    ///     Summary description for CaesarCipherTest
    /// </summary>
    [TestClass]
    public class CaesarCipherTest
    {
        private readonly CaesarCipher _cipher;

        public CaesarCipherTest()
        {
            _cipher = new CaesarCipher();
        }

        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestEncrypt()
        {
            CollectionAssert.AreEqual("crpelh dsrfdobsvh".ToCharArray(), _cipher.Encrypt("zombie apocalypse").ToArray());
        }

        [TestMethod]
        public void TestDecrypt()
        {
            CollectionAssert.AreEqual("zombie apocalypse".ToCharArray(), _cipher.Decrypt("crpelh dsrfdobsvh").ToArray());
        }
    }
}