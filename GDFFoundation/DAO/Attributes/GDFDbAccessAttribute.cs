#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDbAccessAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Attribute to override request column access by request type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbAccessAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     Define how the column is used for insert requests.
        /// </summary>
        public GDFDbColumnAccess insertAccess;

        /// <summary>
        ///     Define how the column is used for select requests.
        /// </summary>
        public GDFDbColumnAccess selectAccess;

        /// <summary>
        ///     Define how the column is used for update requests.
        /// </summary>
        public GDFDbColumnAccess updateAccess;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="selectAccess">Define how the column is used for select requests.</param>
        /// <param name="updateAccess">Define how the column is used for update requests.</param>
        /// <param name="insertAccess">Define how the column is used for insert requests.</param>
        public GDFDbAccessAttribute(
            GDFDbColumnAccess selectAccess = GDFDbColumnAccess.Can,
            GDFDbColumnAccess updateAccess = GDFDbColumnAccess.Can,
            GDFDbColumnAccess insertAccess = GDFDbColumnAccess.Can
        )
        {
            this.selectAccess = selectAccess;
            this.updateAccess = updateAccess;
            this.insertAccess = insertAccess;
        }

        #endregion
    }
}