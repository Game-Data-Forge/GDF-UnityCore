#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFVolatileException.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using GDFFoundation;

#endregion

namespace GDFStandardModels
{
    /// <summary>
    ///     The GDFVolatileException class represents an exception specific to volatile data in the GDFFoundation namespace.
    ///     This class inherits from GDFVolatileData.
    /// </summary>
    /// <remarks>
    ///     <para>This class captures the exception message and help link associated with the exception that occurred.</para>
    ///     <para>To create an instance of GDFVolatileException, use the constructor that matches your requirements.</para>
    /// </remarks>
    [Serializable]
    public sealed class GDFVolatileException : GDFVolatileData
    {
        #region Instance fields and properties

        /// <summary>
        ///     Gets or sets the help link associated with this GDFVolatileException.
        /// </summary>
        public string HelpLink { set; get; } = string.Empty;

        /// <summary>
        ///     The Message property represents the message of the exception that caused the GDFVolatileException to be thrown.
        /// </summary>
        public string Message { set; get; } = string.Empty;

        #endregion

        #region Instance constructors and destructors

        public GDFVolatileException()
        {
        }

        /// <summary>
        ///     Represents a volatile exception used in GDFFoundation.
        /// </summary>
        public GDFVolatileException(IGDFVolatileAgent sVolatileManager, string sCategory, Exception sException, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Message = sException.Message;
            HelpLink = sException.HelpLink;
        }

        /// <summary>
        ///     Represents a volatile exception for GDFFoundation.
        /// </summary>
        public GDFVolatileException(IGDFVolatileAgent sVolatileManager, Enum sCategory, Exception sException, string sInformation = "")
            : base(sVolatileManager, sCategory, sInformation)
        {
            Message = sException.Message;
            HelpLink = sException.HelpLink;
        }

        #endregion
    }
}