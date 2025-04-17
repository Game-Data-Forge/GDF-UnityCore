using System;
using System.Collections.Generic;
using GDFFoundation;

namespace GDFEditor
{
    public class GDFVersionDll : IGDFVersionDll
    {
        public static readonly GDFVersionDll VersionDll = new GDFVersionDll();

        public GDFVersionDll()
        {
            LibrariesWorkflow.AddVersionDefinition(this);
        }

        public bool Printed { set; get; } = false;
        public string DotNet { set; get; } = "9";
        public string GitCommit { set; get; } = string.Empty;
        public string GitCommitShort { set; get; } = string.Empty;
        public string PipelineDate { set; get; } = string.Empty;
        public string PipelineJob { set; get; } = string.Empty;
        public string Version { set; get; } = "1.0.0";
        public bool NuGet { set; get; } = false;
        public string Title { set; get; } = typeof(GDFVersionDll).Assembly.GetName().Name ?? string.Empty;
        public string Description { set; get; } = "Game-Data-Forge module.";
        public bool Localized { set; get; } = false;
        public List<IGDFVersionDll> Dependencies { set; get; } = new List<IGDFVersionDll>() {GDFFoundation.GDFVersionDll.VersionDll};

        public bool DebugStatus()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        public bool DebugTrace()
        {
#if TRACE
            return true;
#else
            return false;
#endif
        }
    }
}