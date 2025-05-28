#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFAccountToken.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents an account token.
    /// </summary>
    [Serializable]
    public class GDFAccountToken : GDFAccountData
    {
        #region Instance fields and properties

        public int Channel { set; get; }

        /// <summary>
        ///     Enum representing the origin of an exchange.
        /// </summary>
        public GDFExchangeOrigin ExchangeOrigin { set; get; }

        /// <summary>
        ///     Represents a token used in an account.
        /// </summary>
        [GDFDbLength(GDFConstants.K_TOKEN_LENGHT)]
        public string Token { set; get; } = string.Empty;

        #endregion

        #region Instance constructors and destructors

        public GDFAccountToken()
        {
            Project = 0;
            Account = 0;
            Range = 0;
            ExchangeOrigin = GDFExchangeOrigin.Unknown;
        }

        /// <summary>
        ///     Represents an account token associated with a specific exchange origin and token.
        /// </summary>
        public GDFAccountToken(GDFRequestPlayerToken sToCopy)
        {
            Project = sToCopy.ProjectReference;
            Account = sToCopy.PlayerReference;
            Range = sToCopy.AccountRange;
            ExchangeOrigin = sToCopy.ExchangeOrigin;
            Token = sToCopy.Token;
        }

        #endregion
    }
}