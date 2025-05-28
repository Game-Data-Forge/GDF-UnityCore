#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFTrackRights.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Enum representing the track rights for a project.
    /// </summary>
    /// <remarks>
    ///     This enum is used in <see cref="GDFProjectDescription" /> to define the rights for each track in a project.
    /// </remarks>
    [Serializable]
    //[Flags]
    public enum GDFTrackRights
    {
        /// <summary>
        ///     No rights, not readable, not writable
        /// </summary>
        None = 0,

        /// <summary>
        ///     Can read data in this environment and copy from this environment to a writable environment
        /// </summary>
        Read = 2,

        /// <summary>
        ///     Can write data in this environment
        /// </summary>
        Write = 4,
    }
}