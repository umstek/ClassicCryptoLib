using System.Linq;
using CCL.Cipher.SubstitutionCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLTest.CipherTest.SubstitutionCipherTest
{
    /// <summary>
    ///     Summary description for ShiftCipherTest
    /// </summary>
    [TestClass]
    public class ShiftCipherTest
    {
        private readonly ShiftCipher<char> _cipher;

        public ShiftCipherTest()
        {
            _cipher = new ShiftCipher<char>("abcdefghijklmnopqrstuvwxyz", 2);
        }

        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestEncrypt()
        {
            CollectionAssert.AreEqual("vyq ujkhv".ToCharArray(), _cipher.Encrypt("two shift").ToArray());
        }

        [TestMethod]
        public void TestDecrypt()
        {
            CollectionAssert.AreEqual("two shift".ToCharArray(), _cipher.Decrypt("vyq ujkhv").ToArray());
        }
    }
}