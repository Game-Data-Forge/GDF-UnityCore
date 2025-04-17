

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute used to specify a test for a GET request to a web method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class GDFWebMethodTestGetAttribute : Attribute
    {
        /// _GetLinearizedParams is a private variable of type string in the GDFWebMethodTestGetAttribute class.
        /// The GDFWebMethodTestGetAttribute class is a custom attribute that can be applied to methods in the GDFFoundation namespace.
        /// This attribute is used to specify test parameters for web methods and expected response statuses.
        /// Constructors:
        /// - GDFWebMethodTestGetAttribute(string sGetLinearizedParams, int sExpected = 200, GDFPageStandardStatusTag sTag = GDFPageStandardStatusTag.None):
        /// - Constructs a new instance of GDFWebMethodTestGetAttribute with the specified linearized parameters, expected response status, and status tag.
        /// - sGetLinearizedParams (string): The linearized parameters for the web method.
        /// - sExpected (int, optional): The expected response status. Default is 200.
        /// - sTag (GDFPageStandardStatusTag, optional): The status tag for the web method. Default is GDFPageStandardStatusTag.None.
        /// Methods:
        /// - string GetLinearizedParams():
        /// - Returns the linearized parameters for the web method.
        /// - int GetExpected():
        /// - Returns the expected response status for the web method.
        /// - GDFPageStandardStatusTag GetTag():
        /// - Returns the status tag for the web method.
        /// Example usage:
        /// [GDFWebMethodTestGet("_userId=12345", 200, GDFPageStandardStatusTag.None)]
        /// public void TestWebMethod()
        /// {
        /// // Test code here
        /// }
        /// /
        private string _GetLinearizedParams;

        /// <summary>
        /// _Expected is a private variable of type int in the GDFWebMethodTestGetAttribute class.
        /// The GDFWebMethodTestGetAttribute class is a custom attribute that can be applied to methods in the GDFFoundation namespace.
        /// This attribute is used to specify test parameters for web methods and expected response statuses.
        /// Constructors:
        /// - GDFWebMethodTestGetAttribute(string sGetLinearizedParams, int sExpected = 200, GDFPageStandardStatusTag sTag = GDFPageStandardStatusTag.None):
        /// - Constructs a new instance of GDFWebMethodTestGetAttribute with the specified linearized parameters, expected response status, and status tag.
        /// - sGetLinearizedParams (string): The linearized parameters for the web method.
        /// - sExpected (int, optional): The expected response status. Default is 200.
        /// - sTag (GDFPageStandardStatusTag, optional): The status tag for the web method. Default is GDFPageStandardStatusTag.None.
        /// Methods:
        /// /- string GetLinearizedParams():
        /// - Returns the linearized parameters for the web method.
        /// - int GetExpected():
        /// - Returns the expected response status for the web method.
        /// - GDFPageStandardStatusTag GetTag():
        /// - Returns the status tag for the web method.
        /// Example usage:
        /// [GDFWebMethodTestGet("_userId=12345", 200, GDFPageStandardStatusTag.None)]
        /// public void TestWebMethod()
        /// {
        /// // Test code here
        /// }
        /// </summary>
        private int[] _Expected;

        public GDFWebMethodTestGetAttribute(string sGetLinearizedParams, params int[] expectedValues)
        {
            _GetLinearizedParams = sGetLinearizedParams;
            _Expected = expectedValues;
        }

        /// <summary>
        /// Retrieves the linearized parameters for a web method test.
        /// </summary>
        /// <returns>The linearized parameters as a string.</returns>
        public string GetLinearizedParams()
        {
            return _GetLinearizedParams;
        }

        /// <summary>
        /// Get the expected status code for a web method test.
        /// </summary>
        /// <returns>The expected status code.</returns>
        public int[] GetExpected()
        {
            return _Expected;
        }
    }
}


