using System;

namespace GDFUnity
{
    public class SQLiteTypeInt : SQLiteTypeInteger
    {
        public override byte ByteSize => 4;

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            SQLite3.BindInt(request, index, Convert.ToInt32(value));
        }
    }
}