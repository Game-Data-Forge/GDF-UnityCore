using System;

namespace GDFFoundation
{
    /// <summary>
    /// Attribute to declare a SQL index constraint.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbIndexAttribute : GDFDbConstraintAttribute { }
}