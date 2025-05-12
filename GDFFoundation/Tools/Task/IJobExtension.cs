namespace GDFFoundation
{
    static public class IJobExtension
    {
        static public bool InUse(this IJob op)
        {
            return op != null && !op.IsDone;
        }
        
        static public void EnsureNotInUse(this IJob op)
        {
            if (op.InUse())
            {
                throw IJob.Exceptions.InUse;
            }
        }
    }
}