#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFDataTrack.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents an interface for tracking data in the GDFFoundation.
    /// </summary>
    public interface IGDFDataTrack
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a data track used for tracking changes in data.
        /// </summary>
        public Int64 DataTrack { set; get; }

        #endregion
    }
}