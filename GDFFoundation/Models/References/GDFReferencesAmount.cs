using System;
using System.Collections.Generic;



namespace GDFFoundation
{
    /// <summary>
    /// Represents a base abstract class for GDFReferencesAmount objects.
    /// </summary>
    [Serializable]
    // TODO change for structure
    public abstract class GDFReferencesAmount : GDFDataType, IGDFSubModel
    {
        public Dictionary<long, float> ReferenceAmount { set; get; } = new Dictionary<long, float>();

    }

    /// <summary>
    /// Represents a base abstract class for GDFReferencesAmount objects.
    /// </summary>
    [Serializable]
    // TODO change for structure
    public class GDFReferencesAmount<T> : GDFReferencesAmount where T : GDFDatabaseObject
    {

    }
}

