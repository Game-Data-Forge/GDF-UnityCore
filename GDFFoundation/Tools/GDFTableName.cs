#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFTableName.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     A static class that generates table names for database objects.
    /// </summary>
    public static class GDFTableName
    {
        #region Static methods

        /// <summary>
        ///     Generates a table name based on the input parameters.
        /// </summary>
        /// <param name="sType">The Type of the object.</param>
        /// <param name="sEnvironment">The environment kind.</param>
        /// <param name="sPrefix">The prefix to be added to the table name.</param>
        /// <returns>The generated table name.</returns>
        public static string GenerateTableName(Type sType, ProjectEnvironment sEnvironment, string sPrefix)
        {
            string rReturn = "_";
            switch (sEnvironment)
            {
                case ProjectEnvironment.Development:
                    rReturn = sPrefix + "_Dev_" + sType.Name;
                break;
                case ProjectEnvironment.PlayTest:
                    rReturn = sPrefix + "_PlayT_" + sType.Name;
                break;
                case ProjectEnvironment.Preproduction:
                    rReturn = sPrefix + "_Pre_" + sType.Name;
                break;
                case ProjectEnvironment.Production:
                    rReturn = sPrefix + "_Prod_" + sType.Name;
                break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sEnvironment), sEnvironment, null);
            }

            return rReturn;
        }

        #endregion
    }
}