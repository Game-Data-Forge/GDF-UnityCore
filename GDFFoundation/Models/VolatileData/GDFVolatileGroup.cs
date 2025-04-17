

using System;
using System.Collections;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a volatile group of GDFVolatileData objects.
    /// </summary>
    public class GDFVolatileGroup : IDisposable, IEnumerable<GDFVolatileData>
    {
        /// <summary>
        /// Token represents a volatile group token in the GDFFoundation namespace.
        /// </summary>
        internal string Token = string.Empty;

        /// <summary>
        /// The Data class represents a collection of volatile data objects in the GDFFoundation namespace.
        /// </summary>
        private List<GDFVolatileData> Data = new List<GDFVolatileData>();

        /// <summary>
        /// Represents a volatile group used for generating a unique token based on the current timestamp and a random number.
        /// </summary>
        public GDFVolatileGroup()
        {
            Token = GDFTimestamp.Timestamp() + "-" + GDFRandom.LongNumeric(16);
        }

        /// <summary>
        /// Adds a <see cref="GDFVolatileData"/> object to the <see cref="Data"/> list.
        /// </summary>
        /// <param name="sVolatileData">The <see cref="GDFVolatileData"/> object to add.</param>
        /// <returns>
        /// The added <see cref="GDFVolatileData"/> object, or null if <paramref name="sVolatileData"/> is null.
        /// </returns>
        public GDFVolatileData Add(GDFVolatileData sVolatileData)
        {
            if (sVolatileData == null)
            {
                return null;
            }

            sVolatileData.Group = Token;
            Data.Add(sVolatileData);
            return sVolatileData;
        }

        /// <summary>
        /// Releases all resources used by the GDFVolatileGroup object.
        /// </summary>
        public void Dispose()
        {
            Token = string.Empty;
            Data.Clear();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<GDFVolatileData> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        /// <summary>
        /// Gets or sets the GDFVolatileData at the specified index.
        /// </summary>
        /// <param name="i">The zero-based index of the data to get or set.</param>
        /// <returns>The GDFVolatileData at the specified index.</returns>
        /// <remarks>
        /// This property allows getting the GDFVolatileData at the specified index. However, setting the value is not allowed and will display a warning message.
        /// </remarks>
        public GDFVolatileData this[int i]
        {
            get
            {
                return Data[i];
            }
            set
            {
                GDFLogger.Warning("Cannot edit Volatile group data!");
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        /// <value>
        /// The number of elements contained in the collection.
        /// </value>
        public int Count => Data.Count;
    }
}

