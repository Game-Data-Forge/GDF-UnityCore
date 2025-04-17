

using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a class for storing and managing references to enum values for a specific database model.
    /// </summary>
    /// <typeparam name="T">The type of the database model.</typeparam>
    /// <typeparam name="TE">The type of the enum.</typeparam>
    [Serializable]
    // TODO change for structure
    public class GDFReferencesEnum<T, TE> : GDFDataType where TE : Enum where T : GDFDatabaseObject
    {
        /// <summary>
        /// Represents a reference enum data type for GDFFoundation.
        /// </summary>
        /// <typeparam name="T">The type of the referenced database model.</typeparam>
        /// <typeparam name="TE">The type of the enum.</typeparam>
        public Dictionary<ulong, TE> ReferenceEnum { set; get; } = new Dictionary<ulong, TE>();
    }
}

