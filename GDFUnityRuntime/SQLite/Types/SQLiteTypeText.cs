using System.Text;

namespace GDFUnity
{
    public class SQLiteTypeText : SQLiteType
    {
        protected override string CreateColumnFormat => SelectColumnFormat + " TEXT NOT NULL DEFAULT ''";

        public override void BindParamter (SQLiteDbRequest request, int index, object value)
        {
            string str = (string)value;
            int length = Encoding.Unicode.GetByteCount(str);
            SQLite3.BindText(request, index, str, length, System.IntPtr.Zero);
        }

        public override object Read (SQLiteDbRequest request, int columnIndex)
        {
            return SQLite3.ColumnString(request, columnIndex);
        }
    }
}