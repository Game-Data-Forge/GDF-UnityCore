using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents the payload object for retrieving Studio data by bundle in the down communication between the server and client.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadStudioDataByBundle : GDFDownPayload
    {
        /// <summary>
        /// Represents the last synchronization timestamp of the studio data.
        /// </summary>
        /// <value>
        /// The last synchronization timestamp.
        /// </value>
        public long StudioLastSync { set; get; }

        /// <summary>
        /// Represents a payload object for downloading studio data by bundle.
        /// </summary>
        public List<GDFStudioDataStorage> StudioDataList { set; get; }
    }
}