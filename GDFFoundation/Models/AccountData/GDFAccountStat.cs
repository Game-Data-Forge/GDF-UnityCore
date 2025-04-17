

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Account statistics data.
    /// </summary>
    [Serializable]
    [GDFDatabaseIndex("StatIndex", nameof(Account), nameof(Project), nameof(StatKey))]
    public abstract class GDFAccountStat : GDFAccountData
    {
        [GDFDbLength(GDFConstants.K_STAT_KEY_LENGHT)]
        public string StatKey { set; get; } = string.Empty;

        /// <summary>
        /// Generates a preference key based on the specified date and stat range.
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
    }
}

