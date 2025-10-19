/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AesCryptoUtility.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace MGS.Crypto
{
    /// <summary>
    /// Utility base on AesCryptoServiceProvider (SymmetricAlgorithm).
    /// </summary>
    public sealed class AesCryptoUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keySize">Size of key (128/192/256).</param>
        /// <returns>Key string (Base64String).</returns>
        public static string GenerateKey(int keySize = 128)
        {
            using var aes = new AesCryptoServiceProvider();
            aes.KeySize = keySize;
            aes.GenerateKey();
            return Convert.ToBase64String(aes.Key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>IV string (Base64String).</returns>
        public static string GenerateIV()
        {
            using var aes = new AesCryptoServiceProvider();
            aes.GenerateIV();
            return Convert.ToBase64String(aes.IV);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="key">Key string (Encoding.UTF8, 16/24/32)</param>
        /// <param name="iv">IV string (Encoding.UTF8, 16)</param>
        /// <returns>Cipher string (Base64String).</returns>
        public static string Encrypt(string plainText, string key, string iv = null)
        {
            try
            {
                using var aes = new AesCryptoServiceProvider();
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = string.IsNullOrEmpty(iv) ? new byte[16] : Encoding.UTF8.GetBytes(iv);

                using var msEncrypt = new MemoryStream();
                using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherText">Cipher string (Base64String).</param>
        /// <param name="key">Key string (Encoding.UTF8, 16/24/32)</param>
        /// <param name="iv">IV string (Encoding.UTF8, 16)</param>
        /// <returns>Plain string.</returns>
        public static string Decrypt(string cipherText, string key, string iv = null)
        {
            try
            {
                using Aes aes = new AesCryptoServiceProvider();
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = string.IsNullOrEmpty(iv) ? new byte[16] : Encoding.UTF8.GetBytes(iv);

                var cipherBytes = Convert.FromBase64String(cipherText);
                using var msDecrypt = new MemoryStream(cipherBytes);
                using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                return srDecrypt.ReadToEnd();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
                return null;
            }
        }
    }
}