/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RandomNumberUtilityTests.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/21/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using NUnit.Framework;
using UnityEngine;

namespace MGS.Crypto.Tests
{
    public class RandomNumberUtilityTests
    {
        [Test]
        public void GenerateNumberTest()
        {
            var numberText = RandomNumberUtility.GenerateNumber();
            Debug.Log(numberText);
            Assert.IsNotEmpty(numberText);
        }
    }
}