namespace GDFFoundation
{
    public interface IGDFWritableAccountData : IGDFWritableData, IGDFAccountData
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        [GDFDbUnique(constraintName = "Identity")]
        public new long Account { get; set; }
    }
}


