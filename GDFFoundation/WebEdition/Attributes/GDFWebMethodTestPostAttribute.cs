

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute used to specify the test post condition for a web method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class GDFWebMethodTestPostAttribute : Attribute
    {
        /// <summary>
        /// Represents an attribute used to specify the linearized JSON data for a test POST method.
        /// </summary>
        private string _PostLinearized;
        private int[] _Expected;


        /// <summary>
        /// Attribute used for testing a web method with a POST request.
        /// </summary>
        public GDFWebMethodTestPostAttribute(string sPostLinearized, params int[] expectedValues)
        {
            _PostLinearized = sPostLinearized;
            _Expected = expectedValues;
        }

        /// <summary>
        /// Retrieves the linearized JSON string used for the POST request in the GDFWebMethodTestPostAttribute.
        /// </summary>
        /// <returns>The linearized JSON string used for the POST request.</returns>
        public string PostLinearizedJson()
        {
            return _PostLinearized;
        }

        /// <summary>
        /// Retrieves the expected status code for a POST request specified by this attribute.
        /// </summary>
        /// <returns>The expected status code for the POST request.</returns>
        public int[] GetExpected()
        {
            return _Expected;
        }
    }
}


