using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an account token.
    /// </summary>
    [Serializable]
    public class GDFAccountToken : GDFAccountData
    {
        /// <summary>
        /// Enum representing the origin of an exchange.
        /// </summary>
        public GDFExchangeOrigin ExchangeOrigin { set; get; }
        public int Channel { set; get; }
        /// <summary>
        /// Represents a token used in an account.
        /// </summary>
        [GDFDbLength(GDFConstants.K_TOKEN_LENGHT)]
        public string Token { set; get; } = string.Empty;

        public GDFAccountToken()
        {
            Project = 0;
            Account = 0;
            Range = 0;
            ExchangeOrigin = GDFExchangeOrigin.Unknown;
        }

        /// <summary>
        /// Represents an account token associated with a specific exchange origin and token.
        /// </summary>
        public GDFAccountToken(GDFRequestPlayerToken sToCopy)
        {
            Project = sToCopy.ProjectReference;
            Account = sToCopy.PlayerReference;
            Range = sToCopy.AccountRange;
            ExchangeOrigin = sToCopy.ExchangeOrigin;
            Token = sToCopy.Token;
        }
    }
}

