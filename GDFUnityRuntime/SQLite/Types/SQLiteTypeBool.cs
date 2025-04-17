using System;

namespace GDFUnity
{
    public class SQLiteTypeBool : SQLiteTypeInteger
    {
        public override byte ByteSize => 1;

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            sbyte val = Convert.ToSByte(value);
            SQLite3.BindInt(request, index, val);
        }

        public override object Read (SQLiteDbRequest request, int columnIndex)
        {
            sbyte value = Convert.ToSByte(base.Read(request, columnIndex));
            return value == 0 ? false : true;
        }
    }
}