#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj ConsentExchange.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public class ConsentExchange : ISignConsent, ISignCountry, ISignChannel
    {
        #region Instance fields and properties

        #region From interface ISignConsent

        public short Channel { get; set; }
        public bool Consent { set; get; }
        public string ConsentVersion { set; get; }
        public Country Country { get; set; }
        public ConsentOptions GameConsentOptions { set; get; }
        public string GameConsentVersion { set; get; }

        #endregion

        #endregion
    }
}