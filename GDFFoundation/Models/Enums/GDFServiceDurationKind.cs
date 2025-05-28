#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFServiceDurationKind.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents the various duration kinds that can be associated with a service.
    /// </summary>
    [Serializable]
    public enum GDFServiceDurationKind
    {
        /// <summary>
        ///     Represents the duration kind of a service in minutes.
        /// </summary>
        Minute = 0,

        /// <summary>
        ///     Represents the duration in hours.
        /// </summary>
        Hour = 1,

        /// <summary>
        ///     Represents a day as a duration kind in the GDFServiceDurationKind enum.
        /// </summary>
        Day = 2,

        /// <summary>
        ///     Represents the 'Week' duration kind for a service.
        /// </summary>
        Week = 3,

        /// <summary>
        ///     Represents the duration kind of a service.
        /// </summary>
        Month = 4,

        /// <summary>
        ///     Represents the duration in years.
        /// </summary>
        Year = 5,

        /// <summary>
        ///     Represents the infinity duration kind of a service in GDFFoundation.
        /// </summary>
        Infinity = 99,
    }
}