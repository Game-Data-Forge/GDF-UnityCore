

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a sprite data type in the GDFFoundation.
    /// </summary>
    /// <remarks>
    /// GDFSprite is a subclass of the GDFDataType class and represents a sprite asset in the GDFFoundation framework.
    /// It stores information about the sprite asset that can be used in a game or application.
    /// </remarks>
    [Serializable]
    public class GDFSprite : GDFDataType
    {
        /// <summary>
        /// Represents an asset in the GDFFoundation.
        /// </summary>
        public string Asset { set; get; } = string.Empty;
    }
}



