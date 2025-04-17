namespace GDFFoundation
{
    /// <summary>
    /// Represents project information.
    /// </summary>
    public interface IGDFProjectInformation
    {
        /// <summary>
        /// Get the instance name of the project information.
        /// </summary>
        /// <returns>The instance name of the project information.</returns>
        public string GetProjectInformationInstanceName();

        /// <summary>
        /// Retrieves the project ID from the IGDFProjectInformation instance.
        /// </summary>
        /// <returns>The project ID.</returns>
        public long GetProjectReference();

        /// <summary>
        /// Gets the environment kind of the project.
        /// </summary>
        /// <returns>The environment kind.</returns>
        public GDFEnvironmentKind GetProjectEnvironment();
    }
}
