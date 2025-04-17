

using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a model for generating SQL WHERE clauses for database queries.
    /// </summary>
    public class GDFDatabaseWhereModel
    {
        /// <summary>
        /// Represents a model for generating SQL WHERE clauses for database queries.
        /// </summary>
        public string Column { set; get; } = string.Empty;

        /// <summary>
        /// Represents a database where condition.
        /// </summary>
        public GDFDatabaseWhereKind Operation { set; get; } = GDFDatabaseWhereKind.Equal;

        /// <summary>
        /// Represents a model for building WHERE clauses in a database query.
        /// </summary>
        public string Value { set; get; } = string.Empty;

        /// <summary>
        /// Represents a boolean value used in the GDFDatabaseWhereModel class.
        /// </summary>
        public bool ValueBool { set; get; } = true;

        /// <summary>
        /// Creates a database where condition with the equal operation.
        /// </summary>
        /// <param name="sColumn">The name of the column.</param>
        /// <param name="sValueBool">The value to compare with (as a boolean).</param>
        /// <returns>A new GDFDatabaseWhereModel instance with the equal operation.</returns>
        public static GDFDatabaseWhereModel Equal(string sColumn, bool sValueBool)
        {
            return new GDFDatabaseWhereModel()
            {
                Column = sColumn,
                Operation = GDFDatabaseWhereKind.Equal,
                Value = sValueBool == true ? "1" : "0",
                ValueBool = sValueBool,
            };
        }

        /// <summary>
        /// Creates a new instance of <see cref="GDFDatabaseWhereModel"/> with the operation set to Equal.
        /// </summary>
        /// <param name="sColumn">The column name to compare.</param>
        /// <param name="sValue">The value to compare.</param>
        /// <returns>A new instance of <see cref="GDFDatabaseWhereModel"/> with the column, operation, and value set.</returns>
        public static GDFDatabaseWhereModel Equal(string sColumn, string sValue)
        {
            return new GDFDatabaseWhereModel()
            {
                Column = sColumn,
                Operation = GDFDatabaseWhereKind.Equal,
                Value = sValue
            };
        }

        /// <summary>
        /// Creates a new instance of <see cref="GDFDatabaseWhereModel"/> with the <see cref="GDFDatabaseWhereKind.NotEqual"/> operation.
        /// </summary>
        /// <param name="sColumn">The column name.</param>
        /// <param name="sValue">The value to compare against.</param>
        /// <returns>A new instance of <see cref="GDFDatabaseWhereModel"/> with the <see cref="GDFDatabaseWhereKind.NotEqual"/> operation.</returns>
        public static GDFDatabaseWhereModel NotEqual(string sColumn, string sValue)
        {
            return new GDFDatabaseWhereModel()
            {
                Column = sColumn,
                Operation = GDFDatabaseWhereKind.NotEqual,
                Value = sValue
            };
        }

        /// <summary>
        /// Creates a database query condition for a column value greater than a specified value.
        /// </summary>
        /// <param name="sColumn">The name of the column.</param>
        /// <param name="sValue">The value to compare against.</param>
        /// <returns>A new instance of GDFDatabaseWhereModel with the Operation set to GDFDatabaseWhereKind.GreaterThan.</returns>
        public static GDFDatabaseWhereModel GreaterThan(string sColumn, string sValue)
        {
            return new GDFDatabaseWhereModel()
            {
                Column = sColumn,
                Operation = GDFDatabaseWhereKind.GreaterThan,
                Value = sValue
            };
        }

        /// <summary>
        /// Creates a GDFDatabaseWhereModel with the Operation set to GreaterThanOrEqual.
        /// </summary>
        /// <param name="sColumn">The name of the column to compare.</param>
        /// <param name="sValue">The value to compare with.</param>
        /// <returns>A new GDFDatabaseWhereModel instance with the Operation set to GreaterThanOrEqual.</returns>
        public static GDFDatabaseWhereModel GreaterThanOrEqual(string sColumn, string sValue)
        {
            return new GDFDatabaseWhereModel()
            {
                Column = sColumn,
                Operation = GDFDatabaseWhereKind.GreaterThanOrEqual,
                Value = sValue
            };
        }

        /// <summary>
        /// Retrieves the first relationship code that satisfies the specified conditions.
        /// If there is any relationship with a state of 'Pending' and a code expiry date smaller than the current UTC time,
        /// the code and reference of that relationship are returned.
        /// Otherwise, a new random code is generated.
        /// </summary>
        /// <param name="sColumn">The name of the column to compare.</param>
        /// <param name="sValue">The value to compare against.</param>
        /// <returns>
        /// The relationship code that satisfies the conditions, or a new random code if no relationship is found.
        /// </returns>
        public static GDFDatabaseWhereModel SmallerThan(string sColumn, string sValue)
        {
            return new GDFDatabaseWhereModel()
            {
                Column = sColumn,
                Operation = GDFDatabaseWhereKind.SmallerThan,
                Value = sValue
            };
        }

        /// <summary>
        /// Returns a new instance of GDFDatabaseWhereModel with the specified column, operation, and value.
        /// The operation is SmallerThanOrEqual.
        /// </summary>
        /// <param name="sColumn">The column to compare.</param>
        /// <param name="sValue">The value to compare with.</param>
        /// <returns>A new instance of GDFDatabaseWhereModel with the specified column, operation, and value.</returns>
        public static GDFDatabaseWhereModel SmallerThanOrEqual(string sColumn, string sValue)
        {
            return new GDFDatabaseWhereModel()
            {
                Column = sColumn,
                Operation = GDFDatabaseWhereKind.SmallerThanOrEqual,
                Value = sValue
            };
        }

        /// <summary>
        /// Converts an GDFDatabaseWhereKind operation to a string representation based on the database kind.
        /// </summary>
        /// <param name="sOperation">The operation to convert to a string.</param>
        /// <param name="engine">The database kind to determine the string representation.</param>
        /// <returns>A string representation of the operation based on the database kind.</returns>
        private static string OperationToString(GDFDatabaseWhereKind sOperation, GDFDatabaseEngine engine)
        {
            string rReturn = " = ";
            switch (engine)
            {
                case GDFDatabaseEngine.None:
                    break;
                // case GDFDatabaseKind.MySql:
                // case GDFDatabaseKind.MysqlReflexion:
                case GDFDatabaseEngine.MariaDb:
                // case GDFDatabaseKind.SqlServer:
                // case GDFDatabaseKind.SqlServerReflexion:
                //     {
                //         switch (sOperation)
                //         {
                //             case GDFDatabaseWhereKind.Equal:
                //                 rReturn = " = ";
                //                 break;
                //             case GDFDatabaseWhereKind.NotEqual:
                //                 rReturn = " != ";
                //                 break;
                //             case GDFDatabaseWhereKind.GreaterThan:
                //                 rReturn = " > ";
                //                 break;
                //             case GDFDatabaseWhereKind.GreaterThanOrEqual:
                //                 rReturn = " >= ";
                //                 break;
                //             case GDFDatabaseWhereKind.SmallerThan:
                //                 rReturn = " < ";
                //                 break;
                //             case GDFDatabaseWhereKind.SmallerThanOrEqual:
                //                 rReturn = " <= ";
                //                 break;
                //         }
                //     }
                //     break;
                // case GDFDatabaseKind.PostgreSql:
                // case GDFDatabaseKind.PostgreSqlReflexion:
                //     {
                //         switch (sOperation)
                //         {
                //             case GDFDatabaseWhereKind.Equal:
                //                 rReturn = "=";
                //                 break;
                //             case GDFDatabaseWhereKind.NotEqual:
                //                 rReturn = "!=";
                //                 break;
                //             case GDFDatabaseWhereKind.GreaterThan:
                //                 rReturn = ">";
                //                 break;
                //             case GDFDatabaseWhereKind.GreaterThanOrEqual:
                //                 rReturn = ">=";
                //                 break;
                //             case GDFDatabaseWhereKind.SmallerThan:
                //                 rReturn = "<";
                //                 break;
                //             case GDFDatabaseWhereKind.SmallerThanOrEqual:
                //                 rReturn = "<=";
                //                 break;
                //         }
                //     }
                //     break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(engine), engine, null);
            }
            return rReturn;
        }

        /// <summary>
        /// Converts a GDFDatabaseWhereModel object into a string representation of a clause based on the provided database kind.
        /// </summary>
        /// <param name="sEvent">The GDFDatabaseWhereModel object to convert into a clause string.</param>
        /// <param name="engine">The database kind to use for generating the clause string.</param>
        /// <returns>A string representation of the clause based on the provided database kind.</returns>
        private static string ClauseToString(GDFDatabaseWhereModel sEvent, GDFDatabaseEngine engine)
        {
            string rReturn = "";
            switch (engine)
            {
                case GDFDatabaseEngine.None:
                    break;
                // case GDFDatabaseKind.MySql:
                // case GDFDatabaseKind.MysqlReflexion:
                    // rReturn = "" + sEvent.Column + " " + OperationToString(sEvent.Operation, sKind) + "'" + sEvent.Value.Replace("'", "''") + "' ";
                    // break;
                case GDFDatabaseEngine.MariaDb:
                    rReturn = "`" + sEvent.Column + "` " + OperationToString(sEvent.Operation, engine) + "'" + sEvent.Value.Replace("'", "''") + "' ";
                    break;
                // case GDFDatabaseKind.SqlServer:
                // case GDFDatabaseKind.SqlServerReflexion:
                //     rReturn = "[" + sEvent.Column + "] " + OperationToString(sEvent.Operation, sKind) + "'" + sEvent.Value.Replace("'", "''") + "' ";
                //     break;
                // case GDFDatabaseKind.PostgreSql:
                // case GDFDatabaseKind.PostgreSqlReflexion:
                //     rReturn = "\"" + sEvent.Column + "\"" + OperationToString(sEvent.Operation, sKind) + "'" + sEvent.Value.Replace("'", "\\\'") + "' ";
                //     break;
            }
            return rReturn;
        }

        /// <summary>
        /// Converts a list of GDFDatabaseWhereModel objects into a string representation of the WHERE clause
        /// </summary>
        /// <param name="sList">The list of GDFDatabaseWhereModel objects</param>
        /// <param name="engine">The GDFDatabaseKind value</param>
        /// <returns>The string representation of the WHERE clause</returns>
        public static string WhereClauseToString(List<GDFDatabaseWhereModel> sList, GDFDatabaseEngine engine)
        {
            if (sList != null)
            {
                List<string> tReturnList = new List<string>();
                foreach (GDFDatabaseWhereModel tEvent in sList)
                {
                    tReturnList.Add(ClauseToString(tEvent, engine));
                }
                if (tReturnList.Count > 0)
                {
                    return " WHERE " + string.Join(" AND ", tReturnList) + " ";
                }
            }
            return " ";
        }
    }

}

