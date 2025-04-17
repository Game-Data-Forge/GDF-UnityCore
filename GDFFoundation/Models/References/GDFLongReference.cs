using System;


namespace GDFFoundation
{
    /// <summary>
    /// GDFLongReference represents a reference to another object in the GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFLongReference : IGDFSubModel, IGDFWritableLongReference
    {
        /// <summary>
        /// Represents a reference to another object.
        /// </summary>
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { set; get; }

        /// <summary>
        /// Represents a reference to a database object.
        /// </summary>
        public GDFLongReference()
            : this(0L)
        {
        }

        /// <summary>
        /// GDFLongReference is a class that represents a generic reference to another object in the GDFFoundation framework.
        /// </summary>
        public GDFLongReference(long sReference)
        {
            Reference = sReference;
        }

        /// <summary>
        /// Represents a reference to a database model.
        /// </summary>
        public GDFLongReference(GDFLongReference sCopy)
            : this(sCopy.Reference)
        {
        }

        /// <summary>
        /// Represents a reference to another database model.
        /// </summary>
        public GDFLongReference(IGDFWritableLongReference sData)
            : this(sData.Reference)
        {
        }

        /// Calculates a hash code for the GDFLongReference object based on its Reference property.
        /// @return An integer hash code representing the GDFLongReference object.
        /// /
        public override int GetHashCode()
        {
            return Reference.GetHashCode();
        }

        static public implicit operator GDFLongReference(long value)
        {
            return new GDFLongReference(value);
        }

        static public implicit operator long(GDFLongReference value)
        {
            return value.Reference;
        }
    }

    /// <summary>
    /// The GDFLongReference class is a generic reference class used in GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFLongReference<T> : GDFLongReference where T : IGDFLongReference
    {
        /// <summary>
        /// Base class for GDFLongReference.
        /// </summary>
        public GDFLongReference()
            : base()
        {
        }

        /// <summary>
        /// The GDFLongReference class represents a reference to an object in the GDFFoundation namespace.
        /// </summary>
        public GDFLongReference(long sReference)
            : base(sReference)
        {
        }

        /// <summary>
        /// Represents a reference to a database object.
        /// </summary>
        public GDFLongReference(GDFLongReference sCopy)
            : base(sCopy)
        {
        }

        /// <summary>
        /// The GDFLongReference class is a base class for storing reference values.
        /// </summary>
        public GDFLongReference(GDFLongReference<T> sCopy)
            : base(sCopy.Reference)
        {
        }

        /// <summary>
        /// The GDFLongReference class represents a generic reference to a GDFDatabaseObject object.
        /// </summary>
        public GDFLongReference(T sObject)
            : base(sObject?.Reference ?? 0)
        {
        }

        static public implicit operator GDFLongReference<T>(long value)
        {
            return new GDFLongReference<T>(value);
        }
    }
}