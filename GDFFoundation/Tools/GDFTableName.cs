

using System;

namespace GDFFoundation
{
    /// <summary>
    /// A static class that generates table names for database objects.
    /// </summary>
    public static class GDFTableName
    {
        /// <summary>
        /// Generates a table name based on the input parameters.
        /// </summary>
        /// <param name="sType">The Type of the object.</param>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sPrefix">The prefix to be added to the table name.</param>
        /// <returns>The generated table name.</returns>
        public static string GenerateTableName(Type sType, GDFEnvironmentKind sEnvironment, string sPrefix)
        {
            string rReturn = "_";
                switch (sEnvironment)
                {
                    case GDFEnvironmentKind.Development:
                        rReturn = sPrefix + "_Dev_" + sType.Name;
                        break;
                    case GDFEnvironmentKind.PlayTest:
                        rReturn = sPrefix + "_PlayT_" + sType.Name;
                        break;
                    case GDFEnvironmentKind.Preproduction:
                        rReturn = sPrefix + "_Pre_" + sType.Name;
                        break;
                    case GDFEnvironmentKind.Production:
                        rReturn = sPrefix + "_Prod_" + sType.Name;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(sEnvironment), sEnvironment, null);
                }

            return rReturn;
        }
    }
}

