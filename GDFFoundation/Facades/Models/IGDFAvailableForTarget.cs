
namespace GDFFoundation
{
    /// <summary>
    /// The IGDFAvailableForTarget interface defines properties to define the availability of an object for different targets.
    /// </summary>
    public interface IGDFAvailableForTarget
    {
        /// <summary>
        /// Gets or sets a value indicating whether this property is available for web.
        /// </summary>
        public bool AvailableForWeb { set; get; }

        /// <summary>
        /// Gets or sets a value indicating whether the property is available for the game.
        /// </summary>
        /// <remarks>
        /// This property is used to determine if the data is available for the game.
        /// </remarks>
        public bool AvailableForGame { set; get; }

        /// <summary>
        /// Interface for objects that can be available for an app.
        /// </summary>
        public bool AvailableForApp { set; get; }

    }
}


