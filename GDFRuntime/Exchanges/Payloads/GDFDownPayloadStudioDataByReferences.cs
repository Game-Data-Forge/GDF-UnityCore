using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents the payload object for the down communication between the server and client.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadStudioDataByReferences : GDFDownPayload
    {
        public List<GDFStudioDataStorage> StudioDataList { set; get; }
    }
}