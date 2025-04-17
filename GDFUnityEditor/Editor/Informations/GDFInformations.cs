using GDFFoundation;

namespace GDFUnityEditor
{
    /// <summary>
    /// The GDFUnityEditorInformation class provides information about the GDFUnityEditor DLL.
    /// </summary>
    public static class GDFUnityEditorInformation
    {
        /// <summary>
        /// Represents the version information for the GDFUnityEditor DLL.
        /// </summary>
        public static GDFReleaseVersion Version = GDFVersionDll.Version;

        /// <summary>
        /// Provides information about the GDFUnityEditor DLL version.
        /// </summary>
        /// <returns>The version number of the GDFUnityEditor DLL.</returns>
        public static string Description()
        {
            return typeof(GDFUnityEditorInformation).Namespace + " DLL, version " + Version.ToString();
        }
    }
}
