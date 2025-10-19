/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Rfc2898Utility.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/18/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Security.Cryptography;

namespace MGS.Crypto
{
    /// <summary>
    /// Utility base on Rfc2898DeriveBytes (PBKDF2, SHA256, salt16).
    /// </summary>
    public sealed class Rfc2898Utility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Hash string (Base64String).</returns>
        public static string HashPassword(string password)
        {
            var salt = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            using var rfc = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            var hash = rfc.GetBytes(32);

            var hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashedPassword">Hash string (Base64String)</param>
        /// <returns></returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var pwdBytes = Convert.FromBase64String(hashedPassword);
            var salt = new byte[16];
            Array.Copy(pwdBytes, 0, salt, 0, 16);

            using var rfc = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            var hashBytes = rfc.GetBytes(32);

            for (int i = 0; i < hashBytes.Length; i++)
            {
                if (hashBytes[i] != pwdBytes[i + 16])
                {
                    return false;
                }
            }
            return true;
        }
    }
}