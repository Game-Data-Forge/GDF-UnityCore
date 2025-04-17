using System.Collections.Generic;
using GDFFoundation;
using GDFRuntime;
using UnityEngine;

namespace GDFUnity
{
    public class RuntimeConfigurationEngine : IRuntimeConfigurationEngine
    {
        protected const string _RESOURCE_NAME = "Game-Data-Forge/RuntimeConfiguration";
        protected const string _PATH = "Assets/Resources/" + _RESOURCE_NAME + ".asset";

        static public class RuntimeExceptions
        {
            static public GDFException NotFound => new GDFException("CFG", 01, "No configuration found !");
            static public GDFException NotCastable => new GDFException("CFG", 02, "Stored configuration is not of a valid configuration format !");
            static public GDFException InvalidReference => new GDFException("CFG", 03, $"Configuration does not have a valid {nameof(IRuntimeConfiguration.Reference)} !");
            static public GDFException InvalidName => new GDFException("CFG", 04, $"Configuration does not have a valid {nameof(IRuntimeConfiguration.Name)} !");
            static public GDFException InvalidOrganization => new GDFException("CFG", 05, $"Configuration does not have a valid {nameof(IRuntimeConfiguration.Organization)} !");
            static public GDFException InvalidPublicToken => new GDFException("CFG", 06, $"Configuration does not have a valid {nameof(IRuntimeConfiguration.PublicToken)} !");
            static public GDFException InvalidChannel => new GDFException("CFG", 07, $"Configuration does not have a valid {nameof(IRuntimeConfiguration.Channel)} !");
            static public GDFException InvalidAgentPool => new GDFException("CFG", 08, $"Configuration does not have a valid {nameof(IRuntimeConfiguration.AgentPool)} !");
        }

        static private IRuntimeConfigurationEngine _instance = null;
        static public IRuntimeConfigurationEngine Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RuntimeConfigurationEngine();
                }

                return _instance;
            }
        }

        public List<GDFException> ValidationReport(IRuntimeConfiguration configuration)
        {
            List<GDFException> result = new List<GDFException>();

            DefaultValidation(result, configuration);
            TokenValidation(result, configuration);

            return result;
        }

        protected void DefaultValidation(List<GDFException> result, IRuntimeConfiguration configuration)
        {
            if (configuration.Reference == 0)
            {
                result.Add (RuntimeExceptions.InvalidReference);
            }

            if (string.IsNullOrWhiteSpace(configuration.Name))
            {
                result.Add (RuntimeExceptions.InvalidName);
            }

            if (string.IsNullOrWhiteSpace(configuration.Organization))
            {
                result.Add (RuntimeExceptions.InvalidOrganization);
            }

            if (configuration.Channel == 0)
            {
                result.Add (RuntimeExceptions.InvalidChannel);
            }

            if (configuration.AgentPool.Count == 0)
            {
                result.Add (RuntimeExceptions.InvalidAgentPool);
            }
        }

        protected void TokenValidation(List<GDFException> result, IRuntimeConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(configuration.PublicToken))
            {
                result.Add (RuntimeExceptions.InvalidPublicToken);
            }
        }

        public void Validate(IRuntimeConfiguration configuration)
        {
            List<GDFException> result = ValidationReport(configuration);
            if (result.Count > 0)
            {
                throw result[0];
            }
        }

        public IRuntimeConfiguration Load()
        {
            TextAsset asset;
            try
            {
                asset = Resources.Load<TextAsset>(_RESOURCE_NAME);
            }
            catch
            {
                throw RuntimeExceptions.NotFound;
            }

            if (asset == null)
            {
                throw RuntimeExceptions.NotFound;
            }

            RuntimeConfiguration configuration;
            try
            {
                configuration = JsonUtility.Deserialize<RuntimeConfiguration>(asset.text);
            }
            catch
            {
                throw RuntimeExceptions.NotCastable;
            }
            Validate(configuration);
            return configuration;
        }
    }
}