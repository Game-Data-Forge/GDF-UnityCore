namespace GDFUnity
{
    public class SQLiteTypeFloat : SQLiteTypeReal
    {
        public override object Read (SQLiteDbRequest request, int columnIndex)
        {
            double value = (double)base.Read(request, columnIndex);
            return (float)value;
        }
    }
}