namespace GDFFoundation
{

    public interface IGDFConfiguration
    {
        
    }
    
    /// <summary>
    /// Interface allowing to create classes which will be used as configurators in particular environments.
    /// </summary>
    public interface IGDFConfig : IGDFProjectKey //, IGDFProjectLocalization
    {
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
        public string WebEditorURL();
        public string WebServerURLFormat();
        public long GetProjectReference();
        public GDFExchangeDevice GetDeviceOS();
        public GDFDataTrackDescription GetSelectedEnvironment();
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