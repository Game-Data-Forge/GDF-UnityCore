using System;
//using System.ComponentModel.DataAnnotations;

namespace GDFFoundation
{
    public static class GDFWebNoHtmlAttribute
    {
        public const string K_REGULAR_EXPRESSION = @"^(?!.*<[^>]+>).*";
        public const string K_ERROR_MESSAGE = "The {0} field doesn't allow tag html.";
    }
    
    // [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    // public class GDFWebNoHtmlAttribute : RegularExpressionAttribute
    // {
    //     public const string EregPattern = @"^(?!.*<[^>]+>).*";
    //
    //     public GDFWebNoHtmlAttribute()
    //         : base(EregPattern)
    //     {
    //         ErrorMessage = "The {0} field doesn't allow tag html.";
    //     }
    //
    //     public override string FormatErrorMessage(string name)
    //     {
    //         return string.Format(ErrorMessage, name);
    //     }
    // }
}