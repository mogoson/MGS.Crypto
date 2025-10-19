/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Rfc2898UtilityTests.cs
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
    public class Rfc2898UtilityTests
    {
        string password = "12348765";
        string hashPwd = "DRhUx2IUumk+27/qvn6vtUTaJvK0kuVGyGeVbM+tWRuvjq+4/uAkLnX72vPyROF4";

        [Test]
        public void HashPasswordTest()
        {
            Debug.Log(password);

            var hashPwd = Rfc2898Utility.HashPassword(password);

            Debug.Log(hashPwd);
            Assert.IsNotEmpty(hashPwd);
        }

        [Test]
        public void VerifyPasswordTest()
        {
            Debug.Log(password);
            var isVerify = Rfc2898Utility.VerifyPassword(password, hashPwd);
            Debug.Log(isVerify);
            Assert.IsTrue(isVerify);

            password += " modify";
            Debug.Log(password);
            isVerify = Rfc2898Utility.VerifyPassword(password, hashPwd);
            Debug.Log(isVerify);
            Assert.IsFalse(isVerify);
        }
    }
}