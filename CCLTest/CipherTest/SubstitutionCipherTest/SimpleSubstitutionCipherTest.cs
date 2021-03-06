﻿using System.Linq;
using CCL.Cipher.SubstitutionCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCLTest.CipherTest.SubstitutionCipherTest
{
    /// <summary>
    /// </summary>
    [TestClass]
    public class SimpleSubstitutionCipherTest
    {
        private readonly SimpleSubstitutionCipher<char> _caesar;
        private readonly SimpleSubstitutionCipher<char> _rot13;
        private readonly SimpleSubstitutionCipher<char> _ssc1;

        public SimpleSubstitutionCipherTest()
        {
            _ssc1 = new SimpleSubstitutionCipher<char>("0123456789", "makeprofit");
            _rot13 = new SimpleSubstitutionCipher<char>("abcdefghijklmnopqrstuvwxyz", "nopqrstuvwxyzabcdefghijklm");
            _caesar = new SimpleSubstitutionCipher<char>("abcdefghijklmnopqrstuvwxyz", "defghijklmnopqrstuvwxyzabc");
        }

        [TestMethod]
        public void TestEncrypt()
        {
            CollectionAssert.AreEqual("makeprofit".ToArray(), _ssc1.Encrypt("0123456789").ToArray());

            CollectionAssert.AreEqual("nycun".ToArray(), _rot13.Encrypt("alpha").ToArray()); // With rot13, encrypt and
            CollectionAssert.AreEqual("nycun".ToArray(), _rot13.Decrypt("alpha").ToArray()); // decrypt are the same.

            CollectionAssert.AreEqual("cheud".ToArray(), _caesar.Encrypt("zebra").ToArray());
        }

        [TestMethod]
        public void TestDecrypt()
        {
            CollectionAssert.AreEqual("0123456789".ToArray(), _ssc1.Decrypt("makeprofit").ToArray());

            CollectionAssert.AreEqual("alpha".ToArray(), _rot13.Decrypt("nycun").ToArray());
            CollectionAssert.AreEqual("alpha".ToArray(), _rot13.Encrypt("nycun").ToArray());

            CollectionAssert.AreEqual("zebra".ToArray(), _caesar.Decrypt("cheud").ToArray());
        }
    }
}