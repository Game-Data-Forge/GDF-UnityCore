using System;

namespace GDFFoundation
{
    public interface IGDFWritableData : IGDFData
    {
        public new long DataVersion { get; set; }
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public new DateTime Creation { get; set; }
        public new DateTime Modification { get; set; }
    }
}


