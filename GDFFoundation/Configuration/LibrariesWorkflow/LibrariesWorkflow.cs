using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace GDFFoundation
{
    public static class LibrariesWorkflow
    {
        private static readonly List<Assembly> InstalledAssemblies = new List<Assembly>();
        private static readonly List<IGDFVersionDll> NuGetDefinition = new List<IGDFVersionDll>();

        /// <summary>
        /// Represents a private, static, and readonly dictionary that stores information about
        /// installed items and the user or entity responsible for their installation.
        /// The key of the dictionary indicates the installed item, while the value
        /// corresponds to the installer identifier.
        /// </summary>
        private static readonly Dictionary<string, string> Installed = new Dictionary<string,string>();

        /// <summary>
        /// Attempts to mark an item as installed by a specific user or entity.
        /// Logs a warning if the item is already marked as installed.
        /// </summary>
        /// <param name="what">The name of the item to install.</param>
        /// <param name="byWho">The identifier of the user or entity performing the installation.</param>
        /// <returns>
        /// Returns true if the item is successfully marked as installed;
        /// otherwise, false if the item was already marked as installed.
        /// </returns>
        public static bool Set_ModuleInstalledBy(string what, string who)
        {
            bool result = Installed.TryAdd(what, who);
            if (result == false)
            {
                string whoBefore = Installed[what]; 
                GDFLogger.TraceError($"Not possible! the '{what}' was already installed by '{whoBefore}' before '{who}'!");
            }
            else
            {
                GDFLogger.TraceSuccess($"Add '{what}' by '{who}'");
            }

            return result;
        }
        // public static bool Set_ModuleInstalledBy<T>(Expression<Action> methodExpr, string who)
        // {
        //     if (methodExpr.Body is MethodCallExpression methodCall)
        //     {
        //         string methodName = methodCall.Method.Name;
        //         return Set_ModuleInstalledBy(methodName, who);
        //     }
        //
        //     throw new ArgumentException("Expression must be a method call", nameof(methodExpr));
        // }
        public static bool Set_ModuleInstalledBy<T>(Expression<Action<T>> methodExpr, string who)
        {
            if (methodExpr.Body is MethodCallExpression methodCall)
            {
                string methodName = methodCall.Method.Name;
                return Set_ModuleInstalledBy(methodName, who);
            }

            throw new ArgumentException("Expression must be a method call", nameof(methodExpr));
        }
        
        public static bool SetModuleInstalledBy(Expression<Action> expr, string who)
        {
            if (expr.Body is MethodCallExpression call)
            {
                string methodName = call.Method.Name;
                return Set_ModuleInstalledBy(methodName, who);
            }

            throw new ArgumentException("Expression must be a method call", nameof(expr));
        }
        
        public static bool SetModuleInstalledBy(Delegate methodDelegate, string who)
        {
            string methodName = methodDelegate.Method.Name;
            return Set_ModuleInstalledBy(methodName, who);
        }
        
        public static bool Set_ModuleInstalledBy(Action methodCall, string who)
        {
            var methodName = methodCall.Method.Name;
            return Set_ModuleInstalledBy(methodName, who);
        }
        
        public static List<IGDFVersionDll> GetVersionDllList()
        {
            return new List<IGDFVersionDll>(NuGetDefinition);
        }

        public static void AddVersionDefinition(IGDFVersionDll version)
        {
            if (!InstalledAssemblies.Contains(version.GetType().Assembly))
            {
                InstalledAssemblies.Add(version.GetType().Assembly);
                NuGetDefinition.Add(version);
                if (version.Printed == false)
                {
                    version.Printed = true;
                    if (GDFFoundation.GDFConstants.PrintAscii.HasFlag(PrintAsciiKind.Logo))
                    {
                        version.PrintLogo();
                    }

                    if (GDFFoundation.GDFConstants.PrintAscii.HasFlag(PrintAsciiKind.Version))
                    {
                        version.PrintVersion();
                    }

                    if (GDFFoundation.GDFConstants.PrintAscii.HasFlag(PrintAsciiKind.Information))
                    {
                        version.PrintInformation();
                    }
                }
            }
        }

        public static void AddAssembly(Assembly assembly)
        {
            if (!InstalledAssemblies.Contains(assembly))
            {
                InstalledAssemblies.Add(assembly);
            }
        }

        public static void AddType(Type type)
        {
            AddAssembly(Assembly.GetAssembly(type));
        }
    }
}

