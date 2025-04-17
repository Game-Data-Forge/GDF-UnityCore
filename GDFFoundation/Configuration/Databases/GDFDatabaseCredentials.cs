using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// GDFDatabaseCredentials represents the credentials required to connect to a database.
    /// These credentials include the name, range, kind, server, user, database, common environment, table prefix, port, password, and SSL connection mode.
    /// /
    [Serializable]
    [Obsolete("to rename DatabaseCredentials")]
    public class GDFDatabaseCredentials
    {
        /// <summary>
        /// The name of the database.
        /// </summary>
        public string Name { set; get; } = "Name's database";

        /// <summary>
        /// Represents the range property of the GDFDatabaseCredentials class.
        /// </summary>
        // [Obsolete("It will be removed as soon as possible! Please use Range Credentials instead.")]
        public short Range { set; get; } = 1;

        /// <summary>
        /// Represents the kind of database used in the application.
        /// </summary>
        public GDFDatabaseEngine Engine { set; get; } = GDFDatabaseEngine.MariaDb;

        /// <summary>
        /// Represents the credentials for connecting to a server.
        /// </summary>
        public string Server { set; get; } = "10.10.10.10";

        /// <summary>
        /// Represents the credentials for connecting to a database.
        /// </summary>
        public string User { set; get; } = "User";

        /// <summary>
        /// Represents a database connection.
        /// </summary>
        public string Database { set; get; } = "MyDatabase";

        /// <summary>
        /// Gets or sets the table prefix for the database credentials.
        /// </summary>
        public string TablePrefix { set; get; }// = GDFRandom.RandomStringToken(4);

        /// <summary>
        /// Gets or sets the table name format for the database credentials.
        /// <para>
        /// Use {0} to insert the default name of the table.
        /// </para>
        /// </summary>
        public string TableFormat { set; get; }

        /// <summary>
        /// The port used for the database connection.
        /// </summary>
        /// <remarks>
        /// The default value is 3652.
        /// </remarks>
        /// <seealso cref="GDFDatabaseCredentials"/>
        public int Port { set; get; } = 3652;

        /// <summary>
        /// Represents the password for a database connection.
        /// </summary>
        public string Password { set; get; } = GDFRandom.RandomStringToken(32);

        /// <summary>
        /// The Secure property represents the SSL/TLS security level for a database connection.
        /// </summary>
        public GDFDatabaseConnectionSsl Secure { set; get; } = GDFDatabaseConnectionSsl.Required;

        /// <summary>
        /// GDFDatabaseCredentials represents the credentials required to access a database.
        /// </summary>
        public GDFDatabaseCredentials()
        {

        }

        /// <summary>
        /// GDFDatabaseCredentials represents the credentials required to access a database.
        /// </summary>
        public GDFDatabaseCredentials(GDFDatabaseCredentials other)
        {
            Name = other.Name;
            Range = other.Range;
            Engine = other.Engine;
            Server = other.Server;
            User = other.User;
            Database = other.Database;
            TablePrefix = other.TablePrefix;
            TableFormat = other.TableFormat;
            Port = other.Port;
            Password = other.Password;
            Secure = other.Secure;
        }
        public GDFDatabaseCredentials Copy()
        {
            return new GDFDatabaseCredentials(this);
        }

        /// <summary>
        /// Initializes and creates the TableFormat.
        /// </summary>
        public string GetTableFormat()
        {
            if (!string.IsNullOrWhiteSpace(TableFormat))
            {
                if (TableFormat.Contains("{0}"))
                {
                    return TableFormat;
                }

                return TableFormat + "_{0}";
            }

            if (!string.IsNullOrWhiteSpace(TablePrefix))
            {
                return TablePrefix + "_{0}";
            }
            return "{0}";
        }
    }
}

