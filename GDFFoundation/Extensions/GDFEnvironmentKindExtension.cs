#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFEnvironmentKindExtension.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Gets or sets a value indicating whether the setup page needs to be executed.
    /// </summary>
    static public class GDFEnvironmentKindExtension
    {
        #region Static fields and properties

        static private ProjectEnvironment[] _array = null;

        #endregion

        #region Static methods

        static public ProjectEnvironment[] ToArray()
        {
            if (_array == null)
            {
                _array = new ProjectEnvironment[]
                {
                    ProjectEnvironment.Development,
                    ProjectEnvironment.PlayTest,
                    ProjectEnvironment.Preproduction,
                    ProjectEnvironment.Production
                };
            }

            return _array;
        }

        static public ProjectEnvironment ToEnvironment(this string self)
        {
            switch (self)
            {
                case "Development":
                case "Dev":
                    return ProjectEnvironment.Development;
                case "PlayTest":
                case "PlayT":
                    return ProjectEnvironment.PlayTest;
                case "Preproduction":
                case "Pre":
                    return ProjectEnvironment.Preproduction;
                case "Production":
                case "Prod":
                    return ProjectEnvironment.Production;
            }

            return ProjectEnvironment.Development;
        }

        static public string ToLongString(this ProjectEnvironment self)
        {
            switch (self)
            {
                case ProjectEnvironment.Development:
                    return "Development";
                case ProjectEnvironment.PlayTest:
                    return "PlayTest";
                case ProjectEnvironment.Preproduction:
                    return "Preproduction";
                case ProjectEnvironment.Production:
                    return "Production";
            }

            return null;
        }

        static public string ToShortString(this ProjectEnvironment self)
        {
            switch (self)
            {
                case ProjectEnvironment.Development:
                    return "Dev";
                case ProjectEnvironment.PlayTest:
                    return "PlayT";
                case ProjectEnvironment.Preproduction:
                    return "Pre";
                case ProjectEnvironment.Production:
                    return "Prod";
            }

            return null;
        }

        #endregion
    }
}