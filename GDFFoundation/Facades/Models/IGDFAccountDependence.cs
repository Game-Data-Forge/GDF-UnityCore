#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFAccountDependence.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents an account dependence that references another account
    /// </summary>
    [Obsolete("Use IGDFAccountData instead !")]
    public interface IGDFAccountDependence : IGDFAccountRange
    {
        #region Instance fields and properties

        /// <summary>
        ///     The primary account this dependence is associated with
        /// </summary>
        public long Account { set; get; }

        #endregion
    }
}