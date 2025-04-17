﻿using System;



namespace GDFFoundation
{
    /// <summary>
    /// GDFLongReference represents a reference to another object in the GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFStringReference : IGDFSubModel, IGDFWritableStringReference
    {
        /// <summary>
        /// Represents a reference to another object.
        /// </summary>
        public string Reference { set; get; }

        /// <summary>
        /// Represents a reference to a database object.
        /// </summary>
        public GDFStringReference() : this("") { }

        /// <summary>
        /// GDFLongReference is a class that represents a generic reference to another object in the GDFFoundation framework.
        /// </summary>
        public GDFStringReference(string sReference)
        {
            Reference = sReference;
        }

        /// <summary>
        /// Represents a reference to a database model.
        /// </summary>
        public GDFStringReference(GDFStringReference sCopy) : this (sCopy.Reference) { }

        /// <summary>
        /// Represents a reference to another database model.
        /// </summary>
        public GDFStringReference(IGDFWritableStringReference sData) : this(sData.Reference) { }

        /// Calculates a hash code for the GDFLongReference object based on its Reference property.
        /// @return An integer hash code representing the GDFLongReference object.
        /// /
        public override int GetHashCode()
        {
            return Reference.GetHashCode();
        }

        static public implicit operator GDFStringReference(string value)
        {
            return new GDFStringReference(value);
        }

        static public implicit operator string(GDFStringReference value)
        {
            return value.Reference;
        }
    }

    /// <summary>
    /// The GDFLongReference class is a generic reference class used in GDFFoundation.
    /// </summary>
    [Serializable]
    public class GDFStringReference<T> : GDFStringReference where T : IGDFStringReference
    {
        /// <summary>
        /// Base class for GDFLongReference.
        /// </summary>
        public GDFStringReference() : base() { }

        /// <summary>
        /// The GDFLongReference class represents a reference to an object in the GDFFoundation namespace.
        /// </summary>
        public GDFStringReference(string sReference) : base(sReference) { }

        /// <summary>
        /// Represents a reference to a database object.
        /// </summary>
        public GDFStringReference(GDFStringReference sCopy) : base(sCopy) { }

        /// <summary>
        /// The GDFLongReference class is a base class for storing reference values.
        /// </summary>
        public GDFStringReference(GDFStringReference<T> sCopy) : base(sCopy.Reference) { }

        /// <summary>
        /// The GDFLongReference class represents a generic reference to a GDFDatabaseObject object.
        /// </summary>
        public GDFStringReference(T sObject) : base(sObject?.Reference) { }

        static public implicit operator GDFStringReference<T>(string value)
        {
            return new GDFStringReference<T>(value);
        }
    }
}



