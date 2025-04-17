

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an account order.
    /// </summary>
    /// <remarks>
    /// This class inherits from GDFAccountData and adds three properties Name, Payload, and Url.
    /// </remarks>
    [Serializable]
    public class GDFAccountOrder : GDFAccountData
    {
        /// <summary>
        /// The name of the account order.
        /// </summary>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the payload of the GDFAccountOrder.
        /// </summary>
        /// <remarks>
        /// The payload is a string property that stores additional data related to the GDFAccountOrder.
        /// It can be used to store any kind of additional information that is not directly represented by other properties.
        /// </remarks>
        public string Payload { set; get; } = string.Empty;

        /// <summary>
        /// The URL associated with an account order.
        /// </summary>
        public string Url { set; get; } = string.Empty;
    }
}

