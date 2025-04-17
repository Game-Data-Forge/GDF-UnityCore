using System;

namespace GDFUnity
{
    public class SQLiteTypeSByte : SQLiteTypeInteger
    {
        public override byte ByteSize => 1;

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            SQLite3.BindInt(request, index, Convert.ToSByte(value));
        }
        
        public override object Read (SQLiteDbRequest request, int columnIndex)
        {
            return Convert.ToSByte(base.Read(request, columnIndex));
        }
    }
}