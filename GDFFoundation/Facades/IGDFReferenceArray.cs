#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFReferenceArray.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    // TODO remove Interface ?
    /// <summary>
    ///     Represents an interface for an array of references.
    /// </summary>
    public interface IGDFReferenceArray
    {
        #region Instance fields and properties

        /// <summary>
        ///     Interface for an array of references.
        /// </summary>
        List<string> ReferencesList { set; get; }

        #endregion
    }
}