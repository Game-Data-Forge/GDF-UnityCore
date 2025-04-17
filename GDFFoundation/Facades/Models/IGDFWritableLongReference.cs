namespace GDFFoundation
{
    public interface IGDFWritableLongReference : IGDFLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        [GDFDbUnique(constraintName = "Identity")]
        public new long Reference { get; set; }
    }
}


