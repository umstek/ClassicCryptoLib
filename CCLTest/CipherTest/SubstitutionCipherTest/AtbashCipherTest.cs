using System.Linq;
using CCL.Cipher.SubstitutionCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLTest.CipherTest.SubstitutionCipherTest
{
    /// <summary>
    ///     Summary description for AtbashCipherTest
    /// </summary>
    [TestClass]
    public class AtbashCipherTest
    {
        private readonly AtbashCipher<char> _cipher;

        public AtbashCipherTest()
        {
            _cipher = new AtbashCipher<char>("abcdefghijklmnopqrstuvwxyz");
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
                CollectionAssert.AreEqual("low draziw".ToArray(), _cipher.Encrypt("old wizard").ToArray());
            }
        }

        [TestMethod]
        public void TestDecrypt()
        {
            {
                CollectionAssert.AreEqual("old wizard".ToArray(), _cipher.Decrypt("low draziw").ToArray());
            }
        }
    }
}