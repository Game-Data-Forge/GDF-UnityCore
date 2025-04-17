using System;

namespace GDFUnity
{
    public class SQLiteTypeDateTime : SQLiteTypeText
    {
        public override void BindParamter (SQLiteDbRequest request, int index, object value)
        {
            base.BindParamter(request, index, ((DateTime)value).ToString("yyyy-MM-dd hh:mm:ss.fff"));
        }

        public override object Read (SQLiteDbRequest request, int columnIndex)
        {
            return DateTime.Parse((string)base.Read(request, columnIndex));
        }
    }
}