using System;
using GDFFoundation;

namespace GDFStandardModels
{
    /// <summary>
    /// The GDFVolatileBoolean class represents a volatile boolean value in the GDFStandardModels namespace.
    /// </summary>
    [Serializable]
    public sealed class GDFVolatileBoolean : GDFVolatileData
    {
        /// <summary>
        /// Represents a volatile boolean value.
        /// </summary>
        public bool Boolean { set; get; } = false;

        /// <summary>
        /// The GDFVolatileBoolean class represents a volatile boolean value that can be stored in the database.
        /// </summary>
        public GDFVolatileBoolean() : base()
        {
        }

        /// <summary>
        /// Represents a volatile boolean used in GDFFoundation.
        /// </summary>
        public GDFVolatileBoolean(IGDFVolatileAgent sVolatileManager, string sCategory, bool sBoolean, string sInformation = "") : base(sVolatileManager, sCategory, sInformation)
        {
            Boolean = sBoolean;
        }

        /// Represents a class for handling volatile boolean data.
        /// /
        public GDFVolatileBoolean(IGDFVolatileAgent sVolatileManager, Enum sCategory, bool sBoolean, string sInformation = "") : base(sVolatileManager, sCategory, sInformation)
        {
            Boolean = sBoolean;
        }
    }
}