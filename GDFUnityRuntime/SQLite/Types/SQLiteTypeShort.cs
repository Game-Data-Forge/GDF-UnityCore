using System;

namespace GDFUnity
{
    public class SQLiteTypeShort : SQLiteTypeInteger
    {
        public override byte ByteSize => 2;

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            SQLite3.BindInt(request, index, Convert.ToInt16(value));
        }
        
        public override object Read (SQLiteDbRequest request, int columnIndex)
        {
            return Convert.ToInt16(base.Read(request, columnIndex));
        }
    }
}