namespace GDFFoundation
{
    public interface IGDFSecretKey
    {
        /// <summary>
        /// Gets the instance name of the secret key.
        /// </summary>
        /// <returns>The instance name of the secret key.</returns>
        public string GetSecretKeyInstanceName();

        /// <summary>
        /// Retrieves the secret key for the specified project and environment.
        /// </summary>
        /// <param name="sProjectReference">The ID of the project.</param>
        /// <param name="sEnvironmentKind">The environment kind.</param>
        /// <returns>The secret key as a string.</returns>
        public string GetSecretKey(long sProjectReference, GDFEnvironmentKind sEnvironmentKind);
    }
}
