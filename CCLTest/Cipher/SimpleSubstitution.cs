using System;
using CCL.Cipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLTest.Cipher
{
    [TestClass]
    public class SimpleSubstitution
    {
        [TestMethod]
        public void TestSimpleSubstitution()
        {
            var ssc = new SimpleSubstitutionCipher<char, char>("0123456789", "qwertyuiop");
            Assert.AreEqual(ssc.Encrypt("0123456789"), "qwertyuiop");
        }
    }
}
