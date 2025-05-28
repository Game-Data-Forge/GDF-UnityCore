#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDbLengthAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Attribute to define the maximum leght of a string when storing in a SQl table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GDFDbLengthAttribute : Attribute
    {
        #region Instance fields and properties

        /// <summary>
        ///     The maximum length of the string.
        /// </summary>
        public int length;

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="length">The maximum length of the string.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if length is inferior or equal to 0.</exception>
        public GDFDbLengthAttribute(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException("length");

            this.length = length;
        }

        #endregion
    }
}