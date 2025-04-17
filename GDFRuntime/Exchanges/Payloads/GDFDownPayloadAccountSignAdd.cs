using System;
using GDFFoundation;

namespace GDFRuntime
{
    /// Represents a payload object for adding an account sign.
    /// /
    [Serializable]
    public class GDFDownPayloadAccountSignAdd : GDFDownPayload
    {
        public GDFAccountSign AccountSign { set; get; }
    }
}