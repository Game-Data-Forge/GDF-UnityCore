

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an account dependence that references another account
    /// </summary> 
    [Obsolete("Use IGDFAccountData instead !")]
    public interface IGDFAccountDependence : IGDFAccountRange
    {
        /// <summary>
        /// The primary account this dependence is associated with
        /// </summary>
        public long Account { set; get; }

    }
}

