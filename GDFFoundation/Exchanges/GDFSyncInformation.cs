#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFSyncInformation.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents synchronization information used for data synchronization.
    /// </summary>
    [Serializable]
    public class GDFSyncInformation : IGDFSerializable
    {
        #region Static methods

        /// <summary>
        ///     Represents a method that creates a new instance of the GDFSyncInformation class by converting an existing instance of GDFSyncInformation and updating its properties.
        /// </summary>
        /// <param name="sSyncInformation">The existing instance of GDFSyncInformation to convert.</param>
        /// <param name="sNewSyncDateTime">The new DateTime value to update the SyncDateTime property of the new instance.</param>
        /// <param name="sNewCommitId">The new Int64 value to update the SyncCommitId property of the new instance.</param>
        /// <returns>A new instance of the GDFSyncInformation class with updated properties.</returns>
        /// <remarks>
        ///     This method should be used to create a new instance of GDFSyncInformation by converting an existing instance and updating its properties.
        ///     The method takes an existing instance of GDFSyncInformation and updates its properties based on the given newSyncDateTime and newCommitId parameters.
        ///     The OldSyncDateTime and OldSyncCommitId properties of the existingInstance are used to set the corresponding properties of the new instance.
        /// </remarks>
        [Obsolete("There is no reason to use this method anymore.")]
        public static GDFSyncInformation From(GDFSyncInformation sSyncInformation, DateTime sNewSyncDateTime, Int64 sNewCommitId)
        {
            GDFSyncInformation rReturn = new GDFSyncInformation
            {
                OldSyncCommitId = sSyncInformation.SyncCommitId,
                OldSyncDateTime = GDFTimestamp.TimeStampToDateTime(sSyncInformation.SyncDateTime),
                SyncDateTime = GDFTimestamp.Timestamp(sNewSyncDateTime),
                SyncCommitId = sNewCommitId
            };
            return rReturn;
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the old sync commit ID.
        /// </summary>
        [Obsolete("Use SyncCommitId instead!")]
        public Int64 OldSyncCommitId
        {
            get
            {
                try
                {
                    return SyncCommitId;
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                try
                {
                    SyncCommitId = value;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        ///     A property representing the old synchronization date and time.
        /// </summary>
        /// <remarks>
        ///     This property is marked as obsolete and should not be used. It is recommended to use the <see cref="SyncDateTime" /> property instead.
        /// </remarks>
        [Obsolete("Use SyncDateTime instead!")]
        public DateTime OldSyncDateTime
        {
            get
            {
                try
                {
                    return GDFTimestamp.TimeStampToDateTime(SyncDateTime);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            set
            {
                try
                {
                    SyncDateTime = GDFTimestamp.Timestamp(value);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        ///     A long property that represents the synchronization commit ID.
        /// </summary>
        public Int64 SyncCommitId { set; get; }

        /// <summary>
        ///     A long property representing the synchronization date and time.
        /// </summary>
        public long SyncDateTime { set; get; }

        /// <summary>
        ///     A boolean property that indicates whether this instance should be used or not.
        /// </summary>
        public bool UseMe { set; get; } = true;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents synchronization information used for data synchronization.
        /// </summary>
        public GDFSyncInformation()
        {
            SyncDateTime = 0;
            SyncCommitId = 0;
        }

        /// <summary>
        ///     The GDFSyncInformation class is a serializable class representing synchronization information.
        /// </summary>
        public GDFSyncInformation(GDFSyncInformation sSyncInformation)
        {
            if (sSyncInformation != null)
            {
                Copy(sSyncInformation);
            }
        }

        /// <summary>
        ///     Represents the synchronization information used for data synchronization.
        /// </summary>
        public GDFSyncInformation(GDFNewSyncInformation sSyncInformation)
        {
            if (sSyncInformation != null)
            {
                Copy(sSyncInformation);
            }
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Copies the synchronization information from another instance of GDFSyncInformation.
        /// </summary>
        /// <param name="sSyncInformation">The GDFSyncInformation instance to copy from.</param>
        public void Copy(GDFSyncInformation sSyncInformation)
        {
            SyncDateTime = sSyncInformation.SyncDateTime;
            SyncCommitId = sSyncInformation.SyncCommitId;
        }

        /// <summary>
        ///     Copies the properties from another GDFSyncInformation object.
        /// </summary>
        /// <param name="sSyncInformation">The GDFSyncInformation object to copy from.</param>
        public void Copy(GDFNewSyncInformation sSyncInformation)
        {
            SyncDateTime = GDFTimestamp.Timestamp(sSyncInformation.SyncTime);
            SyncCommitId = sSyncInformation.SyncCommit;
        }

        #endregion
    }
}