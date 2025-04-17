using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload object for deleting account sign information.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAccountSignDelete : GDFDownPayload
    {
        /// <summary>
        /// Represents a list of account signs.
        /// </summary>
        public List<GDFAccountSign> AccountSignList { set; get; }
    }
}