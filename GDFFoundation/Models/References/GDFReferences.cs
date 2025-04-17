using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GDFFoundation
{
    /// <summary>
    /// GDFReferences is an abstract class that represents a generic list of references. It is used for referencing other objects in the GDFFoundation.
    /// </summary>
    [Serializable]
    public abstract class GDFReferences : IGDFSubModel, IEnumerable<long>
    {
        /// <summary>
        /// Represents a list of references to other objects in the GDFFoundation.
        /// </summary>
        public List<long> References { set; get; }

        /// <summary>
        /// GDFReferences is an abstract class that represents a collection of references to other objects in the GDFFoundation.
        /// </summary>
        public GDFReferences()
        {
            References = new List<long>();
        }

        /// <summary>
        /// GDFReferences is an abstract class that represents a collection of references to other objects.
        /// </summary>
        public GDFReferences(IEnumerable<long> sReferences)
        {
            if (sReferences == null)
            {
                References = new List<long>();
            }
            else
            {
                References = sReferences.ToList();
            }
        }

        /// <summary>
        /// GDFReferences is an abstract class representing a collection of references to objects in the GDFFoundation.
        /// </summary>
        public GDFReferences(IEnumerable<GDFLongReference> sReferences)
        {
            if (sReferences == null)
            {
                References = new List<long>();
            }
            else
            {
                References = sReferences.Select(x => x.Reference).ToList();
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list of long values.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the list of long values.</returns>
        public IEnumerator<long> GetEnumerator()
        {
            return References.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return References.GetEnumerator();
        }
    }

    /// <summary>
    /// Represents a set of references to objects in the GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFReferences<T> : GDFReferences where T : IGDFLongReference
    {
        /// <summary>
        /// This is an abstract base class for GDFReferences.
        /// </summary>
        public GDFReferences() : base() { }

        /// <summary>
        /// The GDFReferences class represents a collection of references to other objects in the GDFFoundation.
        /// </summary>
        public GDFReferences(IEnumerable<long> sReferences) : base(sReferences) { }

        public GDFReferences(IEnumerable<GDFLongReference> sReferences) : base(sReferences) { }

        /// <summary>
        /// The GDFReferences class is an abstract base class for storing a list of references.
        /// This class is serialized and can be used as a reference property in database objects.
        /// </summary>
        public GDFReferences(IEnumerable<GDFLongReference<T>> sReferences) : base(sReferences) { }
    }
}



