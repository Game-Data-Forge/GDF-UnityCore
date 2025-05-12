using System;
using System.Collections.Generic;
using System.Reflection;

namespace GDFFoundation
{
    [Obsolete("Rename ... but by what?")]
    public class GDFAssemblyInfo : IGDFAssemblyInfo
    {
        public static readonly GDFAssemblyInfo AssemblyInfo = new GDFAssemblyInfo();

        public GDFAssemblyInfo()
        {
            LibrariesWorkflow.AddAssemblyInfo(this);
        }

        public bool Printed { set; get; } = false;
        public string DotNet { set; get; } = "9";
        public string GitCommit { set; get; } = string.Empty;
        public string GitCommitShort { set; get; } = string.Empty;
        public string PipelineDate { set; get; } = string.Empty;
        public string PipelineJob { set; get; } = string.Empty;
        public string Version { set; get; } = "1.0.0";
        public bool NuGet { set; get; } = false;
        public string Title { set; get; } = typeof(GDFAssemblyInfo).Assembly.GetName().Name ?? string.Empty;
        public string Description { set; get; } = @"The core module of Game-Data-Forge.
Provides the fundamental building blocks, shared abstractions, and common utility functions used across all other GDF modules. It defines the essential concepts such as StudioData, PlayerData, AccountData, role-based access, environment segmentation, and sync strategies.
This module ensures consistency and reusability across the system, and introduces foundational types, interfaces, and services required by higher-level components like the SyncAgent, AuthAgent, and Companion integrations.";
        public bool Localized { set; get; } = false;
        public List<IGDFAssemblyInfo> Dependencies { set; get; } = new List<IGDFAssemblyInfo>() {GDFFoundation.GDFAssemblyInfo.AssemblyInfo};

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