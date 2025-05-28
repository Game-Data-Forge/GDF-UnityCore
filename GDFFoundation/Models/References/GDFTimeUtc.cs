#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFTimeUtc.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a class for storing UTC time values.
    /// </summary>
    [Serializable]
    public class GDFTimeUtc : GDFDataType
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a property for storing a value of type int.
        /// </summary>
        public int Value { set; get; } = 0;

        #endregion
    }
}