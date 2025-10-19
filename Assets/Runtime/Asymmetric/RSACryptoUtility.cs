/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RSACryptoUtility.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace MGS.Crypto
{
    /// <summary>
    /// Utility base on RSACryptoServiceProvider (AsymmetricAlgorithm).
    /// </summary>
    public sealed class RSACryptoUtility
    {
        public static void GenerateKey(out string publicKey, out string privateKey)
        {
            using var rsa = new RSACryptoServiceProvider();
            publicKey = rsa.ToXmlString(false);
            privateKey = rsa.ToXmlString(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="publicKey"></param>
        /// <returns>Cipher string (Base64String).</returns>
        public static string Encrypt(string plainText, string publicKey)
        {
            try
            {
                using var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(publicKey);

                var plainBytes = Encoding.UTF8.GetBytes(plainText);
                var encryptedBytes = rsa.Encrypt(plainBytes, false);

                return Convert.ToBase64String(encryptedBytes);
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
        /// <param name="privateKey"></param>
        /// <returns>Plain string (Encoding.UTF8).</returns>
        public static string Decrypt(string cipherText, string privateKey)
        {
            try
            {
                using var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(privateKey);

                var cipherBytes = Convert.FromBase64String(cipherText);
                var decryptedBytes = rsa.Decrypt(cipherBytes, false);

                return Encoding.UTF8.GetString(decryptedBytes);
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
        /// <param name="data">Data string (Encoding.UTF8).</param>
        /// <param name="privateKey"></param>
        /// <returns>Signature string (Base64String).</returns>
        public static string SignData(string data, string privateKey)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            var dataBytes = Encoding.UTF8.GetBytes(data);
            var signature = rsa.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            return Convert.ToBase64String(signature);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">Data string (Encoding.UTF8).</param>
        /// <param name="signature">Signature string (Base64String).</param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static bool VerifyData(string data, string signature, string publicKey)
        {
            using var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            var dataBytes = Encoding.UTF8.GetBytes(data);
            var signatureBytes = Convert.FromBase64String(signature);

            return rsa.VerifyData(dataBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }
}