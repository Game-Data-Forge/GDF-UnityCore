namespace GDFFoundation
{
    public interface IGDFLongReference
    {
        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public long Reference { get; }
    }
}
