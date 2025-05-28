#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFConfig.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public interface IGDFConfiguration
    {
    }

    /// <summary>
    ///     Interface allowing to create classes which will be used as configurators in particular environments.
    /// </summary>
    public interface IGDFConfig : IGDFProjectKey //, IGDFProjectLocalization
    {
        #region Instance methods

        /*
        #region interface

        /// <summary>
        /// All Environments in project
        /// </summary>
        /// <returns></returns>
        public GDFEnvironment[] ReturnAllEnabledEnvironments();

        public GDFEnvironment[] ReturnAllDisabledEnvironments();

        public GDFEnvironment ReturnActiveEnvironment();

        */
        //public string ServerURL();

        //public string WebSiteURL();

        public string GetDefaultWebEditor();
        public GDFExchangeDevice GetDeviceOS();
        public long GetProjectReference();
        public GDFDataTrackDescription GetSelectedEnvironment();
        public string WebEditorURL();
        public string WebServerURLFormat();

        #endregion

        /*
        /// <summary>
        /// Active environment in build or runtime
        /// </summary>
        /// <returns></returns>
        //public GDFEnvironment ReturnActiveEnvironment();

        public void Prepare();

        /// <summary>
        /// Save this config
        /// </summary>
        public void Save();

        /// <summary>
        /// Create all datamanager by environment
        /// </summary>
        public IGDFDatabaseConnection CreateDatabasesConnectionEnvironment(GDFEnvironment sEnvironment);

        /// <summary>
        /// Allows the use of a serializer by config
        /// </summary>
        /// <param name="sObject"></param>
        /// <returns></returns>
        public string ToJson(Object sObject);

        #endregion
        */
    }
}