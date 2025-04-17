

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Enum representing the track rights for a project.
    /// </summary>
    /// <remarks>
    /// This enum is used in <see cref="GDFProjectDescription"/> to define the rights for each track in a project.
    /// </remarks>
    [Serializable]
    //[Flags]
    public enum GDFTrackRights
    {
        /// <summary>
        /// No rights, not readable, not writable
        /// </summary>
        None = 0,

        /// <summary>
        /// Can read data in this environment and copy from this environment to a writable environment
        /// </summary>
        Read = 2,

        /// <summary>
        /// Can write data in this environment
        /// </summary>
        Write = 4,
    }
}

