#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFVolatileBoolean.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using GDFFoundation;

#endregion

namespace GDFStandardModels
{
    /// <summary>
    ///     The GDFVolatileBoolean class represents a volatile boolean value in the GDFStandardModels namespace.
    /// </summary>
    [Serializable]
    public sealed class GDFVolatileBoolean : GDFVolatileData
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a volatile boolean value.
        /// </summary>
        public bool Boolean { set; get; } = false;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     The GDFVolatileBoolean class represents a volatile boolean value that can be stored in the database.
        /// </summary>
        public GDFVolatileBoolean()
            : base()
        {
        }

        /// <summary>
        ///     Represents a volatile boolean used in GDFFoundation.
        /// </summary>
        public GDFVolatileBoolean(IGDFVolatileAgent sVolatileManager, string sCategory, bool sBoolean, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Boolean = sBoolean;
        }

        /// Represents a class for handling volatile boolean data.
        /// /
        public GDFVolatileBoolean(IGDFVolatileAgent sVolatileManager, Enum sCategory, bool sBoolean, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Boolean = sBoolean;
        }

        #endregion
    }
}