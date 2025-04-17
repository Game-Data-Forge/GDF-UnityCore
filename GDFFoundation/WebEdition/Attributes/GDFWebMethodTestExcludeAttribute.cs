

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute used to exclude a web method from testing.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class GDFWebMethodTestExcludeAttribute : Attribute
    {
        /// <summary>
        /// Attribute used to exclude a web method from testing.
        /// </summary>
        public GDFWebMethodTestExcludeAttribute()
        {
        }
    }
}

