namespace  GDFFoundation
{
    static class SignKindExtension
    {
        public static string Obfuscation(this SignKind kind)
        {
            switch (kind)
            {
                case SignKind.EmailPassword:
                    return "M";
                case SignKind.Device:
                    return "P";
                case SignKind.Facebook:
                    return "E";
                case SignKind.Google:
                    return "R";
                case SignKind.Apple:
                    return "D";
                case SignKind.Microsoft:
                    return "I";
                case SignKind.Twitter:
                    return "Q";
                case SignKind.LinkedIn:
                    return "U";
                case SignKind.Discord:
                    return "A";
                default:
                    return "W";
            }
        }
    }
}