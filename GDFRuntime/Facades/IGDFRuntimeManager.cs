namespace GDFRuntime
{
    /// <summary>
    /// Represents the interface for the GDFRuntimeManager.
    /// </summary>
    public interface IGDFRuntimeManager
    {
        /// <summary>
        /// Processes the GDFRequestRuntime and returns a GDFResponseRuntime object.
        /// </summary>
        /// <param name="sRequestRuntime">The GDFRequestRuntime object to process.</param>
        /// <returns>A GDFResponseRuntime object containing the response data.</returns>
        public GDFResponseRuntime Process(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime Test(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime None(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime AccountDelete(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime AccountChangeRange(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime SignOut(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime SignIn(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime SignUp(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime SignLost(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime SignRescue(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime SignAdd(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime SignModify(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime SignDelete(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime GetAllSign(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime SyncDataByIncrement(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime GetAllData(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime GetAllPlayerData(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime GetPlayerDataByReferences(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime GetPlayerDataByBundle(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime GetAllStudioData(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime GetStudioDataByReferences(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime GetStudioDataByBundle(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime CreateRelationship(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime GetRelationship(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime LinkRelationship(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime FinalizeRelationship(GDFRequestRuntime sRequestRuntime);
        // public GDFResponseRuntime UpdateRelationship(GDFRequestRuntime sRequestRuntime);
    }
}