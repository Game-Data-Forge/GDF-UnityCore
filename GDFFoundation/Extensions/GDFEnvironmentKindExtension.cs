namespace GDFFoundation
{
    /// <summary>
    /// Gets or sets a value indicating whether the setup page needs to be executed.
    /// </summary>
    static public class GDFEnvironmentKindExtension
    {
        static private GDFEnvironmentKind[] _array = null;

        static public string ToLongString(this GDFEnvironmentKind self)
        {
            switch (self)
            {
                case GDFEnvironmentKind.Development:
                    return "Development";
                case GDFEnvironmentKind.PlayTest:
                    return "PlayTest";
                case GDFEnvironmentKind.Preproduction:
                    return "Preproduction";
                case GDFEnvironmentKind.Production:
                    return "Production";
            }
            return null;
        }
        static public string ToShortString(this GDFEnvironmentKind self)
        {
            switch (self)
            {
                case GDFEnvironmentKind.Development:
                    return "Dev";
                case GDFEnvironmentKind.PlayTest:
                    return "PlayT";
                case GDFEnvironmentKind.Preproduction:
                    return "Pre";
                case GDFEnvironmentKind.Production:
                    return "Prod";
            }
            return null;
        }
        static public GDFEnvironmentKind[] ToArray()
        {
            if (_array == null)
            {
                _array = new GDFEnvironmentKind[]
                {
                    GDFEnvironmentKind.Development,
                    GDFEnvironmentKind.PlayTest,
                    GDFEnvironmentKind.Preproduction,
                    GDFEnvironmentKind.Production
                };
            }

            return _array;
        }

        static public GDFEnvironmentKind ToEnvironment(this string self)
        {
            switch (self)
            {
                case "Development":
                case "Dev":
                    return GDFEnvironmentKind.Development;
                case "PlayTest":
                case "PlayT":
                    return GDFEnvironmentKind.PlayTest;
                case "Preproduction":
                case "Pre":
                    return GDFEnvironmentKind.Preproduction;
                case "Production":
                case "Prod":
                    return GDFEnvironmentKind.Production;
            }
            return GDFEnvironmentKind.Development;
        }
    }
}
