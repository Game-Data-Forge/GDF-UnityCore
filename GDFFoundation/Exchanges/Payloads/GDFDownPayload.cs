

using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// GDFDownPayload class represents the payload object for the down communication between the server and client.
    /// </summary>
    [Serializable]
    public class GDFDownPayload
    {
        /// <summary>
        /// Represents a list of GDFAccountService objects.
        /// </summary>
        public List<GDFAccountService> AccountServiceList { set; get; } = new List<GDFAccountService>();
    }
}

