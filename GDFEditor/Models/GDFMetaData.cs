using System;
using GDFFoundation;

namespace GDFEditor
{
    /// <summary>
    /// The GDFMetaData class represents metadata information for a project.
    /// </summary>
    public class GDFMetaData : GDFLocalWebData
    {
        /// <summary>
        /// Gets or sets the unique identifier for a project.
        /// </summary>
        public long ProjectUniqueId { set; get; }

        //public Dictionary<ushort, List<GDFStudioData>> DataByDataTrack  {set; get; } = new Dictionary<ushort, List<GDFStudioData>>();
        /// <summary>
        /// Gets or sets the data organized by data track.
        /// </summary>
        public string DataByDataTrack { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the title of a project.
        /// </summary>
        public string Title { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the GDFMetaData.
        /// </summary>
        public string Description { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets the class name of the metadata.
        /// </summary>
        public string ClassName { set; get; } = string.Empty;

        /// <summary>
        /// Gets or sets whether the metadata is locked or not.
        /// </summary>
        public bool IsLocked { set; get; } = false;

        /// <summary>
        /// Gets or sets the lock limit for a metadata entry.
        /// </summary>
        public long LockLimit { set; get; } = 0;

        /// <summary>
        /// Gets or sets the name of the locker for the metadata object.
        /// </summary>
        public string LockerName { set; get; } = string.Empty;

        /// <summary>
        /// The channel the data is accessible from.
        /// </summary>
        public int Channel { set; get; } = 0;

        /// <summary>
        /// The GDFMetaData class represents metadata information for a project.
        /// </summary>
        public GDFMetaData()
        {
        }

        /// <summary>
        /// The GDFMetaData class represents metadata information for a project.
        /// </summary>
        public GDFMetaData(GDFMetaData sOther) : base(sOther)
        {
            Reference = sOther.Reference;
            ProjectUniqueId = sOther.ProjectUniqueId;
            DataByDataTrack = sOther.DataByDataTrack;
            Title = sOther.Title;
            Description = sOther.Description;
            ClassName = sOther.ClassName;
            IsLocked = sOther.IsLocked;
            LockerName = sOther.LockerName;
            Channel = sOther.Channel;
        }

        /// <summary>
        /// Copy the property values of another GDFMetaData object to this instance.
        /// </summary>
        /// <param name="sOther">The GDFMetaData object to copy from.</param>
        public void CopyFrom(GDFMetaData sOther)
        {
            if (sOther == null) throw new ArgumentNullException(nameof(sOther));

            base.CopyFrom(sOther);

            Reference = sOther.Reference;
            ProjectUniqueId = sOther.ProjectUniqueId;
            DataByDataTrack = sOther.DataByDataTrack;
            Title = sOther.Title;
            Description = sOther.Description;
            ClassName = sOther.ClassName;
            IsLocked = sOther.IsLocked;
            LockerName = sOther.LockerName;
            Channel = sOther.Channel;
        }
    }
}