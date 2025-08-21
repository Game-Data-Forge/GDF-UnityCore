#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFAccountConsent.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public class GDFAccountConsent : GDFAccountData, ISignConsent, ISignCountry
    {
        #region Instance fields and properties

        [GDFDbLength(64)]
        public string Address { get; set; } = string.Empty;

        #region From interface ISignConsent

        public short Channel { get; set; } = 0;

        public bool Consent { set; get; } = false;
        [GDFDbLength(32)]
        public string ConsentVersion { set; get; } = "0.0.0";
        public Country Country { get; set; }
        public ConsentOptions GameConsentOptions { set; get; } = ConsentOptions.None;
        [GDFDbLength(32)]
        public string GameConsentVersion { set; get; } = "0.0.0";

        #endregion

        #endregion
    }
}