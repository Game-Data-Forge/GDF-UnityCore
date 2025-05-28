#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFAvailableForTarget.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     The IGDFAvailableForTarget interface defines properties to define the availability of an object for different targets.
    /// </summary>
    public interface IGDFAvailableForTarget
    {
        #region Instance fields and properties

        /// <summary>
        ///     Interface for objects that can be available for an app.
        /// </summary>
        public bool AvailableForApp { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether the property is available for the game.
        /// </summary>
        /// <remarks>
        ///     This property is used to determine if the data is available for the game.
        /// </remarks>
        public bool AvailableForGame { set; get; }

        /// <summary>
        ///     Gets or sets a value indicating whether this property is available for web.
        /// </summary>
        public bool AvailableForWeb { set; get; }

        #endregion
    }
}