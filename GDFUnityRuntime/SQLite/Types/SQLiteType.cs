using System;
using System.Collections.Generic;

namespace GDFUnity
{
    public abstract class SQLiteType
    {
        static private Dictionary<Type, SQLiteType> _types = new Dictionary<Type, SQLiteType>(){
            { typeof(string), new SQLiteTypeText() },
            { typeof(Enum), new SQLiteTypeEnum() },
            { typeof(sbyte), new SQLiteTypeSByte() },
            { typeof(byte), new SQLiteTypeByte() },
            { typeof(short), new SQLiteTypeShort() },
            { typeof(ushort), new SQLiteTypeUShort() },
            { typeof(int), new SQLiteTypeInt() },
            { typeof(uint), new SQLiteTypeUInt() },
            { typeof(long), new SQLiteTypeLong() },
            { typeof(ulong), new SQLiteTypeULong() },
            { typeof(bool), new SQLiteTypeBool() },
            { typeof(float), new SQLiteTypeFloat() },
            { typeof(double), new SQLiteTypeDouble() },
            { typeof(DateTime), new SQLiteTypeDateTime() },
        };

        static public SQLiteType Get(Type type)
        {
            if (_types.TryGetValue(type, out SQLiteType value))
            {
                return value;
            }

            throw SQLiteException.InvalidDataType;
        }
        static public SQLiteType Get<T>()
        {
            return Get(typeof(T));
        }

        static public bool Contains(Type type)
        {
            return _types.ContainsKey(type);
        }
        static public bool Contains<T>()
        {
            return Contains(typeof(T));
        }

        protected abstract string CreateColumnFormat { get; }
        protected virtual string SelectColumnFormat => "`{0}`";
        protected virtual string UpdateColumnFormat => "{0}";

        public string CreateColumn (string columnName)
        {
            return string.Format(CreateColumnFormat, columnName);
        }

        public string SelectColumn(string columnName)
        {
            return string.Format(SelectColumnFormat, columnName);
        }

        public abstract void BindParamter (SQLiteDbRequest request, int index, object value);

        public abstract object Read (SQLiteDbRequest request, int columnIndex);
    }
}