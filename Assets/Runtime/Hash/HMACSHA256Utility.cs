/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HMACSHA256Utility.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/18/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Security.Cryptography;
using System.Text;

namespace MGS.Crypto
{
    /// <summary>
    /// Utility base on HMACSHA256 (HashAlgorithm).
    /// </summary>
    public sealed class HMACSHA256Utility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Message string (Encoding.UTF8).</param>
        /// <param name="key">Key string (Encoding.UTF8).</param>
        /// <returns>Hash string (Base64String).</returns>
        public static string ComputeHash(string message, string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            using var hmac = new HMACSHA256(keyBytes);
            var hashBytes = hmac.ComputeHash(messageBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}