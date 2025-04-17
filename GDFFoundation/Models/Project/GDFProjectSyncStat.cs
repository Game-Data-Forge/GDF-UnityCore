

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a project synchronization statistic.
    /// </summary>
    [Serializable]
    public class GDFProjectSyncStat : GDFProjectStat
    {
        /// <summary>
        /// Represents the synchronization counter for a project.
        /// </summary>
        public long SyncCounter { set; get; } = 0;

        /// <summary>
        /// Represents a synchronization statistic for a project.
        /// </summary>
        public GDFProjectSyncStat()
        {
        }
    }
}

