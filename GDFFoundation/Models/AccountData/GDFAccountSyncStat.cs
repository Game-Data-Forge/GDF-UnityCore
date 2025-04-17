

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an account synchronization statistic.
    /// </summary>
    [Serializable]
    public class GDFAccountSyncStat : GDFAccountStat
    {
        /// <summary>
        /// Represents the synchronization counter for an account.
        /// </summary>
        public double SyncCounter { set; get; } = 0;

        /// <summary>
        /// Represents a synchronization statistic for an account.
        /// </summary>
        public GDFAccountSyncStat()
        {
        }

        /// <summary>
        /// Represents a synchronized account statistic.
        /// </summary>
        public GDFAccountSyncStat(GDFRequestPlayerToken sToCopy, GDFStatRange sStatRange)
        {
            Creation = GDFDatetime.Now;
            Modification = Creation;
            StatKey = PrefKey(DateTime.UtcNow, sStatRange);
            Project = sToCopy.ProjectReference;
            Account = sToCopy.PlayerReference;
            Range = sToCopy.AccountRange;
            SyncCounter = 1;
        }
    }
}

