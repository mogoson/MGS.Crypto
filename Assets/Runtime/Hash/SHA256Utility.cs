/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SHA256Utility.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/19/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Security.Cryptography;
using System.Text;

namespace MGS.Crypto
{
    /// <summary>
    /// Utility base on SHA256 (HashAlgorithm).
    /// </summary>
    public class SHA256Utility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">Data string (Encoding.UTF8)</param>
        /// <returns></returns>
        public static string ComputeHash(string data)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(dataBytes);
            return BitConverter.ToString(hashBytes);
        }
    }
}