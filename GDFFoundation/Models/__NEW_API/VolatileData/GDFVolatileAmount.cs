using System;
using GDFFoundation;

namespace GDFStandardModels
{
    /// <summary>
    /// The GDFVolatileAmount class represents a volatile amount object in the GDFStandardModels namespace.
    /// </summary>
    [Serializable]
    public sealed class GDFVolatileAmount : GDFVolatileData
    {
        /// <summary>
        /// Represents a volatile amount object.
        /// </summary>
        public float Amount { set; get; } = 0;

        /// <summary>
        /// Represents a volatile amount that can be stored in the database.
        /// </summary>
        public GDFVolatileAmount() : base() { }

        /// <summary>
        /// Represents volatile amount data used in GDFFoundation.
        /// </summary>
        public GDFVolatileAmount(IGDFVolatileAgent sVolatileManager, string sCategory, float sAmount, string sInformation = "") : base(sVolatileManager, sCategory, sInformation)
        {
            Amount = sAmount;
        }

        /// <summary>
        /// Represents a volatile amount for GDFFoundation.
        /// </summary>
        public GDFVolatileAmount(IGDFVolatileAgent sVolatileManager, Enum sCategory, float sAmount, string sInformation = "") : base(sVolatileManager, sCategory, sInformation)
        {
            Amount = sAmount;
        }
    }
}