#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFReferencesArray.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     A generic class that represents an array of GDFReferences.
    /// </summary>
    /// <typeparam name="T">The type of GDFReferences in the array.</typeparam>
    [Serializable]
    // TODO change for structure
    public class GDFReferencesArray<T> : IGDFReferenceArray where T : GDFDatabaseObject, IGDFLongReference
    {
        #region Constants

        public const char K_SEPARATOR = ',';

        #endregion

        #region Instance fields and properties

        /// <summary>
        ///     Represents a collection of references.
        /// </summary>
        /// <typeparam name="T">The type of the references.</typeparam>
        private string _References = string.Empty;

        /// <summary>
        ///     Represents a reference array of type T.
        /// </summary>
        /// <typeparam name="T">The type of objects stored in the reference array.</typeparam>
        private ulong[] ReferenceArray { set; get; } = new ulong[] { };

        /// The GDFReferencesArray class represents an array of references.
        /// References are stored as a comma-separated string.
        /// @tparam T The type of object referenced.
        /// /
        public string References
        {
            get
            {
                _References = string.Join(K_SEPARATOR, ReferencesList);
                return _References;
            }
            set
            {
                _References = value;
                ReferencesList = _References.Split(K_SEPARATOR, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        #region From interface IGDFReferenceArray

        /// <summary>
        ///     Represents a list of references to GDFDatabaseObject objects.
        /// </summary>
        /// <typeparam name="T">The type of GDFDatabaseObject.</typeparam>
        public List<string> ReferencesList { set; get; } = new List<string>();

        #endregion

        #endregion

        #region Instance constructors and destructors

        /// Represents a generic array of references.
        /// @typeparam T The type of the referenced object.
        /// /
        public GDFReferencesArray(T sObject)
        {
            if (sObject != null)
            {
                ReferencesList.Add(sObject.Reference.ToString());
            }
        }

        /// The GDFReferencesArray class represents an array of references.
        /// It is used to store and manipulate a list of references to objects that inherit from GDFDatabaseObject.
        /// @typeparam T The type of objects that the references array is storing
        /// /
        public GDFReferencesArray(ulong[] sReferencesArray)
        {
            if (sReferencesArray != null)
            {
                foreach (ulong tRef in sReferencesArray)
                {
                    ReferencesList.Add(tRef.ToString());
                }
            }
        }

        /// Represents a generic array of GDFReferences.
        /// @typeparam T The type of the objects in the array.
        /// /
        public GDFReferencesArray(T[] sObjectsArray)
        {
            if (sObjectsArray != null)
            {
                foreach (T tObject in sObjectsArray)
                {
                    ReferencesList.Add(tObject.RowId.ToString());
                }
            }
        }

        /// /
        public GDFReferencesArray(List<string> sReferencesList)
        {
            ReferencesList = sReferencesList;
        }

        /// <summary>
        ///     Represents an array of references to objects of type T.
        /// </summary>
        /// <typeparam name="T">The type of object being referenced.</typeparam>
        public GDFReferencesArray()
        {
        }

        #endregion

        #region Instance methods

        /// <summary>
        ///     Adds a value to the GDFReferencesArray.
        /// </summary>
        /// <typeparam name="T">The type of the value to add.</typeparam>
        /// <param name="sObject">The value to add.</param>
        /// <returns>A new GDFReferencesArray instance with the added value.</returns>
        public GDFReferencesArray<T> AddValue(T sObject)
        {
            if (!ReferencesList.Contains(sObject.Reference.ToString()))
            {
                ReferencesList.Add(sObject.Reference.ToString());
            }

            return new GDFReferencesArray<T>(ReferencesList);
        }

        /// <summary>
        ///     Adds a single value to the GDFReferencesArray.
        /// </summary>
        /// <param name="sObjectReference">The value to add to the GDFReferencesArray.</param>
        /// <returns>A new instance of GDFReferencesArray with the added value.</returns>
        public GDFReferencesArray<T> AddValue(string sObjectReference)
        {
            if (!ReferencesList.Contains(sObjectReference.ToString()))
            {
                ReferencesList.Add(sObjectReference.ToString());
            }

            return new GDFReferencesArray<T>(ReferencesList);
        }

        /// <summary>
        ///     Adds values to the ReferencesList of the GDFReferencesArray object.
        /// </summary>
        /// <param name="sReferencesArray">An array of ulong values representing the references to be added.</param>
        /// <returns>A new GDFReferencesArray object with the added values.</returns>
        /// /
        public GDFReferencesArray<T> AddValues(ulong[] sReferencesArray)
        {
            if (sReferencesArray != null)
            {
                foreach (ulong tRef in sReferencesArray)
                {
                    if (!ReferencesList.Contains(tRef.ToString()))
                    {
                        ReferencesList.Add(tRef.ToString());
                    }
                }
            }

            return new GDFReferencesArray<T>(ReferencesList);
        }


        /// <summary>
        ///     Adds the values from an array of objects to the GDFReferencesArray.
        /// </summary>
        /// <typeparam name="T">The type of objects in the array.</typeparam>
        /// <param name="sObjectsArray">The array of objects to add.</param>
        /// <returns>The updated GDFReferencesArray with the added values.</returns>
        public GDFReferencesArray<T> AddValues(T[] sObjectsArray)
        {
            if (sObjectsArray != null)
            {
                foreach (T tRef in sObjectsArray)
                {
                    if (!ReferencesList.Contains(tRef.Reference.ToString()))
                    {
                        ReferencesList.Add(tRef.Reference.ToString());
                    }
                }
            }

            return new GDFReferencesArray<T>(ReferencesList);
        }

        /// <summary>
        ///     Retrieves the references from a given string.
        /// </summary>
        /// <param name="sReferencesString">The string containing the references.</param>
        /// <returns>A list of references extracted from the given string.</returns>
        private List<ulong> GetReferences(string sReferencesString)
        {
            List<ulong> rReferences = new List<ulong>();
            if (string.IsNullOrEmpty(sReferencesString) == false)
            {
                foreach (string tRef in sReferencesString.Split(K_SEPARATOR, StringSplitOptions.RemoveEmptyEntries))
                {
                    rReferences.Add(ulong.Parse(tRef));
                }
            }

            return rReferences;
        }

        /// <summary>
        ///     Removes the specified array of references from the <see cref="GDFReferencesArray{T}" /> object.
        /// </summary>
        /// <param name="sReferencesArray">The array of references to be removed.</param>
        /// <returns>A new <see cref="GDFReferencesArray{T}" /> object with the references removed.</returns>
        public GDFReferencesArray<T> RemoveValues(ulong[] sReferencesArray)
        {
            if (sReferencesArray != null)
            {
                foreach (ulong tRef in sReferencesArray)
                {
                    if (ReferencesList.Contains(tRef.ToString()))
                    {
                        ReferencesList.Remove(tRef.ToString());
                    }
                }
            }

            return new GDFReferencesArray<T>(ReferencesList);
        }

        /// <summary>
        ///     Removes the values from the ReferencesList based on the given array of objects.
        /// </summary>
        /// <typeparam name="T">The type of objects in the ReferencesList.</typeparam>
        /// <param name="sObjectsArray">The array of objects to be removed from the ReferencesList.</param>
        /// <returns>A new instance of GDFReferencesArray with the removed values.</returns>
        public GDFReferencesArray<T> RemoveValues(T[] sObjectsArray)
        {
            if (sObjectsArray != null)
            {
                foreach (T tRef in sObjectsArray)
                {
                    if (ReferencesList.Contains(tRef.ToString() ?? string.Empty))
                    {
                        ReferencesList.Remove(tRef.ToString() ?? string.Empty);
                    }
                }
            }

            return new GDFReferencesArray<T>(ReferencesList);
        }

        /// <summary>
        ///     Represents a class that manages an array of references to database objects.
        /// </summary>
        /// <typeparam name="T">The type of the database object.</typeparam>
        public string SqlValue()
        {
            return string.Join(K_SEPARATOR, ReferencesList);
        }

        #endregion
    }
}