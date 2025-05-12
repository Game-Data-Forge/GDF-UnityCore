namespace  GDFFoundation
{
    static class SignKindExtension
    {
        public static string Obfuscation(this GDFAccountSignType kind)
        {
            switch (kind)
            {
                case GDFAccountSignType.EmailPassword:
                    return "M";
                case GDFAccountSignType.DeviceId:
                    return "P";
                case GDFAccountSignType.Facebook:
                    return "E";
                case GDFAccountSignType.Google:
                    return "R";
                case GDFAccountSignType.Apple:
                    return "D";
                case GDFAccountSignType.Microsoft:
                    return "I";
                case GDFAccountSignType.Twitter:
                    return "Q";
                case GDFAccountSignType.LinkedIn:
                    return "U";
                case GDFAccountSignType.Discord:
                    return "A";
                case GDFAccountSignType.None:
                    return "?";
                default:
                    return "W";
            }
        }
    }
}