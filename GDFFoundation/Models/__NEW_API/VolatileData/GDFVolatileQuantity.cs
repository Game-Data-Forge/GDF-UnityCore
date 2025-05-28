#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFVolatileQuantity.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using GDFFoundation;

#endregion

namespace GDFStandardModels
{
    /// <summary>
    ///     Represents a volatile quantity.
    /// </summary>
    [Serializable]
    public sealed class GDFVolatileQuantity : GDFVolatileData
    {
        #region Instance fields and properties

        /// <summary>
        ///     The Quantity property represents the quantity of an item.
        /// </summary>
        public int Quantity { set; get; } = 0;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     The GDFVolatileQuantity class represents a volatile quantity value that can be stored in the database.
        /// </summary>
        public GDFVolatileQuantity()
            : base()
        {
        }

        /// <summary>
        ///     The GDFVolatileQuantity class represents a volatile quantity value that can be stored in the database.
        /// </summary>
        /// <remarks>
        ///     This class is derived from the GDFVolatileData class.
        /// </remarks>
        public GDFVolatileQuantity(IGDFVolatileAgent sVolatileManager, string sCategory, int sQuantity, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Quantity = sQuantity;
        }

        /// <summary>
        ///     Represents a volatile quantity.
        /// </summary>
        /// <remarks>
        ///     The GDFVolatileQuantity class represents a volatile quantity value that can be stored in the database.
        /// </remarks>
        public GDFVolatileQuantity(IGDFVolatileAgent sVolatileManager, Enum sCategory, int sQuantity, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Quantity = sQuantity;
        }

        #endregion
    }
}