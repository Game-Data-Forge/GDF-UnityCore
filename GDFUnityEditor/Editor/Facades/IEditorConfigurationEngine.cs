using System;
using System.Collections.Generic;
using GDFEditor;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFRuntime;

namespace GDFUnity.Editor
{
    public interface IEditorConfigurationEngine : IRuntimeConfigurationEngine
    {
        public new IEditorConfiguration Load();
        public void Save(IEditorConfiguration configuration);
        public void Save(IRuntimeConfiguration configuration);
        public IRuntimeConfiguration CreateRuntimeConfiguration();
        public List<GDFException> ValidationReport(IEditorConfiguration configuration);
        public void Validate(IEditorConfiguration configuration);
        public IEditorConfiguration LoadWithoutValidation();
        public bool IsValidDashboardAddress(string address);
        public ITask<DateTime> ContactDashboard(string dashboardAddress);
        public ITask<GDFProjectConfiguration> RequestConfigurationUpdate(string dashboardAddress, string role);
    }
}
