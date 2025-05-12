using GDFFoundation;
using GDFRuntime;

namespace GDFEditor
{
    public interface IEditorEnvironmentManager : IRuntimeEnvironmentManager
    {
        public Notification<GDFEnvironmentKind> EnvironmentChangingNotif { get; }
        public Notification<GDFEnvironmentKind> EnvironmentChangedNotif { get; }
        public Job<GDFEnvironmentKind> SetEnvironment (GDFEnvironmentKind environment);
    }
}