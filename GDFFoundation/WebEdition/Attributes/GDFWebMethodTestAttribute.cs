#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFWebMethodTestAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents an attribute that is applied to a method to specify a test for a web method.
    /// </summary>
    /// <remarks>
    ///     This attribute can be applied to a method to indicate that it is a test for a web method.
    ///     It provides information about the expected HTTP status code and the page status tag.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class GDFWebMethodTestAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     Attribute class used to specify the expected HTTP status code for a web method test.
        /// </summary>
        /// <remarks>
        ///     This attribute is used to mark a method as a web method test. It can be applied to method definitions, and it specifies the expected HTTP status code that the test method should return.
        /// </remarks>
        private int[] _Expected;

        #endregion

        #region Instance constructors and destructors

        public GDFWebMethodTestAttribute(params int[] expectedValues)
        {
            _Expected = expectedValues;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Get the expected value from GDFWebMethodTestAttribute.
        /// </summary>
        /// <returns>The expected value.</returns>
        public int[] GetExpected()
        {
            return _Expected;
        }

        #endregion
    }
}