using System;

namespace GDFUnity
{
    public class SQLiteTypeULong : SQLiteTypeInteger
    {
        public override byte ByteSize => 8;

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            ulong val = Convert.ToUInt64(value);
            SQLite3.BindInt64(request, index, unchecked((long)val + long.MinValue));
        }
        
        public override object Read (SQLiteDbRequest request, int columnIndex)
        {
            long value = SQLite3.ColumnInt(request, columnIndex);
            return unchecked((ulong)(value - long.MinValue));
        }
    }
}