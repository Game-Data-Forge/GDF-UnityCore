#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFOrderAttribut.cs create at 2025/03/27 21:03:15
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a custom attribute that is used to specify the order of properties
    ///     in a class.
    /// </summary>
    /// <remarks>
    ///     This attribute can be applied to properties and allows you to set a specific
    ///     order for serialization, deserialization, or any operation that requires
    ///     organized processing of properties. The default order is 0.
    /// </remarks>
    /// <example>
    ///     This class should not provide example usage as per specific requirements.
    /// </example>
    /// <param name="order">
    ///     Defines the order in which the attributed property should appear or be processed.
    ///     The order must be provided as an integer value at initialization.
    /// </param>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class GDFOrderAttribut : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     Specifies the order value attributed to a property for determining its processing sequence.
        /// </summary>
        /// <remarks>
        ///     The <c>Order</c> variable is used to establish the order of properties in contexts like
        ///     serialization, deserialization, or other operations requiring a systematic arrangement.
        ///     It represents an integer value and defaults to 0 if not explicitly set.
        /// </remarks>
        public int Order = 0;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Represents a custom attribute designed to specify a custom order for property processing.
        /// </summary>
        /// <remarks>
        ///     This attribute is intended for use with properties and supports scenarios where
        ///     processing order for serialization, deserialization, or other organized property handling
        ///     is required. The default order value is 0.
        /// </remarks>
        public GDFOrderAttribut(int order)
        {
            Order = order;
        }

        #endregion
    }
}