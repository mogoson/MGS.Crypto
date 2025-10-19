/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HMACSHA256UtilityTests.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/18/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using NUnit.Framework;
using UnityEngine;

namespace MGS.Crypto.Tests
{
    public class HMACSHA256UtilityTests
    {
        string plainText = "This is a test text line.";
        string key = "m8Yu4c742eh7C0sEmrrVBQ==";
        string signature = "2HMpbXOcmTqHKhV4Xj5veG4iCcFa1jR3ShOVnOILKMA=";

        [Test]
        public void SignDataTest()
        {
            Debug.Log(plainText);

            var signature = HMACSHA256Utility.ComputeHash(plainText, key);

            Debug.Log(signature);
            Assert.IsNotEmpty(signature);
        }

        [Test]
        public void VerifyDataTest()
        {
            Debug.Log(plainText);

            var signature = HMACSHA256Utility.ComputeHash(plainText, key);
            Debug.Log(signature);

            Debug.Log(signature == this.signature);
            Assert.AreEqual(signature, this.signature);
        }
    }
}