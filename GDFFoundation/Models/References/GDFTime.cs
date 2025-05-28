#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFTime.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a time data type in GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFTime : GDFDataType
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a data type for storing a value.
        /// </summary>
        public int Value { set; get; } = 0;

        #endregion
    }
}