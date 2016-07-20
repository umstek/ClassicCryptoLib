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

        private AffineCipher<char> _affine;

        public AffineCipherTest()
        {
            this._affine = new AffineCipher<char>("abcdefghijklmnopqrstuvwxyz", 1, 1);
        }

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion

        [TestMethod]
        public void TestAffine1()
        {
            {
                CollectionAssert.AreEqual("abcde".ToArray(), _affine.Decrypt("bcdef").ToArray());
            }
        }
    }
}
