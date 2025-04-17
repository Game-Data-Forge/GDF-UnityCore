using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents the payload object for the down communication between the server and client, containing all studio data.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAllStudioData : GDFDownPayload
    {
        /// <summary>
        /// Represents the last synchronization time (in ticks) of the Studio data.
        /// </summary>
        public long StudioLastSync { set; get; }

        /// <summary>
        /// Represents a list of studio data.
        /// </summary>
        public List<GDFStudioDataStorage> StudioDataList
        { set; get; }
    }
}