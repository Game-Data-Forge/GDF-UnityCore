using System;

namespace GDFEditor
{
    /// <summary>
    /// Enumeration for GDFCheck flags.
    /// </summary>
    /// <remarks>
    /// The GDFCheck enum is used to represent different flags for checking certain numbers or actions.
    /// </remarks>
    [Serializable]
    [Flags]
    public enum GDFCheck : int
    {
        /// <summary>
        /// Represents the None member of the GDFCheck enum.
        /// </summary>
        None = 0,

        /// <summary>
        /// Represents the Test member of the GDFCheck enum.
        /// </summary>
        Test = 1 << 0,

        /// <summary>
        /// Represents the CheckTwo member of the GDFCheck enum.
        /// </summary>
        CheckTwo = 1 << 1,

        /// <summary>
        /// Represents the CheckThree member of the GDFCheck enum.
        /// </summary>
        CheckThree = 1 << 2,

        /// <summary>
        /// Represents the CheckFour member of the GDFCheck enum.
        /// </summary>
        CheckFour = 1 << 3,

        /// <summary>
        /// Represents the CheckFive member of the GDFCheck enum.
        /// </summary>
        CheckFive = 1 << 4,

        /// <summary>
        /// Represents the CheckSix member of the GDFCheck enum.
        /// </summary>
        CheckSix = 1 << 5,

        /// <summary>
        /// Represents the CheckSeven member of the GDFCheck enum.
        /// </summary>
        CheckSeven = 1 << 6,

        /// <summary>
        /// Represents the CheckHeight member of the GDFCheck enum.
        /// </summary>
        CheckHeight = 1 << 7,

        /// <summary>
        /// Represents the CheckNine member of the GDFCheck enum.
        /// </summary>
        CheckNine = 1 << 8,

        /// <summary>
        /// Represents the CheckTen member of the GDFCheck enum.
        /// </summary>
        CheckTen = 1 << 9,

        /// <summary>
        /// Represents the ToTranslate member of the GDFCheck enum.
        /// </summary>
        ToTranslate = 1 << 10,

        /// <summary>
        /// Represents the ToPublish member of the GDFCheck enum.
        /// </summary>
        ToPublish = 1 << 11,
    }
}