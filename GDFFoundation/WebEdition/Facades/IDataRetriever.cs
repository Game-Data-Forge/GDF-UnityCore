

using System.Collections.Generic;

namespace GDFFoundation
{
    //TODO rename IGDFDataRetriever
    /// <summary>
    /// Represents an interface for retrieving data.
    /// </summary>
    public interface IDataRetriever
    {
        /// <summary>
        /// Retrieves all items of the specified type from the GDFFoundation database.
        /// </summary>
        /// <typeparam name="T">The type of the items to retrieve. Must derive from GDFLocalWebData.</typeparam>
        /// <returns>A list of items of the specified type retrieved from the database.</returns>
        public List<T> GetAll<T>() where T : GDFLocalWebData;

        /// <summary>
        /// Retrieves a list of objects of type T based on the provided references array.
        /// </summary>
        /// <typeparam name="T">The type of the objects to retrieve.</typeparam>
        /// <param name="sReferencesArray">The references array used to filter the objects.</param>
        /// <returns>A list of objects of type T.</returns>
        public List<T> GetAllByReference<T>(IEnumerable<T> sReferencesArray) where T : GDFLocalWebData;
    }
}



