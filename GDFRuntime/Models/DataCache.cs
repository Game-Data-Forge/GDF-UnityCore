namespace GDFRuntime
{
    /// <summary>
    /// This class represents a general data structure for storing in-memory data.
    /// It is used for synchronization of user, player, and studio data.
    /// </summary>
    public class DataCache
    {
        /// <summary>
        /// Class representing user data stored in memory.
        /// </summary>
        public StringReferenceCache UserDataInMemory { set; get; } = new StringReferenceCache();

        /// <summary>
        /// Class representing player data stored in memory.
        /// </summary>
        public StringReferenceCache PlayerDataInMemory { set; get; } = new StringReferenceCache();

        /// <summary>
        /// Represents a class for storing data in memory.
        /// </summary>
        public LongReferenceCache StudioDataInMemory { set; get; } = new LongReferenceCache();
    }
}