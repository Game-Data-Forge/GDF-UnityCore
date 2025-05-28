#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFWebNoHtmlAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


//using System.ComponentModel.DataAnnotations;

namespace GDFFoundation
{
    public static class GDFWebNoHtmlAttribute
    {
        #region Constants

        public const string K_ERROR_MESSAGE = "The {0} field doesn't allow tag html.";
        public const string K_REGULAR_EXPRESSION = @"^(?!.*<[^>]+>).*";

        #endregion
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