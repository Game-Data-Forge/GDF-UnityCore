#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFVersion.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a version number with major, minor, and build components.
    /// </summary>
    [Serializable]
    public class GDFVersion : IGDFSubModel, IComparable<GDFVersion>
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents the build number of a version of software.
        /// </summary>
        public int Build { set; get; }

        /// <summary>
        ///     Represents the major version of a software application.
        /// </summary>
        public int Major { set; get; }

        /// <summary>
        ///     Gets or sets the minor version number.
        /// </summary>
        public int Minor { set; get; }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Returns a string that represents the current GDFVersion object.
        /// </summary>
        /// <returns>A string representation of the current GDFVersion object. The string format is "Major.Minor.Build".</returns>
        public override string ToString()
        {
            return Major.ToString() + "." + Minor.ToString() + "." + Build.ToString();
        }

        #region From interface IComparable<GDFVersion>

        /// <summary>
        ///     Compares the current version object with another version object.
        /// </summary>
        /// <param name="other">The version object to compare with.</param>
        /// <returns>
        ///     A signed integer that indicates the relative values of the current instance and the <paramref name="other" />.
        /// </returns>
        public int CompareTo(GDFVersion other)
        {
            if (other != null)
            {
                int tComparison = Major.CompareTo(other.Major);
                if (tComparison != 0)
                {
                    return tComparison;
                }

                tComparison = Minor.CompareTo(other.Minor);
                if (tComparison != 0)
                {
                    return tComparison;
                }
            }

            return Build.CompareTo(other!.Build);
        }

        #endregion

        #endregion
    }
}