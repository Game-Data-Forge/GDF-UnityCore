namespace GDFUnity
{
    public abstract class SQLiteTypeReal : SQLiteType
    {
        protected override string CreateColumnFormat => SelectColumnFormat + " REAL NOT NULL DEFAULT 0";

        public override void BindParamter(SQLiteDbRequest request, int index, object value)
        {
            double val = (double)value;
            SQLite3.BindDouble(request, index, val);
        }

        public override object Read (SQLiteDbRequest sRequest, int sColumnIndex)
        {
            return SQLite3.ColumnDouble(sRequest, sColumnIndex);
        }
    }
}