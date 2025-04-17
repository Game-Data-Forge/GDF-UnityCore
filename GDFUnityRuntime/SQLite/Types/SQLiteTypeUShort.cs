using System;

namespace GDFUnity
{
    public class SQLiteTypeUShort : SQLiteTypeInteger
    {
        public override byte ByteSize => 2;

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            ushort val = Convert.ToUInt16(value);
            SQLite3.BindInt(request, index, unchecked((short)((short)val + short.MinValue)));
        }
        
        public override object Read (SQLiteDbRequest request, int columnIndex)
        {
            short value = Convert.ToInt16(base.Read(request, columnIndex));
            return unchecked((ushort)(value - short.MinValue));
        }
    }
}