using System;

namespace GDFUnity
{
    public class SQLiteTypeEnum : SQLiteTypeInteger
    {
        public override byte ByteSize => 4;

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            int val = Convert.ToInt32(value);
            SQLite3.BindInt(request, index, val);
        }
    }
}