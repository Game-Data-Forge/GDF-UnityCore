#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFAccountSyncStat.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents an account synchronization statistic.
    /// </summary>
    [Serializable]
    public class GDFAccountSyncStat : GDFAccountStat
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the synchronization counter for an account.
        /// </summary>
        public double SyncCounter { set; get; } = 0;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a synchronization statistic for an account.
        /// </summary>
        public GDFAccountSyncStat()
        {
        }

        /// <summary>
        ///     Represents a synchronized account statistic.
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

        #endregion
    }
}