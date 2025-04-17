using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents the payload for an account change range request in the GDF server.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAccountChangeRange : GDFDownPayload
    {
        /// <summary>
        /// Represents the payload for an account change range request in the GDF server.
        /// </summary>
        public GDFDownPayloadAccountChangeRange()
        {
            AccountSignList = new List<GDFAccountSign>();
            PlayerDataList = new List<GDFPlayerDataStorage>();
        }
        
        /// <summary>
        /// Represents the payload for an account change range request in the GDF server.
        /// </summary>
        public GDFDownPayloadAccountChangeRange(List<GDFAccountSign> sAccountSignList, List<GDFPlayerDataStorage> sPlayerDataList)
        {
            AccountSignList = sAccountSignList;
            PlayerDataList = sPlayerDataList;
        }

        /// <summary>
        /// Gets or sets the list of account sign information.
        /// </summary>
        public List<GDFAccountSign> AccountSignList { set; get; }

        /// <summary>
        /// Represents a list of GDFPlayerDataStorage objects.
        /// </summary>
        public List<GDFPlayerDataStorage> PlayerDataList { set; get; }
    }
}