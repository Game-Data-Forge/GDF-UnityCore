using System;

namespace GDFUnity
{
    public class SQLiteTypeLong : SQLiteTypeInteger
    {
        public override byte ByteSize => 8;

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            SQLite3.BindInt64(request, index, Convert.ToInt64(value));
        }

        public override object Read(SQLiteDbRequest sRequest, int sColumnIndex)
        {
            return SQLite3.ColumnInt64(sRequest, sColumnIndex);
        }
    }
}