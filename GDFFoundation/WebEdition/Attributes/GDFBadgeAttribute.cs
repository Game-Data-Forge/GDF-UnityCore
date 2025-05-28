#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFBadgeAttribute.cs create at 2025/03/27 21:03:15
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public class GDFBadgeAttribute : Attribute
    {
        #region Instance fields and properties

        public GDFBootstrapKindOfStyle Style = GDFBootstrapKindOfStyle.Primary;
        public string Text = string.Empty;

        #endregion

        #region Instance constructors and destructors

        public GDFBadgeAttribute()
        {
        }

        public GDFBadgeAttribute(string text, GDFBootstrapKindOfStyle style)
        {
            Text = text;
            Style = style;
        }

        #endregion
    }
}