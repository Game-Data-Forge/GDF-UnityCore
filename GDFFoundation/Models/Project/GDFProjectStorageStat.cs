#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFProjectStorageStat.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Class representing storage statistics for a project.
    /// </summary>
    [Serializable]
    public class GDFProjectStorageStat : GDFProjectStat
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the total storage value for a project.
        /// </summary>
        public double StoragePlayerTotal { set; get; } = 1;

        /// <summary>
        ///     Gets or sets the total storage used by a project.
        /// </summary>
        /// <value>The total storage used by a project.</value>
        public double StorageTotal { set; get; } = 1;

        /// <summary>
        ///     Represents the total storage used by a project.
        /// </summary>
        public double StorageUserTotal { set; get; } = 1;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents project storage statistics data.
        /// </summary>
        public GDFProjectStorageStat()
        {
        }

        #endregion
    }
}