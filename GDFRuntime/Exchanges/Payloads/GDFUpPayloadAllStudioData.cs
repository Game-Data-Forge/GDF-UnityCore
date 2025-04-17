using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload class for uploading all studio data.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadAllStudioData : GDFUpPayload
    {
        /// <summary>
        /// Represents a payload object for storing a list of studio data.
        /// </summary>
        public List<GDFStudioDataStorage> StudioDataList { set; get; }
    }
}