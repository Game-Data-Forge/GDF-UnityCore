using System;

namespace GDFEditor
{
    /// <summary>
    /// Enumeration for the state of GDFSubMetaData.
    /// </summary>
    [Serializable]
    public enum GDFSubMetaDataState : int
    {
        /// <summary>
        /// Represents the value "None" in the GDFSubMetaDataState enumeration.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies if the GDFSubMetaData is visible in the build or not.
        /// </summary>
        VisibleInBuild = 1 << 0,

        /// <summary>
        /// The Overriden state of the GDFSubMetaData.
        /// </summary>
        Overriden = 1 << 1,

        /// <summary>
        /// The 'Outdated' member of the GDFSubMetaDataState enumeration.
        /// </summary>
        Outdated = 1 << 2,

        /// <summary>
        /// Represents a state of GDFSubMetaData indicating that propagation of changes should be denied.
        /// </summary>
        DenyPropagation = 1 << 3,

        /// <summary>
        /// Enumeration for the state of GDFSubMetaData.
        /// </summary>
        All = ~0
    }
}