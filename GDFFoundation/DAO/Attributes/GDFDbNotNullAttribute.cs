using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute to set a SQL column as not null.
    /// Use it only for reference types.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbNotNullAttribute : Attribute { }
}