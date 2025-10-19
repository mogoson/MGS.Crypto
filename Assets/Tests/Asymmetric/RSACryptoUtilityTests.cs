/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RSACryptoUtilityTests.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using NUnit.Framework;
using UnityEngine;

namespace MGS.Crypto.Tests
{
    public class RSACryptoUtilityTests
    {
        string publicKey = "<RSAKeyValue><Modulus>gAJ01zTpl9ICg5G1gBWwlS8TZIdUTwluQ5xpemRkjRnvmL+RXcYbsSpIJzYqeTuvZ206rsPm8z2S1+XzSs1vZS2E2vjMqtpNGClD6QKwWaIv/SXbSd9hZheRGYNKle30+QVmdG1kKkJFjlIuQBoNVe+AzjMgkd+a8AZ0MvZHJ1c=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        string privateKey = "<RSAKeyValue><Modulus>gAJ01zTpl9ICg5G1gBWwlS8TZIdUTwluQ5xpemRkjRnvmL+RXcYbsSpIJzYqeTuvZ206rsPm8z2S1+XzSs1vZS2E2vjMqtpNGClD6QKwWaIv/SXbSd9hZheRGYNKle30+QVmdG1kKkJFjlIuQBoNVe+AzjMgkd+a8AZ0MvZHJ1c=</Modulus><Exponent>AQAB</Exponent><P>stMSrO7BXJ7iNImS9KnpvMZ/59P7SErFNiaWuqVKuKp1pCI7ywhX2hGll7aw4QQUV8Cfi+bRiPqKXQDeJwcoBQ==</P><Q>t0E9aUrh//Dhnn7YOt1HgNPX/EtobGMQx5RiVhtS3fgHHe1A91MljithFRau6do34kN0MbroRbdKHG88tDl8qw==</Q><DP>fMKMBgCxAMiMsvDEiVO+Egk/FWOsrbwUqPn1MRS+8+VhG/kSVE1m1Wp4aEd6UhLBipOF/Fo2F+YMAGTpmLsCbQ==</DP><DQ>JJDjBSCJCf3xtyOOV+iRfPZIcbJGSuJVlc1Y9d+L4Hi+Ss1tmixAIScsvv2At27wmbhl9gpakJarNhNIJJoX8w==</DQ><InverseQ>drRynpnhBli+QwvyRk0JWnQ9llUk9omcuSYu9V9ZHthACzlRiHgeemsjgBm3Lu+5am+lfTSy9cSpjkNGIQrnuA==</InverseQ><D>TfexDMc4o/UQ/OwJ3YrYc/UpXaijrEQ1Oc8R2688I0kxyxqbQr+AbGcxbVirhA3bZyZ7gKjniS3uu7tedSgteVk3uhAIt55Za/3d3GR6BBVHpFEmTimiFtn1tuusp2sgXXlyhgVRkl52pZAQMm9oWgSFhNg9uwKJyPMaFEiZrYk=</D></RSAKeyValue>";
        string plainText = "This is a test text line.";
        string cipherText = "JgmxSfgynwXud7h9bOnoJo02l2iYlI92n7yqu/hCQM0+GkaC8ibgTRMpNjoqGBF430nwuOxFPLESo+SgcvQARdzbnjNXrZ9nMlZUWfvJHvu8ymjNuVoDFdDyxiFOwTU6fGeSPDugGrmCF4c486K/hd+P8Xqny0jE2n94jpIdavI=";
        string signature = "R5FDqrwA8KTWqLeg5AkPUFEgrxP97Dcar1JccnPi8bAVXiM8XXzEUaAUS6/ClDbu4syJbsFKTyYiMQ2O1LfsNVmf7yteUtsOc7GlUfMi0awCfhUm9AFC/kEmyJrGHpuRFmKFXHJ35kfSEhggxk/05Zd0BlPnEXjML1fTHgqD4WI=";

        [Test]
        public void GenerateKeyTest()
        {
            RSACryptoUtility.GenerateKey(out string publicKey, out string privateKey);

            Debug.Log(publicKey);
            Debug.Log(privateKey);

            Assert.IsNotEmpty(publicKey);
            Assert.IsNotEmpty(privateKey);
        }

        [Test]
        public void EncryptTest()
        {
            Debug.Log(plainText);

            var cipherText = RSACryptoUtility.Encrypt(plainText, publicKey);

            Debug.Log(cipherText);
            Assert.IsNotEmpty(cipherText);
        }

        [Test]
        public void DecryptTest()
        {
            Debug.Log(cipherText);

            var plainText = RSACryptoUtility.Decrypt(cipherText, privateKey);

            Debug.Log(plainText);
            Assert.IsNotEmpty(plainText);
        }

        [Test]
        public void SignDataTest()
        {
            Debug.Log(plainText);

            var signature = RSACryptoUtility.SignData(plainText, privateKey);

            Debug.Log(signature);
            Assert.IsNotEmpty(signature);
        }

        [Test]
        public void VerifyDataTest()
        {
            Debug.Log(plainText);

            var isVerify = RSACryptoUtility.VerifyData(plainText, signature, publicKey);
            Debug.Log(isVerify);
            Assert.IsTrue(isVerify);

            plainText = "This is a test text line. modify";
            Debug.Log(plainText);

            isVerify = RSACryptoUtility.VerifyData(plainText, signature, publicKey);
            Debug.Log(isVerify);
            Assert.IsFalse(isVerify);
        }
    }
}