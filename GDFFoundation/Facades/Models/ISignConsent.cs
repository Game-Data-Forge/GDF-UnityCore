#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj ISignConsent.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Flags]
    public enum ConsentOptions
    {
        None = 0,
        ConsentOne = 1 << 1,
        ConsentTwo = 1 << 2,
        ConsentThree = 1 << 3,
        ConsentFour = 1 << 4,
        ConsentFive = 1 << 5,
        ConsentSix = 1 << 6,
        ConsentSeven = 1 << 7,
        ConsentEight = 1 << 8,
        ConsentNine = 1 << 9,
        ConsentTen = 1 << 10,
        ConsentEleven = 1 << 11,
        ConsentTwelve = 1 << 12,
    }

    public interface ISignConsent : ISignCountry, ISignChannel
    {
        #region Instance fields and properties

        public bool Consent { set; get; }
        public string ConsentVersion { set; get; }
        public ConsentOptions GameConsentOptions { set; get; }
        public string GameConsentVersion { set; get; }

        #endregion
    }
}