/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MD5Utility.cs
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
    /// Utility base on MD5 (HashAlgorithm).
    /// </summary>
    public sealed class MD5Utility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">Data string (Encoding.UTF8)</param>
        /// <returns></returns>
        public static string ComputeHash(string data)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            using var md5 = MD5.Create();
            var hashBytes = md5.ComputeHash(dataBytes);
            return BitConverter.ToString(hashBytes);
        }
    }
}