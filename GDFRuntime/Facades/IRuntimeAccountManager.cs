using GDFFoundation.Tasks;

namespace GDFRuntime
{
    public interface IRuntimeAccountManager
    {
        public Event DeletingEvent { get; }
        public Event DeletedEvent { get; }

        public Task Delete();
    }
}