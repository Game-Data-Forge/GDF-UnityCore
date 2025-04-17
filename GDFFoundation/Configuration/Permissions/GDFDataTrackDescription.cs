

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a track description for GDF data.
    /// </summary>
    [Serializable]
    //[Obsolete("Pourquoi c'est un heritage de 'GDFLocalWebData' ... c'est pas un heritage de GDFDatabasebBasicModel?")]
    public class GDFDataTrackDescription : GDFLocalWebData
    {
        /// <summary>
        /// The data track identifier.
        /// There is a unique couple (<see cref="Track"/>, <see cref="Kind"/>).
        /// </summary>
        public int Track { set; get; }

        /// <summary>
        /// Represents a reference to a stalked object.
        /// </summary>
        /// <remarks>
        /// StalkedReference property is used to identify and track a stalked object associated with a data track.
        /// </remarks>
        public long StalkedReference { set; get; }

        /// <summary>
        /// The kind of environment for a data track.
        /// </summary>
        public GDFEnvironmentKind Kind { set; get; }

        /// <summary>
        /// The name of the data track description.
        /// </summary>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        /// The Color property represents the color of a data track.
        /// </summary>
        /// <remarks>
        /// This property is defined in the class GDFProjectDataTrack.
        /// </remarks>
        public string Color { set; get; } = "FFFFFFFF";

        /// <summary>
        /// Represents a data track description in the GDFFoundation namespace.
        /// </summary>
        public GDFDataTrackDescription()
        {

        }
    }
}
