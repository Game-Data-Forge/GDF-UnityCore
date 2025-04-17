using System;
using System.Collections.Generic;



namespace GDFFoundation
{
    /// <summary>
    /// Represents a class that stores reference quantities for classes inheriting from GDFDatabaseObject.
    /// </summary>
    [Serializable]
    // TODO change for structure
    public class GDFReferencesQuantity : GDFDataType, IGDFSubModel
    {
        /// <summary>
        /// Represents a class for storing reference quantities.
        /// </summary>
        public Dictionary<long, Int64> ReferenceQuantity { set; get; } = new Dictionary<long, Int64>();

    }

    /// <summary>
    /// Represents a class that stores references and quantities of a particular data type.
    /// </summary>
    [Serializable]
    // TODO change for structure
    public class GDFReferencesQuantity<T> : GDFReferencesQuantity where T : GDFDatabaseObject
    {

    }
}

