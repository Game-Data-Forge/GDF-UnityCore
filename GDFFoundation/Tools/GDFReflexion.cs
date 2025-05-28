#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFReflexion.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace GDFFoundation
{
    public static class GDFReflexion
    {
        #region Static fields and properties

        /// <summary>
        ///     Dictionary that maps string keys to Type values.
        /// </summary>
        private static Dictionary<string, Type> DictionaryOfStringToType = new Dictionary<string, Type>();

        /// <summary>
        ///     Dictionary to store the mapping of types to their string representations.
        /// </summary>
        private static Dictionary<Type, string> DictionaryOfTypeToString = new Dictionary<Type, string>();

        #endregion

        #region Static methods

        /// <summary>
        ///     Retrieves all types in all assemblies that are subclasses of a specified type.
        /// </summary>
        /// <param name="sType">The base type.</param>
        /// <returns>A list of types that are subclasses of the specified type.</returns>
        public static List<Type> GetAllTypesInAllAssembliesSubclassOf(Type sType)
        {
            return GetAllTypesSubclassOf(sType, AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        ///     Gets all types that are subclasses of the specified type in the given assembly.
        /// </summary>
        /// <param name="sType">The base type to filter the subclasses.</param>
        /// <param name="sAssembly">The assembly to search for subclasses.</param>
        /// <returns>A list of types that are subclasses of the specified type in the given assembly.</returns>
        public static List<Type> GetAllTypesSubclassOf(Type sType, Assembly sAssembly)
        {
            List<Type> rReturn = new List<Type>();
            foreach (Type tType in sAssembly.GetTypes())
            {
                if (tType.BaseType == sType)
                {
                    rReturn.Add(tType);
                }
                else if (tType.IsSubclassOf(sType))
                {
                    rReturn.Add(tType);
                }
                else if (tType.BaseType != null && tType.BaseType.IsGenericType && tType.BaseType.GetGenericTypeDefinition() == sType)
                {
                    rReturn.Add(tType);
                }
                else
                {
                    // bye bye
                }
            }

            return rReturn;
        }

        /// <summary>
        ///     Retrieves all types that are subclasses of a specified type from the given assembly.
        /// </summary>
        /// <param name="sType">The type whose subclasses are to be retrieved.</param>
        /// <param name="sAssemblies">The assemblies to search for subclasses.</param>
        /// <returns>A list of types that are subclasses of the specified type in the given assembly.</returns>
        public static List<Type> GetAllTypesSubclassOf(Type sType, Assembly[] sAssemblies)
        {
            List<Type> rReturn = new List<Type>();
            foreach (Assembly tAssembly in sAssemblies)
            {
                rReturn.AddRange(GetAllTypesSubclassOf(sType, tAssembly));
            }

            return rReturn;
        }

        /// <summary>
        ///     Gets the <see cref="Type" /> object with the specified full name.
        /// </summary>
        /// <param name="sFullname">The full name of the type.</param>
        /// <returns>
        ///     The <see cref="Type" /> object with the specified full name if found; otherwise, null.
        /// </returns>
        public static Type GetTypeFromFullname(string sFullname)
        {
            if (DictionaryOfStringToType.ContainsKey(sFullname) == true)
            {
                return DictionaryOfStringToType[sFullname];
            }
            else
            {
                Assembly[] tAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly tAssembly in tAssemblies)
                {
                    Type[] tTypes = tAssembly.GetTypes();
                    foreach (Type tType in tTypes)
                    {
                        if (tType.FullName == sFullname)
                        {
                            DictionaryOfStringToType.TryAdd(sFullname, tType);
                            DictionaryOfTypeToString.TryAdd(tType, sFullname); // TODO: Why ? There is no need for this cache to exist. If you have the type: Type.FullName
                            return tType;
                        }
                    }
                }

                return null;
            }
        }

        #endregion
    }
}