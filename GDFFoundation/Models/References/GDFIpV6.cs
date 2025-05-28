#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFIpV6.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents an IP address version 6.
    /// </summary>
    [Serializable]
    public class GDFIpV6 : GDFDataType
    {
        #region Static methods

        /// <summary>
        ///     Generates a random GDFIpV6 object.
        /// </summary>
        /// <returns>A randomly generated GDFIpV6 object.</returns>
        public static GDFIpV6 Random()
        {
            return new GDFIpV6()
            {
                A = GDFRandom.Int255Numeric(),
                B = GDFRandom.Int255Numeric(),
                C = GDFRandom.Int255Numeric(),
                D = GDFRandom.Int255Numeric(),
                E = GDFRandom.Int255Numeric(),
                F = GDFRandom.Int255Numeric(),
                G = GDFRandom.Int255Numeric(),
                H = GDFRandom.Int255Numeric(),
            };
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents the property A of the GDFIpV6 class.
        /// </summary>
        public int A { set; get; }

        /// <summary>
        ///     Represents the property B of the GDFIpV6 class.
        /// </summary>
        public int B { set; get; }

        /// <summary>
        ///     Represents the property C of the GDFIpV6 class.
        /// </summary>
        /// <remarks>
        ///     This property is an integer and is used to store the value of the C component of an IPv6 address.
        /// </remarks>
        public int C { set; get; }

        /// <summary>
        ///     Represents the property D of the GDFIpV6 class.
        /// </summary>
        /// <remarks>
        ///     This property represents an integer value that is part of an IPv6 address.
        /// </remarks>
        public int D { set; get; }

        /// <summary>
        ///     Represents property E of the GDFIpV6 class.
        /// </summary>
        /// <remarks>
        ///     This property is an int type and is accessible through getters and setters.
        /// </remarks>
        public int E { set; get; }

        /// <summary>
        ///     Represents the property F of the GDFIpV6 class.
        /// </summary>
        /// <value>
        ///     The value of the property F.
        /// </value>
        public int F { set; get; }

        /// <summary>
        ///     Represents the G property of the GDFIpV6 class.
        /// </summary>
        public int G { set; get; }

        /// <summary>
        ///     Represents the property H of the GDFIpV6 class.
        /// </summary>
        public int H { set; get; }

        #endregion
    }
}