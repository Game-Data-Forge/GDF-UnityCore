using System;

namespace GDFFoundation
{
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
}