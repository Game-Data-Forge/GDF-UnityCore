#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFSecretKey.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public interface IGDFSecretKey
    {
        #region Instance methods

        /// <summary>
        ///     Retrieves the secret key for the specified project and environment.
        /// </summary>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sEnvironmentKind">The environment kind.</param>
        /// <returns>The secret key as a string.</returns>
        public string GetSecretKey(long sProjectReference, ProjectEnvironment sEnvironmentKind);

        /// <summary>
        ///     Gets the instance name of the secret key.
        /// </summary>
        /// <returns>The instance name of the secret key.</returns>
        public string GetSecretKeyInstanceName();

        #endregion
    }
}