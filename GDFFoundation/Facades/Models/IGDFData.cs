using System;

namespace GDFFoundation
{
    public interface IGDFData
    {
        public long DataVersion { get; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; }
        public DateTime Modification { get; }
        public bool Trashed { get; set; }

        public object GetReference();
    }
}


