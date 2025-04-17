using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Enumeration of exchange license kinds.
    /// </summary>
    [Serializable]
    public enum GDFExchangeLicenseKind
    {
        /// <summary>
        /// No exchange kind (!)
        /// </summary>
        None = GDFExchangeKind.None,

        /// <summary>
        /// Enumeration member Test of GDFExchangeLicenseKind.
        /// </summary>
        /// <remarks>
        /// This member represents the Test exchange kind.
        /// </remarks>
        Test = GDFExchangeKind.Test,

        /// <summary>
        /// Enumeration member representing an unknown exchange license kind.
        /// </summary>
        Unknown = GDFExchangeKind.Unknown,

        /// <summary>
        /// Enumeration member representing the Check License kind of GDFExchangeLicenseKind.
        /// </summary>
        CheckLicense = 110,
    }
}