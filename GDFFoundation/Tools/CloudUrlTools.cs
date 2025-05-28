#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj CloudUrlTools.cs create at 2025/05/20 10:05:01
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public static class CloudUrlTools
    {
        #region Static fields and properties

        public static CloudConfiguration ShareConfig = new CloudConfiguration();

        #endregion

        #region Static methods

        public static string GetBestAuthUrlFor(Country country)
        {
            return "https://" + ShareConfig.Auth[country];
        }

        public static string GetBestDashboardUrlFor()
        {
            return "https://" + ShareConfig.Dashboard;
        }

        public static string GetBestLicenceUrlFor()
        {
            return GDFConstants.K_GDFURL;
        }


        public static string GetBestSyncUrlFor(Country country)
        {
            return "https://" + ShareConfig.Sync[country];
        }

        public static string GetBestVolatiuleUrlFor(Country country)
        {
            return "https://" + ShareConfig.Volatile[country];
        }

        public static CloudConfiguration GetCloudConfig()
        {
            return ShareConfig;
        }

        #endregion
    }
}