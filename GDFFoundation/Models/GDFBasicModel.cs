

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a basic model for the GDF database.
    /// </summary>
    [Serializable]
    [Obsolete("Use the IGDFData structure instead !")]
    public abstract class GDFBasicData : GDFDatabaseObject
    {
        /// <summary>
        /// Project ID
        /// </summary>
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        [GDFDbUnique(constraintName = "Identity")]
        public long ProjectReference { set; get; } = 0;

        /// <summary>
        /// Represents the data version of a GDFBasicData.
        /// </summary>
        public long DataVersion { set; get; } = 0;

        /// <summary>
        /// The GDFBasicData class is an abstract class that serves as the base model for all the models in the application.
        /// It extends the GDFDatabaseObject class and provides additional properties and methods specific to the application's models.
        /// </summary>
        protected GDFBasicData()
        {
            DataVersion = GetModelVersion();
        }

        /// <summary>
        /// Returns the model version of the current instance.
        /// </summary>
        /// <returns>The model version.</returns>
        public virtual long GetModelVersion()
        {
            return 0;
        }

        /// <summary>
        /// Upgrades the model with the given JSON data and version.
        /// </summary>
        /// <param name="sJson">The JSON data to upgrade the model with.</param>
        /// <param name="sVersion">The version of the data to upgrade.</param>
        public virtual void Upgrade(string sJson, long sVersion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to copy the values from another <see cref="GDFBasicData"/> object.
        /// </summary>
        /// <param name="sOther">The <see cref="GDFBasicData"/> object from which to copy the values.</param>
        public void CopyFrom(GDFBasicData sOther)
        {
            // Console.WriteLine("CopyFrom GDFBasicData");
            base.CopyFrom(sOther);
            ProjectReference = sOther.ProjectReference;
        }

        public object GetReference()
        {
            IGDFWritableStringReference stringReference = this as IGDFWritableStringReference;
            if (stringReference != null)
            {
                return stringReference.Reference;
            }

            IGDFWritableLongReference longReference = this as IGDFWritableLongReference;
            if (longReference != null)
            {
                return longReference.Reference;
            }

            return null;
        }
    }
}

