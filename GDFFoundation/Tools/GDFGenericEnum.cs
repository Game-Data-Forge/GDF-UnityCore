#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFGenericEnum.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Can create generic class working like dynamical enum
    /// </summary>
    [Serializable]
    public abstract class GDFGenericEnum : IComparable
    {
        #region Static methods

        /// <summary>
        ///     Overloads the equality operator for GDFGenericEnum class.
        /// </summary>
        /// <param name="sA">The first GDFGenericEnum to compare.</param>
        /// <param name="sB">The second GDFGenericEnum to compare.</param>
        /// <returns>True if the two GDFGenericEnum instances are equal, otherwise false.</returns>
        public static bool operator ==(GDFGenericEnum sA, GDFGenericEnum sB) //TODO fix infinite loop
        {
            if (sA == null && sB == null)
            {
                return true;
            }
            else if (sA == null)
            {
                return false;
            }
            else if (sB == null)
            {
                return false;
            }
            else
            {
                var tTypeMatches = sA.GetType().Equals(sB.GetType());
                if (tTypeMatches)
                {
                    return sA.Value.Equals(sB.Value);
                }
            }

            return false;
        }

        /// <summary>
        ///     Determines if two GDFGenericEnum objects are not equal.
        /// </summary>
        /// <param name="sA">The first GDFGenericEnum object.</param>
        /// <param name="sB">The second GDFGenericEnum object.</param>
        /// <returns>True if the two GDFGenericEnum objects are not equal, otherwise False.</returns>
        public static bool operator !=(GDFGenericEnum sA, GDFGenericEnum sB)
        {
            if (sA == null && sB == null)
            {
                return false;
            }
            else if (sA == null)
            {
                return true;
            }
            else if (sB == null)
            {
                return true;
            }
            else
            {
                var tTypeMatches = sA.GetType().Equals(sB.GetType());
                if (tTypeMatches)
                {
                    return !sA.Value.Equals(sB.Value);
                }
            }

            return false;
        }

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     The name of the GDFGenericEnum instance.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        ///     The value of the static enum instance
        /// </summary>
        public long Value { set; get; }

        #endregion

        #region Instance constructors and destructors

        /// <summary>
        ///     GDFGenericEnum class represents a base class for generic enumerations.
        /// </summary>
        public GDFGenericEnum()
        {
            Value = 0;
            Name = null;
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Determines whether the current instance of GDFGenericEnum is equal to the specified object.
        /// </summary>
        /// <param name="sObject">The object to compare with the current instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified object is equal to the current instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object sObject)
        {
            var tOtherValue = sObject as GDFGenericEnum;
            if (tOtherValue == null)
            {
                return false;
            }

            if (sObject != null)
            {
                var tTypeMatches = GetType().Equals(sObject.GetType());
                var tValueMatches = Value.Equals(tOtherValue.Value);
                return tTypeMatches && tValueMatches;
            }

            return false;
        }

        /// <summary>
        ///     Gets the hash code value for this object.
        /// </summary>
        /// <returns>
        ///     The hash code value for this object.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        ///     Convert value of enum instance to long
        /// </summary>
        /// <returns>The long representation of the enum value</returns>
        public long GetLong()
        {
            return Value;
        }

        /// <summary>
        ///     Convert value of enum instance to long.
        /// </summary>
        /// <returns>The long value of the enum instance.</returns>
        public long ToLong()
        {
            return Value;
        }

        /// <summary>
        ///     Convert enum to string with value as string
        /// </summary>
        /// <returns>The string representation of the enum.</returns>
        public override string ToString()
        {
            return Name?.ToString(CultureInfo.InvariantCulture);
        }

        #region From interface IComparable

        /// <summary>
        ///     Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="sOther">The object to compare with this instance.</param>
        /// <returns>
        ///     A value indicating the relative order of the objects being compared.
        ///     This method returns:
        ///     - a negative integer if this instance is less than <paramref name="sOther" />,
        ///     - zero if this instance is equal to <paramref name="sOther" />, or
        ///     - a positive integer if this instance is greater than <paramref name="sOther" />.
        /// </returns>
        public int CompareTo(object sOther)
        {
            if (sOther != null)
            {
                return Value.CompareTo(((GDFGenericEnum)sOther).Value);
            }

            return 0;
        }

        #endregion

        #endregion
    }

    /// <summary>
    ///     Can create generic class working like dynamical enum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class GDFGenericEnumGeneric<T> : GDFGenericEnum where T : GDFGenericEnumGeneric<T>, new()
    {
        #region Static fields and properties

        /// <summary>
        ///     Dictionary that stores values of type <typeparamref name="T" /> indexed by a key of type <see cref="long" />.
        /// </summary>
        /// <typeparam name="T">The type of values stored in the dictionary</typeparam>
        private static readonly Dictionary<long, T> KList = new Dictionary<long, T>();

        /// <summary>
        ///     A dictionary that contains string keys and values of type T.
        /// </summary>
        /// <typeparam name="T">The type of values stored in the dictionary.</typeparam>
        /// <remarks>
        ///     This dictionary is static and readonly, meaning it cannot be modified once initialized.
        /// </remarks>
        private static readonly Dictionary<string, T> KStringList = new Dictionary<string, T>();

        #endregion

        #region Static methods

        /// <summary>
        ///     Adds a new item to the collection with the specified identifier and name.
        /// </summary>
        /// <typeparam name="T">The type of the item to be added.</typeparam>
        /// <param name="sId">The identifier of the item.</param>
        /// <param name="sName">The name of the item.</param>
        /// <returns>Returns the added item if successful, otherwise null.</returns>
        protected static T Add(int sId, string sName)
        {
            string tCleanedName = GDFStringCleaner.UnixCleaner(sName);
            T rReturn = null;
            if (KList.ContainsKey(sId) == false && KStringList.ContainsKey(tCleanedName) == false)
            {
                rReturn = Activator.CreateInstance(typeof(T)) as T;
                if (rReturn != null)
                {
                    rReturn.Value = sId;
                    rReturn.Name = tCleanedName;
                    KList.Add(sId, rReturn);
                    KStringList.Add(tCleanedName, rReturn);
                }
            }
            else
            {
                if (KList.ContainsKey(sId))
                {
                    rReturn = KList[sId];
                }
                else if (KStringList.ContainsKey(tCleanedName))
                {
                    rReturn = KStringList[tCleanedName];
                }
            }

            return rReturn;
        }

        /// <summary>
        ///     Creates an instance of type T if the given sId and sName are not already present in the KList or KStringList dictionaries.
        ///     If either the sId or the sName is already present in the dictionaries, it generates a new sId and sName by incrementing the sId by 10 and appending the sId to the sName respectively.
        ///     Recursively calls itself with the new sId and sName until it finds a unique sId and sName.
        /// </summary>
        /// <typeparam name="T">The type of object to be created.</typeparam>
        /// <param name="sId">The unique identifier for the object.</param>
        /// <param name="sName">The name of the object.</param>
        /// <returns>
        ///     Returns a nullable instance of type T if it is successfully created, otherwise null.
        /// </returns>
        public static T Create(int sId, string sName)
        {
            string tCleanedName = GDFStringCleaner.UnixCleaner(sName);
            T rReturn = null;
            if (KList.ContainsKey(sId) == false && KStringList.ContainsKey(tCleanedName) == false)
            {
                rReturn = Add(sId, tCleanedName);
            }
            else
            {
                int tId = sId;
                string tName = tCleanedName;
                if (KList.ContainsKey(tId) == true)
                {
                    tId = 10 + tId;
                }

                if (KStringList.ContainsKey(tName) == true)
                {
                    tName = tName + "_" + tId;
                }

                rReturn = Create(tId, tName);
            }

            return rReturn;
        }

        /// <summary>
        ///     Retrieves all keys in the string dictionary.
        /// </summary>
        /// <typeparam name="T">The type of keys stored in the dictionary.</typeparam>
        /// <returns>An array containing all the keys stored in the dictionary.</returns>
        public static T[] GetAll()
        {
            return KStringList.Values.ToArray();
        }

        /// <summary>
        ///     Returns all keys of type string.
        /// </summary>
        /// <returns>An array of strings representing all the keys.</returns>
        public static string[] GetAllValues()
        {
            return KStringList.Keys.ToArray();
        }

        /// <summary>
        ///     Return static instance for the given long value.
        /// </summary>
        /// <param name="sId">The long value used to get the instance.</param>
        /// <returns>The instance of type T, or null if not found.</returns>
        /// /
        public static T GetForValue(long sId)
        {
            T rReturn = null;
            if (KList.ContainsKey(sId))
            {
                rReturn = KList[sId];
            }

            return rReturn;
        }

        /// <summary>
        ///     Return static instance for the specified string value.
        /// </summary>
        /// <param name="sName">The string value to get the instance for.</param>
        /// <returns>The instance of type T associated with the specified string value, or null if the value doesn't exist.</returns>
        public static T GetForValue(string sName)
        {
            string tCleanedName = GDFStringCleaner.UnixCleaner(sName);
            T rReturn = null;
            if (KStringList.ContainsKey(tCleanedName))
            {
                rReturn = KStringList[tCleanedName];
            }

            return rReturn;
        }

        #endregion

        #region Instance constructors and destructors

        //public static K None = Add(0, "None", "None", false);

        /// <summary>
        ///     Default constructor for the GDFGenericEnumGeneric class.
        /// </summary>
        public GDFGenericEnumGeneric()
        {
        }

        #endregion
    }
}