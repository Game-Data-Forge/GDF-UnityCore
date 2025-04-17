using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute to declare a SQL unique constraint.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbUniqueAttribute : GDFDbConstraintAttribute { }
}