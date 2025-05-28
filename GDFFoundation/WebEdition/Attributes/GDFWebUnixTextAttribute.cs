#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFWebUnixTextAttribute.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public static class GDFWebUnixTextAttribute
    {
        #region Constants

        public const string K_ERROR_MESSAGE = "The {0} field allows only unix format.";
        public const string K_REGULAR_EXPRESSION = "[a-zA-Z0-9_]*";

        #endregion
    }
    // [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    // public class GDFWebUnixTextAttribute : RegularExpressionAttribute
    // {
    //     public const string EregPattern = @"[a-zA-Z0-9_]*";
    //
    //     public GDFWebUnixTextAttribute() : base(EregPattern)
    //     {
    //         ErrorMessage = "The {0} field allows only unix format.";
    //     }
    //     
    //     public override string FormatErrorMessage(string name)
    //     {
    //         return string.Format(ErrorMessage, name);
    //     }
    // }
}