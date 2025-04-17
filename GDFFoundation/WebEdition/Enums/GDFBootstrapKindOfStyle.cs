

using System;

namespace GDFFoundation
{
    public enum GDFBootstrapKindOfAlign : int
    {
        Start,
        Middle,
        End,
    }

    /// <summary>
    /// Represents the kind of bootstrap style for HTML elements.
    /// </summary>
    [Serializable]
    public enum GDFBootstrapKindOfStyle : int
    {
        /// <summary>
        /// Represents the primary style for the Bootstrap framework.
        /// </summary>
        /// <remarks>
        /// This member is used in the GDFBootstrapKindOfStyle enumeration in the GDFFoundation namespace.
        /// It represents the primary style for the Bootstrap framework.
        /// </remarks>
        Primary,

        /// <summary>
        /// Represents a secondary style for GDFBootstrapKindOfStyle enum.
        /// </summary>
        Secondary,
        
        /// <summary>
        /// Represents a Tertiary style for GDFBootstrapKindOfStyle enum.
        /// </summary>
        Tertiary,

        /// <summary>
        /// Represents the Success member of the GDFBootstrapKindOfStyle enum.
        /// </summary>
        Success,

        /// <summary>
        /// The Warning member of the GDFBootstrapKindOfStyle enumeration.
        /// </summary>
        Warning,

        /// <summary>
        /// Represents the danger style of a Bootstrap component.
        /// </summary>
        Danger,

        Info,
        
        Normal,
        
        Light,
        Dark,
    }
}


