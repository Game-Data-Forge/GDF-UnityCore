using System;
using System.Reflection;

namespace GDFFoundation
{
    /// <summary>
    /// Gets or sets a value indicating whether the setup page needs to be executed.
    /// </summary>
    static public class PropertyInfoExtension
    {
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
    }
}
