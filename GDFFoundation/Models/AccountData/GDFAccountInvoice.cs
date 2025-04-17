

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an account invoice that is associated with an account and contains invoice details.
    /// Inherits from GDFAccountData.
    /// </summary>
    [Serializable]
    public class GDFAccountInvoice : GDFAccountData
    {
        /// <summary>
        /// Name of the GDFAccountInvoice object.
        /// </summary>
        /// <remarks>
        /// This property represents the name of the GDFAccountInvoice object.
        /// </remarks>
        public string Name { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the payload for the GDFAccountInvoice.
        /// </summary>
        /// <remarks>
        /// The payload can be any additional data that needs to be associated with the invoice. It is stored as a string.
        /// </remarks>
        public string Payload { set; get; } = string.Empty;

        /// Url property of GDFAccountInvoice
        /// <p>The Url property is a string representation of a URL associated with an GDFAccountInvoice object.</p> <p>It is used to store and retrieve the URL of a specific invoice.</p>
        /// @see GDFAccountInvoice
        /// /
        public string Url { set; get; } = string.Empty;
    }
}

