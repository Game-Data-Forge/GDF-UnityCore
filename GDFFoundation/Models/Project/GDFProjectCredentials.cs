#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFProjectCredentials.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public class GDFNewStudioData : IGDFDbStorage, IGDFWritableData, IGDFWritableLongReference
    {
        #region Instance fields and properties

        #region From interface IGDFDbStorage

        public long Project { get; set; }
        public long RowId { get; set; }

        #endregion

        #region From interface IGDFWritableData

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }

        public long DataVersion { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }

        #endregion

        #region From interface IGDFWritableLongReference

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }

        #endregion

        #endregion

        #region Instance methods

        #region From interface IGDFWritableData

        public object GetReference() => Reference;

        #endregion

        #endregion
    }

    [Serializable]
    public class GDFReportData : IGDFDbStorage, IGDFWritableData, IGDFWritableLongReference, IGDFRangedData
    {
        #region Instance fields and properties

        #region From interface IGDFDbStorage

        public long Project { get; set; }
        public long RowId { get; set; }

        #endregion

        #region From interface IGDFRangedData

        public int Range { get; set; }

        #endregion

        #region From interface IGDFWritableData

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }

        public long DataVersion { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }

        #endregion

        #region From interface IGDFWritableLongReference

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }

        #endregion

        #endregion

        #region Instance methods

        #region From interface IGDFWritableData

        public object GetReference() => Reference;

        #endregion

        #endregion
    }

    [Serializable]
    public class GDFDashboardData : IGDFDbStorage, IGDFWritableData, IGDFWritableLongReference
    {
        #region Instance fields and properties

        #region From interface IGDFDbStorage

        public long Project { get; set; }
        public long RowId { get; set; }
        
        public string SignUpApiUrl { get; set; } = string.Empty;
        public string SignLostApiUrl { get; set; } = string.Empty;
        public string EmailFrom { get; set; } = string.Empty;

        #endregion

        #region From interface IGDFWritableData

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }

        public long DataVersion { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }

        #endregion

        #region From interface IGDFWritableLongReference

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }

        #endregion

        #endregion

        #region Instance methods

        #region From interface IGDFWritableData

        public object GetReference() => Reference;

        #endregion

        #endregion
    }

    [Serializable]
    public class GDFProjectMinimalCredentials
    {
        #region Instance fields and properties

        public ProjectEnvironment Environment { set; get; }
        public string PublicKey { set; get; }

        public SavePolicyKind SavePolicy { get; set; } = SavePolicyKind.LocalOnly;

        #endregion

        #region Instance constructors and destructors

        public GDFProjectMinimalCredentials()
        {
            Environment = ProjectEnvironment.Development;
            PublicKey = "";
        }

        public GDFProjectMinimalCredentials(GDFProjectCredentials projectCredentials)
        {
            Environment = projectCredentials.Environment;
            PublicKey = projectCredentials.PublicKey;
            SavePolicy = projectCredentials.SavePolicy;
        }

        #endregion
    }

    /// <summary>
    ///     Represents the credentials used in an GDF project.
    /// </summary>
    [Serializable]
    public class GDFProjectCredentials : IGDFDbStorage, IGDFWritableData, IGDFWritableLongReference
    {
        #region Instance fields and properties
        
        [GDFDbLength(128)]
        public string SignUpApiUrl { get; set; } = string.Empty;
        [GDFDbLength(128)]
        public string SignLostApiUrl { get; set; } = string.Empty;
        [GDFDbLength(128)]
        public string EmailFrom { get; set; } = string.Empty;
        public ProjectEnvironment Environment { set; get; } = ProjectEnvironment.Development;

        public string Game { get; set; } = "Game Name";
        public string GameLogo { get; set; }

        [GDFDbUnique(constraintName = "PublicKey")]
        [GDFDbLength(128)]
        public string PublicKey { set; get; } = GDFRandom.RandomStringKey();

        /// <summary>
        ///     The TreatKey for this project and this environment, use only by editor administration
        /// </summary>

        public SavePolicyKind SavePolicy { get; set; } = SavePolicyKind.LocalOnly;

        [GDFDbUnique(constraintName = "SecretKey")]
        [GDFDbLength(128)]
        public string SecretKey { set; get; } = GDFRandom.RandomStringKey();

        /// <summary>
        ///     The project status : active, inactive, upgrading data
        /// </summary>
        // TODO rename
        public GDFEnvironmentStatus Status { set; get; } = GDFEnvironmentStatus.Active;

        [GDFDbUnique(constraintName = "TreatKey")]
        [GDFDbLength(128)]
        public string TreatKey { set; get; } = GDFRandom.RandomStringKey();

        #region From interface IGDFDbStorage

        public long Project { get; set; }
        public long RowId { get; set; }

        #endregion

        #region From interface IGDFWritableData

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }

        public long DataVersion { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }

        #endregion

        #region From interface IGDFWritableLongReference

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents the credentials used in an GDF project.
        /// </summary>
        public GDFProjectCredentials()
        {
        }

        #endregion

        #region Instance methods

        #region From interface IGDFWritableData

        public object GetReference() => Reference;

        #endregion

        #endregion
    }
}