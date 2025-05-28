#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFBasicRequest.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Base class for all GDF requests.
    /// </summary>
    [Serializable]
    public abstract class GDFBasicRequest : GDFBasicExchange
    {
        #region Instance fields and properties

        /// <summary>
        ///     The device used for the request.
        /// </summary>
        public GDFExchangeDevice Device { set; get; } = GDFExchangeDevice.Unknown;

        /// <summary>
        ///     Represents the origin of an exchange.
        /// </summary>
        public GDFExchangeOrigin Origin { set; get; } = GDFExchangeOrigin.Unknown;

        #endregion
    }
}