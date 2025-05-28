#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFAccountStorageStat.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Class representing storage statistics for an account.
    /// </summary>
    [Serializable]
    public class GDFAccountStorageStat : GDFAccountStat
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the total storage value for a player.
        /// </summary>
        public double StoragePlayerTotal { set; get; } = 1;

        /// <summary>
        ///     Gets or sets the total storage used by an account.
        /// </summary>
        /// <value>The total storage used by an account.</value>
        public double StorageTotal { set; get; } = 1;

        /// <summary>
        ///     Represents the total storage used by a user.
        /// </summary>
        public double StorageUserTotal { set; get; } = 1;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents account storage statistics data.
        /// </summary>
        public GDFAccountStorageStat()
        {
        }

        public GDFAccountStorageStat(GDFRequestPlayerToken sToCopy, GDFStatRange sStatRange)
        {
            Creation = GDFDatetime.Now;
            Modification = Creation;
            StatKey = PrefKey(DateTime.UtcNow, sStatRange);
            StorageUserTotal = 0;
            StoragePlayerTotal = 0;
            StorageTotal = 0;
            Project = sToCopy.ProjectReference;
            Account = sToCopy.PlayerReference;
            Range = sToCopy.AccountRange;
        }

        #endregion
    }
}