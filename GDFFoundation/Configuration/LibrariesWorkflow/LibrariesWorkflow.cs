using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GDFFoundation
{
    public static class LibrariesWorkflow
    {
        private static readonly List<Assembly> InstalledAssemblies = new List<Assembly>();
        private static readonly List<IGDFAssemblyInfo> AssemblyInfoList = new List<IGDFAssemblyInfo>();

        /// <summary>
        /// Represents a private, static, and readonly dictionary that stores information about
        /// installed items and the user or entity responsible for their installation.
        /// The key of the dictionary indicates the installed item, while the value
        /// corresponds to the installer identifier.
        /// </summary>
        private static readonly Dictionary<string, string> Installed = new Dictionary<string, string>();

        /// <summary>
        /// Attempts to mark an item as installed by a specific user or entity.
        /// Logs a warning if the item is already marked as installed.
        /// </summary>
        /// <param name="what">The name of the item to install.</param>
        /// <param name="who">The identifier of the user or entity performing the installation.</param>
        /// <param name="optional"></param>
        /// <returns>
        /// Returns true if the item is successfully marked as installed;
        /// otherwise, false if the item was already marked as installed.
        /// </returns>
        private static bool SetModuleInstalledByInternal(string what, string who, string optional)
        {
            bool result = Installed.TryAdd(what, who);
            if (result == false)
            {
                string whoBefore = Installed[what];
                GDFLogger.Error($"Warning: possible conflict! The '{what}' was already installed by '{whoBefore}' before '{who}'! ({optional})");
            }
            else
            {
                GDFLogger.Success($"Add '{what}' by '{who}' ({optional})");
            }

            return result;
        }

        public static bool SetModuleInstalledByExpressionT<T>(Expression<Action<T>> methodExpr, string who, string optional = "")
        {
            if (methodExpr.Body is MethodCallExpression methodCall)
            {
                // string methodName = methodCall.Method.Name;
                var method = methodCall.Method;
                string methodName = method.Name;

                if (method.IsGenericMethod)
                {
                    var genericArguments = method.GetGenericArguments();
                    var genericPart = "<" + string.Join(", ", genericArguments.Select(t => t.Name)) + ">";
                    methodName += genericPart;
                }

                return SetModuleInstalledByInternal(methodName, who, optional);
            }

            throw new ArgumentException("Expression must be a method call", nameof(methodExpr));
        }

        public static bool SetModuleInstalledByExpression(Expression<Action> expr, string who, string optional = "")
        {
            if (expr.Body is MethodCallExpression call)
            {
                // string methodName = call.Method.Name;
                string methodName = ExtractMethodName(expr);
                return SetModuleInstalledByInternal(methodName, who, optional);
            }

            throw new ArgumentException("Expression must be a method call", nameof(expr));
        }

        public static bool SetModuleInstalledByName(string what, string who, string optional = "")
        {
            return SetModuleInstalledByInternal(what, who, optional);
        }

        public static List<IGDFAssemblyInfo> GetVersionDllList()
        {
            return new List<IGDFAssemblyInfo>(AssemblyInfoList);
        }

        public static void AddAssemblyInfo(IGDFAssemblyInfo info)
        {
            if (!InstalledAssemblies.Contains(info.GetType().Assembly))
            {
                InstalledAssemblies.Add(info.GetType().Assembly);
                AssemblyInfoList.Add(info);
                if (info.Printed == false)
                {
                    info.Printed = true;
                    if (GDFFoundation.GDFConstants.PrintAscii.HasFlag(PrintAsciiKind.Logo))
                    {
                        info.PrintLogo();
                    }

                    if (GDFFoundation.GDFConstants.PrintAscii.HasFlag(PrintAsciiKind.Version))
                    {
                        info.PrintVersion();
                    }

                    if (GDFFoundation.GDFConstants.PrintAscii.HasFlag(PrintAsciiKind.Information))
                    {
                        info.PrintInformation();
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

        public static string ExtractMethodName(Expression<Action> expr)
        {
            if (expr.Body is MethodCallExpression call)
            {
                return call.Method.Name;
            }

            if (expr.Body is UnaryExpression unary && unary.Operand is MethodCallExpression innerCall)
            {
                return innerCall.Method.Name;
            }

            throw new ArgumentException("Expression must be a method call", nameof(expr));
        }
    }
}