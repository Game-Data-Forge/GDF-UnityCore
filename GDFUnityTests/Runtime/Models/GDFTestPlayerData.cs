using GDFFoundation;

namespace GDFUnity.Tests
{
    /// <summary>
    /// The GDFTestPlayerData class represents player data for testing purposes.
    /// </summary>
    public class GDFTestPlayerData : GDFPlayerData
    {
        /// <summary>
        /// Gets or sets the TestString property of the GDFTestPlayerData class.
        /// </summary>
        /// <value>The value of the TestString property.</value>
        public string TestString { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the value indicating whether the TestBool property is true or false.
        /// </summary>
        public bool TestBool { set; get; }

        /// <summary>
        /// The TestInt property represents an integer value associated with the GDFTestPlayerData class.
        /// </summary>
        /// <remarks>
        /// This property is defined in the GDFTestPlayerData class which is a subclass of GDFPlayerData.
        /// It can be used to store an integer value for player data in a game.
        /// </remarks>
        /// <value>The integer value of the TestInt property.</value>
        public int TestInt { set; get; }
    }
}
