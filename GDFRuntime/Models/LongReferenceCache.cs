using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// Represents a class for storing and retrieving data in memory.
    /// </summary>
    public class LongReferenceCache
    {
        /// <summary>
        /// Represents the synchronization index used to track the synchronization progress of data.
        /// </summary>
        public long syncIndex = 0;

        /// <summary>
        /// Class that represents the in-memory data store for GDFBasicData objects.
        /// </summary>
        private ConcurrentDictionary<Type, ConcurrentDictionary<long, GDFBasicData>> _cache = new ConcurrentDictionary<Type, ConcurrentDictionary<long, GDFBasicData>>();

        /// <summary>
        /// Represents the data memory of the application.
        /// </summary>
        public List<GDFBasicData> DataMemory
        {
            get { return _cache.Values.SelectMany(x => x.Values).ToList(); }
        }

        /// <summary>
        /// Adds data to the in-memory cache of the given type.
        /// </summary>
        /// <param name="data">The data object to add to the cache.</param>
        /// <param name="type">The type of the data object.</param>
        public void Add(GDFBasicData data, Type type)
        {
            IGDFWritableLongReference reference = data as IGDFWritableLongReference;
            if (reference == null) return;

            if (!_cache.ContainsKey(type))
            {
                _cache.TryAdd(type, new ConcurrentDictionary<long, GDFBasicData>());
            }
            if (!_cache[type].TryAdd(reference.Reference, data))
            {
                _cache[type][reference.Reference] = data;
            }
        }

        /// <summary>
        /// Adds the given object to the data memory.
        /// </summary>
        /// <typeparam name="T">The type of the object being added to the data memory.</typeparam>
        /// <param name="data">The object to be added to the data memory.</param>
        /// <remarks>
        /// This method adds the given object to the data memory dictionary of the GDFDataInMemory instance.
        /// The object must be a derived class of GDFBasicData.
        /// If the object already exists in the data memory dictionary, it will be replaced.
        /// </remarks>
        public void Add<T>(T data) where T : GDFBasicData, IGDFWritableLongReference
        {
            Add(data, data.GetType());
        }

        /// <summary>
        /// Adds data to the in-memory cache of the given type.
        /// </summary>
        /// <param name="cache">The data object to add to the cache.</param>
        public void Add(LongReferenceCache cache)
        {
            foreach (KeyValuePair<Type, ConcurrentDictionary<long, GDFBasicData>> tType in cache._cache)
            {
                foreach (KeyValuePair<long, GDFBasicData> tObject in tType.Value)
                {
                    Add(tObject.Value, tType.Key);
                }
            }

        }

        /// <summary>
        /// Removes the specified object from the data memory.
        /// </summary>
        /// <typeparam name="T">The type of the object to remove. Must be a subclass of GDFBasicData.</typeparam>
        /// <param name="data">The object to remove.</param>
        /// <remarks>
        /// This method removes the specified object from the data memory dictionary.
        /// </remarks>
        public void Remove<T>(T data) where T : GDFBasicData, IGDFWritableLongReference
        {
            _cache[typeof(T)].Remove(data.Reference, out GDFBasicData _);
        }

        /// <summary>
        /// Retrieves data from the data memory dictionary based on the provided reference.
        /// </summary>
        /// <typeparam name="T">The type of the data to retrieve. Must inherit from GDFBasicData.</typeparam>
        /// <param name="reference">The reference to search for in the data memory.</param>
        /// <returns>The data object of type T if found; otherwise, null.</returns>
        public T GetByReference<T>(long reference) where T : GDFBasicData
        {
            if (_cache.TryGetValue(typeof(T), out ConcurrentDictionary<long, GDFBasicData> cache) && cache.TryGetValue(reference, out GDFBasicData result))
            {
                return result as T;
            }
            return null;
        }

        /// <summary>
        /// Retrieves data of a specified class from the data memory.
        /// </summary>
        /// <typeparam name="T">The class type to retrieve data from.</typeparam>
        /// <returns>A list of objects of the specified class type. Returns an empty list if the data memory does not contain any objects of the specified class.</returns>
        public List<T> GetByClass<T>() where T : GDFBasicData
        {
            if (_cache.TryGetValue(typeof(T), out ConcurrentDictionary<long, GDFBasicData> cache))
            {
                return cache.Values.Cast<T>().ToList();
            }
            return new List<T>();
        }

        /// <summary>
        /// Returns all the data of type T stored in the memory.
        /// </summary>
        /// <typeparam name="T">The type of data to retrieve.</typeparam>
        /// <returns>A list of data of type T.</returns>
        public List<T> FindAll<T>() where T : GDFBasicData
        {
            return _cache.Values.SelectMany(x => x.Values).Cast<T>().ToList();
        }

        /// <summary>
        /// Clear all data from the memory.
        /// </summary>
        public void Clear()
        {
            _cache.Clear();
        }
    }
}

