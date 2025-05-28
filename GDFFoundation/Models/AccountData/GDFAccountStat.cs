#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFAccountStat.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Account statistics data.
    /// </summary>
    [Serializable]
    [GDFDatabaseIndex("StatIndex", nameof(Account), nameof(Project), nameof(StatKey))]
    public abstract class GDFAccountStat : GDFAccountData
    {
        #region Static methods

        /// <summary>
        ///     Generates a preference key based on the specified date and stat range.
        /// </summary>
        /// <param name="sDateTime">The DateTime value used to generate the preference key.</param>
        /// <param name="sStatRange">The stat range used to determine the format of the preference key.</param>
        /// <returns>A GDFShortString object representing the generated preference key.</returns>
        protected static string PrefKey(DateTime sDateTime, GDFStatRange sStatRange)
        {
            string rReturn = "none";
            switch (sStatRange)
            {
                case GDFStatRange.Minute:
                {
                    rReturn = sDateTime.ToString("yyyy-MM-dd-HH-mm");
                }
                break;
                case GDFStatRange.Hour:
                {
                    rReturn = sDateTime.ToString("yyyy-MM-dd-HH");
                }
                break;
                case GDFStatRange.Day:
                {
                    rReturn = sDateTime.ToString("yyyy-MM-dd");
                }
                break;
                case GDFStatRange.Month:
                {
                    rReturn = sDateTime.ToString("yyyy-MM");
                }
                break;
                case GDFStatRange.Year:
                {
                    rReturn = sDateTime.ToString("yyyy");
                }
                break;
            }

            return rReturn;
        }

        #endregion

        #region Instance fields and properties

        [GDFDbLength(GDFConstants.K_STAT_KEY_LENGHT)]
        public string StatKey { set; get; } = string.Empty;

        #endregion
    }
}