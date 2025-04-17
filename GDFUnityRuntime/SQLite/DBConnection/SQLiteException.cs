using System;
using GDFFoundation;

namespace GDFUnity
{
    public class SQLiteException : GDFException
    {
        static public SQLiteException ConnectionOpenError(SQLiteDbConnection connection, SQLite3.Result result)
        {
            return New(connection, result, 01, "Could not open SQLite connection !");
        }
        static public SQLiteException ConnectionCloseError(SQLiteDbConnection connection, SQLite3.Result result)
        {
            return New(connection, result, 02, "Could not close SQLite connection !");
        }
        static public SQLiteException ConnectionNotOpenedError(SQLiteDbConnection connection, SQLite3.Result result)
        {
            return New(connection, result, 03, "Could not execute request, connection is not opened !");
        }
        static public SQLiteException RequestOpenError(SQLiteDbConnection connection, SQLite3.Result result)
        {
            return New(connection, result, 04, "Could not open the request !");
        }
        static public SQLiteException RequestCloseError(SQLiteDbConnection connection, SQLite3.Result result)
        {
            return New(connection, result, 05, "Could not close the request !");
        }
        static public SQLiteException RequestNotOpenedError(SQLiteDbConnection connection, SQLite3.Result result)
        {
            return New(connection, result, 06, "Could not execute request, request is not opened !");
        }
        static public SQLiteException RequestSteppingError(SQLiteDbConnection connection, SQLite3.Result result)
        {
            return New(connection, result, 07, "The request could not be stepped !");
        }
        static public SQLiteException WriteError(SQLiteDbConnection connection, SQLite3.Result result)
        {
            return New(connection, result, 08, "Could not write data in database !");
        }
        static public SQLiteException InvalidDataType => New(null, SQLite3.Result.Error, 09, "Data type not supported !");

        static public bool IsError(SQLite3.Result result)
        {
            switch (result)
            {
                case SQLite3.Result.OK:
                case SQLite3.Result.Row:
                case SQLite3.Result.Done:
                case SQLite3.Result.Warning:
                    return false;
            }

            return true;
        }
        static private SQLiteException New(SQLiteDbConnection connection, SQLite3.Result result, int errorId, string message)
        {
            message += "\nResult: " + result;
            if (connection != IntPtr.Zero)
            {
                message += ": " + SQLite3.GetErrmsg(connection) + "\nDatabase: " + connection.GetPath();
            }
            return new SQLiteException(result, errorId, message);
        }

        public SQLite3.Result Result { get; private set; }

        private SQLiteException(SQLite3.Result result, int errorId, string message) : base("SQL", errorId, message)
        {
            Result = result;
        }
    }
}