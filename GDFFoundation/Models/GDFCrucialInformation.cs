#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFCrucialInformation.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents crucial information for the GDF database.
    /// </summary>
    [Serializable]
    public class GDFCrucialInformation : GDFBasicData, IGDFWritableLongReference
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the hash value of a table in the GDFCrucialInformation class.
        /// </summary>
        /// <remarks>
        ///     This property is used to store the hash value of a table in the GDFCrucialInformation class.
        ///     The hash value represents a fingerprint of the table's data, which can be used for comparison or verification purposes.
        /// </remarks>
        public string TableHash { set; get; } = string.Empty;

        /// <summary>
        ///     Represents a unique identity for a table.
        /// </summary>
        public string TableKey { set; get; } = string.Empty;

        #region From interface IGDFWritableLongReference

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { set; get; }

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     GDFCrucialInformation class represents crucial information used in the application.
        ///     It extends the GDFBasicData class and provides properties for table key and table hash.
        /// </summary>
        public GDFCrucialInformation()
        {
        }

        #endregion
    }
}