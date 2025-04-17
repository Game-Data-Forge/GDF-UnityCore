

using System;

namespace GDFFoundation
{
    /// <summary>
    /// The GDFToolboxEnum class provides utility methods for converting between enum types and their corresponding values.
    /// </summary>
    public partial class GDFToolboxEnum
    {
        /// <summary>
        /// Converts a string representation of an enum value to the corresponding enum value.
        /// </summary>
        /// <typeparam name="T">The enum type to convert to.</typeparam>
        /// <param name="sValue">The string representation of the enum value.</param>
        /// <returns>The enum value if the string representation is valid; otherwise, null.</returns>
        public static T StringConvertToEnum<T>(string sValue) where T : Enum
        {
            if (string.IsNullOrEmpty(sValue) == false)
            {
                return (T)Enum.Parse(typeof(T), sValue);
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        /// <summary>
        /// Converts an enumeration value to its string representation.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="sValue">The enumeration value to convert.</param>
        /// <returns>The string representation of the enumeration value.</returns>
        public static string EnumConvertToString<T>(T sValue) where T : Enum
        {
            return sValue.ToString();
        }

        /// <summary>
        /// Converts an Int32 value to the corresponding enum value of type T.
        /// </summary>
        /// <typeparam name="T">The enum type to convert to.</typeparam>
        /// <param name="sValue">The Int32 value to convert.</param>
        /// <returns>The enum value of type T corresponding to the Int32 value.</returns>
        /// <remarks>
        /// If the Int32 value is not defined in the enum, a default value of type T will be returned.
        /// </remarks>
        public static T Int32ConvertToEnum<T>(Int32 sValue) where T : Enum
        {
            if (Enum.IsDefined(typeof(T), sValue))
            {
                return (T)Enum.ToObject(typeof(T), sValue);
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        /// <summary>
        /// Converts an enum value to its equivalent 32-bit signed integer representation.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="sValue">The enum value.</param>
        /// <returns>The equivalent 32-bit signed integer representation of the enum value.</returns>
        public static Int32 EnumConvertToInt32<T>(T sValue) where T : Enum
        {
            return Convert.ToInt32(sValue);
        }

        /// <summary>
        /// Converts an Int64 value to the specified Enum type.
        /// </summary>
        /// <typeparam name="T">The type of the Enum.</typeparam>
        /// <param name="sValue">The Int64 value to convert.</param>
        /// <returns>The Enum value converted from the Int64 value.</returns>
        public static T Int64ConvertToEnum<T>(Int64 sValue) where T : Enum
        {
            if (Enum.IsDefined(typeof(T), sValue))
            {
                return (T)Enum.ToObject(typeof(T), sValue);
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        /// <summary>
        /// Converts an enum value to a 64-bit signed integer representation.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="sValue">The enum value to be converted.</param>
        /// <returns>The 64-bit signed integer representation of the enum value.</returns>
        public static Int64 EnumConvertToInt64<T>(T sValue) where T : Enum
        {
            return Convert.ToInt64(sValue);
        }

        /// <summary>
        /// Converts a string representation of an enum value to the corresponding enum value.
        /// </summary>
        /// <param name="sType">The enum type to convert to.</param>
        /// <param name="sValue">The string representation of the enum value.</param>
        /// <returns>The enum value if the string representation is valid; otherwise, null.</returns>
        public static Enum StringConvertToEnum(Type sType, string sValue)
        {
            if (!sType.IsEnum)
            {
                throw new ArgumentException("Type expected.");
            }

            if (string.IsNullOrEmpty(sValue) == false)
            {
                return (Enum)Enum.Parse(sType, sValue);
            }
            else
            {
                return (Enum)Activator.CreateInstance(sType);
            }
        }

        /// <summary>
        /// Converts an enum value to its string representation.
        /// </summary>
        /// <param name="sValue">The enum value to convert to string.</param>
        /// <returns>The string representation of the enum value.</returns>
        public static string EnumConvertToString(Enum sValue)
        {
            return sValue.ToString();
        }

        /// <summary>
        /// Converts an integer value to the specified enumeration type.
        /// </summary>
        /// <param name="sType">The enum type to convert to.</param>
        /// <param name="sValue">The integer value to convert.</param>
        /// <returns>The converted enumeration value of type T.</returns>
        public static Enum Int32ConvertToEnum(Type sType, Int32 sValue)
        {
            if (!sType.IsEnum)
            {
                throw new ArgumentException("Type expected.");
            }
            if (Enum.IsDefined(sType, sValue))
            {
                return (Enum)Enum.ToObject(sType, sValue);
            }
            else
            {
                return (Enum)Activator.CreateInstance(sType);
            }
        }

        /// <summary>
        /// Converts an enumeration value to an Int32.
        /// </summary>
        /// <param name="sValue">The enumeration value to convert.</param>
        /// <returns>The Int32 representation of the enumeration value.</returns>
        public static Int32 EnumConvertToInt32(Enum sValue)
        {
            return Convert.ToInt32(sValue);
        }

        /// <summary>
        /// Converts an Int64 value to an Enum of type T.
        /// </summary>
        /// <param name="sType">The enum type to convert to.</param>
        /// <param name="sValue">The Int64 value to convert.</param>
        /// <returns>An Enum value of type T if the conversion is successful; otherwise, null.</returns>
        /// <exception cref="ArgumentException">Thrown if the type parameter T is not an Enum.</exception>
        public static Enum Int64ConvertToEnum(Type sType, Int64 sValue)
        {
            if (!sType.IsEnum)
            {
                throw new ArgumentException("Type expected.");
            }
            if (Enum.IsDefined(sType, sValue))
            {
                return (Enum)Enum.ToObject(sType, sValue);
            }
            else
            {
                return (Enum)Activator.CreateInstance(sType);
            }
        }

        /// <summary>
        /// Converts an enumeration value to a 64-bit integer.
        /// </summary>
        /// <param name="sValue">The enumeration value to convert.</param>
        /// <returns>The 64-bit integer representation of the enumeration value.</returns>
        public static Int64 EnumConvertToInt64(Enum sValue)
        {
            return Convert.ToInt64(sValue);
        }
    }
}

