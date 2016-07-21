using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CCL.Cipher.SubstitutionCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLTest.CipherTest.SubstitutionCipherTest
{
    /// <summary>
    /// Summary description for AffineCipherTest
    /// </summary>
    [TestClass]
    public class AffineCipherTest
    {

        private readonly AffineCipher<char> _affine;

        public AffineCipherTest()
        {
            _affine = new AffineCipher<char>("abcdefghijklmnopqrstuvwxyz", 1, 1);
        }

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestEncrypt()
        {
            {
                CollectionAssert.AreEqual("bcdef".ToArray(), _affine.Encrypt("abcde").ToArray());
            }
        }

        [TestMethod]
        public void TestDecrypt()
        {
            {
                CollectionAssert.AreEqual("abcde".ToArray(), _affine.Decrypt("bcdef").ToArray());
            }
        }

    }
}
