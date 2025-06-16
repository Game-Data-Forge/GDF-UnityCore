#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj PropertyInfoExtension.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Gets or sets a value indicating whether the setup page needs to be executed.
    /// </summary>
    static public class PropertyInfoExtension
    {
        #region Static methods

        static public T ComplexGetCustomAttribute<T>(this PropertyInfo self) where T : Attribute
        {
            T attribute = self.GetCustomAttribute<T>();
            if (attribute != null)
            {
                return attribute;
            }

            PropertyInfo other;
            Type[] interfaces = self.DeclaringType.GetInterfaces();
            if (interfaces != null)
            {
                for (int i = 0; i < interfaces.Length; i++)
                {
                    other = interfaces[i].GetProperty(self.Name);
                    if (other == null)
                    {
                        continue;
                    }

                    attribute = other.ComplexGetCustomAttribute<T>();
                    if (attribute != null)
                    {
                        return attribute;
                    }
                }
            }

            Type parentType = self.DeclaringType.BaseType;
            while (parentType != null)
            {
                other = parentType.GetProperty(self.Name);
                if (other == null)
                {
                    parentType = parentType.BaseType;
                    continue;
                }

                return other.ComplexGetCustomAttribute<T>();
            }

            return null;
        }
        
        static public List<T> ComplexGetCustomAttributes<T>(this PropertyInfo self) where T : Attribute
        {
            List<T> result = new List<T>();
            IEnumerable<T> attributes = self.GetCustomAttributes<T>();
            if (attributes != null)
            {
                result.AddRange(attributes);
            }

            PropertyInfo other;
            Type[] interfaces = self.DeclaringType.GetInterfaces();
            if (interfaces != null)
            {
                for (int i = 0; i < interfaces.Length; i++)
                {
                    other = interfaces[i].GetProperty(self.Name);
                    if (other == null)
                    {
                        continue;
                    }

                    IEnumerable<T> otherAttributes = other.ComplexGetCustomAttributes<T>();
                    if (otherAttributes != null)
                    {
                        result.AddRange(otherAttributes);
                    }
                }
            }

            Type parentType = self.DeclaringType.BaseType;
            while (parentType != null)
            {
                other = parentType.GetProperty(self.Name);
                if (other == null)
                {
                    parentType = parentType.BaseType;
                    continue;
                }
                IEnumerable<T> otherAttributes = other.ComplexGetCustomAttributes<T>();
                if (otherAttributes != null)
                {
                    result.AddRange(otherAttributes);
                }
            }

            return result;
        }

        #endregion
    }
}