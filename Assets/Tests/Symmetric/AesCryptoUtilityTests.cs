/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AesCryptoUtilityTests.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using NUnit.Framework;
using UnityEngine;

namespace MGS.Crypto.Tests
{
    public class AesCryptoUtilityTests
    {
        string key = "m8Yu4c742eh7C0sEmrrVBQ==";
        string iv = "KS5sHFwiBpxBKlsTMGEixg==";
        string plainText = "This is a test text line.";
        string cipherText = "CLk7AnuswOR7RBeWslXuCswOL4Q/R2kMdykpiSMN01s=";

        [Test]
        public void GenerateKeyTest()
        {
            var key = AesCryptoUtility.GenerateKey();
            Debug.Log(key);
            Assert.IsNotEmpty(key);
        }

        [Test]
        public void GenerateIVTest()
        {
            var iv = AesCryptoUtility.GenerateIV();
            Debug.Log(iv);
            Assert.IsNotEmpty(iv);
        }

        [Test]
        public void EncryptTest()
        {
            Debug.Log(plainText);

            iv = iv.Substring(0, 16);
            var cipherText = AesCryptoUtility.Encrypt(plainText, key, iv);

            Debug.Log(cipherText);
            Assert.IsNotEmpty(cipherText);
        }

        [Test]
        public void DecryptTest()
        {
            Debug.Log(cipherText);

            iv = iv.Substring(0, 16);
            var plainText = AesCryptoUtility.Decrypt(cipherText, key, iv);

            Debug.Log(plainText);
            Assert.IsNotEmpty(plainText);
        }
    }
}