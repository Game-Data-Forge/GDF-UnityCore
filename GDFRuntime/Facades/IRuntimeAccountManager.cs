using GDFFoundation;

namespace GDFRuntime
{
    public interface IRuntimeAccountManager
    {
        public Notification DeletingNotif { get; }
        public Notification DeletedNotif { get; }

        public Job Delete();
    }
}