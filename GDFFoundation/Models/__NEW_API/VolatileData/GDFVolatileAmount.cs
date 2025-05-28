#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFVolatileAmount.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using GDFFoundation;

#endregion

namespace GDFStandardModels
{
    /// <summary>
    ///     The GDFVolatileAmount class represents a volatile amount object in the GDFStandardModels namespace.
    /// </summary>
    [Serializable]
    public sealed class GDFVolatileAmount : GDFVolatileData
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a volatile amount object.
        /// </summary>
        public float Amount { set; get; } = 0;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a volatile amount that can be stored in the database.
        /// </summary>
        public GDFVolatileAmount()
            : base()
        {
        }

        /// <summary>
        ///     Represents volatile amount data used in GDFFoundation.
        /// </summary>
        public GDFVolatileAmount(IGDFVolatileAgent sVolatileManager, string sCategory, float sAmount, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Amount = sAmount;
        }

        /// <summary>
        ///     Represents a volatile amount for GDFFoundation.
        /// </summary>
        public GDFVolatileAmount(IGDFVolatileAgent sVolatileManager, Enum sCategory, float sAmount, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Amount = sAmount;
        }

        #endregion
    }
}