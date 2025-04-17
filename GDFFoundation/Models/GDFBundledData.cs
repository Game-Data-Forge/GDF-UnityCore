

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a bundled data model for the GDF database.
    /// </summary>
    [Serializable]
    public abstract class GDFBundledData : GDFBasicData
    {
        /// <summary>
        /// Represents the BundleId property of an GDFBundledData object.
        /// </summary>
        public int BundleId { set; get; }

        /// <summary>
        /// Represents a bundled data class in the GDFFoundation namespace.
        /// </summary>
        public string ClassName { set; get; }

        /// <summary>
        /// Represents the value of IndexOne property in the GDFBundledData class.
        /// </summary>
        /// <remarks>
        /// IndexOne is a string property used for indexing purposes in the GDFBundledData class.
        /// </remarks>
        public string IndexOne { set; get; }

        /// <summary>
        /// Gets or sets the IndexTwo property of the GDFBundledData class.
        /// </summary>
        /// <value>The IndexTwo property.</value>
        public string IndexTwo { set; get; }

        /// <summary>
        /// Represents a property for the GDFBundledData class that stores the value of IndexThree.
        /// </summary>
        /// <value>
        /// The value of IndexThree.
        /// </value>
        public string IndexThree { set; get; }

        /// <summary>
        /// Represents a property for the IndexFour value of an GDFBundledData object.
        /// </summary>
        /// <remarks>
        /// The IndexFour property is used to store a string value that represents the fourth index of an GDFBundledData object.
        /// This value can be used for indexing or searching purposes.
        /// </remarks>
        public string IndexFour { set; get; }
    }
}

