using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GDFFoundation;
using GDFUnity.Editor.ServiceProviders;

namespace GDFUnity.Editor
{
    static public class AuthenticationSelection
    {
        static public event Action<AuthenticationSettingsProvider, AuthenticationSettingsProvider> onSelectionChanged;
        static internal AuthenticationSettingsProvider selection = null;
        static private List<AuthenticationSettingsProvider> _providers = null;

        static public AuthenticationSettingsProvider Selection
        {
            get => selection;
            set
            {
                AuthenticationSettingsProvider last = selection;
                selection = value;
                onSelectionChanged?.Invoke(last, value);
            }
        }
        static public List<AuthenticationSettingsProvider> Providers
        {
            get
            {
                if (_providers != null)
                {
                    return _providers;
                }

                Type providerType = typeof(AuthenticationSettingsProvider);
                _providers = new List<AuthenticationSettingsProvider>();

                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    _providers.AddRange(assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType && providerType.IsAssignableFrom(x)).Select(x => {
                        try
                        {
                            return Activator.CreateInstance(x) as AuthenticationSettingsProvider;
                        }
                        catch
                        {
                            GDFLogger.Warning($"Authentication settings provider {x.Name} does not have a default constructor !");
                        }
                        return null;
                    }).Where(x => x != null));
                }

                return _providers;
            }
        }
    }
}
