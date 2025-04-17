using System;
using GDFFoundation;

namespace GDFStandardModels
{
    /// <summary>
    /// The GDFVolatileException class represents an exception specific to volatile data in the GDFFoundation namespace.
    /// This class inherits from GDFVolatileData.
    /// </summary>
    /// <remarks>
    /// <para>This class captures the exception message and help link associated with the exception that occurred.</para>
    /// <para>To create an instance of GDFVolatileException, use the constructor that matches your requirements.</para>
    /// </remarks>
    [Serializable]
    public sealed class GDFVolatileException : GDFVolatileData
    {
        /// <summary>
        /// The Message property represents the message of the exception that caused the GDFVolatileException to be thrown.
        /// </summary>
        public string Message { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the help link associated with this GDFVolatileException.
        /// </summary>
        public string HelpLink { set; get; } = string.Empty;

        public GDFVolatileException()
        {
        }

        /// <summary>
        /// Represents a volatile exception used in GDFFoundation.
        /// </summary>
        public GDFVolatileException(IGDFVolatileAgent sVolatileManager, string sCategory, Exception sException, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Message = sException.Message;
            HelpLink = sException.HelpLink;
        }

        /// <summary>
        /// Represents a volatile exception for GDFFoundation.
        /// </summary>
        public GDFVolatileException(IGDFVolatileAgent sVolatileManager, Enum sCategory, Exception sException, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Message = sException.Message;
            HelpLink = sException.HelpLink;
        }
    }
}