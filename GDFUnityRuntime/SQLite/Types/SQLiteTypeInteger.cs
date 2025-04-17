namespace GDFUnity
{
    public abstract class SQLiteTypeInteger : SQLiteType
    {
        public abstract byte ByteSize { get; }
        protected override string CreateColumnFormat => SelectColumnFormat + " INT(" + ByteSize + ") NOT NULL DEFAULT 0";

        public override object Read (SQLiteDbRequest sRequest, int sColumnIndex)
        {
            return SQLite3.ColumnInt(sRequest, sColumnIndex);
        }
    }
}