using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute to override request column access by request type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbAccessAttribute : Attribute
    {
        /// <summary>
        /// Define how the column is used for select requests.
        /// </summary>
        public GDFDbColumnAccess selectAccess;
        /// <summary>
        /// Define how the column is used for update requests.
        /// </summary>
        public GDFDbColumnAccess updateAccess;
        /// <summary>
        /// Define how the column is used for insert requests.
        /// </summary>
        public GDFDbColumnAccess insertAccess;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="selectAccess">Define how the column is used for select requests.</param>
        /// <param name="updateAccess">Define how the column is used for update requests.</param>
        /// <param name="insertAccess">Define how the column is used for insert requests.</param>
        public GDFDbAccessAttribute(
            GDFDbColumnAccess selectAccess = GDFDbColumnAccess.Can,
            GDFDbColumnAccess updateAccess = GDFDbColumnAccess.Can,
            GDFDbColumnAccess insertAccess = GDFDbColumnAccess.Can)
        {
            this.selectAccess = selectAccess;
            this.updateAccess = updateAccess;
            this.insertAccess = insertAccess;
        }
    }
}