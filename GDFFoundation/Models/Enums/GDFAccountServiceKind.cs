#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFAccountServiceKind.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


namespace GDFFoundation
{
    /// <summary>
    ///     Enum representing the kind of account service.
    /// </summary>
    public enum GDFAccountServiceKind
    {
        /// <summary>
        ///     The original kind of GDFAccountService.
        /// </summary>
        Original = 0,

        /// <summary>
        ///     Represents the status of a granted account service.
        /// </summary>
        Granted = 1,

        /// <summary>
        ///     Represents the Transferred member of the GDFAccountServiceKind enum.
        /// </summary>
        /// <remarks>
        ///     This member is used to indicate that a service has been transferred to another account.
        /// </remarks>
        Transferred = 2,
    }
}