using System;

namespace GDFUnityEditor
{
    /// <summary>
    /// Custom property drawer attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class GDFCustomPropertyDrawer : Attribute
    {
        /// <summary>
        /// Attribute used to specify a custom property drawer for a specific type.
        /// </summary>
        public Type Type;

        /// <summary>
        /// Specifies whether the custom property drawer allows children.
        /// </summary>
        private bool AllowChildren;

        /// <summary>
        /// Attribute used to define a custom property drawer for a specific type.
        /// </summary>
        public GDFCustomPropertyDrawer(Type sType, bool sAllowChildren = false)
        {
            Type = sType;
            AllowChildren = sAllowChildren;
        }

        /// <summary>
        /// Checks if a given Type matches the Type specified in the GDFCustomPropertyDrawer attribute.
        /// </summary>
        /// <param name="sType">The Type to check for a match.</param>
        /// <returns>True if the Type matches the specified Type, or if it is a subclass of the specified Type (if AllowChildren is set to true in the GDFCustomPropertyDrawer attribute), otherwise false.</returns>
        public bool Match(Type sType)
        {
            bool sReturn;
            if (AllowChildren)
            {
                sReturn = Type == sType || sType.IsSubclassOf(Type);
            }
            else
            {
                sReturn = Type == sType;
            }

            return sReturn;
        }
    }
}
