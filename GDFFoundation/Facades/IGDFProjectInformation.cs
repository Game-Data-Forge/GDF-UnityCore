#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFProjectInformation.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents project information.
    /// </summary>
    public interface IGDFProjectInformation
    {
        #region Instance methods

        /// <summary>
        ///     Gets the environment kind of the project.
        /// </summary>
        /// <returns>The environment kind.</returns>
        public ProjectEnvironment GetProjectEnvironment();

        /// <summary>
        ///     Get the instance name of the project information.
        /// </summary>
        /// <returns>The instance name of the project information.</returns>
        public string GetProjectInformationInstanceName();

        /// <summary>
        ///     Retrieves the project ID from the IGDFProjectInformation instance.
        /// </summary>
        /// <returns>The project ID.</returns>
        public long GetProjectReference();

        #endregion
    }
}