#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFVector3.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a three-dimensional vector.
    /// </summary>
    [Serializable]
    public class GDFVector3 : GDFVector2
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the Z coordinate of a three-dimensional vector.
        /// </summary>
        public float Z { set; get; }

        #endregion
    }
}