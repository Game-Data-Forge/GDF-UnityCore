using GDFFoundation;
using GDFFoundation.Tasks;
using GDFRuntime;

namespace GDFEditor
{
    public interface IEditorEnvironmentManager : IRuntimeEnvironmentManager
    {
        public Event<GDFEnvironmentKind> EnvironmentChangingEvent { get; }
        public Event<GDFEnvironmentKind> EnvironmentChangedEvent { get; }
        public Task<GDFEnvironmentKind> SetEnvironment (GDFEnvironmentKind environment);
    }
}