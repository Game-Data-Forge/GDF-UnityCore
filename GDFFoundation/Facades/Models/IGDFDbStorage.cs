using System;

namespace GDFFoundation
{
    public interface IGDFDbStorage : IGDFIdStorage
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        [GDFDbUnique(constraintName = "Identity")]
        public long Project { get; set; }
    }
}


