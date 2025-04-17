using System;
using GDFFoundation;

namespace GDFStandardModels
{
    /// <summary>
    /// The GDFVolatileEnum class represents a volatile enumeration object in the GDFStandardModels namespace.
    /// </summary>
    [Serializable]
    public sealed class GDFVolatileEnum : GDFVolatileData
    {
        /// <summary>
        /// The GDFVolatileEnum class represents a volatile enumeration in the GDFStandardModels namespace.
        /// </summary>
        public Enum Enumeration { set; get; }

        /// <summary>
        /// The GDFVolatileEnum class represents a volatile enumeration in the database.
        /// </summary>
        public GDFVolatileEnum() : base() { }

        /// <summary>
        /// Represents a volatile enum data used in GDFFoundation.
        /// </summary>
        public GDFVolatileEnum(IGDFVolatileAgent sVolatileManager, string sCategory, Enum sEnum, string sInformation = "") : base(sVolatileManager, sCategory, sInformation)
        {
            Enumeration = sEnum;
        }

        /// <summary>
        /// Represents a volatile enumeration data for GDFFoundation.
        /// </summary>
        public GDFVolatileEnum(IGDFVolatileAgent sVolatileManager, Enum sCategory, Enum sEnum, string sInformation = "") : base(sVolatileManager, sCategory, sInformation)
        {
            Enumeration = sEnum;
        }
    }
}