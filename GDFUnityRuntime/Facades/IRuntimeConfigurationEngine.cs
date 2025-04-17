using System.Collections.Generic;
using GDFFoundation;
using GDFRuntime;

namespace GDFUnity
{
    public interface IRuntimeConfigurationEngine
    {
        public IRuntimeConfiguration Load();
        public List<GDFException> ValidationReport(IRuntimeConfiguration configuration);
        public void Validate(IRuntimeConfiguration configuration);
    }
}
