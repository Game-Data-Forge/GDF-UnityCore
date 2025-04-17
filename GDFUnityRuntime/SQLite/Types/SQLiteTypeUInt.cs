using System;

namespace GDFUnity
{
    public class SQLiteTypeUInt : SQLiteTypeInteger
    {
        public override byte ByteSize => 4;

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            uint val = Convert.ToUInt32(value);
            SQLite3.BindInt(request, index, unchecked((int)val + int.MinValue));
        }
        
        public override object Read (SQLiteDbRequest request, int columnIndex)
        {
            int value = Convert.ToInt32(base.Read(request, columnIndex));
            return unchecked((uint)value - int.MinValue);
        }
    }
}