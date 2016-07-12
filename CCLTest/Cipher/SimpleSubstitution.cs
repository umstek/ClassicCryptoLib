using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
            CollectionAssert.AreEqual("qwertyuiop".ToArray(), ssc.Encrypt("0123456789").ToArray());
        }
    }
}
