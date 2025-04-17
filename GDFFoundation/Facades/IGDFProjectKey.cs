namespace GDFFoundation
{
    /// <summary>
    /// Represents a project key for a specific GDF project.
    /// </summary>
    public interface IGDFProjectKey
    {
        /// <summary>
        /// Retrieves the name of the project key instance.
        /// </summary>
        /// <returns>The name of the project key instance.</returns>
        public string GetProjectKeyInstanceName();

        /// <summary>
        /// Retrieves the project key for a given project ID and environment kind.
        /// </summary>
        /// <param name="sProjectReference">The project ID.</param>
        /// <param name="sEnvironmentKind">The environment kind.</param>
        /// <returns>The project key as a string.</returns>
        public string GetProjectKey(long sProjectReference, GDFEnvironmentKind sEnvironmentKind);
    }
}

