namespace GDFEditor
{
    /// <summary>
    /// Represents a data storage manager interface for IGDFDataStorageManager.
    /// </summary>
    public interface IGDFDataStorageManager
    {
        /// <summary>
        /// Processes a GDFRequestEditor and returns a GDFResponseEditor.
        /// </summary>
        /// <param name="sRequestRuntime">The GDFRequestEditor to process.</param>
        /// <returns>The GDFResponseEditor containing the response from the server.</returns>
        public GDFResponseEditor Process(GDFRequestEditor sRequestRuntime);
    }
}