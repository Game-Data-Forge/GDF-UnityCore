#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFVolatileDuration.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using GDFFoundation;

#endregion

namespace GDFStandardModels
{
    /// <summary>
    ///     Represents a volatile duration in the GDFStandardModels namespace.
    ///     Inherits from GDFVolatileData class.
    /// </summary>
    [Serializable]
    public sealed class GDFVolatileDuration : GDFVolatileData
    {
        #region Instance fields and properties

        /// <summary>
        ///     The Duration property represents the duration of a volatile data object.
        /// </summary>
        public long Duration { set; get; } = 0;

        /// <summary>
        ///     Gets or sets the end time of the volatile duration.
        /// </summary>
        public long EndAt { set; get; } = 0;

        /// <summary>
        ///     The Scene class represents a volatile duration in a scene.
        ///     It inherits from the GDFVolatileData class in the GDFFoundation namespace.
        /// </summary>
        public string Scene { set; get; } = string.Empty;

        /// <summary>
        ///     Gets or sets the start time of the volatile duration.
        ///     Start time should be in Unix timestamp format.
        /// </summary>
        public long StartAt { set; get; } = 0;

        #endregion

        #region Instance constructors and destructors

        /// Represents a volatile duration that can be stored in the database.
        /// /
        public GDFVolatileDuration()
            : base()
        {
        }

        /// <summary>
        ///     Represents a volatile duration used in GDFFoundation.
        /// </summary>
        public GDFVolatileDuration(
            IGDFVolatileAgent sVolatileManager,
            string sCategory,
            string sScene,
            int sStartAt,
            int sEndAt,
            long sDuration,
            string sInformation = ""
        )
            : base(sVolatileManager, sCategory, sInformation)
        {
            Scene = sScene;
            StartAt = sStartAt;
            EndAt = sEndAt;
            Duration = sDuration;
        }

        /// <summary>
        ///     Represents a volatile duration data object.
        /// </summary>
        public GDFVolatileDuration(
            IGDFVolatileAgent sVolatileManager,
            Enum sCategory,
            string sScene,
            int sStartAt,
            int sEndAt,
            long sDuration,
            string sInformation = ""
        )
            : base(sVolatileManager, sCategory, sInformation)
        {
            Scene = sScene;
            StartAt = sStartAt;
            EndAt = sEndAt;
            Duration = sDuration;
        }

        #endregion
    }
}