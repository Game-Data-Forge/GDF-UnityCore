

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Class representing storage statistics for a project.
    /// </summary>
    [Serializable]
    public class GDFProjectStorageStat : GDFProjectStat
    {
        /// <summary>
        /// Represents the total storage used by a project.
        /// </summary>
        public double StorageUserTotal { set; get; } = 1;

        /// <summary>
        /// Represents the total storage value for a project.
        /// </summary>
        public double StoragePlayerTotal { set; get; } = 1;

        /// <summary>
        /// Gets or sets the total storage used by a project.
        /// </summary>
        /// <value>The total storage used by a project.</value>
        public double StorageTotal { set; get; } = 1;

        /// <summary>
        /// Represents project storage statistics data.
        /// </summary>
        public GDFProjectStorageStat()
        {
        }
    }
}

