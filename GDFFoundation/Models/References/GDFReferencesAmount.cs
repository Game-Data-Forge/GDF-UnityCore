#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFReferencesAmount.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a base abstract class for GDFReferencesAmount objects.
    /// </summary>
    [Serializable]
    // TODO change for structure
    public abstract class GDFReferencesAmount : GDFDataType, IGDFSubModel
    {
        #region Instance fields and properties

        public Dictionary<long, float> ReferenceAmount { set; get; } = new Dictionary<long, float>();

        #endregion
    }

    /// <summary>
    ///     Represents a base abstract class for GDFReferencesAmount objects.
    /// </summary>
    [Serializable]
    // TODO change for structure
    public class GDFReferencesAmount<T> : GDFReferencesAmount where T : GDFDatabaseObject
    {
    }
}