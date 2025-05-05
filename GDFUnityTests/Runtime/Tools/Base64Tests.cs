using NUnit.Framework;
using GDFFoundation;

namespace Tools
{
    public class Base64Tests
    {
        [TestCase(new object[] { "azertyuiopqsdfg", "YXplcnR5dWlvcHFzZGZn" })]
        [TestCase(new object[] { "azertyuiopqsdfghj", "YXplcnR5dWlvcHFzZGZnaGo=" })]
        [TestCase(new object[] { "azertyuiopqsdfghjkl", "YXplcnR5dWlvcHFzZGZnaGprbA==" })]
        [TestCase(new object[] { "éèâîôûïöê", "w6nDqMOiw67DtMO7w6/DtsOq" })]
        [TestCase(new object[] { "ÿÿÿ", "w7/Dv8O/" })]
        public void Base64Encoding(string value, string base64)
        {
            Assert.AreEqual(base64, value.ToBase64());
        }

        [TestCase(new object[] { "YXplcnR5dWlvcHFzZGZn", "azertyuiopqsdfg" })]
        [TestCase(new object[] { "YXplcnR5dWlvcHFzZGZnaGo=", "azertyuiopqsdfghj" })]
        [TestCase(new object[] { "YXplcnR5dWlvcHFzZGZnaGprbA==", "azertyuiopqsdfghjkl" })]
        [TestCase(new object[] { "w6nDqMOiw67DtMO7w6/DtsOq", "éèâîôûïöê" })]
        [TestCase(new object[] { "w7/Dv8O/", "ÿÿÿ" })]
        public void Base64Decoding(string base64, string value)
        {
            Assert.AreEqual(value, base64.FromBase64());
        }

        [TestCase(new object[] { "azertyuiopqsdfg", "YXplcnR5dWlvcHFzZGZn" })]
        [TestCase(new object[] { "azertyuiopqsdfghj", "YXplcnR5dWlvcHFzZGZnaGo" })]
        [TestCase(new object[] { "azertyuiopqsdfghjkl", "YXplcnR5dWlvcHFzZGZnaGprbA" })]
        [TestCase(new object[] { "éèâîôûïöê", "w6nDqMOiw67DtMO7w6_DtsOq" })]
        [TestCase(new object[] { "ÿÿÿ", "w7_Dv8O_" })]
        public void Base64URLEncoding(string value, string base64)
        {
            Assert.AreEqual(base64, value.ToBase64URL());
        }

        [TestCase(new object[] { "YXplcnR5dWlvcHFzZGZn", "azertyuiopqsdfg" })]
        [TestCase(new object[] { "YXplcnR5dWlvcHFzZGZnaGo", "azertyuiopqsdfghj" })]
        [TestCase(new object[] { "YXplcnR5dWlvcHFzZGZnaGprbA", "azertyuiopqsdfghjkl" })]
        [TestCase(new object[] { "w6nDqMOiw67DtMO7w6_DtsOq", "éèâîôûïöê" })]
        [TestCase(new object[] { "w7_Dv8O_", "ÿÿÿ" })]
        public void Base64URLDecoding(string base64, string value)
        {
            Assert.AreEqual(value, base64.FromBase64URL());
        }
    }
}