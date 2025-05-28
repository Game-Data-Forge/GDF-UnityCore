#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFVolatileEnum.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using GDFFoundation;

#endregion

namespace GDFStandardModels
{
    /// <summary>
    ///     The GDFVolatileEnum class represents a volatile enumeration object in the GDFStandardModels namespace.
    /// </summary>
    [Serializable]
    public sealed class GDFVolatileEnum : GDFVolatileData
    {
        #region Instance fields and properties

        /// <summary>
        ///     The GDFVolatileEnum class represents a volatile enumeration in the GDFStandardModels namespace.
        /// </summary>
        public Enum Enumeration { set; get; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     The GDFVolatileEnum class represents a volatile enumeration in the database.
        /// </summary>
        public GDFVolatileEnum()
            : base()
        {
        }

        /// <summary>
        ///     Represents a volatile enum data used in GDFFoundation.
        /// </summary>
        public GDFVolatileEnum(IGDFVolatileAgent sVolatileManager, string sCategory, Enum sEnum, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Enumeration = sEnum;
        }

        /// <summary>
        ///     Represents a volatile enumeration data for GDFFoundation.
        /// </summary>
        public GDFVolatileEnum(IGDFVolatileAgent sVolatileManager, Enum sCategory, Enum sEnum, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Enumeration = sEnum;
        }

        #endregion
    }
}