#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFProjectSyncStat.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a project synchronization statistic.
    /// </summary>
    [Serializable]
    public class GDFProjectSyncStat : GDFProjectStat
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the synchronization counter for a project.
        /// </summary>
        public long SyncCounter { set; get; } = 0;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a synchronization statistic for a project.
        /// </summary>
        public GDFProjectSyncStat()
        {
        }

        #endregion
    }
}