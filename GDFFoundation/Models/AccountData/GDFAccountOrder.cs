#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFAccountOrder.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents an account order.
    /// </summary>
    /// <remarks>
    ///     This class inherits from GDFAccountData and adds three properties Name, Payload, and Url.
    /// </remarks>
    [Serializable]
    public class GDFAccountOrder : GDFAccountData
    {
        #region Instance fields and properties

        /// <summary>
        ///     The name of the account order.
        /// </summary>
        [GDFDbLength(1024)] 
        public string Name { set; get; } = string.Empty;

        /// <summary>
        ///     Gets or sets the payload of the GDFAccountOrder.
        /// </summary>
        /// <remarks>
        ///     The payload is a string property that stores additional data related to the GDFAccountOrder.
        ///     It can be used to store any kind of additional information that is not directly represented by other properties.
        /// </remarks>
        [GDFDbLength(1024)]
        public string Payload { set; get; } = string.Empty;

        /// <summary>
        ///     The URL associated with an account order.
        /// </summary>
        [GDFDbLength(1024)]
        public string Url { set; get; } = string.Empty;

        #endregion
    }
}