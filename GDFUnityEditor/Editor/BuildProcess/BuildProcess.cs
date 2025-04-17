using System;
using GDFFoundation;
using GDFRuntime;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace GDFUnity.Editor
{
    public class BuildProcess : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            try
            {
                GDFLogger.Debug("Started GDF Build process...");
                IRuntimeConfiguration configuration = EditorConfigurationEngine.Instance.CreateRuntimeConfiguration();
                EditorConfigurationEngine.Instance.Save(configuration);
                GDFLogger.Debug("GDF Build process done !");
            }
            catch (Exception e)
            {
                FailBuild(e.Message);
            }
        }

        private void FailBuild (string message)
        {
            throw new BuildFailedException("FORCED FAILED");
        }
    }
}