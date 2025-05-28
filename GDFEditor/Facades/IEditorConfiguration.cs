using System.Collections.Generic;
using GDFFoundation;
using GDFRuntime;

namespace GDFEditor
{
    public interface IEditorConfiguration : IRuntimeConfiguration
    {
        public new short Channel { get; set; }
        public string Dashboard { get; }
        public Dictionary<ProjectEnvironment, GDFProjectMinimalCredentials> Credentials { get; }
        public Dictionary<string, short> Channels { get; }
    }
}