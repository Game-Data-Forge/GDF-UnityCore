using GDFFoundation;
using GDFRuntime;

namespace GDFEditor
{
    public interface IEditorEnvironmentManager : IRuntimeEnvironmentManager, IAsyncManager
    {
        public Notification<ProjectEnvironment> EnvironmentChanging { get; }
        public Notification<ProjectEnvironment> EnvironmentChanged { get; }
        public Job<ProjectEnvironment> SetEnvironment (ProjectEnvironment environment);
    }
}