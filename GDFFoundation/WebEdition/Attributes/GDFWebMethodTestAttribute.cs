

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents an attribute that is applied to a method to specify a test for a web method.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied to a method to indicate that it is a test for a web method.
    /// It provides information about the expected HTTP status code and the page status tag.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class GDFWebMethodTestAttribute : Attribute
    {
        /// <summary>
        /// Attribute class used to specify the expected HTTP status code for a web method test.
        /// </summary>
        /// <remarks>
        /// This attribute is used to mark a method as a web method test. It can be applied to method definitions, and it specifies the expected HTTP status code that the test method should return.
        /// </remarks>
        private int[] _Expected;

        public GDFWebMethodTestAttribute(params int[] expectedValues)
        {
            _Expected = expectedValues;
        }

        /// <summary>
        /// Get the expected value from GDFWebMethodTestAttribute.
        /// </summary>
        /// <returns>The expected value.</returns>
        public int[] GetExpected()
        {
            return _Expected;
        }
    }
}

