/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SHA256UtilityTests.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/19/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using NUnit.Framework;
using UnityEngine;

namespace MGS.Crypto.Tests
{
    public class SHA256UtilityTests
    {
        string plainText = "This is a test text line.";

        [Test]
        public void ComputeHashTest()
        {
            Debug.Log(plainText);

            var hashText = SHA256Utility.ComputeHash(plainText);

            Debug.Log(hashText);
            Assert.IsNotEmpty(hashText);
        }
    }
}