#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFConfig.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public interface IGDFConfig : IGDFProjectKey 
    {
        #region Instance methods
        public string GetDefaultWebEditor();
        public GDFExchangeDevice GetDeviceOS();
        public long GetProjectReference();
        public GDFDataTrackDescription GetSelectedEnvironment();
        public string WebEditorURL();
        public string WebServerURLFormat();

        #endregion

    }
}