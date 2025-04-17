using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents the payload object for the down communication between the server and client.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadAccountSignUp : GDFDownPayload
    {
        /// <summary>
        /// Represents a reference to an account sign.
        /// </summary>
        public long SignReference { set; get; }

        /// <summary>
        /// Represents a list of account signs.
        /// </summary>
        /// <remarks>
        /// The <see cref="AccountSignList"/> property contains a collection of <see cref="GDFAccountSign"/> objects
        /// that represent different sign-in methods for an account.
        /// </remarks>
        public List<GDFAccountSign> AccountSignList { set; get; } = new List<GDFAccountSign>();
    }
}