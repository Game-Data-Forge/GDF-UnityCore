using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload object for modifying account signs in the down communication between the server and client.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAccountSignModify : GDFDownPayload
    {
        /// <summary>
        /// Represents a list of account signs.
        /// </summary>
        public List<GDFAccountSign> AccountSignList { set; get; } = new List<GDFAccountSign>();
    }
}