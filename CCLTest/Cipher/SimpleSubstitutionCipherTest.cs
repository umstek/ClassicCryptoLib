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
    public class SimpleSubstitutionCipherTest
    {
        private SimpleSubstitutionCipher<char> _ssc1;
        private SimpleSubstitutionCipher<char> _rot13;
        private SimpleSubstitutionCipher<char> _caesar;

        [TestInitialize]
        public void Initialize()
        {
            _ssc1 = new SimpleSubstitutionCipher<char>("0123456789", "qwertyuiop");
            _rot13 = new SimpleSubstitutionCipher<char>("abcdefghijklmnopqrstuvwxyz", "nopqrstuvwxyzabcdefghijklm");
            _caesar = new SimpleSubstitutionCipher<char>("abcdefghijklmnopqrstuvwxyz", "defghijklmnopqrstuvwxyzabc");
        }

        [TestMethod]
        public void TestEncrypt()
        {
            CollectionAssert.AreEqual("qwertyuiop".ToArray(), _ssc1.Encrypt("0123456789").ToArray());

            CollectionAssert.AreEqual("nycun".ToArray(), _rot13.Encrypt("alpha").ToArray()); // With rot13, encrypt and
            CollectionAssert.AreEqual("nycun".ToArray(), _rot13.Decrypt("alpha").ToArray()); // decrypt are the same.

            CollectionAssert.AreEqual("cheud".ToArray(), _caesar.Encrypt("zebra").ToArray());
        }

        [TestMethod]
        public void TestDecrypt()
        {
            CollectionAssert.AreEqual("0123456789".ToArray(), _ssc1.Decrypt("qwertyuiop").ToArray());

            CollectionAssert.AreEqual("alpha".ToArray(), _rot13.Decrypt("nycun").ToArray());
            CollectionAssert.AreEqual("alpha".ToArray(), _rot13.Encrypt("nycun").ToArray());

            CollectionAssert.AreEqual("zebra".ToArray(), _caesar.Decrypt("cheud").ToArray());
        }
    }
}
