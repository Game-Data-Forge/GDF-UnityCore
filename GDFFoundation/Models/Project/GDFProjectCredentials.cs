using System;

namespace GDFFoundation
{
    [Serializable]
    public class GDFNewStudioData : IGDFDbStorage, IGDFWritableData, IGDFWritableLongReference
    {
        public long RowId { get; set; }
        public long Project { get; set; }
        public long DataVersion { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }
        public object GetReference() => Reference;
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
    }
    
    [Serializable]
    public class GDFReportData : IGDFDbStorage, IGDFWritableData, IGDFWritableLongReference, IGDFRangedData
    {
        public long RowId { get; set; }
        public long Project { get; set; }
        public long DataVersion { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }
        public object GetReference() => Reference;
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        public int Range { get; set; }
    }
    
    [Serializable]
    public class GDFDashboardData : IGDFDbStorage, IGDFWritableData, IGDFWritableLongReference
    {
        public long RowId { get; set; }
        public long Project { get; set; }
        public long DataVersion { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }
        public object GetReference() => Reference;
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
    }

    [Serializable]
    public class GDFProjectMinimalCredentials 
    {
        public GDFEnvironmentKind Environment { set; get; }
        public string PublicKey { set; get; }
        
        public SavePolicyKind  SavePolicy { get; set; } = SavePolicyKind.LocalOnly;
        
        public GDFProjectMinimalCredentials()
        {
            Environment = GDFEnvironmentKind.Development;
            PublicKey = "";
        }

        public GDFProjectMinimalCredentials(GDFProjectCredentials projectCredentials)
        {
            Environment = projectCredentials.Environment;
            PublicKey = projectCredentials.PublicKey;
            SavePolicy  = projectCredentials.SavePolicy;
        }
    }

    /// <summary>
    /// Represents the credentials used in an GDF project.
    /// </summary>
    [Serializable]
    public class GDFProjectCredentials : IGDFDbStorage, IGDFWritableData, IGDFWritableLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; set; }
        /// <summary>
        /// Environment of this instance (use to change the table usage)
        /// </summary>
        // TODO rename Environment
        public GDFEnvironmentKind Environment { set; get; } = GDFEnvironmentKind.Development;
        /// <summary>
        /// The project status : active, inactive, upgrading data
        /// </summary>
// TODO rename
        public GDFEnvironmentStatus Status { set; get; } = GDFEnvironmentStatus.Active;
        /// <summary>
        /// The TreatKey for this project and this environment, use only by editor administration
        /// </summary>
     
        public SavePolicyKind  SavePolicy { get; set; } = SavePolicyKind.LocalOnly;
        
        [GDFDbUnique(constraintName = "TreatKey")]
        [GDFDbLength(128)]
        public string TreatKey { set; get; } = GDFRandom.RandomStringKey();
        [GDFDbUnique(constraintName = "PublicKey")]
        [GDFDbLength(128)]
        public string PublicKey { set; get; } = GDFRandom.RandomStringKey();
        [GDFDbUnique(constraintName = "SecretKey")]
        [GDFDbLength(128)]
        public string SecretKey { set; get; } = GDFRandom.RandomStringKey();
        public long RowId { get; set; }
        public long Project { get; set; }
        public long DataVersion { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
        public bool Trashed { get; set; }

        /// <summary>
        /// Represents the credentials used in an GDF project.
        /// </summary>
        public GDFProjectCredentials()
        {

        }

        public object GetReference() => Reference;
    }
}

