using System;

namespace GDFUnity
{
    public class SQLiteTypeByte : SQLiteTypeInteger
    {
        private const sbyte Min = -128;

        public override byte ByteSize => 1;

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            byte val = Convert.ToByte(value);
            SQLite3.BindInt(request, index, unchecked((sbyte)((sbyte)val + Min)));
        }
        
        public override object Read (SQLiteDbRequest request, int columnIndex)
        {
            sbyte value = Convert.ToSByte(base.Read(request, columnIndex));
            return unchecked((byte)(value - Min));
        }
    }
}