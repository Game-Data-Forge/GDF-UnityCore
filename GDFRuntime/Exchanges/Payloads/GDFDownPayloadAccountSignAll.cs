using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// GDFDownPayloadAccountSignAll represents the payload object for the down communication between the server and client.
    /// It contains a list of GDFAccountSign objects.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAccountSignAll : GDFDownPayload
    {
        /// <summary>
        /// Represents a list of account sign information.
        /// </summary>
        public List<GDFAccountSign> AccountSignList { set; get; }
    }
}