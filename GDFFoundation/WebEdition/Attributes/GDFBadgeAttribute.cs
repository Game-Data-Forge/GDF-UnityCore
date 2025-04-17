using System;

namespace GDFFoundation
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public class GDFBadgeAttribute : Attribute
    {
        public string Text = string.Empty;
        public GDFBootstrapKindOfStyle Style = GDFBootstrapKindOfStyle.Primary;
        public GDFBadgeAttribute()
        {
        }
        public GDFBadgeAttribute(string text,  GDFBootstrapKindOfStyle style )
        {
            Text = text;
            Style = style;
        }
    }
}