#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFReferencesQuantity.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a class that stores reference quantities for classes inheriting from GDFDatabaseObject.
    /// </summary>
    [Serializable]
    // TODO change for structure
    public class GDFReferencesQuantity : GDFDataType, IGDFSubModel
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a class for storing reference quantities.
        /// </summary>
        public Dictionary<long, Int64> ReferenceQuantity { set; get; } = new Dictionary<long, Int64>();

        #endregion
    }

    /// <summary>
    ///     Represents a class that stores references and quantities of a particular data type.
    /// </summary>
    [Serializable]
    // TODO change for structure
    public class GDFReferencesQuantity<T> : GDFReferencesQuantity where T : GDFDatabaseObject
    {
    }
}