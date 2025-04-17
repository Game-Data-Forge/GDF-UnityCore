namespace GDFFoundation
{
    public interface IGDFWritableStringReference : IGDFStringReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        [GDFDbUnique(constraintName = "Identity")]
        public new string Reference { get; set; }
    }
}


