using System;

namespace GDFFoundation
{
    [Flags]
    public enum ConsentOptions
    {
        None = 0,
        ConsentOne = 1<<1,
        ConsentTwo = 1<<2,
        ConsentThree = 1<<3,
        ConsentFour = 1<<4,
        ConsentFive = 1<<5,
        ConsentSix = 1<<6,
        ConsentSeven = 1<<7,
        ConsentEight = 1<<8,
        ConsentNine = 1<<9,
        ConsentTen = 1<<10,
        ConsentEleven = 1<<11,
        ConsentTwelve = 1<<12,
    }
    
    public interface ISignConsent : ISignCountry, ISignChannel
    {
        public bool Consent { set; get; }
        public string ConsentVersion { set; get; }
        public string GameConsentVersion { set; get; }
        public ConsentOptions GameConsentOptions { set; get; }
    }
}