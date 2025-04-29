using System;
using System.Security.Claims;
using GDFFoundation;

namespace GDFFoundation
{
    [Serializable]
    public class MemoryJwtToken
    {
        public GDFEnvironmentKind Environment { get; set; }
        public long Project { get; set; }
        public short Channel { get; set; }
        public long Account { get; set; }
        public short Range { get; set; }
        public string Token { get; set; }
        public string Country { get; set; }

        public MemoryJwtToken()
        {
            Project = 0;
            Channel = 0;
            Account = 0;
            Range = 0;
            Token = string.Empty;
            Country = string.Empty;
        }

        public bool IsValid()
        {
            return Project != 0 && Channel > 0 && Account != 0 && Range != 0 && !string.IsNullOrEmpty(Token);
        }

        public GDFCountryISO GetCountry()
        {
            return GDFCountryISO.GetFromTwoLetterCode(Country);
        }
    }
}