using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace GDFFoundation
{
    /// <summary>
    /// The GDFConfigurationInstalled class is responsible for managing installed configurations.
    /// </summary>
    public static class GDFConfigurationInstalled
    {
        /// <summary>
        /// Provides configuration management for installed configurations.
        /// </summary>
        private static readonly Dictionary<string, Object> ConfigurationsInstalled = new Dictionary<string, Object>();

        /// <summary>
        /// Represents a list of installed configurations.
        /// </summary>
        private static readonly List<IGDFConfiguration> ConfigurationList = new List<IGDFConfiguration>();

        /// <summary>
        /// Adds a configuration object to the list of installed configurations.
        /// </summary>
        /// <param name="sObject">The configuration object to add.</param>
        public static void AddConfiguration(IGDFConfiguration configuration)
        {
            if (ConfigurationsInstalled.ContainsKey(configuration.GetType().Name) == false)
            {
                ConfigurationsInstalled.Add(configuration.GetType().Name, configuration);
            }

            if (ConfigurationList.Contains(configuration) == false)
            {
                ConfigurationList.Add(configuration);
            }
        }

        public static Dictionary<string, string> GetConfigurations()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (KeyValuePair<string, Object> configKeyValue in ConfigurationsInstalled)
            {
                result.TryAdd(configKeyValue.Key, JsonConvert.SerializeObject(configKeyValue.Value));
            }

            return result;
        }


        public static void WriteOptimizedConfigInConsole(bool fileByFile = false)
        {
            string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (!string.IsNullOrEmpty(env))
            {
                env = env + ".";
            }
            else
            {
                env = "";
            }
            if (fileByFile == true)
            {
                foreach (KeyValuePair<string, Object> configKeyValue in ConfigurationsInstalled)
                {
                    List<string> additionalFile = new List<string>();
                    additionalFile.Add($"{{");
                    additionalFile.Add($"\"{configKeyValue.Key}\" : ");
                    additionalFile.AddRange(GDFLogger.SplitObjectSerializable(configKeyValue.Value));
                    additionalFile.Add($"}}");
                    GDFLogger.Information($"{configKeyValue.Key}.{env}json example", additionalFile.ToArray());
                }
            }
            else
            {
                List<string> appsettings = new List<string>();
                appsettings.Add($"{{");
                appsettings.Add($"…");
                foreach (KeyValuePair<string, Object> configKeyValue in ConfigurationsInstalled)
                {
                    appsettings.Add($"\"{configKeyValue.Key}\" : ");
                    appsettings.AddRange(GDFLogger.SplitObjectSerializable(configKeyValue.Value));
                    appsettings[appsettings.Count-1] = appsettings[appsettings.Count-1]+",";
                }
                appsettings.Add($"…");
                appsettings.Add($"}}");
                GDFLogger.Information($"appsettings.{env}json example", appsettings.ToArray());
            }
        }
    }
}