using System;

namespace GDFFoundation.Tasks
{
    static public class ITaskExtension
    {
        static public bool InUse(this ITask op)
        {
            return op != null && !op.IsDone;
        }
        
        static public void EnsureNotInUse(this ITask op)
        {
            if (op.InUse())
            {
                throw ITask.Exceptions.InUse;
            }
        }
    }
}