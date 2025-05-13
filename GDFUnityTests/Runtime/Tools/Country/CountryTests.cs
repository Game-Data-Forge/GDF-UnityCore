using GDFFoundation;
using NUnit.Framework;

namespace Tools
{
    public class CountryTests
    {
        [TestCase("fr")]
        [TestCase("FR")]
        [TestCase("fR")]
        [TestCase("Fr")]
        public void CanFindCountryByTwoLetterCode(string code)
        {
            Country country = Country.FromTwoLetterCode(code);
            Assert.IsNotNull(country);
            Assert.IsNotNull(country.Name);
            Assert.IsNotEmpty(country.Name);
        }
        
        [TestCase("")]
        [TestCase("xx")]
        [TestCase("XX")]
        [TestCase("azertyuiop")]
        public void ReturnsEmptyIfNotFound(string code)
        {
            Country country = Country.FromTwoLetterCode(code);
            Assert.IsNotNull(country);
            Assert.IsEmpty(country.Name);
        }
    }
}