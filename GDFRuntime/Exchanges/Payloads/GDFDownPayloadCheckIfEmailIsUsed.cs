using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a payload object for checking if an email is used.
    /// </summary>
    [Serializable]
    public class GDFDownPayloadCheckIfEmailIsUsed : GDFDownPayload
    {
        /// <summary>
        /// Represents a payload object for checking if an email is already used.
        /// </summary>
        public bool EmailIsUsed { set; get; }


        /// <summary>
        /// The GDFDownPayloadCheckIfEmailIsUsed class represents the payload object for checking if an email is used.
        /// </summary>
        public GDFDownPayloadCheckIfEmailIsUsed()
        {
        }

        /// <summary>
        /// Represents a payload for checking if an email is already in use.
        /// </summary>
        public GDFDownPayloadCheckIfEmailIsUsed(bool sEmailIsUsed)
        {
            EmailIsUsed = sEmailIsUsed;
        }
    }
}