

using System;

namespace GDFFoundation
{
    /// <summary>
    /// project statistics data.
    /// </summary>
    [Serializable]
    [GDFDatabaseIndex("StatIndex", nameof(ProjectReference), nameof(StatKey))]
    public abstract class GDFProjectStat : GDFBasicData, IGDFWritableLongReference, IGDFAccountRange
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        /// <summary>
        /// Represents the range of a project.
        /// </summary>
        public short Range { set; get; }
        [GDFDbLength(GDFConstants.K_STAT_KEY_LENGHT)]
        [GDFDbUnique(constraintName = "Identity")]
        public string StatKey { set; get; } = string.Empty;
        public string StatKeyGroup { set; get; } = string.Empty;

        /// <summary>
        /// Generates a preference key based on the specified date and stat range.
        /// </summary>
        /// <param name="dateTime">The DateTime value used to generate the preference key.</param>
        /// <param name="statRange">The stat range used to determine the format of the preference key.</param>
        /// <returns>A GDFShortString object representing the generated preference key.</returns>
        public static string PrefKey(DateTime dateTime, GDFStatRange statRange)
        {
            string rReturn = "none";
            switch (statRange)
            {
                case GDFStatRange.Minute:
                    {
                        rReturn = dateTime.ToString("yyyy-MM-dd-HH-mm");
                    }
                    break;
                case GDFStatRange.Hour:
                    {
                        rReturn = dateTime.ToString("yyyy-MM-dd-HH");
                    }
                    break;
                case GDFStatRange.Day:
                    {
                        rReturn = dateTime.ToString("yyyy-MM-dd");
                    }
                    break;
                case GDFStatRange.Month:
                    {
                        rReturn = dateTime.ToString("yyyy-MM");
                    }
                    break;
                case GDFStatRange.Year:
                    {
                        rReturn = dateTime.ToString("yyyy");
                    }
                    break;
            }

            return rReturn;
        }
    }
}

