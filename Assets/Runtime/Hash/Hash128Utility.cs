/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Hash128Utility.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/18/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Crypto
{
    /// <summary>
    /// Utility base on Hash128 (HashAlgorithm).
    /// </summary>
    public sealed class Hash128Utility
    {
        public static string Compute(string data)
        {
            var hash128 = Hash128.Compute(data);
            return hash128.ToString();
        }
    }
}