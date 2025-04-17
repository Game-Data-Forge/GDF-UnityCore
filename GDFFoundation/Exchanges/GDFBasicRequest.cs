

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Base class for all GDF requests.
    /// </summary>
    [Serializable]
    public abstract class GDFBasicRequest : GDFBasicExchange
    {
        /// <summary>
        /// Represents the origin of an exchange.
        /// </summary>
        public GDFExchangeOrigin Origin { set; get; } = GDFExchangeOrigin.Unknown;

        /// <summary>
        /// The device used for the request.
        /// </summary>
        public GDFExchangeDevice Device { set; get; } = GDFExchangeDevice.Unknown;

    }
}


