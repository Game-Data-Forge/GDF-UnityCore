#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFWebMethodTestExcludeAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Attribute used to exclude a web method from testing.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class GDFWebMethodTestExcludeAttribute : Attribute
    {
        #region Instance constructors and destructors

        /// <summary>
        ///     Attribute used to exclude a web method from testing.
        /// </summary>
        public GDFWebMethodTestExcludeAttribute()
        {
        }

        #endregion
    }
}