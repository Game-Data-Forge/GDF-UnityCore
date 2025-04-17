using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Class representing a payload for retrieving studio data by references.
    /// </summary>
    [Serializable]
    public class GDFUpPayloadStudioDataByReferences : GDFUpPayload
    {
        /// <summary>
        /// Represents a payload for updating studio data by references.
        /// </summary>
        public List<long> StudioDataReferenceList { set; get; }
    }
}