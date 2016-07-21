using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CCL.Cipher.SubstitutionCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLTest.CipherTest.SubstitutionCipherTest
{
    /// <summary>
    /// Summary description for AugustusCipherTest
    /// </summary>
    [TestClass]
    public class AugustusCipherTest
    {
        private readonly AugustusCipher _cipher;
        public AugustusCipherTest()
        {
            _cipher = new AugustusCipher();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestEncrypt()
        {
            CollectionAssert.AreEqual("aafcsb".ToCharArray(), _cipher.Encrypt("zebra").ToArray());
        }

        [TestMethod]
        public void TestDecrypt()
        {
            CollectionAssert.AreEqual("zebra".ToCharArray(), _cipher.Decrypt("aafcsb").ToArray());
        }

    }
}
