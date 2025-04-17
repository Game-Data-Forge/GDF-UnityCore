namespace GDFFoundation
{

    public static class GDFWebUnixTextAttribute
    {
        public const string K_REGULAR_EXPRESSION = "[a-zA-Z0-9_]*";
        public const string K_ERROR_MESSAGE = "The {0} field allows only unix format.";
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


