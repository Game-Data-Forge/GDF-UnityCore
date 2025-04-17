using System;
using GDFFoundation;

namespace GDFEditor
{
    /// <summary>
    /// Represents sub metadata for GDFSubMetaData.
    /// </summary>
    public class GDFSubMetaData
    {
        /// <summary>
        /// Gets or sets the track ID of the GDFSubMetaData.
        /// </summary>
        public int TrackId { set; get; }

        /// <summary>
        /// Gets or sets the track kind of the GDFSubMetaData.
        /// </summary>
        public GDFEnvironmentKind TrackKind { set; get; }

        /// <summary>
        /// Represents the state of a sub metadata for GDFSubMetaData.
        /// </summary>
        public GDFSubMetaDataState State { set; get; }

        /// <summary>
        /// Represents the origin of a sub metadata. The origin is an identifier that indicates the source or reference track for the sub metadata.
        /// </summary>
        public long Origin { set; get; }

        /// <summary>
        /// Represents the data property of a GDFSubMetaData object.
        /// </summary>
        public string Data { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the sub metadata is trashed.
        /// </summary>
        public bool Trashed { set; get; }

        public DateTime Modification { set; get; }

        /// <summary>
        /// Adds a state to the GDFSubMetaDataState enumeration.
        /// </summary>
        /// <param name="sState">The state to add.</param>
        public void AddState(GDFSubMetaDataState sState)
        {
            State |= sState;
        }

        /// <summary>
        /// Removes a state from the GDFSubMetaDataState enumeration.
        /// </summary>
        /// <param name="sState">The state to remove.</param>
        public void RemoveState(GDFSubMetaDataState sState)
        {
            State = ~sState & State;
        }
    }
}
