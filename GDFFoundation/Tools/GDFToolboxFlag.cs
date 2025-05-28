#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFToolboxFlag.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Provides a toolbox of static methods for working with enums.
    /// </summary>
    public partial class GDFToolboxEnum
    {
        #region Static methods

        /// <summary>
        ///     Converts the specified flag enum value to an Int32 value.
        /// </summary>
        /// <typeparam name="TK">The type of the flag enum.</typeparam>
        /// <param name="sValue">The flag enum value to convert.</param>
        /// <returns>The Int32 value representing the flag enum value.</returns>
        public static Int32 FlagConvertToInt32<TK>(TK sValue) where TK : Enum
        {
            return (Int32)Convert.ToInt32(sValue);
        }

        /// <summary>
        ///     Converts the specified enum value to an integer.
        /// </summary>
        /// <param name="sValue">The enum value to convert.</param>
        /// <returns>
        ///     The integer representation of the enum value.
        /// </returns>
        public static Int32 FlagConvertToInt32(Enum sValue)
        {
            return (Int32)Convert.ToInt32(sValue);
        }

        /// <summary>
        ///     Converts an enum value to a 64-bit integer representation.
        /// </summary>
        /// <typeparam name="TK">The type of the enum.</typeparam>
        /// <param name="sValue">The enum value to convert.</param>
        /// <returns>The 64-bit integer representation of the enum value.</returns>
        public static Int64 FlagConvertToInt64<TK>(TK sValue) where TK : Enum
        {
            return (Int64)Convert.ToInt64(sValue);
        }

        /// <summary>
        ///     Converts the given enum value to a 64-bit signed integer.
        /// </summary>
        /// <param name="sValue">The enum value to convert.</param>
        /// <returns>The converted 64-bit signed integer.</returns>
        public static Int64 FlagConvertToInt64(Enum sValue)
        {
            return (Int64)Convert.ToInt64(sValue);
        }

        /// <summary>
        ///     Converts an enum flag value to its string representation.
        /// </summary>
        /// <typeparam name="TK">The type of the enum flag.</typeparam>
        /// <param name="sValue">The enum flag value to convert.</param>
        /// <returns>The string representation of the enum flag.</returns>
        public static string FlagConvertToString<TK>(TK sValue) where TK : Enum
        {
            return sValue.ToString();
        }

        /// <summary>
        ///     Converts an enum value to its string representation.
        /// </summary>
        /// <param name="sValue">The enum value to convert to string.</param>
        /// <returns>The string representation of the enum value.</returns>
        public static string FlagConvertToString(Enum sValue)
        {
            return sValue.ToString();
        }

        /// <summary>
        ///     Converts an Int32 value to a flag of the specified enum type.
        /// </summary>
        /// <typeparam name="TK">The enum type.</typeparam>
        /// <param name="sValue">The Int32 value to convert.</param>
        /// <returns>The flag of the specified enum type.</returns>
        public static TK Int32ConvertToFlag<TK>(Int32 sValue) where TK : Enum
        {
            return (TK)Enum.ToObject(typeof(TK), sValue);
        }

        /// <summary>
        ///     Converts an Int32 value to an enum flag of type TK.
        /// </summary>
        /// <param name="sType">The enum type to convert to.</param>
        /// <param name="sValue">The Int32 value to convert.</param>
        /// <returns>The enum flag value of type TK.</returns>
        public static Enum Int32ConvertToFlag(Type sType, Int32 sValue)
        {
            if (!sType.IsEnum)
            {
                throw new ArgumentException("Enum expected.", sType.Name);
            }

            if (sType.GetCustomAttributes(typeof(FlagsAttribute), false).Length == 0)
            {
                throw new ArgumentException("Enum expected. Must have FlagsAttribute", sType.Name);
            }

            return (Enum)Enum.ToObject(sType, sValue);
        }

        /// <summary>
        ///     Converts a Int64 value to an Enum flag of type TK.
        /// </summary>
        /// <typeparam name="TK">The type of the Enum flag.</typeparam>
        /// <param name="sValue">The Int64 value to convert.</param>
        /// <returns>The Enum flag of type TK representing the Int64 value.</returns>
        public static TK Int64ConvertToFlag<TK>(Int64 sValue) where TK : Enum
        {
            return (TK)Enum.ToObject(typeof(TK), sValue);
        }

        /// <summary>
        ///     Converts a value of type <see cref="Int64" /> to an enum flag of type.
        /// </summary>
        /// <param name="sType">The enum type to convert to.</param>
        /// <param name="sValue">The value to be converted.</param>
        /// <returns>The converted enum flag of type.</returns>
        public static Enum Int64ConvertToFlag(Type sType, Int64 sValue)
        {
            if (!sType.IsEnum)
            {
                throw new ArgumentException("Enum expected.", sType.Name);
            }

            if (sType.GetCustomAttributes(typeof(FlagsAttribute), false).Length == 0)
            {
                throw new ArgumentException("Enum expected. Must have FlagsAttribute", sType.Name);
            }

            return (Enum)Enum.ToObject(sType, sValue);
        }

        /// <summary>
        ///     Converts a string representation of an enum value to its corresponding enum flag.
        /// </summary>
        /// <typeparam name="TK">The enum type.</typeparam>
        /// <param name="sValue">The string representation of the enum value.</param>
        /// <returns>The enum flag.</returns>
        public static TK StringConvertToFlag<TK>(string sValue) where TK : Enum
        {
            if (string.IsNullOrEmpty(sValue) == false)
            {
                return (TK)Enum.Parse(typeof(TK), sValue);
            }
            else
            {
                return (TK)Activator.CreateInstance(typeof(TK))!;
            }
        }

        /// <summary>
        ///     Converts a string value to a flag enumeration.
        /// </summary>
        /// <param name="sType">The enum type to convert to.</param>
        /// <param name="sValue">The string value to convert.</param>
        /// <returns>The flag enumeration value.</returns>
        /// <exception cref="ArgumentException">Thrown if the input type is not an enum or does not have the FlagsAttribute.</exception>
        public static Enum StringConvertToFlag(Type sType, string sValue)
        {
            if (!sType.IsEnum)
            {
                throw new ArgumentException("Enum expected.", sType.Name);
            }

            if (sType.GetCustomAttributes(typeof(FlagsAttribute), false).Length == 0)
            {
                throw new ArgumentException("Enum expected. Must have FlagsAttribute", sType.Name);
            }

            if (string.IsNullOrEmpty(sValue) == false)
            {
                return (Enum)Enum.Parse(sType, sValue);
            }
            else
            {
                return (Enum)Activator.CreateInstance(sType)!;
            }
        }

        #endregion
    }
}