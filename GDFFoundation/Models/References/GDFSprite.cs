#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFSprite.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a sprite data type in the GDFFoundation.
    /// </summary>
    /// <remarks>
    ///     GDFSprite is a subclass of the GDFDataType class and represents a sprite asset in the GDFFoundation framework.
    ///     It stores information about the sprite asset that can be used in a game or application.
    /// </remarks>
    [Serializable]
    public class GDFSprite : GDFDataType
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents an asset in the GDFFoundation.
        /// </summary>
        public string Asset { set; get; } = string.Empty;

        #endregion
    }
}