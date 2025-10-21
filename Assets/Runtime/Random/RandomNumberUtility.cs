/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RandomNumberUtility.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/21/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Security.Cryptography;

namespace MGS.Crypto
{
    /// <summary>
    /// Utility base on RandomNumberGenerator.
    /// </summary>
    public sealed class RandomNumberUtility
    {
        public static string GenerateNumber(int size = 16)
        {
            var numberBytes = new byte[size];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(numberBytes);
            return BitConverter.ToString(numberBytes);
        }
    }
}