/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Hash128UtilityTest.cs
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
    public class Hash128UtilityTest
    {
        string plainText = "This is a test text line.";

        [Test]
        public void ComputeHashTest()
        {
            Debug.Log(plainText);

            var hashText = Hash128Utility.Compute(plainText);

            Debug.Log(hashText);
            Assert.IsNotEmpty(hashText);
        }
    }
}